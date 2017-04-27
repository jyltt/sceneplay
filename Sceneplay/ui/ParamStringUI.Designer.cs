namespace Sceneplay.ui
{
    partial class ParamStringUI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnChangeStr = new System.Windows.Forms.Button();
            this.m_labString = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnChangeStr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 23);
            this.panel1.TabIndex = 1;
            // 
            // m_btnChangeStr
            // 
            this.m_btnChangeStr.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnChangeStr.Location = new System.Drawing.Point(0, 0);
            this.m_btnChangeStr.Name = "m_btnChangeStr";
            this.m_btnChangeStr.Size = new System.Drawing.Size(215, 23);
            this.m_btnChangeStr.TabIndex = 1;
            this.m_btnChangeStr.Text = "String";
            this.m_btnChangeStr.UseVisualStyleBackColor = true;
            this.m_btnChangeStr.Click += new System.EventHandler(this.m_btnChangeStr_Click);
            // 
            // m_labString
            // 
            this.m_labString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labString.Location = new System.Drawing.Point(0, 23);
            this.m_labString.Multiline = true;
            this.m_labString.Name = "m_labString";
            this.m_labString.ReadOnly = true;
            this.m_labString.Size = new System.Drawing.Size(281, 130);
            this.m_labString.TabIndex = 2;
            // 
            // ParamStringUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 153);
            this.ControlBox = false;
            this.Controls.Add(this.m_labString);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParamStringUI";
            this.Text = "ParamStringUI";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.TextBox m_labString;
        protected System.Windows.Forms.Button m_btnChangeStr;
    }
}