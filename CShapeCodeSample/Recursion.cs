using System;
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
    public partial class Recursion : Form
    {
        public Recursion()
        {
            InitializeComponent();
        }
        StringBuilder sb = new StringBuilder();
        private void button1_Click(object sender, EventArgs e)
        {
            f(5);
            richTextBox1.Text = sb.ToString();
        }

        public int foo(int i)
        {
            //1 1 2 3 5 8 13
            sb.Append(i + " ");
            if (i <= 0)
            {
                sb.Append(" 返回零 ");
                return 0;
            }
            else if (i > 0 && i <= 2)
            {
                sb.Append(" 返回一 ");
                return 1;
            }
            else
                return foo(i - 1) + foo(i - 2);
        }

        public int f(int m)
        {
            sb.Append(m + " ");
            if (m == 1)
                return 1;
            else return f(m - 1);

        }
    }
}
