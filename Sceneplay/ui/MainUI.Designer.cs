namespace Sceneplay
{
    partial class MainUI
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeletNode = new System.Windows.Forms.Button();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnDownNode = new System.Windows.Forms.Button();
            this.btnUpNode = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelRoot = new System.Windows.Forms.Panel();
            this.panelRoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // SceneTree
            // 
            this.SceneTree.Dock = System.Windows.Forms.DockStyle.Top;
            this.SceneTree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.SceneTree.FullRowSelect = true;
            this.SceneTree.HideSelection = false;
            this.SceneTree.ItemHeight = 14;
            this.SceneTree.LineColor = System.Drawing.Color.Aqua;
            this.SceneTree.Location = new System.Drawing.Point(0, 0);
            this.SceneTree.Name = "SceneTree";
            this.SceneTree.PathSeparator = ".";
            this.SceneTree.Size = new System.Drawing.Size(271, 450);
            this.SceneTree.TabIndex = 0;
            this.SceneTree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.SceneTree_DrawNode);
            this.SceneTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.SceneTreeClickItem);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Location = new System.Drawing.Point(81, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeletNode
            // 
            this.btnDeletNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDeletNode.Location = new System.Drawing.Point(213, 456);
            this.btnDeletNode.Name = "btnDeletNode";
            this.btnDeletNode.Size = new System.Drawing.Size(25, 23);
            this.btnDeletNode.TabIndex = 5;
            this.btnDeletNode.Text = "-";
            this.btnDeletNode.UseVisualStyleBackColor = true;
            this.btnDeletNode.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // btnAddNode
            // 
            this.btnAddNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAddNode.Location = new System.Drawing.Point(244, 456);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(25, 23);
            this.btnAddNode.TabIndex = 8;
            this.btnAddNode.Text = "+";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnDownNode
            // 
            this.btnDownNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDownNode.Location = new System.Drawing.Point(182, 456);
            this.btnDownNode.Name = "btnDownNode";
            this.btnDownNode.Size = new System.Drawing.Size(25, 23);
            this.btnDownNode.TabIndex = 27;
            this.btnDownNode.Text = "↓";
            this.btnDownNode.UseVisualStyleBackColor = true;
            this.btnDownNode.Click += new System.EventHandler(this.btnDownNode_Click);
            // 
            // btnUpNode
            // 
            this.btnUpNode.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUpNode.Location = new System.Drawing.Point(151, 456);
            this.btnUpNode.Name = "btnUpNode";
            this.btnUpNode.Size = new System.Drawing.Size(25, 23);
            this.btnUpNode.TabIndex = 28;
            this.btnUpNode.Text = "↑";
            this.btnUpNode.UseVisualStyleBackColor = true;
            this.btnUpNode.Click += new System.EventHandler(this.btnUpNode_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(0, 456);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "重新加载";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInfo.Location = new System.Drawing.Point(271, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(618, 479);
            this.panelInfo.TabIndex = 30;
            // 
            // panelRoot
            // 
            this.panelRoot.Controls.Add(this.SceneTree);
            this.panelRoot.Controls.Add(this.btnAddNode);
            this.panelRoot.Controls.Add(this.btnDownNode);
            this.panelRoot.Controls.Add(this.btnDeletNode);
            this.panelRoot.Controls.Add(this.btnUpNode);
            this.panelRoot.Controls.Add(this.btnRefresh);
            this.panelRoot.Controls.Add(this.btnSave);
            this.panelRoot.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelRoot.Location = new System.Drawing.Point(0, 0);
            this.panelRoot.Name = "panelRoot";
            this.panelRoot.Size = new System.Drawing.Size(271, 479);
            this.panelRoot.TabIndex = 31;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(893, 479);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "剧情编辑器-无名";
            this.panelRoot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SceneTree;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeletNode;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnDownNode;
        private System.Windows.Forms.Button btnUpNode;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelRoot;
    }
}

