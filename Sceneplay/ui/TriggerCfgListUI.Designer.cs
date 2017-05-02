namespace Sceneplay.ui
{
    partial class TriggerCfgListUI
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
            this.m_listTrigger = new System.Windows.Forms.TreeView();
            this.m_groupID = new System.Windows.Forms.GroupBox();
            this.m_labID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_labRemark = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_labCamp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_labRole = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_labType = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_labCount = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.m_labParam = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.m_labEffect = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.m_labSelectRemark = new System.Windows.Forms.TextBox();
            this.m_panel = new System.Windows.Forms.Panel();
            this.m_groupID.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.m_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_listTrigger
            // 
            this.m_listTrigger.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_listTrigger.Location = new System.Drawing.Point(0, 0);
            this.m_listTrigger.Name = "m_listTrigger";
            this.m_listTrigger.Size = new System.Drawing.Size(121, 431);
            this.m_listTrigger.TabIndex = 0;
            this.m_listTrigger.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_listTrigger_AfterSelect);
            // 
            // m_groupID
            // 
            this.m_groupID.Controls.Add(this.m_labID);
            this.m_groupID.Location = new System.Drawing.Point(137, 12);
            this.m_groupID.Name = "m_groupID";
            this.m_groupID.Size = new System.Drawing.Size(91, 45);
            this.m_groupID.TabIndex = 1;
            this.m_groupID.TabStop = false;
            this.m_groupID.Text = "触发器编号";
            // 
            // m_labID
            // 
            this.m_labID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labID.Location = new System.Drawing.Point(3, 17);
            this.m_labID.Name = "m_labID";
            this.m_labID.Size = new System.Drawing.Size(85, 21);
            this.m_labID.TabIndex = 0;
            this.m_labID.TextChanged += new System.EventHandler(this.m_labID_TextChanged);
            this.m_labID.Enter += new System.EventHandler(this.m_labID_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_labRemark);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(121, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 112);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注";
            // 
            // m_labRemark
            // 
            this.m_labRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRemark.Location = new System.Drawing.Point(3, 17);
            this.m_labRemark.Multiline = true;
            this.m_labRemark.Name = "m_labRemark";
            this.m_labRemark.Size = new System.Drawing.Size(472, 92);
            this.m_labRemark.TabIndex = 0;
            this.m_labRemark.TextChanged += new System.EventHandler(this.m_labRemark_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_labCamp);
            this.groupBox3.Location = new System.Drawing.Point(337, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(91, 45);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "触发阵营";
            // 
            // m_labCamp
            // 
            this.m_labCamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labCamp.Location = new System.Drawing.Point(3, 17);
            this.m_labCamp.Name = "m_labCamp";
            this.m_labCamp.Size = new System.Drawing.Size(85, 21);
            this.m_labCamp.TabIndex = 0;
            this.m_labCamp.TextChanged += new System.EventHandler(this.m_labCamp_TextChanged);
            this.m_labCamp.Enter += new System.EventHandler(this.m_labCamp_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_labRole);
            this.groupBox4.Location = new System.Drawing.Point(13, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 45);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "触发指定角色";
            // 
            // m_labRole
            // 
            this.m_labRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRole.Location = new System.Drawing.Point(3, 17);
            this.m_labRole.Name = "m_labRole";
            this.m_labRole.Size = new System.Drawing.Size(193, 21);
            this.m_labRole.TabIndex = 0;
            this.m_labRole.TextChanged += new System.EventHandler(this.m_labRole_TextChanged);
            this.m_labRole.Enter += new System.EventHandler(this.m_labRole_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_labType);
            this.groupBox5.Location = new System.Drawing.Point(229, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(91, 45);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "触发类型";
            // 
            // m_labType
            // 
            this.m_labType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labType.Location = new System.Drawing.Point(3, 17);
            this.m_labType.Name = "m_labType";
            this.m_labType.Size = new System.Drawing.Size(85, 21);
            this.m_labType.TabIndex = 0;
            this.m_labType.TextChanged += new System.EventHandler(this.m_labType_TextChanged);
            this.m_labType.Enter += new System.EventHandler(this.m_labType_Enter);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_labCount);
            this.groupBox6.Location = new System.Drawing.Point(121, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(91, 45);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "触发完成次数";
            // 
            // m_labCount
            // 
            this.m_labCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labCount.Location = new System.Drawing.Point(3, 17);
            this.m_labCount.Name = "m_labCount";
            this.m_labCount.Size = new System.Drawing.Size(85, 21);
            this.m_labCount.TabIndex = 0;
            this.m_labCount.TextChanged += new System.EventHandler(this.m_labCount_TextChanged);
            this.m_labCount.Enter += new System.EventHandler(this.m_labCount_Enter);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.m_labParam);
            this.groupBox7.Location = new System.Drawing.Point(13, 119);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(199, 45);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "触发参数";
            // 
            // m_labParam
            // 
            this.m_labParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labParam.Location = new System.Drawing.Point(3, 17);
            this.m_labParam.Name = "m_labParam";
            this.m_labParam.Size = new System.Drawing.Size(193, 21);
            this.m_labParam.TabIndex = 0;
            this.m_labParam.TextChanged += new System.EventHandler(this.m_labParam_TextChanged);
            this.m_labParam.Enter += new System.EventHandler(this.m_labParam_Enter);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.m_labEffect);
            this.groupBox8.Location = new System.Drawing.Point(229, 68);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(199, 45);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "触发效果";
            // 
            // m_labEffect
            // 
            this.m_labEffect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labEffect.Location = new System.Drawing.Point(3, 17);
            this.m_labEffect.Name = "m_labEffect";
            this.m_labEffect.Size = new System.Drawing.Size(193, 21);
            this.m_labEffect.TabIndex = 0;
            this.m_labEffect.TextChanged += new System.EventHandler(this.m_labEffect_TextChanged);
            this.m_labEffect.Enter += new System.EventHandler(this.m_labEffect_Enter);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.m_labSelectRemark);
            this.groupBox9.Location = new System.Drawing.Point(13, 170);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(415, 87);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "选项备注";
            // 
            // m_labSelectRemark
            // 
            this.m_labSelectRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labSelectRemark.Location = new System.Drawing.Point(3, 17);
            this.m_labSelectRemark.Multiline = true;
            this.m_labSelectRemark.Name = "m_labSelectRemark";
            this.m_labSelectRemark.Size = new System.Drawing.Size(409, 67);
            this.m_labSelectRemark.TabIndex = 0;
            this.m_labSelectRemark.TextChanged += new System.EventHandler(this.m_labSelectRemark_TextChanged);
            // 
            // m_panel
            // 
            this.m_panel.Controls.Add(this.groupBox9);
            this.m_panel.Controls.Add(this.groupBox5);
            this.m_panel.Controls.Add(this.groupBox8);
            this.m_panel.Controls.Add(this.groupBox6);
            this.m_panel.Controls.Add(this.groupBox4);
            this.m_panel.Controls.Add(this.groupBox3);
            this.m_panel.Controls.Add(this.groupBox7);
            this.m_panel.Location = new System.Drawing.Point(121, 0);
            this.m_panel.Name = "m_panel";
            this.m_panel.Size = new System.Drawing.Size(440, 271);
            this.m_panel.TabIndex = 2;
            // 
            // TriggerCfgListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 431);
            this.Controls.Add(this.m_groupID);
            this.Controls.Add(this.m_panel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_listTrigger);
            this.Name = "TriggerCfgListUI";
            this.Text = "TriggerCfgListUI";
            this.m_groupID.ResumeLayout(false);
            this.m_groupID.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.m_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView m_listTrigger;
        private System.Windows.Forms.GroupBox m_groupID;
        private System.Windows.Forms.TextBox m_labID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox m_labRemark;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox m_labCamp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox m_labRole;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox m_labType;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox m_labCount;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox m_labParam;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox m_labEffect;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox m_labSelectRemark;
        private System.Windows.Forms.Panel m_panel;
    }
}