using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeCodeSample
{
    public partial class SocketCustomer : Form
    {
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public SocketCustomer()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            //连接到的目标IP
            IPAddress ip = IPAddress.Parse(txtIP.Text);
            //IPAddress ip = IPAddress.Any;
            //连接到目标IP的哪个应用(端口号！)

            IPEndPoint point = new IPEndPoint(ip, int.Parse(txtPort.Text));
            try
            {
                //连接到服务器
                client.Connect(point);
                ShowMsg("连接成功");
                ShowMsg("服务器" + client.RemoteEndPoint.ToString());
                ShowMsg("客户端:" + client.LocalEndPoint.ToString());
                //连接成功后，就可以接收服务器发送的信息了
                Thread th = new Thread(ReceiveMsg);
                th.IsBackground = true;
                th.Start();
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        //接收服务器的消息
        private void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int n = client.Receive(buffer);
                    string s = Encoding.UTF8.GetString(buffer, 0, n);
                    ShowMsg(client.RemoteEndPoint.ToString() + ":" + s);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                    break;
                }
            }
        }

        private void ShowMsg(string msg)
        {
            txtChat.AppendText(msg + "\r\n");
        }

        private void SocketCustomer_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //客户端给服务器发消息
            if (client != null)
            {
                try
                {
                    ShowMsg(txtMsg.Text);
                    byte[] buffer = Encoding.UTF8.GetBytes(txtMsg.Text);
                    client.Send(buffer);
                }
                catch (Exception ex)
                {
                    ShowMsg(ex.Message);
                }
            }
        }
    }

}
