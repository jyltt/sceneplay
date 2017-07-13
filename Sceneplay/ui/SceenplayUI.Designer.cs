namespace Sceneplay.ui
{
    partial class SceenplayUI
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_labRemarks = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_btnTrigger = new System.Windows.Forms.Button();
            this.m_labTriggerId = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_labID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnAddActor = new System.Windows.Forms.Button();
            this.m_labActor = new System.Windows.Forms.TextBox();
            this.m_listActor = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_labReference = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 270);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_labRemarks);
            this.groupBox4.Location = new System.Drawing.Point(2, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 215);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "备注";
            // 
            // m_labRemarks
            // 
            this.m_labRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labRemarks.Location = new System.Drawing.Point(3, 17);
            this.m_labRemarks.Multiline = true;
            this.m_labRemarks.Name = "m_labRemarks";
            this.m_labRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_labRemarks.Size = new System.Drawing.Size(234, 195);
            this.m_labRemarks.TabIndex = 0;
            this.m_labRemarks.TextChanged += new System.EventHandler(this.m_labRemarks_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_btnTrigger);
            this.groupBox3.Controls.Add(this.m_labTriggerId);
            this.groupBox3.Location = new System.Drawing.Point(125, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 43);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "触发器";
            // 
            // m_btnTrigger
            // 
            this.m_btnTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_btnTrigger.Location = new System.Drawing.Point(82, 17);
            this.m_btnTrigger.Name = "m_btnTrigger";
            this.m_btnTrigger.Size = new System.Drawing.Size(32, 23);
            this.m_btnTrigger.TabIndex = 0;
            this.m_btnTrigger.Text = "...";
            this.m_btnTrigger.UseVisualStyleBackColor = true;
            this.m_btnTrigger.Click += new System.EventHandler(this.m_btnTrigger_Click);
            // 
            // m_labTriggerId
            // 
            this.m_labTriggerId.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_labTriggerId.Location = new System.Drawing.Point(3, 17);
            this.m_labTriggerId.Name = "m_labTriggerId";
            this.m_labTriggerId.Size = new System.Drawing.Size(79, 21);
            this.m_labTriggerId.TabIndex = 1;
            this.m_labTriggerId.Leave += new System.EventHandler(this.m_labTriggerId_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_labID);
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 44);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "剧情id";
            // 
            // m_labID
            // 
            this.m_labID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_labID.Location = new System.Drawing.Point(3, 17);
            this.m_labID.Name = "m_labID";
            this.m_labID.Size = new System.Drawing.Size(111, 21);
            this.m_labID.TabIndex = 1;
            this.m_labID.WordWrap = false;
            this.m_labID.Leave += new System.EventHandler(this.m_labID_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.m_listActor);
            this.groupBox1.Location = new System.Drawing.Point(248, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 263);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登场对象";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnAddActor);
            this.panel2.Controls.Add(this.m_labActor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(109, 22);
            this.panel2.TabIndex = 1;
            // 
            // m_btnAddActor
            // 
            this.m_btnAddActor.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAddActor.Location = new System.Drawing.Point(79, 0);
            this.m_btnAddActor.Name = "m_btnAddActor";
            this.m_btnAddActor.Size = new System.Drawing.Size(30, 22);
            this.m_btnAddActor.TabIndex = 1;
            this.m_btnAddActor.Text = "+";
            this.m_btnAddActor.UseVisualStyleBackColor = true;
            this.m_btnAddActor.Click += new System.EventHandler(this.m_btnAddActor_Click);
            // 
            // m_labActor
            // 
            this.m_labActor.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_labActor.Location = new System.Drawing.Point(0, 0);
            this.m_labActor.Name = "m_labActor";
            this.m_labActor.Size = new System.Drawing.Size(73, 21);
            this.m_labActor.TabIndex = 2;
            this.m_labActor.TextChanged += new System.EventHandler(this.m_labActor_TextChanged);
            // 
            // m_listActor
            // 
            this.m_listActor.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_listActor.FormattingEnabled = true;
            this.m_listActor.ItemHeight = 12;
            this.m_listActor.Location = new System.Drawing.Point(3, 17);
            this.m_listActor.Name = "m_listActor";
            this.m_listActor.Size = new System.Drawing.Size(109, 220);
            this.m_listActor.TabIndex = 0;
            this.m_listActor.SelectedIndexChanged += new System.EventHandler(this.m_listActor_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_labReference);
            this.groupBox5.Location = new System.Drawing.Point(388, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 270);
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
            this.m_labReference.ReadOnly = true;
            this.m_labReference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_labReference.Size = new System.Drawing.Size(105, 250);
            this.m_labReference.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 250);
            this.textBox1.TabIndex = 0;
            // 
            // SceenplayUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 294);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SceenplayUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "SceenplayUI";
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox m_labID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnAddActor;
        private System.Windows.Forms.TextBox m_labActor;
        private System.Windows.Forms.ListBox m_listActor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox m_labRemarks;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox m_labReference;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button m_btnTrigger;
        private System.Windows.Forms.TextBox m_labTriggerId;
    }
}