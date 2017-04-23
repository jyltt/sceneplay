namespace Sceneplay.ui
{
    partial class ParamValueUI
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
            this.m_labParam = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_labRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_labParam
            // 
            this.m_labParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labParam.Location = new System.Drawing.Point(3, 17);
            this.m_labParam.Name = "m_labParam";
            this.m_labParam.Size = new System.Drawing.Size(275, 63);
            this.m_labParam.TabIndex = 3;
            this.m_labParam.Text = "";
            this.m_labParam.WordWrap = false;
            this.m_labParam.TextChanged += new System.EventHandler(this.m_labParam_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_labParam);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 83);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数值";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_labRemarks);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 70);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注";
            // 
            // m_labRemarks
            // 
            this.m_labRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRemarks.Location = new System.Drawing.Point(3, 17);
            this.m_labRemarks.Multiline = true;
            this.m_labRemarks.Name = "m_labRemarks";
            this.m_labRemarks.ReadOnly = true;
            this.m_labRemarks.Size = new System.Drawing.Size(275, 50);
            this.m_labRemarks.TabIndex = 0;
            // 
            // ParamValueUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 153);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParamValueUI";
            this.Text = "ParamValueUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox m_labParam;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_labRemarks;
    }
}