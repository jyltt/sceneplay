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
            System.Windows.Forms.GroupBox groupBox6;
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox1;
            this.m_listFunc = new System.Windows.Forms.ComboBox();
            this.m_listParamType = new System.Windows.Forms.ListBox();
            this.m_labParam = new System.Windows.Forms.RichTextBox();
            this.m_labRemarks = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupFuncRemarks = new System.Windows.Forms.GroupBox();
            this.m_labFuncRemarks = new System.Windows.Forms.RichTextBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupFuncRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(this.m_listFunc);
            groupBox6.Location = new System.Drawing.Point(9, 10);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(265, 41);
            groupBox6.TabIndex = 25;
            groupBox6.TabStop = false;
            groupBox6.Text = "操作列表";
            // 
            // m_listFunc
            // 
            this.m_listFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_listFunc.FormattingEnabled = true;
            this.m_listFunc.Location = new System.Drawing.Point(3, 17);
            this.m_listFunc.Name = "m_listFunc";
            this.m_listFunc.Size = new System.Drawing.Size(259, 20);
            this.m_listFunc.TabIndex = 1;
            this.m_listFunc.SelectedIndexChanged += new System.EventHandler(this.m_listFunc_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.m_listParamType);
            groupBox5.Location = new System.Drawing.Point(9, 201);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(131, 145);
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
            this.m_listParamType.Size = new System.Drawing.Size(125, 125);
            this.m_listParamType.TabIndex = 4;
            this.m_listParamType.SelectedIndexChanged += new System.EventHandler(this.m_listParamType_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.m_labParam);
            groupBox4.Location = new System.Drawing.Point(153, 201);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(267, 145);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "参数值";
            // 
            // m_labParam
            // 
            this.m_labParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labParam.Location = new System.Drawing.Point(3, 17);
            this.m_labParam.Name = "m_labParam";
            this.m_labParam.Size = new System.Drawing.Size(261, 125);
            this.m_labParam.TabIndex = 3;
            this.m_labParam.Text = "";
            this.m_labParam.WordWrap = false;
            this.m_labParam.TextChanged += new System.EventHandler(this.m_labParam_TextChanged);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.m_labRemarks);
            groupBox1.Location = new System.Drawing.Point(9, 53);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(265, 145);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "备注";
            // 
            // m_labRemarks
            // 
            this.m_labRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRemarks.Location = new System.Drawing.Point(3, 17);
            this.m_labRemarks.Multiline = true;
            this.m_labRemarks.Name = "m_labRemarks";
            this.m_labRemarks.Size = new System.Drawing.Size(259, 125);
            this.m_labRemarks.TabIndex = 8;
            this.m_labRemarks.TextChanged += new System.EventHandler(this.m_labRemarks_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupFuncRemarks);
            this.panel1.Controls.Add(groupBox6);
            this.panel1.Controls.Add(groupBox5);
            this.panel1.Controls.Add(groupBox4);
            this.panel1.Controls.Add(groupBox1);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 351);
            this.panel1.TabIndex = 6;
            // 
            // groupFuncRemarks
            // 
            this.groupFuncRemarks.Controls.Add(this.m_labFuncRemarks);
            this.groupFuncRemarks.Location = new System.Drawing.Point(280, 10);
            this.groupFuncRemarks.Name = "groupFuncRemarks";
            this.groupFuncRemarks.Size = new System.Drawing.Size(140, 188);
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
            this.m_labFuncRemarks.Size = new System.Drawing.Size(134, 168);
            this.m_labFuncRemarks.TabIndex = 23;
            this.m_labFuncRemarks.Text = "";
            this.m_labFuncRemarks.WordWrap = false;
            // 
            // ActionFuncUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 368);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionFuncUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActionFuncUI";
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupFuncRemarks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupFuncRemarks;
        private System.Windows.Forms.RichTextBox m_labFuncRemarks;
        private System.Windows.Forms.ComboBox m_listFunc;
        private System.Windows.Forms.ListBox m_listParamType;
        private System.Windows.Forms.RichTextBox m_labParam;
        private System.Windows.Forms.TextBox m_labRemarks;
    }
}