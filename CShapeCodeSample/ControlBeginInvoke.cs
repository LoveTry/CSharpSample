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
    public partial class ControlBeginInvoke : Form
    {
        public ControlBeginInvoke()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 储存UI线程的标识符
            int curThreadID = Thread.CurrentThread.ManagedThreadId;

            new Thread(delegate ()
            {
                PrintThreadLog(curThreadID);
            }).Start();
        }

        private void PrintThreadLog(int mainThreadID)
        {
            // 当前线程的标识符
            // A代码块
            int asyncThreadID = Thread.CurrentThread.ManagedThreadId;

            // 输出当前线程的扼要信息，及与UI线程的引用比对结果
            // B代码块
            label1.BeginInvoke((MethodInvoker)delegate ()
            {
                // 执行BeginInvoke内的方法的线程标识符
                int curThreadID = Thread.CurrentThread.ManagedThreadId;

                label1.Text = string.Format("Async Thread ID:{0},Current Thread ID:{1},Is UI Thread:{2}",
                asyncThreadID, curThreadID, curThreadID.Equals(mainThreadID));
            });

            // 挂起当前线程3秒，模拟耗时操作
            // C代码块
            Thread.Sleep(3000);

            label1.BeginInvoke((MethodInvoker)delegate ()
            {
                label1.Text = "我等待了三秒。";
            });
        }

        private void ControlBeginInvoke_Load(object sender, EventArgs e)
        {
            //当有多个并发线程尝试对UI进行读写时，容易造成线程争用资源带来的死锁。
            //.NET给我们的补充方案就是Control的Invoke和BeginInvoke。
            //下面是不安全的代码
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private readonly int Max_Item_Count = 10000;

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(delegate ()
            {
                for (int i = 0; i < Max_Item_Count; i++)
                {
                    // 此处警惕值类型装箱造成的"性能陷阱"
                    listView1.Invoke((MethodInvoker)delegate ()
                    {
                        listView1.Items.Add(new ListViewItem(new string[]
                        { i.ToString(), string.Format("This is No.{0} item", i.ToString()) }));
                    });
                };
            }).Start();

            new Thread(delegate () {
                label1.Invoke((MethodInvoker)delegate () {
                    label1.Text = "下面好热闹呀";
                });
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Max_Item_Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                { i.ToString(), string.Format("This is No.{0} item", i.ToString()) }));
            };
            label1.Text = "我没看见就完了。";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Thread(delegate ()
            {
                for (int i = 0; i < Max_Item_Count; i++)
                {
                    // 此处警惕值类型装箱造成的"性能陷阱"
                    dbListView1.Invoke((MethodInvoker)delegate ()
                    {
                        dbListView1.Items.Add(new ListViewItem(new string[]
                        { i.ToString(), string.Format("This is No.{0} item", i.ToString()) }));
                    });
                };
            }).Start();
        }
    }
}
