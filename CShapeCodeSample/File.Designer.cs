namespace CShapeCodeSample
{
    partial class File
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtDel = new System.Windows.Forms.TextBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(34, 28);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(429, 21);
            this.txtPath.TabIndex = 0;
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(469, 27);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 1;
            this.btnFile.Text = "选择目录";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtDel
            // 
            this.txtDel.Location = new System.Drawing.Point(129, 219);
            this.txtDel.Name = "txtDel";
            this.txtDel.Size = new System.Drawing.Size(100, 21);
            this.txtDel.TabIndex = 3;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(235, 217);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(112, 23);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "批量修改文件名称";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "想要删除的文字";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(34, 52);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(510, 160);
            this.listBox.TabIndex = 6;
            // 
            // File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 301);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.txtDel);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtPath);
            this.Name = "File";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件操作";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtDel;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListBox listBox;
    }
}