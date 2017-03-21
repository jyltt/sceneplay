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
        ReadFile m_FileInfo;
        int m_curHurdleId = -1;
        int m_curSceneplayId = -1;
        int m_curFuncIndex = -1;
        string m_curFuncName = "";
        TreeNode m_RootNode;

        public MainUI()
        {
            InitializeComponent();
            SceneTree.DrawNode += new DrawTreeNodeEventHandler(SceneTree_DrawNode);
            m_RootNode = new TreeNode("root");
            SceneTree.Nodes.Add(m_RootNode);
            RefreshAll();
        }

        private void CreateTree()
        {
            foreach (var dic in m_FileInfo.m_hurdle)
            {
                var hurdle_id = dic.Key;
                TreeNode nodeHurdle = new TreeNode(hurdle_id.ToString());
                m_RootNode.Nodes.Add(nodeHurdle);
                if (hurdle_id == m_curHurdleId && -1 == m_curSceneplayId && -1 == m_curFuncIndex)
                    SceneTree.SelectedNode = nodeHurdle;
                CreateHurdleTree(nodeHurdle, dic.Key);
            }
        }

        private void CreateHurdleTree(TreeNode node, int hurdle_id)
        {
            var hurdleList = m_FileInfo.m_hurdle[hurdle_id];
            foreach (var hurdle in hurdleList)
            {
                var sceneplay_id = hurdle.SceneplayID;
                TreeNode nodeSceneplay = new TreeNode(sceneplay_id.ToString());
                node.Nodes.Add(nodeSceneplay);
                if (hurdle_id == m_curHurdleId && sceneplay_id == m_curSceneplayId && -1 == m_curFuncIndex)
                    SceneTree.SelectedNode = nodeSceneplay;
                CreateSceneplayTree(nodeSceneplay, sceneplay_id, hurdle_id);
            }
        }

        private void CreateSceneplayTree(TreeNode node, int sceneplay_id, int hurdle_id)
        {
            if (m_FileInfo.m_play.ContainsKey(sceneplay_id))
            {
                for (int i = 0; i < m_FileInfo.m_play[sceneplay_id].Count; i++)
                {
                    var func = m_FileInfo.m_play[sceneplay_id][i];
                    string name = null;
                    string text = null;
                    if (func.ActType == "func")
                    {
                        var obj = func.ActInfo;
                        name = obj.Name;
                        text = obj.Name + "(" + func.Describe + ")";
                    }
                    else if (func.ActType == "talk")
                    {
                        name = "talk";
                        text = "talk" + "(" + func.Describe + ")";
                    }
                    if (name != null)
                    {
                        TreeNode nodeFuncName = new TreeNode(text);
                        nodeFuncName.Tag = name;
                        node.Nodes.Add(nodeFuncName);
                        if (hurdle_id == m_curHurdleId && sceneplay_id == m_curSceneplayId && i == m_curFuncIndex)
                            SceneTree.SelectedNode = nodeFuncName;
                    }
                }
            }
        }

        private void SelectFunc()
        {
        }

        private void SelectSceneplay()
        {
        }

        private void RefreshAll(bool refresh_file = true)
        {
            if (refresh_file)
            {
                m_FileInfo = new ReadFile();
            }
            m_RootNode.Nodes.Clear();
            CreateTree();
        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_FileInfo.WriteConfigFile(m_FileInfo.GetPath() + "screenplay_config.txt");
            m_FileInfo.WriteContentFile(m_FileInfo.GetPath() + "screenplay_content.txt");
            m_FileInfo.m_StringCfg.Save();
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            string nodeName = SceneTree.SelectedNode.Text;
            string fullPath = SceneTree.SelectedNode.FullPath;
            string[] nodeParent = fullPath.Split('.');
            if (nodeParent.Length == 4)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = (string)SceneTree.SelectedNode.Tag;
                m_curFuncIndex = SceneTree.SelectedNode.Index;
                SelectFunc();
            }
            else if(nodeParent.Length == 3)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = "";
                m_curFuncIndex = -1;
                SelectSceneplay();
            }
            else if (nodeParent.Length == 2)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = -1;
                m_curFuncName = "";
                m_curFuncIndex = -1;
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
                    m_FileInfo.CreateHurdle(name);
                    curTreeNode.Nodes.Add(name.ToString());
                    break;
                case 2:
                    var playsceneid = 1;
                    m_FileInfo.CreatePlayid(m_curHurdleId, playsceneid);
                    curTreeNode.Nodes.Add(playsceneid.ToString());
                    break;
                case 3:
                    if(m_FileInfo.m_play2flg[m_curSceneplayId]>1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，添加会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        { 
                            case DialogResult.No:
                                return;
                        }
                    }
                    var funcName = "talk";
                    var sceneplay = m_FileInfo.CreateFunc(m_curSceneplayId, funcName);
                    sceneplay.ActTalk = "str" + m_FileInfo.m_StringCfg.GetStringId().ToString();
                    curTreeNode.Nodes.Add(funcName);
                    RefreshAll(false);
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
                    m_FileInfo.DeleteHurdle(hurdle_id);
                    break;
                case 3:
                    nodeName = curTreeNode.Text;
                    int sceneplay_id;
                    result = Int32.TryParse(nodeName, out sceneplay_id); // return bool value hint y/n
                    if (!result)
                        return;
                    m_FileInfo.RemovePlayid(sceneplay_id, m_curHurdleId, curTreeNode.Index);
                    break;
                case 4:
                    if(m_FileInfo.m_play2flg[m_curSceneplayId]>1)
                    {
                        var ret = MessageBox.Show("该剧情有多个关卡引用，删除会影响其他关卡的该剧情信息\n是否继续？((‵□′))", "有多个引用", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        switch (ret)
                        { 
                            case DialogResult.No:
                                return;
                        }
                    }
                    var list = m_FileInfo.m_play[m_curSceneplayId];
                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (i == curTreeNode.Index)
                        {
                            m_FileInfo.DeleteFunc(m_curSceneplayId, i);
                            break;
                        }
                    }
                    m_curFuncIndex -= 1;
                    RefreshAll(false);
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
                case 3:
                    var hurdleList = m_FileInfo.m_hurdle[m_curHurdleId];
                    if (curTreeNode.Index < hurdleList.Count - 1)
                    {
                        var curIndex = curTreeNode.Index;
                        var curNode = hurdleList[curIndex];
                        hurdleList.RemoveAt(curIndex);
                        hurdleList.Insert(curIndex + 1, curNode);
                        var parentNode = SceneTree.SelectedNode.Parent;
                        parentNode.Nodes.Clear();
                        foreach (var hurdle in hurdleList)
                        {
                            TreeNode nodeSceneplay = new TreeNode(hurdle.SceneplayID.ToString());
                            CreateSceneplayTree(nodeSceneplay, hurdle.SceneplayID, hurdle.HurdleID);
                            parentNode.Nodes.Add(nodeSceneplay);
                            if (hurdle.SceneplayID == m_curSceneplayId)
                                SceneTree.SelectedNode = nodeSceneplay;
                        }
                    }
                    break;
                case 4:
                    var sceneplayList = m_FileInfo.m_play[m_curSceneplayId];
                    if (curTreeNode.Index < sceneplayList.Count - 1)
                    {
                        var curIndex = curTreeNode.Index;
                        var curNode = sceneplayList[curIndex];
                        sceneplayList.RemoveAt(curIndex);
                        sceneplayList.Insert(curIndex + 1, curNode);
                        var parentNode = SceneTree.SelectedNode.Parent;
                        parentNode.Nodes.Clear();
                        foreach (var func in sceneplayList)
                        {
                            string name = null;
                            string text = null;
                            if (func.ActType == "func")
                            {
                                var obj = func.ActInfo;
                                name = obj.Name;
                                text = obj.Name + "(" + func.Describe + ")";
                            }
                            else if (func.ActType == "talk")
                            {
                                name = "talk";
                                text = "talk" + "(" + func.Describe + ")";
                            }
                            if (name != null)
                            {
                                TreeNode nodeFuncName = new TreeNode(text);
                                nodeFuncName.Tag = name;
                                parentNode.Nodes.Add(nodeFuncName);
                                if (func == curNode && parentNode != null)
                                    SceneTree.SelectedNode = nodeFuncName;
                            }
                        }
                        RefreshAll(false);
                    }
                    break;
            }
        }

        private void btnUpNode_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var nodeList = curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 2:
                    break;
                case 3:
                    var list = m_FileInfo.m_hurdle[m_curHurdleId];
                    if (curTreeNode.Index > 0)
                    {
                        var curIndex = curTreeNode.Index;
                        var curNode = list[curIndex];
                        list.RemoveAt(curTreeNode.Index);
                        list.Insert(curIndex - 1, curNode);
                        var parentNode = SceneTree.SelectedNode.Parent;
                        parentNode.Nodes.Clear();
                        foreach (var hurdle in list)
                        {
                            TreeNode nodeSceneplay = new TreeNode(hurdle.SceneplayID.ToString());
                            CreateSceneplayTree(nodeSceneplay, hurdle.SceneplayID, hurdle.HurdleID);
                            parentNode.Nodes.Add(nodeSceneplay);
                            if (hurdle.SceneplayID == m_curSceneplayId)
                                SceneTree.SelectedNode = nodeSceneplay;
                        }
                    }
                    break;
                case 4:
                    var sceneplayList = m_FileInfo.m_play[m_curSceneplayId];
                    if (curTreeNode.Index > 0)
                    {
                        var curIndex = curTreeNode.Index;
                        var curNode = sceneplayList[curIndex];
                        sceneplayList.RemoveAt(curIndex);
                        sceneplayList.Insert(curIndex - 1, curNode);
                        var parentNode = SceneTree.SelectedNode.Parent;
                        parentNode.Nodes.Clear();
                        foreach (var func in sceneplayList)
                        {
                            string name = null;
                            string text = null;
                            if (func.ActType == "func")
                            {
                                var obj = func.ActInfo;
                                name = obj.Name;
                                text = obj.Name + "(" + func.Describe + ")";
                            }
                            else if (func.ActType == "talk")
                            {
                                name = "talk";
                                text = "talk" + "(" + func.Describe + ")";
                            }
                            if (name != null)
                            {
                                TreeNode nodeFuncName = new TreeNode(text);
                                nodeFuncName.Tag = name;
                                parentNode.Nodes.Add(nodeFuncName);
                                if (func == curNode && parentNode != null)
                                    SceneTree.SelectedNode = nodeFuncName;
                            }
                        }
                        RefreshAll(false);
                    }
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
    }
}
