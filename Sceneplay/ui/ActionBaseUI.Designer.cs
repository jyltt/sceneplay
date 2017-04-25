namespace Sceneplay.ui
{
    partial class ActionBaseUI
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
            System.Windows.Forms.Panel m_Node1;
            this.groupFuncRemarks = new System.Windows.Forms.GroupBox();
            this.m_labFuncRemarks = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_labRemarks = new System.Windows.Forms.TextBox();
            this.m_listFunc = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_Node = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_labReference = new System.Windows.Forms.TextBox();
            m_Node1 = new System.Windows.Forms.Panel();
            m_Node1.SuspendLayout();
            this.groupFuncRemarks.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_Node1
            // 
            m_Node1.Controls.Add(this.groupFuncRemarks);
            m_Node1.Controls.Add(this.groupBox2);
            m_Node1.Dock = System.Windows.Forms.DockStyle.Top;
            m_Node1.Location = new System.Drawing.Point(0, 41);
            m_Node1.Name = "m_Node1";
            m_Node1.Size = new System.Drawing.Size(443, 151);
            m_Node1.TabIndex = 26;
            // 
            // groupFuncRemarks
            // 
            this.groupFuncRemarks.Controls.Add(this.m_labFuncRemarks);
            this.groupFuncRemarks.Location = new System.Drawing.Point(274, 2);
            this.groupFuncRemarks.Name = "groupFuncRemarks";
            this.groupFuncRemarks.Size = new System.Drawing.Size(164, 145);
            this.groupFuncRemarks.TabIndex = 25;
            this.groupFuncRemarks.TabStop = false;
            this.groupFuncRemarks.Text = "函数备注";
            // 
            // m_labFuncRemarks
            // 
            this.m_labFuncRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labFuncRemarks.Location = new System.Drawing.Point(3, 17);
            this.m_labFuncRemarks.Name = "m_labFuncRemarks";
            this.m_labFuncRemarks.ReadOnly = true;
            this.m_labFuncRemarks.Size = new System.Drawing.Size(158, 125);
            this.m_labFuncRemarks.TabIndex = 23;
            this.m_labFuncRemarks.Text = "";
            this.m_labFuncRemarks.WordWrap = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_labRemarks);
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 145);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注";
            // 
            // m_labRemarks
            // 
            this.m_labRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRemarks.Location = new System.Drawing.Point(3, 17);
            this.m_labRemarks.Multiline = true;
            this.m_labRemarks.Name = "m_labRemarks";
            this.m_labRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_labRemarks.Size = new System.Drawing.Size(259, 125);
            this.m_labRemarks.TabIndex = 8;
            this.m_labRemarks.TextChanged += new System.EventHandler(this.m_labRemarks_TextChanged);
            // 
            // m_listFunc
            // 
            this.m_listFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_listFunc.FormattingEnabled = true;
            this.m_listFunc.Location = new System.Drawing.Point(3, 17);
            this.m_listFunc.Name = "m_listFunc";
            this.m_listFunc.Size = new System.Drawing.Size(437, 20);
            this.m_listFunc.TabIndex = 1;
            this.m_listFunc.SelectedIndexChanged += new System.EventHandler(this.m_listFunc_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_listFunc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 41);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作列表";
            // 
            // m_Node
            // 
            this.m_Node.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_Node.Location = new System.Drawing.Point(0, 192);
            this.m_Node.Name = "m_Node";
            this.m_Node.Size = new System.Drawing.Size(443, 200);
            this.m_Node.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_Node);
            this.panel1.Controls.Add(m_Node1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 392);
            this.panel1.TabIndex = 28;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_labReference);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(451, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 392);
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
            this.m_labReference.Size = new System.Drawing.Size(105, 372);
            this.m_labReference.TabIndex = 0;
            // 
            // ActionBaseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 392);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionBaseUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActionBaseUI";
            m_Node1.ResumeLayout(false);
            this.groupFuncRemarks.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_listFunc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupFuncRemarks;
        private System.Windows.Forms.RichTextBox m_labFuncRemarks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_labRemarks;
        private System.Windows.Forms.Panel m_Node;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox m_labReference;
    }
}