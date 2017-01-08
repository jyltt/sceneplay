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
            this.SceneTree = new System.Windows.Forms.TreeView();
            this.funcList = new System.Windows.Forms.ComboBox();
            this.param = new System.Windows.Forms.RichTextBox();
            this.paramType = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SceneTree
            // 
            this.SceneTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.SceneTree.ItemHeight = 14;
            this.SceneTree.LineColor = System.Drawing.Color.Bisque;
            this.SceneTree.Location = new System.Drawing.Point(0, 0);
            this.SceneTree.Name = "SceneTree";
            this.SceneTree.PathSeparator = ".";
            this.SceneTree.Size = new System.Drawing.Size(146, 491);
            this.SceneTree.TabIndex = 0;
            this.SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SceneTreeClickItem);
            // 
            // funcList
            // 
            this.funcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcList.FormattingEnabled = true;
            this.funcList.Location = new System.Drawing.Point(152, 12);
            this.funcList.Name = "funcList";
            this.funcList.Size = new System.Drawing.Size(121, 20);
            this.funcList.TabIndex = 1;
            // 
            // param
            // 
            this.param.Location = new System.Drawing.Point(297, 48);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(120, 398);
            this.param.TabIndex = 3;
            this.param.Text = "";
            this.param.WordWrap = false;
            // 
            // paramType
            // 
            this.paramType.FormattingEnabled = true;
            this.paramType.ItemHeight = 12;
            this.paramType.Location = new System.Drawing.Point(153, 48);
            this.paramType.Name = "paramType";
            this.paramType.Size = new System.Drawing.Size(120, 436);
            this.paramType.TabIndex = 4;
            this.paramType.SelectedIndexChanged += new System.EventHandler(this.paramType_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(363, 461);
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
            this.btnDelet.Location = new System.Drawing.Point(297, 461);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(54, 23);
            this.btnDelet.TabIndex = 5;
            this.btnDelet.Text = " 删除";
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 491);
            this.Controls.Add(this.btnDelet);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.paramType);
            this.Controls.Add(this.param);
            this.Controls.Add(this.funcList);
            this.Controls.Add(this.SceneTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SceneTree;
        private System.Windows.Forms.ComboBox funcList;
        private System.Windows.Forms.RichTextBox param;
        private System.Windows.Forms.ListBox paramType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelet;
    }
}

