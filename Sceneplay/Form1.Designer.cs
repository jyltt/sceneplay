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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.GroupBox groupBox6;
            System.Windows.Forms.GroupBox groupBox7;
            System.Windows.Forms.GroupBox groupBox8;
            System.Windows.Forms.GroupBox groupBox9;
            System.Windows.Forms.GroupBox groupBox11;
            this.pos1 = new System.Windows.Forms.RadioButton();
            this.pos2 = new System.Windows.Forms.RadioButton();
            this.pos3 = new System.Windows.Forms.RadioButton();
            this.remarks = new System.Windows.Forms.RichTextBox();
            this.headIconPath = new System.Windows.Forms.TextBox();
            this.param = new System.Windows.Forms.RichTextBox();
            this.paramType = new System.Windows.Forms.ListBox();
            this.funcList = new System.Windows.Forms.ComboBox();
            this.audioId = new System.Windows.Forms.TextBox();
            this.actor = new System.Windows.Forms.ComboBox();
            this.labNodeName = new System.Windows.Forms.TextBox();
            this.labTriggerID = new System.Windows.Forms.TextBox();
            this.SceneTree = new System.Windows.Forms.TreeView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeletNode = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.switchList = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.actorList = new System.Windows.Forms.ListBox();
            this.btnActorAdd = new System.Windows.Forms.Button();
            this.labActorAdd = new System.Windows.Forms.TextBox();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupFuncRemarks = new System.Windows.Forms.GroupBox();
            this.labFuncRemarks = new System.Windows.Forms.RichTextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            groupBox7 = new System.Windows.Forms.GroupBox();
            groupBox8 = new System.Windows.Forms.GroupBox();
            groupBox9 = new System.Windows.Forms.GroupBox();
            groupBox11 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupFuncRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.pos1);
            groupBox1.Controls.Add(this.pos2);
            groupBox1.Controls.Add(this.pos3);
            groupBox1.Location = new System.Drawing.Point(146, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(128, 82);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "人物位置";
            // 
            // pos1
            // 
            this.pos1.AutoSize = true;
            this.pos1.Location = new System.Drawing.Point(6, 15);
            this.pos1.Name = "pos1";
            this.pos1.Size = new System.Drawing.Size(47, 16);
            this.pos1.TabIndex = 16;
            this.pos1.TabStop = true;
            this.pos1.Text = "中间";
            this.pos1.UseVisualStyleBackColor = true;
            this.pos1.CheckedChanged += new System.EventHandler(this.pos_CheckedChanged);
            // 
            // pos2
            // 
            this.pos2.AutoSize = true;
            this.pos2.Location = new System.Drawing.Point(6, 37);
            this.pos2.Name = "pos2";
            this.pos2.Size = new System.Drawing.Size(47, 16);
            this.pos2.TabIndex = 17;
            this.pos2.TabStop = true;
            this.pos2.Text = "左边";
            this.pos2.UseVisualStyleBackColor = true;
            this.pos2.CheckedChanged += new System.EventHandler(this.pos_CheckedChanged);
            // 
            // pos3
            // 
            this.pos3.AutoSize = true;
            this.pos3.Location = new System.Drawing.Point(6, 60);
            this.pos3.Name = "pos3";
            this.pos3.Size = new System.Drawing.Size(47, 16);
            this.pos3.TabIndex = 18;
            this.pos3.TabStop = true;
            this.pos3.Text = "右边";
            this.pos3.UseVisualStyleBackColor = true;
            this.pos3.CheckedChanged += new System.EventHandler(this.pos_CheckedChanged);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.remarks);
            groupBox2.Location = new System.Drawing.Point(186, 440);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(425, 39);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "备注";
            // 
            // remarks
            // 
            this.remarks.Location = new System.Drawing.Point(5, 11);
            this.remarks.Multiline = false;
            this.remarks.Name = "remarks";
            this.remarks.Size = new System.Drawing.Size(413, 25);
            this.remarks.TabIndex = 23;
            this.remarks.Text = "";
            this.remarks.WordWrap = false;
            this.remarks.TextChanged += new System.EventHandler(this.remarks_TextChanged);
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(this.headIconPath);
            groupBox3.Location = new System.Drawing.Point(9, 388);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(265, 46);
            groupBox3.TabIndex = 22;
            groupBox3.TabStop = false;
            groupBox3.Text = "角色头像路径";
            // 
            // headIconPath
            // 
            this.headIconPath.Location = new System.Drawing.Point(6, 20);
            this.headIconPath.Name = "headIconPath";
            this.headIconPath.Size = new System.Drawing.Size(253, 21);
            this.headIconPath.TabIndex = 8;
            this.headIconPath.TextChanged += new System.EventHandler(this.headIconPath_TextChanged);
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.param);
            groupBox4.Location = new System.Drawing.Point(146, 92);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(128, 290);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "参数值";
            // 
            // param
            // 
            this.param.Location = new System.Drawing.Point(4, 20);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(120, 262);
            this.param.TabIndex = 3;
            this.param.Text = "";
            this.param.WordWrap = false;
            this.param.TextChanged += new System.EventHandler(this.param_TextChanged);
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.paramType);
            groupBox5.Location = new System.Drawing.Point(9, 147);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(131, 145);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "操作内容参数列表";
            // 
            // paramType
            // 
            this.paramType.FormattingEnabled = true;
            this.paramType.ItemHeight = 12;
            this.paramType.Location = new System.Drawing.Point(4, 16);
            this.paramType.Name = "paramType";
            this.paramType.Size = new System.Drawing.Size(120, 124);
            this.paramType.TabIndex = 4;
            this.paramType.SelectedIndexChanged += new System.EventHandler(this.paramType_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(this.funcList);
            groupBox6.Location = new System.Drawing.Point(9, 100);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(131, 41);
            groupBox6.TabIndex = 25;
            groupBox6.TabStop = false;
            groupBox6.Text = "操作列表";
            // 
            // funcList
            // 
            this.funcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcList.FormattingEnabled = true;
            this.funcList.Location = new System.Drawing.Point(6, 16);
            this.funcList.Name = "funcList";
            this.funcList.Size = new System.Drawing.Size(121, 20);
            this.funcList.TabIndex = 1;
            this.funcList.SelectedIndexChanged += new System.EventHandler(this.funcList_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(this.audioId);
            groupBox7.Location = new System.Drawing.Point(9, 53);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(131, 41);
            groupBox7.TabIndex = 26;
            groupBox7.TabStop = false;
            groupBox7.Text = "语音id";
            // 
            // audioId
            // 
            this.audioId.Location = new System.Drawing.Point(6, 15);
            this.audioId.Name = "audioId";
            this.audioId.Size = new System.Drawing.Size(119, 21);
            this.audioId.TabIndex = 7;
            this.audioId.TextChanged += new System.EventHandler(this.audioId_TextChanged);
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(this.actor);
            groupBox8.Location = new System.Drawing.Point(9, 7);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new System.Drawing.Size(131, 40);
            groupBox8.TabIndex = 27;
            groupBox8.TabStop = false;
            groupBox8.Text = "剧情操作对象";
            // 
            // actor
            // 
            this.actor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actor.FormattingEnabled = true;
            this.actor.Location = new System.Drawing.Point(6, 15);
            this.actor.Name = "actor";
            this.actor.Size = new System.Drawing.Size(121, 20);
            this.actor.TabIndex = 6;
            this.actor.SelectedIndexChanged += new System.EventHandler(this.actor_SelectedIndexChanged);
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(this.labNodeName);
            groupBox9.Location = new System.Drawing.Point(3, 7);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new System.Drawing.Size(132, 41);
            groupBox9.TabIndex = 24;
            groupBox9.TabStop = false;
            groupBox9.Text = "结点名";
            // 
            // labNodeName
            // 
            this.labNodeName.Location = new System.Drawing.Point(6, 14);
            this.labNodeName.Name = "labNodeName";
            this.labNodeName.Size = new System.Drawing.Size(119, 21);
            this.labNodeName.TabIndex = 23;
            this.labNodeName.Leave += new System.EventHandler(this.labNodeName_Leave);
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(this.labTriggerID);
            groupBox11.Location = new System.Drawing.Point(4, 334);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new System.Drawing.Size(131, 46);
            groupBox11.TabIndex = 25;
            groupBox11.TabStop = false;
            groupBox11.Text = "剧情触发器";
            // 
            // labTriggerID
            // 
            this.labTriggerID.Location = new System.Drawing.Point(6, 18);
            this.labTriggerID.Name = "labTriggerID";
            this.labTriggerID.Size = new System.Drawing.Size(119, 21);
            this.labTriggerID.TabIndex = 21;
            this.labTriggerID.TextChanged += new System.EventHandler(this.labTriggerID_TextChanged);
            // 
            // SceneTree
            // 
            this.SceneTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.SceneTree.HideSelection = false;
            this.SceneTree.ItemHeight = 14;
            this.SceneTree.LineColor = System.Drawing.Color.Aqua;
            this.SceneTree.Location = new System.Drawing.Point(0, 0);
            this.SceneTree.Name = "SceneTree";
            this.SceneTree.PathSeparator = ".";
            this.SceneTree.Size = new System.Drawing.Size(180, 450);
            this.SceneTree.TabIndex = 0;
            this.SceneTree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.SceneTree_DrawNode);
            this.SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SceneTreeClickItem);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(0, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeletNode
            // 
            this.btnDeletNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDeletNode.Location = new System.Drawing.Point(101, 456);
            this.btnDeletNode.Name = "btnDeletNode";
            this.btnDeletNode.Size = new System.Drawing.Size(19, 23);
            this.btnDeletNode.TabIndex = 5;
            this.btnDeletNode.Text = "-";
            this.btnDeletNode.UseVisualStyleBackColor = true;
            this.btnDeletNode.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(groupBox8);
            this.panel1.Controls.Add(groupBox7);
            this.panel1.Controls.Add(groupBox6);
            this.panel1.Controls.Add(groupBox5);
            this.panel1.Controls.Add(groupBox4);
            this.panel1.Controls.Add(groupBox3);
            this.panel1.Controls.Add(groupBox1);
            this.panel1.Controls.Add(this.switchList);
            this.panel1.Location = new System.Drawing.Point(186, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 438);
            this.panel1.TabIndex = 6;
            // 
            // switchList
            // 
            this.switchList.CheckOnClick = true;
            this.switchList.FormattingEnabled = true;
            this.switchList.Items.AddRange(new object[] {
            "是否自动播放",
            "是否显示跳过",
            "是否开启黑幕",
            "是否开启暂停",
            "是否mmo剧情"});
            this.switchList.Location = new System.Drawing.Point(9, 298);
            this.switchList.Name = "switchList";
            this.switchList.Size = new System.Drawing.Size(131, 84);
            this.switchList.TabIndex = 20;
            this.switchList.SelectedIndexChanged += new System.EventHandler(this.switchList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(groupBox11);
            this.panel2.Controls.Add(this.groupBox10);
            this.panel2.Location = new System.Drawing.Point(471, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 384);
            this.panel2.TabIndex = 7;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.actorList);
            this.groupBox10.Controls.Add(this.btnActorAdd);
            this.groupBox10.Controls.Add(this.labActorAdd);
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(131, 325);
            this.groupBox10.TabIndex = 24;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "登场对象";
            // 
            // actorList
            // 
            this.actorList.FormattingEnabled = true;
            this.actorList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.actorList.ItemHeight = 12;
            this.actorList.Location = new System.Drawing.Point(6, 17);
            this.actorList.Name = "actorList";
            this.actorList.Size = new System.Drawing.Size(120, 268);
            this.actorList.TabIndex = 6;
            this.actorList.SelectedIndexChanged += new System.EventHandler(this.actorList_SelectedIndexChanged);
            // 
            // btnActorAdd
            // 
            this.btnActorAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActorAdd.Location = new System.Drawing.Point(107, 296);
            this.btnActorAdd.Name = "btnActorAdd";
            this.btnActorAdd.Size = new System.Drawing.Size(19, 23);
            this.btnActorAdd.TabIndex = 22;
            this.btnActorAdd.Text = "+";
            this.btnActorAdd.UseVisualStyleBackColor = true;
            this.btnActorAdd.Click += new System.EventHandler(this.btnActorAdd_Click);
            // 
            // labActorAdd
            // 
            this.labActorAdd.Location = new System.Drawing.Point(6, 296);
            this.labActorAdd.Name = "labActorAdd";
            this.labActorAdd.Size = new System.Drawing.Size(93, 21);
            this.labActorAdd.TabIndex = 23;
            this.labActorAdd.TextChanged += new System.EventHandler(this.labActorAdd_TextChanged);
            // 
            // btnAddNode
            // 
            this.btnAddNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNode.Location = new System.Drawing.Point(127, 456);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(19, 23);
            this.btnAddNode.TabIndex = 8;
            this.btnAddNode.Text = "+";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(groupBox9);
            this.panel3.Location = new System.Drawing.Point(471, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 51);
            this.panel3.TabIndex = 24;
            // 
            // groupFuncRemarks
            // 
            this.groupFuncRemarks.Controls.Add(this.labFuncRemarks);
            this.groupFuncRemarks.Location = new System.Drawing.Point(471, 2);
            this.groupFuncRemarks.Name = "groupFuncRemarks";
            this.groupFuncRemarks.Size = new System.Drawing.Size(140, 438);
            this.groupFuncRemarks.TabIndex = 25;
            this.groupFuncRemarks.TabStop = false;
            this.groupFuncRemarks.Text = "函数备注";
            // 
            // labFuncRemarks
            // 
            this.labFuncRemarks.Location = new System.Drawing.Point(6, 20);
            this.labFuncRemarks.Name = "labFuncRemarks";
            this.labFuncRemarks.ReadOnly = true;
            this.labFuncRemarks.Size = new System.Drawing.Size(129, 412);
            this.labFuncRemarks.TabIndex = 23;
            this.labFuncRemarks.Text = "";
            this.labFuncRemarks.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 479);
            this.Controls.Add(this.groupFuncRemarks);
            this.Controls.Add(groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDeletNode);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.SceneTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "剧情编辑器-无名";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupFuncRemarks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SceneTree;
        private System.Windows.Forms.ComboBox funcList;
        private System.Windows.Forms.RichTextBox param;
        private System.Windows.Forms.ListBox paramType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeletNode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton pos3;
        private System.Windows.Forms.RadioButton pos2;
        private System.Windows.Forms.RadioButton pos1;
        private System.Windows.Forms.TextBox headIconPath;
        private System.Windows.Forms.TextBox audioId;
        private System.Windows.Forms.ComboBox actor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox actorList;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.TextBox labTriggerID;
        private System.Windows.Forms.RichTextBox remarks;
        private System.Windows.Forms.TextBox labNodeName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox switchList;
        private System.Windows.Forms.TextBox labActorAdd;
        private System.Windows.Forms.Button btnActorAdd;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupFuncRemarks;
        private System.Windows.Forms.RichTextBox labFuncRemarks;
    }
}

