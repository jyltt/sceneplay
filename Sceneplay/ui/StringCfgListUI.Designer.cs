namespace Sceneplay.ui
{
    partial class StringCfgListUI
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
            this.m_listStrID = new System.Windows.Forms.ListBox();
            this.m_btnDelete = new System.Windows.Forms.Button();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_labText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnSure = new System.Windows.Forms.Button();
            this.m_labAdd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_labSearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_labReference = new System.Windows.Forms.TextBox();
            this.m_listFile = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_listStrID
            // 
            this.m_listStrID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listStrID.FormattingEnabled = true;
            this.m_listStrID.ItemHeight = 12;
            this.m_listStrID.Location = new System.Drawing.Point(0, 21);
            this.m_listStrID.Name = "m_listStrID";
            this.m_listStrID.Size = new System.Drawing.Size(130, 459);
            this.m_listStrID.TabIndex = 0;
            this.m_listStrID.SelectedIndexChanged += new System.EventHandler(this.m_listStrID_SelectedIndexChanged);
            this.m_listStrID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_listStrID_MouseDoubleClick);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnDelete.Location = new System.Drawing.Point(175, 0);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(75, 23);
            this.m_btnDelete.TabIndex = 1;
            this.m_btnDelete.Text = "删除";
            this.m_btnDelete.UseVisualStyleBackColor = true;
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAdd.Location = new System.Drawing.Point(100, 0);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(75, 23);
            this.m_btnAdd.TabIndex = 2;
            this.m_btnAdd.Text = "添加";
            this.m_btnAdd.UseVisualStyleBackColor = true;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_labText
            // 
            this.m_labText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labText.Location = new System.Drawing.Point(0, 0);
            this.m_labText.Multiline = true;
            this.m_labText.Name = "m_labText";
            this.m_labText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_labText.Size = new System.Drawing.Size(386, 457);
            this.m_labText.TabIndex = 3;
            this.m_labText.TextChanged += new System.EventHandler(this.m_labText_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnSure);
            this.panel1.Controls.Add(this.m_btnDelete);
            this.panel1.Controls.Add(this.m_btnAdd);
            this.panel1.Controls.Add(this.m_labAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(249, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 23);
            this.panel1.TabIndex = 4;
            // 
            // m_btnSure
            // 
            this.m_btnSure.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSure.Location = new System.Drawing.Point(311, 0);
            this.m_btnSure.Name = "m_btnSure";
            this.m_btnSure.Size = new System.Drawing.Size(75, 23);
            this.m_btnSure.TabIndex = 3;
            this.m_btnSure.Text = "确定";
            this.m_btnSure.UseVisualStyleBackColor = true;
            this.m_btnSure.Click += new System.EventHandler(this.m_btnSure_Click);
            // 
            // m_labAdd
            // 
            this.m_labAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_labAdd.Location = new System.Drawing.Point(0, 0);
            this.m_labAdd.Name = "m_labAdd";
            this.m_labAdd.Size = new System.Drawing.Size(100, 21);
            this.m_labAdd.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_listStrID);
            this.panel2.Controls.Add(this.m_labSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(119, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(130, 480);
            this.panel2.TabIndex = 5;
            // 
            // m_labSearch
            // 
            this.m_labSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_labSearch.Location = new System.Drawing.Point(0, 0);
            this.m_labSearch.Name = "m_labSearch";
            this.m_labSearch.Size = new System.Drawing.Size(130, 21);
            this.m_labSearch.TabIndex = 1;
            this.m_labSearch.TextChanged += new System.EventHandler(this.m_labSearch_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.m_labText);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(249, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 457);
            this.panel3.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_labReference);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(275, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 457);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "引用列表";
            // 
            // m_labReference
            // 
            this.m_labReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labReference.Location = new System.Drawing.Point(3, 17);
            this.m_labReference.Multiline = true;
            this.m_labReference.Name = "m_labReference";
            this.m_labReference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_labReference.Size = new System.Drawing.Size(105, 437);
            this.m_labReference.TabIndex = 0;
            // 
            // m_listFile
            // 
            this.m_listFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listFile.FormattingEnabled = true;
            this.m_listFile.ItemHeight = 12;
            this.m_listFile.Location = new System.Drawing.Point(3, 17);
            this.m_listFile.Name = "m_listFile";
            this.m_listFile.Size = new System.Drawing.Size(113, 460);
            this.m_listFile.TabIndex = 7;
            this.m_listFile.SelectedIndexChanged += new System.EventHandler(this.m_listFile_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_listFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 480);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件列表";
            // 
            // StringCfgListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 480);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StringCfgListUI";
            this.Text = "字符串表";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox m_listStrID;
        private System.Windows.Forms.Button m_btnDelete;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.TextBox m_labText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnSure;
        private System.Windows.Forms.TextBox m_labAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox m_labSearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox m_labReference;
        private System.Windows.Forms.ListBox m_listFile;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}