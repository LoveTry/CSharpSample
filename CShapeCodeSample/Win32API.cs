using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeCodeSample
{
    public partial class Win32API : Form
    {
        [DllImport("User32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int frequency, int duration);

        public Win32API()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox(0, "Hello Win32 API", "C#", comboBox1.SelectedIndex);
        }

        private void Win32API_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("确定按钮");
            comboBox1.Items.Add("确定、取消按钮");
            comboBox1.Items.Add("终止、重试、忽略按钮");
            comboBox1.Items.Add("是、否、取消按钮");
            comboBox1.Items.Add("是、否按钮");
            comboBox1.Items.Add("重试取消钮");
            comboBox1.Items.Add("终止、重试、继续");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                Beep(random.Next(10000), 100);
            }
        }



        [DllImport("kernel32.dll")]
        public static extern bool GetSystemPowerStatus(ref SystemPowerStatus systemPowerStatus);

        private void button3_Click(object sender, EventArgs e)
        {
            SystemPowerStatus sps = new SystemPowerStatus();
            //SystemPowerStatus sps;

            GetSystemPowerStatus(ref sps);
            richTextBox1.AppendText("交流电源状态：" + getACLineStr(sps.ACLineStatus)+ "\r\n");
            richTextBox1.AppendText("电池充电状态：" + getBatteryFlag(sps.batteryFlag) + "\r\n");
            richTextBox1.AppendText("电量百分比：" + sps.batteryLifePercent.ToString() + "\r\n");
            richTextBox1.AppendText("秒为单位的电池剩余电量：" + sps.batteryLifeTime.ToString() + "\r\n");
            richTextBox1.AppendText("秒为单位的电池充满电的电量：" + sps.batteryFullLifeTime.ToString() + "\r\n");
        }

        private string getACLineStr(int n)
        {
            switch (n)
            {
                case 0:
                    return "离线";
                case 1:
                    return "在线";
                case 255:
                    return "未知";
                default:
                    return "未知";
            }
        }

        private string getBatteryFlag(int n)
        {
            switch (n)
            {
                case 1:
                    return "高，电量大于66%";
                case 2:
                    return "低，小于33%";
                case 4:
                    return "极低，小于5%";
                case 8:
                    return "充电中";
                case 128:
                    return "没有电池";
                case 255:
                    return "未知";
                default:
                    return "未知";
            }
        }
    }

    public struct SystemPowerStatus
    {
        public byte ACLineStatus; //交流电源状态
        public byte batteryFlag; //电池充电状态
        public byte batteryLifePercent;//电池还有百分之几能充满.0~100，若未知则为255
        public byte reserved1;
        public int batteryLifeTime;//秒为单位的电池剩余电量, 若未知则为-1
        public int batteryFullLifeTime;//秒为单位的电池充满电的电量，若未知则为-1
    }

    enum ACLineStatus : byte
    {
        Offline = 0,
        Online = 1,
        Unknown = 255,
    }

    enum BatteryFlag : byte
    {
        High = 1,//高，电量大于66%
        Low = 2,//低，小于33%
        Critical = 4,//极低，小于5%
        Charging = 8,//充电中
        NoSystemBattery = 128,//没有电池
        Unknown = 255,
    }
}
