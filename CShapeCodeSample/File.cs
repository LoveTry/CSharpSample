using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CShapeCodeSample
{
    public partial class File : Form
    {
        public File()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = folderBrowserDialog.SelectedPath;
                txtPath.Text = savePath;
                DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
                foreach (var item in directoryInfo.GetFiles())
                {
                    listBox.Items.Add(item.Name);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(txtPath.Text);
            foreach (var item in directoryInfo.GetFiles())
            {
                if (item.Name.Contains(txtDel.Text))
                {
                    item.MoveTo(item.FullName.Replace(txtDel.Text, ""));
                }
            }
            MessageBox.Show("修改成功");
        }
    }
}
