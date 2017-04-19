namespace Sceneplay.ui
{
    partial class ActionFuncUI
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
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.GroupBox groupBox4;
            this.m_listParamType = new System.Windows.Forms.ListBox();
            this.m_labParam = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.m_listParamType);
            groupBox5.Location = new System.Drawing.Point(3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(152, 145);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "操作内容参数列表";
            // 
            // m_listParamType
            // 
            this.m_listParamType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listParamType.FormattingEnabled = true;
            this.m_listParamType.HorizontalScrollbar = true;
            this.m_listParamType.ItemHeight = 12;
            this.m_listParamType.Location = new System.Drawing.Point(3, 17);
            this.m_listParamType.Name = "m_listParamType";
            this.m_listParamType.Size = new System.Drawing.Size(146, 125);
            this.m_listParamType.TabIndex = 4;
            this.m_listParamType.SelectedIndexChanged += new System.EventHandler(this.m_listParamType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.m_labParam);
            groupBox4.Location = new System.Drawing.Point(158, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(264, 145);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "参数值";
            // 
            // m_labParam
            // 
            this.m_labParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labParam.Location = new System.Drawing.Point(3, 17);
            this.m_labParam.Name = "m_labParam";
            this.m_labParam.Size = new System.Drawing.Size(258, 125);
            this.m_labParam.TabIndex = 3;
            this.m_labParam.Text = "";
            this.m_labParam.WordWrap = false;
            this.m_labParam.TextChanged += new System.EventHandler(this.m_labParam_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(groupBox5);
            this.panel1.Controls.Add(groupBox4);
            this.panel1.Location = new System.Drawing.Point(4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 163);
            this.panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 125);
            this.textBox1.TabIndex = 8;
            // 
            // ActionFuncUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 166);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionFuncUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActionFuncUI";
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox m_listParamType;
        private System.Windows.Forms.RichTextBox m_labParam;
        private System.Windows.Forms.TextBox textBox1;
    }
}