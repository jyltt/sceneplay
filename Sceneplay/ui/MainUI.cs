using Sceneplay.data;
using Sceneplay.ui;
using Sceneplay.ui.item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sceneplay
{
    public partial class MainUI : Form
    {
        string m_curFuncName = "";
        TreeNode m_RootNode;
        List<Form> m_curForm = new List<Form>();

        public MainUI()
        {
            InitializeComponent();
            m_RootNode = new TreeNode("root");
            SceneTree.Nodes.Add(m_RootNode);
            RefreshAll();
        }

        void ClearForm()
        {
            foreach (var w2 in m_curForm)
            {
                w2.Parent = null;
                w2.TopLevel = false;
            }
            m_curForm.Clear();
        }

        private void CreateTree()
        {
            foreach (var hurdle_id in FileManager.GetInstance().ConfigMgr.GetHurdleList())
            {
                TreeNode nodeHurdle = new TreeNode(hurdle_id.ToString());
                m_RootNode.Nodes.Add(nodeHurdle);
                if (hurdle_id == DataCenter.curHurdleId && -1 == DataCenter.curScreenplayId && -1 == DataCenter.curFuncIndex)
                    SceneTree.SelectedNode = nodeHurdle;
                CreateHurdleTree(nodeHurdle, hurdle_id);
            }
            m_RootNode.Expand();
        }

        private void CreateHurdleTree(TreeNode node, int hurdle_id)
        {
            var hurdleList = FileManager.GetInstance().ConfigMgr.GetContList(hurdle_id);
            foreach (var hurdle in hurdleList.Values)
            {
                var sceneplay_id = hurdle.SceneplayID;
                ScreenplayTreeNode nodeSceneplay = new ScreenplayTreeNode(sceneplay_id,hurdle_id);
                node.Nodes.Add(nodeSceneplay);
                if (hurdle_id == DataCenter.curHurdleId && sceneplay_id == DataCenter.curScreenplayId && -1 == DataCenter.curFuncIndex)
                    SceneTree.SelectedNode = nodeSceneplay;
                nodeSceneplay.CreateSceneplayTree(sceneplay_id, hurdle_id);
                //CreateSceneplayTree(nodeSceneplay, sceneplay_id, hurdle_id);
            }
        }

        private void SelectFunc()
        {
            ClearForm();
            var w1 = new ActionBaseUI(DataCenter.curScreenplayId, DataCenter.curFuncIndex);
            w1.TopLevel = false;
            w1.Parent = panelInfo;
            w1.Show();
            m_curForm.Add(w1);
        }

        private void SelectSceneplay()
        {
            ClearForm();
            var w1 = new SceenplayUI(DataCenter.curHurdleId, DataCenter.curScreenplayId, SceneTree.SelectedNode);
            w1.TopLevel = false;
            w1.Parent = panelInfo;
            w1.Show();
            m_curForm.Add(w1);
        }

        private void RefreshAll(bool refresh_file = true)
        {
            if (refresh_file)
            {
                FileManager.GetInstance().ReadFile();
            }
            m_RootNode.Nodes.Clear();
            CreateTree();
        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FileManager.GetInstance().Save())
                MessageBox.Show("保存成功");
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            string fullPath = SceneTree.SelectedNode.FullPath;
            string[] nodeParent = fullPath.Split('.');
            if (nodeParent.Length == 4)
            {
                DataCenter.curHurdleId = System.Int32.Parse(nodeParent[1]);
                DataCenter.curScreenplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = (string)SceneTree.SelectedNode.Tag;
                DataCenter.curFuncIndex = SceneTree.SelectedNode.Index;
                SelectFunc();
            }
            else if(nodeParent.Length == 3)
            {
                DataCenter.curHurdleId = System.Int32.Parse(nodeParent[1]);
                DataCenter.curScreenplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = "";
                DataCenter.curFuncIndex = -1;
                SelectSceneplay();
            }
            else if (nodeParent.Length == 2)
            {
                DataCenter.curHurdleId = System.Int32.Parse(nodeParent[1]);
                DataCenter.curScreenplayId = -1;
                m_curFuncName = "";
                DataCenter.curFuncIndex = -1;
                ClearForm();
                var w1 = new HurdleUI(DataCenter.curHurdleId, SceneTree.SelectedNode);
                w1.TopLevel = false;
                w1.Parent = panelInfo;
                w1.Show();
                m_curForm.Add(w1);
            }
            else
            { 
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var nodeList = curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 1:
                    var name = 1;
                    if (FileManager.GetInstance().ConfigMgr.CreateNewHurdle(name))
                        curTreeNode.Nodes.Add(name.ToString());
                    else
                        MessageBox.Show("关卡id已存在d(╯﹏╰)b", "创建失败");
                    break;
                case 2:
                    var playsceneid = 1;
                    var res = FileManager.GetInstance().ConfigMgr.CreateNewScreenplay(DataCenter.curHurdleId, playsceneid);
                    if(res)
                    {
                        ScreenplayTreeNode nodeSceneplay = new ScreenplayTreeNode(playsceneid, DataCenter.curHurdleId );
                        curTreeNode.Nodes.Add(nodeSceneplay);
                    }
                    else
                        MessageBox.Show("剧情id创建失败⊙︿⊙", "创建失败");
                    break;
                case 3:
                    if (FileManager.GetInstance().ConfigMgr.GetSceenplayReferenceList(DataCenter.curScreenplayId).Count > 1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，添加会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        {
                            case DialogResult.No:
                                return;
                        }
                    }
                    FileManager.GetInstance().ContentMgr.CreateNewAction(DataCenter.curScreenplayId);
                    break;
                default:
                    MessageBox.Show("该节点不能创建子节点(─.─|||)");
                    break;
            }
        }
        private void btnDelet_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var nodeList = curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 2:
                    var nodeName = curTreeNode.Text;
                    int hurdle_id;
                    bool result = Int32.TryParse(nodeName, out hurdle_id); // return bool value hint y/n
                    if (!result)
                        return;
                    FileManager.GetInstance().ConfigMgr.RemoveHurdle(hurdle_id);
                    break;
                case 3:
                    nodeName = curTreeNode.Text;
                    int sceneplay_id;
                    result = Int32.TryParse(nodeName, out sceneplay_id); // return bool value hint y/n
                    if (!result)
                        return;
                    FileManager.GetInstance().ConfigMgr.RemoveScreenplay(DataCenter.curHurdleId, sceneplay_id);
                    break;
                case 4:
                    if (FileManager.GetInstance().ConfigMgr.GetSceenplayReferenceList(DataCenter.curScreenplayId).Count > 1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，删除会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        {
                            case DialogResult.No:
                                return;
                        }
                    }
                    FileManager.GetInstance().ContentMgr.RemoveAction(DataCenter.curScreenplayId, DataCenter.curFuncIndex);
                    DataCenter.curFuncIndex -= 1;
                    break;
                default:
                    MessageBox.Show("别乱删结点啊喂！！(╯‵□′)╯︵┴─┴");
                    return;
            }
            curTreeNode.Remove();
            SceneTreeClickItem(null, null);
        }

        private void SceneTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void btnDownNode_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var nodeList = curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 4:
                    if (FileManager.GetInstance().ConfigMgr.GetSceenplayReferenceList(DataCenter.curScreenplayId).Count > 1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，删除会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        {
                            case DialogResult.No:
                                return;
                        }
                    }
                    FileManager.GetInstance().ContentMgr.MoveDownFunc(DataCenter.curScreenplayId, DataCenter.curFuncIndex);
                    break;
            }
        }

        private void btnUpNode_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var nodeList = curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 4:
                    if (FileManager.GetInstance().ConfigMgr.GetSceenplayReferenceList(DataCenter.curScreenplayId).Count > 1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，删除会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        {
                            case DialogResult.No:
                                return;
                        }
                    }
                    FileManager.GetInstance().ContentMgr.MoveUpFunc(DataCenter.curScreenplayId, DataCenter.curFuncIndex);
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var ret = MessageBox.Show("是否重新加载所有配置？√(─皿─)√\n未保存内容将被丢弃！！", "重新加载", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (ret)
            { 
                case DialogResult.Yes:
                    RefreshAll();
                    break;
            }
        }

        private void SceneTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var nodeList = e.Node.FullPath.Split('.');
            switch (nodeList.Length)
            {
                case 3:
                    var screenplayNode = e.Node as ScreenplayTreeNode;
                    screenplayNode.UpdateUI();
                    break;
            }
        }
    }
}
