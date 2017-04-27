namespace Sceneplay.ui
{
    partial class ActionStringUI
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
            System.Windows.Forms.GroupBox groupBox1;
            this.m_labHeadIconPath = new System.Windows.Forms.TextBox();
            this.m_btnChangeStr = new System.Windows.Forms.Button();
            this.m_labString = new System.Windows.Forms.TextBox();
            this.m_pos1 = new System.Windows.Forms.RadioButton();
            this.m_pos2 = new System.Windows.Forms.RadioButton();
            this.m_pos3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_switchList = new System.Windows.Forms.CheckedListBox();
            this.m_labAudioID = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_listActor = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.m_labHeadIconPath);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupBox1.Location = new System.Drawing.Point(0, 154);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(441, 46);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "角色头像路径";
            // 
            // m_labHeadIconPath
            // 
            this.m_labHeadIconPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labHeadIconPath.Location = new System.Drawing.Point(3, 17);
            this.m_labHeadIconPath.Name = "m_labHeadIconPath";
            this.m_labHeadIconPath.Size = new System.Drawing.Size(435, 21);
            this.m_labHeadIconPath.TabIndex = 8;
            this.m_labHeadIconPath.TextChanged += new System.EventHandler(this.m_labHeadIconPath_TextChanged);
            // 
            // m_btnChangeStr
            // 
            this.m_btnChangeStr.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnChangeStr.Location = new System.Drawing.Point(0, 0);
            this.m_btnChangeStr.Name = "m_btnChangeStr";
            this.m_btnChangeStr.Size = new System.Drawing.Size(188, 23);
            this.m_btnChangeStr.TabIndex = 1;
            this.m_btnChangeStr.Text = "String";
            this.m_btnChangeStr.UseVisualStyleBackColor = true;
            this.m_btnChangeStr.Click += new System.EventHandler(this.m_btnChangeStr_Click);
            // 
            // m_labString
            // 
            this.m_labString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labString.Location = new System.Drawing.Point(0, 85);
            this.m_labString.Multiline = true;
            this.m_labString.Name = "m_labString";
            this.m_labString.ReadOnly = true;
            this.m_labString.Size = new System.Drawing.Size(441, 69);
            this.m_labString.TabIndex = 2;
            // 
            // m_pos1
            // 
            this.m_pos1.AutoSize = true;
            this.m_pos1.Location = new System.Drawing.Point(6, 15);
            this.m_pos1.Name = "m_pos1";
            this.m_pos1.Size = new System.Drawing.Size(47, 16);
            this.m_pos1.TabIndex = 16;
            this.m_pos1.TabStop = true;
            this.m_pos1.Text = "中间";
            this.m_pos1.UseVisualStyleBackColor = true;
            this.m_pos1.CheckedChanged += new System.EventHandler(this.pos_CheckedChanged);
            // 
            // m_pos2
            // 
            this.m_pos2.AutoSize = true;
            this.m_pos2.Location = new System.Drawing.Point(6, 37);
            this.m_pos2.Name = "m_pos2";
            this.m_pos2.Size = new System.Drawing.Size(47, 16);
            this.m_pos2.TabIndex = 17;
            this.m_pos2.TabStop = true;
            this.m_pos2.Text = "左边";
            this.m_pos2.UseVisualStyleBackColor = true;
            // 
            // m_pos3
            // 
            this.m_pos3.AutoSize = true;
            this.m_pos3.Location = new System.Drawing.Point(6, 60);
            this.m_pos3.Name = "m_pos3";
            this.m_pos3.Size = new System.Drawing.Size(47, 16);
            this.m_pos3.TabIndex = 18;
            this.m_pos3.TabStop = true;
            this.m_pos3.Text = "右边";
            this.m_pos3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_pos1);
            this.groupBox2.Controls.Add(this.m_pos2);
            this.groupBox2.Controls.Add(this.m_pos3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(70, 85);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "人物位置";
            // 
            // m_switchList
            // 
            this.m_switchList.CheckOnClick = true;
            this.m_switchList.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_switchList.FormattingEnabled = true;
            this.m_switchList.Items.AddRange(new object[] {
            "是否自动播放",
            "是否显示跳过",
            "是否开启黑幕",
            "是否开启暂停",
            "是否mmo剧情"});
            this.m_switchList.Location = new System.Drawing.Point(70, 0);
            this.m_switchList.Name = "m_switchList";
            this.m_switchList.Size = new System.Drawing.Size(101, 85);
            this.m_switchList.TabIndex = 20;
            this.m_switchList.SelectedIndexChanged += new System.EventHandler(this.m_switchList_SelectedIndexChanged);
            // 
            // m_labAudioID
            // 
            this.m_labAudioID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labAudioID.Location = new System.Drawing.Point(3, 17);
            this.m_labAudioID.Name = "m_labAudioID";
            this.m_labAudioID.Size = new System.Drawing.Size(113, 21);
            this.m_labAudioID.TabIndex = 7;
            this.m_labAudioID.TextChanged += new System.EventHandler(this.m_labAudioID_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_labAudioID);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(148, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 41);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "语音id";
            // 
            // m_listActor
            // 
            this.m_listActor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listActor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_listActor.FormattingEnabled = true;
            this.m_listActor.Location = new System.Drawing.Point(3, 17);
            this.m_listActor.Name = "m_listActor";
            this.m_listActor.Size = new System.Drawing.Size(142, 20);
            this.m_listActor.TabIndex = 6;
            this.m_listActor.SelectedIndexChanged += new System.EventHandler(this.m_listActor_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_listActor);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 41);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "剧情操作对象";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.m_switchList);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 85);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(171, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(270, 85);
            this.panel2.TabIndex = 29;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_btnChangeStr);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 23);
            this.panel3.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(270, 41);
            this.panel4.TabIndex = 28;
            // 
            // ActionStringUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 200);
            this.ControlBox = false;
            this.Controls.Add(this.m_labString);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionStringUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ActionStringUI";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button m_btnChangeStr;
        private System.Windows.Forms.TextBox m_labString;
        private System.Windows.Forms.RadioButton m_pos1;
        private System.Windows.Forms.RadioButton m_pos2;
        private System.Windows.Forms.RadioButton m_pos3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox m_switchList;
        private System.Windows.Forms.TextBox m_labAudioID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox m_listActor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox m_labHeadIconPath;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}