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
            this.m_listParamType = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.m_paramNode = new System.Windows.Forms.Panel();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.m_listParamType);
            groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            groupBox5.Location = new System.Drawing.Point(0, 0);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(161, 153);
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
            this.m_listParamType.Size = new System.Drawing.Size(155, 133);
            this.m_listParamType.TabIndex = 4;
            this.m_listParamType.SelectedIndexChanged += new System.EventHandler(this.m_listParamType_SelectedIndexChanged);
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
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(263, 125);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // m_paramNode
            // 
            this.m_paramNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_paramNode.Location = new System.Drawing.Point(161, 0);
            this.m_paramNode.Name = "m_paramNode";
            this.m_paramNode.Size = new System.Drawing.Size(281, 153);
            this.m_paramNode.TabIndex = 25;
            // 
            // ActionFuncUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 153);
            this.ControlBox = false;
            this.Controls.Add(this.m_paramNode);
            this.Controls.Add(groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionFuncUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActionFuncUI";
            groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox m_listParamType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel m_paramNode;
    }
}