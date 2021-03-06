﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeCodeSample
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SocketCustomer().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ControlBeginInvoke().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Win32API().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Async().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Recursion().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new File().ShowDialog();
        }
    }
}
