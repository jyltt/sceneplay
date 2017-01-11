namespace Sceneplay
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            this.SceneTree = new System.Windows.Forms.TreeView();
            this.funcList = new System.Windows.Forms.ComboBox();
            this.param = new System.Windows.Forms.RichTextBox();
            this.paramType = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pos3 = new System.Windows.Forms.RadioButton();
            this.pos2 = new System.Windows.Forms.RadioButton();
            this.pos1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headIconPath = new System.Windows.Forms.TextBox();
            this.audioId = new System.Windows.Forms.TextBox();
            this.actor = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTriggerID = new System.Windows.Forms.TextBox();
            this.actorList = new System.Windows.Forms.ListBox();
            this.labNodeName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.remarks = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.switchList = new System.Windows.Forms.CheckedListBox();
            this.btnActorAdd = new System.Windows.Forms.Button();
            this.labActorAdd = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(5, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 12);
            label1.TabIndex = 9;
            label1.Text = "剧情操作对象";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(131, 4);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 12);
            label3.TabIndex = 11;
            label3.Text = "人物位置";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 128);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(101, 12);
            label5.TabIndex = 13;
            label5.Text = "操作内容参数列表";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(131, 90);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 12);
            label6.TabIndex = 14;
            label6.Text = "参数值";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(5, 393);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 12);
            label7.TabIndex = 15;
            label7.Text = "角色头像路径";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(5, 4);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(53, 12);
            label8.TabIndex = 19;
            label8.Text = "登场对象";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(5, 148);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(65, 12);
            label9.TabIndex = 20;
            label9.Text = "剧情触发器";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(410, 262);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(29, 12);
            label10.TabIndex = 22;
            label10.Text = "备注";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(5, 5);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(41, 12);
            label11.TabIndex = 22;
            label11.Text = "结点名";
            // 
            // SceneTree
            // 
            this.SceneTree.ItemHeight = 14;
            this.SceneTree.LineColor = System.Drawing.Color.Bisque;
            this.SceneTree.Location = new System.Drawing.Point(0, 0);
            this.SceneTree.Name = "SceneTree";
            this.SceneTree.PathSeparator = ".";
            this.SceneTree.Size = new System.Drawing.Size(146, 417);
            this.SceneTree.TabIndex = 0;
            this.SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SceneTreeClickItem);
            // 
            // funcList
            // 
            this.funcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcList.FormattingEnabled = true;
            this.funcList.Location = new System.Drawing.Point(5, 105);
            this.funcList.Name = "funcList";
            this.funcList.Size = new System.Drawing.Size(121, 20);
            this.funcList.TabIndex = 1;
            this.funcList.SelectedIndexChanged += new System.EventHandler(this.funcList_SelectedIndexChanged);
            // 
            // param
            // 
            this.param.Location = new System.Drawing.Point(131, 105);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(120, 297);
            this.param.TabIndex = 3;
            this.param.Text = "";
            this.param.WordWrap = false;
            // 
            // paramType
            // 
            this.paramType.FormattingEnabled = true;
            this.paramType.ItemHeight = 12;
            this.paramType.Location = new System.Drawing.Point(5, 152);
            this.paramType.Name = "paramType";
            this.paramType.Size = new System.Drawing.Size(120, 124);
            this.paramType.TabIndex = 4;
            this.paramType.SelectedIndexChanged += new System.EventHandler(this.paramType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(12, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // btnDelet
            // 
            this.btnDelet.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDelet.Location = new System.Drawing.Point(102, 423);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(19, 23);
            this.btnDelet.TabIndex = 5;
            this.btnDelet.Text = "-";
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.switchList);
            this.panel1.Controls.Add(this.pos3);
            this.panel1.Controls.Add(this.pos2);
            this.panel1.Controls.Add(this.pos1);
            this.panel1.Controls.Add(label7);
            this.panel1.Controls.Add(label6);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(label1);
            this.panel1.Controls.Add(this.headIconPath);
            this.panel1.Controls.Add(this.audioId);
            this.panel1.Controls.Add(this.actor);
            this.panel1.Controls.Add(this.funcList);
            this.panel1.Controls.Add(this.paramType);
            this.panel1.Controls.Add(this.param);
            this.panel1.Location = new System.Drawing.Point(152, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 433);
            this.panel1.TabIndex = 6;
            // 
            // pos3
            // 
            this.pos3.AutoSize = true;
            this.pos3.Location = new System.Drawing.Point(131, 68);
            this.pos3.Name = "pos3";
            this.pos3.Size = new System.Drawing.Size(47, 16);
            this.pos3.TabIndex = 18;
            this.pos3.TabStop = true;
            this.pos3.Text = "右边";
            this.pos3.UseVisualStyleBackColor = true;
            // 
            // pos2
            // 
            this.pos2.AutoSize = true;
            this.pos2.Location = new System.Drawing.Point(131, 46);
            this.pos2.Name = "pos2";
            this.pos2.Size = new System.Drawing.Size(47, 16);
            this.pos2.TabIndex = 17;
            this.pos2.TabStop = true;
            this.pos2.Text = "左边";
            this.pos2.UseVisualStyleBackColor = true;
            // 
            // pos1
            // 
            this.pos1.AutoSize = true;
            this.pos1.Location = new System.Drawing.Point(131, 24);
            this.pos1.Name = "pos1";
            this.pos1.Size = new System.Drawing.Size(47, 16);
            this.pos1.TabIndex = 16;
            this.pos1.TabStop = true;
            this.pos1.Text = "中间";
            this.pos1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "操作列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "语音id";
            // 
            // headIconPath
            // 
            this.headIconPath.Location = new System.Drawing.Point(3, 408);
            this.headIconPath.Name = "headIconPath";
            this.headIconPath.Size = new System.Drawing.Size(247, 21);
            this.headIconPath.TabIndex = 8;
            // 
            // audioId
            // 
            this.audioId.Location = new System.Drawing.Point(5, 63);
            this.audioId.Name = "audioId";
            this.audioId.Size = new System.Drawing.Size(119, 21);
            this.audioId.TabIndex = 7;
            // 
            // actor
            // 
            this.actor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actor.FormattingEnabled = true;
            this.actor.Location = new System.Drawing.Point(5, 20);
            this.actor.Name = "actor";
            this.actor.Size = new System.Drawing.Size(121, 20);
            this.actor.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labActorAdd);
            this.panel2.Controls.Add(this.btnActorAdd);
            this.panel2.Controls.Add(this.labTriggerID);
            this.panel2.Controls.Add(label9);
            this.panel2.Controls.Add(label8);
            this.panel2.Controls.Add(this.actorList);
            this.panel2.Location = new System.Drawing.Point(412, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 190);
            this.panel2.TabIndex = 7;
            // 
            // labTriggerID
            // 
            this.labTriggerID.Location = new System.Drawing.Point(5, 164);
            this.labTriggerID.Name = "labTriggerID";
            this.labTriggerID.Size = new System.Drawing.Size(119, 21);
            this.labTriggerID.TabIndex = 21;
            // 
            // actorList
            // 
            this.actorList.FormattingEnabled = true;
            this.actorList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.actorList.ItemHeight = 12;
            this.actorList.Location = new System.Drawing.Point(5, 20);
            this.actorList.Name = "actorList";
            this.actorList.Size = new System.Drawing.Size(120, 100);
            this.actorList.TabIndex = 6;
            // 
            // labNodeName
            // 
            this.labNodeName.Location = new System.Drawing.Point(5, 21);
            this.labNodeName.Name = "labNodeName";
            this.labNodeName.Size = new System.Drawing.Size(119, 21);
            this.labNodeName.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Location = new System.Drawing.Point(127, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(412, 277);
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(134, 168);
            this.remarks.TabIndex = 23;
            this.remarks.Text = "";
            this.remarks.WordWrap = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labNodeName);
            this.panel3.Controls.Add(label11);
            this.panel3.Location = new System.Drawing.Point(412, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(134, 51);
            this.panel3.TabIndex = 24;
            // 
            // switchList
            // 
            this.switchList.FormattingEnabled = true;
            this.switchList.Items.AddRange(new object[] {
            "是否自动播放",
            "是否显示跳过",
            "是否开启黑幕",
            "是否开启暂停",
            "是否mmo剧情"});
            this.switchList.Location = new System.Drawing.Point(5, 282);
            this.switchList.Name = "switchList";
            this.switchList.Size = new System.Drawing.Size(120, 84);
            this.switchList.TabIndex = 20;
            // 
            // btnActorAdd
            // 
            this.btnActorAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActorAdd.Location = new System.Drawing.Point(105, 123);
            this.btnActorAdd.Name = "btnActorAdd";
            this.btnActorAdd.Size = new System.Drawing.Size(19, 23);
            this.btnActorAdd.TabIndex = 22;
            this.btnActorAdd.Text = "+";
            this.btnActorAdd.UseVisualStyleBackColor = true;
            // 
            // labActorAdd
            // 
            this.labActorAdd.Location = new System.Drawing.Point(6, 124);
            this.labActorAdd.Name = "labActorAdd";
            this.labActorAdd.Size = new System.Drawing.Size(93, 21);
            this.labActorAdd.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 452);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.remarks);
            this.Controls.Add(label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelet);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.SceneTree);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView SceneTree;
        private System.Windows.Forms.ComboBox funcList;
        private System.Windows.Forms.RichTextBox param;
        private System.Windows.Forms.ListBox paramType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton pos3;
        private System.Windows.Forms.RadioButton pos2;
        private System.Windows.Forms.RadioButton pos1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox headIconPath;
        private System.Windows.Forms.TextBox audioId;
        private System.Windows.Forms.ComboBox actor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox actorList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox labTriggerID;
        private System.Windows.Forms.RichTextBox remarks;
        private System.Windows.Forms.TextBox labNodeName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox switchList;
        private System.Windows.Forms.TextBox labActorAdd;
        private System.Windows.Forms.Button btnActorAdd;
    }
}

