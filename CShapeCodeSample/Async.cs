using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeCodeSample
{
    public partial class Async : Form
    {

        public Async()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string a = await Method1Async();
            //此处可继续执行其他代码
            Task<int> b = Method2Async();
            //此处可继续执行其他代码
            int c = await b;//等待任务b完成，且可以拿到任务b的返回值
        }

        async Task<string> Method1Async()
        {
            await Task.Delay(100);
            return "我执行完了";
        }
        async Task<int> Method2Async()
        {
            await Task.Delay(100);
            return 1;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Task.Run方法表示使用默认的任务调度程序在线程池中通过后台执行指定的任务
            //如果不需要自己去调度方法，使用这个方式最方便
            await Task.Run(() => Method1Async());//执行同步方法
            int c = await Task.Run(() => Method2Async());//执行异步方法
            await Task.Run(async () => { c = 2; });//执行异步匿名方法
        }

        //CancellationTokenSource类和CancellationToken结构用于实现多线程、线程池和Task任务的取消操作
        CancellationTokenSource cts;

        private async void button3_Click(object sender, EventArgs e)
        {
            //progressBar1.Maximum = 100;
            //progressBar1.Value = 0;
            //cts = new CancellationTokenSource();
            //var task = MYThreadAsync("计划A", cts.Token);
            //try
            //{
            //    await task;
            //    listBox1.Items.Add("await后面");
            //}
            //catch
            //{
            //    if (task.IsCanceled)
            //        listBox1.Items.Add("计划A取消");
            //}

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;
            var pp = new Progress<int>();
            pp.ProgressChanged += (s, n) =>
            {
                progressBar1.Value = n;
            };
            var tt = Task.Run(() => MYThreadAsync(pp, cts.Token, 500), cts.Token);
            try
            {
                await tt;
                if (tt.Exception == null)
                    listBox1.Items.Add("任务完成");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("异常" + ex.Message);
            }
        }

        private void MYThreadAsync(IProgress<int> progress, CancellationToken ct, int delay)
        {
            int p = 0;//进度
            while (p < 100 && ct.IsCancellationRequested == false)
            {
                p += 1;
                Thread.Sleep(delay);
                progress.Report(p);//这个方法将会触发ProgressChanged事件更新进度条
            }
        }

        private async Task MYThreadAsync(string s, CancellationToken ct)
        {

            for (int i = 0; i < 50; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();//它会终止任务并且返回catch语句块里面
                }
                progressBar1.Value += 2;
                await Task.Delay(100);
            }
            listBox1.Items.Add("任务" + s + "完成了");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        System.Timers.Timer timer;
        private void button5_Click(object sender, EventArgs e)
        {
            progressBar2.Maximum = 100;
            progressBar2.Value = 0;
            int pro = 0;
            timer = new System.Timers.Timer(500);
            timer.AutoReset = true;
            timer.Elapsed += (obj, args) =>
            {

                pro += 5;
                if (pro > 100)
                {
                    timer.Stop();
                    listBox1.BeginInvoke((MethodInvoker)delegate () {
                        listBox1.Items.Add("执行完毕");
                    });
                    return;
                }
                progressBar2.BeginInvoke((MethodInvoker)delegate ()
                {
                    progressBar2.Value = pro;
                });

            };
            timer.Start();
        }

        System.Threading.Timer threadtimer;
        private void button6_Click(object sender, EventArgs e)
        {
            progressBar3.Maximum = 100;
            progressBar3.Value = 0;
            TimeSpan dueTime = new TimeSpan(0, 0, 0, 1);
            TimeSpan period = new TimeSpan(0, 0, 0, 0, 200);
            TimerCallback timecall = new TimerCallback((obj) =>
            {
                progressBar3.BeginInvoke((MethodInvoker)delegate ()
                {
                    if (progressBar3.Value >= 100)
                    {
                        threadtimer.Dispose();
                        listBox1.Items.Add("执行完毕");
                        return;
                    }
                    progressBar3.Value += 5;
                });
            });
            threadtimer = new System.Threading.Timer(timecall, null, dueTime, period);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer.Stop();
            listBox1.Items.Add("第一个已经停止");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            threadtimer.Dispose();
            listBox1.Items.Add("第二个已经停止");
        }
    }
}
