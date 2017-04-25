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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_listStrID
            // 
            this.m_listStrID.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_listStrID.FormattingEnabled = true;
            this.m_listStrID.ItemHeight = 12;
            this.m_listStrID.Location = new System.Drawing.Point(0, 0);
            this.m_listStrID.Name = "m_listStrID";
            this.m_listStrID.Size = new System.Drawing.Size(120, 492);
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
            this.m_labText.Location = new System.Drawing.Point(120, 0);
            this.m_labText.Multiline = true;
            this.m_labText.Name = "m_labText";
            this.m_labText.Size = new System.Drawing.Size(356, 492);
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
            this.panel1.Location = new System.Drawing.Point(120, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 23);
            this.panel1.TabIndex = 4;
            // 
            // m_btnSure
            // 
            this.m_btnSure.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSure.Location = new System.Drawing.Point(281, 0);
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
            // StringCfgListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_labText);
            this.Controls.Add(this.m_listStrID);
            this.Name = "StringCfgListUI";
            this.Text = "字符串表";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox m_listStrID;
        private System.Windows.Forms.Button m_btnDelete;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.TextBox m_labText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnSure;
        private System.Windows.Forms.TextBox m_labAdd;
    }
}