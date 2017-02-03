﻿using System;
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
    public partial class Form1 : Form
    {
        ReadFile m_FileInfo = new ReadFile();
        int m_curHurdleId = -1;
        int m_curSceneplayId = -1;
        string m_curFuncName = "";

        public Form1()
        {
            InitializeComponent();
            SceneTree.DrawNode += new DrawTreeNodeEventHandler(SceneTree_DrawNode);
            CreateTree();
            CreateFuncList();
        }

        private void CreateFuncList()
        {
            foreach(var dic in m_FileInfo.m_funcList)
            {
                funcList.Items.Add(dic.ToString());
            }
        }

        private void ClearParamTypeList()
        {
            paramType.Items.Clear();
        }

        private void CreateTree()
        {
            var RootNode = new TreeNode("root");
            foreach (var dic in m_FileInfo.m_hurdle)
            {
                TreeNode nodeHurdle = new TreeNode(dic.Key.ToString());
                CreateHurdleTree(nodeHurdle, dic.Key);
                RootNode.Nodes.Add(nodeHurdle);
            }
            SceneTree.Nodes.Add(RootNode);
        }

        private void CreateHurdleTree(TreeNode node, int hurdle_id)
        {
            var hurdleList = m_FileInfo.m_hurdle[hurdle_id];
            foreach (var hurdle in hurdleList)
            {
                TreeNode nodeSceneplay = new TreeNode(hurdle.SceneplayID.ToString());
                CreateSceneplayTree(nodeSceneplay, hurdle.SceneplayID);
                node.Nodes.Add(nodeSceneplay);
            }
        }

        private void CreateSceneplayTree(TreeNode node, int sceneplay_id)
        {
            if (m_FileInfo.m_play.ContainsKey(sceneplay_id))
            {
                foreach (var func in m_FileInfo.m_play[sceneplay_id])
                {
                    if (func.ActType == "func")
                    {
                        var obj = func.ActInfo;
                        TreeNode nodeFuncName = new TreeNode(obj.Name.ToString());
                        node.Nodes.Add(nodeFuncName);
                    }
                    else if (func.ActType == "talk")
                    {
                        node.Nodes.Add(new TreeNode("talk"));
                    }
                }
            }
        }

        private void CreateParamTypeList()
        {
            ClearParamTypeList();
            if (!m_FileInfo.m_funcCfgList.ContainsKey(m_curFuncName))
                return;
            foreach (var type in m_FileInfo.m_funcCfgList[m_curFuncName].GetParamList())
            {
                paramType.Items.Add(type.ToString());
            }
            labFuncRemarks.Text = m_FileInfo.m_funcCfgList[m_curFuncName].Describe;
        }

        private void SetParam(string p)
        {
            if (!m_FileInfo.m_play.ContainsKey(m_curSceneplayId))
                return;
            var curTreeNode = SceneTree.SelectedNode;
            var act = m_FileInfo.m_play[m_curSceneplayId];
            if (act.Count <= curTreeNode.Index)
                return;
            var funcList = act[curTreeNode.Index];
            if (funcList.ActType == "func")
            {
                var func = funcList.ActInfo;
                if (func.GetParamValue(p) != null)
                    param.Text = func.GetParamValue(p);
                else
                    param.Text = "";
            }
            else if (funcList.ActType == "talk")
            {
                var func = funcList.ActTalk;
                param.Text = func.ToString();
            }
            else
                param.Text = "";
            remarks.Text = "";
            if(!m_FileInfo.m_funcCfgList.ContainsKey(m_curFuncName))
                return;
            var funcDes = m_FileInfo.m_funcCfgList[m_curFuncName].GetParamInfo(p);
            if (funcDes == null)
                return;
            remarks.Text = funcDes.Describe;
        }

        private void SelectFunc()
        {
            int id = funcList.Items.IndexOf(m_curFuncName);
            funcList.SelectedIndex = id;
            CreateParamTypeList();

            actor.Items.Clear();
            var curTreeNode = SceneTree.SelectedNode;
            if (m_FileInfo.m_play.ContainsKey(m_curSceneplayId))
            {
                var sceneplay = m_FileInfo.m_play[m_curSceneplayId];
                if (sceneplay.Count > curTreeNode.Index)
                {
                    var sceneplayInfo = sceneplay[curTreeNode.Index];
                    audioId.Text = sceneplayInfo.Audio.ToString();
                    headIconPath.Text = sceneplayInfo.IconPath.ToString();
                    switch (sceneplayInfo.Pos)
                    {
                        case 0:
                            pos1.Checked = true;
                            pos2.Checked = false;
                            pos3.Checked = false;
                            break;
                        case 1:
                            pos1.Checked = false;
                            pos2.Checked = true;
                            pos3.Checked = false;
                            break;
                        case 2:
                            pos1.Checked = false;
                            pos2.Checked = false;
                            pos3.Checked = true;
                            break;
                        default:
                            pos1.Checked = false;
                            pos2.Checked = false;
                            pos3.Checked = false;
                            break;
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        switchList.SetSelected(i, sceneplayInfo.GetSwitch(i));
                    }
                    var hurdleInfo = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Parent.Index];
                    for (int i = 0; i < hurdleInfo.ObjList.Count; i++)
                    {
                        actor.Items.Add(hurdleInfo.ObjList[i]);
                    }
                    if (actor.Items.Count > sceneplayInfo.ActorID-1)
                        actor.SelectedIndex = sceneplayInfo.ActorID-1;
                    else
                        MessageBox.Show("你把登场角色列表里的角色删了，我找不到之前的角色了ψ(╰_╯)");
                    remarks.Text = sceneplayInfo.Describe;
                }
                else
                {
                    audioId.Text = "0";
                    headIconPath.Text = "";
                    pos1.Checked = false;
                    pos2.Checked = false;
                    pos3.Checked = false;
                    for (int i = 0; i < 5; i++)
                    {
                        switchList.SetSelected(i, false);
                    }
                    remarks.Text = "";
                }
            }
            else
            { 
                audioId.Text = "0";
                headIconPath.Text = "";
                pos1.Checked = false;
                pos2.Checked = false;
                pos3.Checked = false;
                for (int i = 0; i < 5; i++)
                {
                    switchList.SetSelected(i, false);
                }
                remarks.Text = "";
            }

            param.Text = "";
            labFuncRemarks.Text = "";
            if (!m_FileInfo.m_funcCfgList.ContainsKey(m_curFuncName))
                return;
            labFuncRemarks.Text = m_FileInfo.m_funcCfgList[m_curFuncName].Describe;
        }

        private void SelectSceneplay()
        {
            actorList.Items.Clear();
            var curTreeNode = SceneTree.SelectedNode;
            if (m_FileInfo.m_hurdle.ContainsKey(m_curHurdleId))
            {
                if (m_FileInfo.m_hurdle[m_curHurdleId].Count > curTreeNode.Index)
                { 
                    var sceneplay = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].ObjList;
                    for (int i = 0; i < sceneplay.Count; i++)
                    {
                        actorList.Items.Add(sceneplay[i]);
                    }
                    var TriggerList = m_FileInfo.m_hurdle[m_curHurdleId];
                    if (TriggerList.Count > curTreeNode.Index)
                        labTriggerID.Text = TriggerList[curTreeNode.Index].TriggerID.ToString();
                    remarks.Text = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].Describe;
                }
            }

        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_FileInfo.WriteConfigFile(m_FileInfo.GetPath() + "screenplay_config.txt");
            m_FileInfo.WriteContentFile(m_FileInfo.GetPath() + "screenplay_content.txt");
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            string nodeName = SceneTree.SelectedNode.Text;
            labNodeName.Text = nodeName;
            string fullPath = SceneTree.SelectedNode.FullPath;
            string[] nodeParent = fullPath.Split('.');
            if (nodeParent.Length == 4)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                groupFuncRemarks.Visible = true;
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = nodeParent[3];
                labReference.Text = m_FileInfo.GetReferenceListStr(m_curSceneplayId);
                SelectFunc();
            }
            else if(nodeParent.Length == 3)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[2]);
                m_curFuncName = "";
                groupFuncRemarks.Visible = false;
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = true;
                SelectSceneplay();
                labReference.Text = m_FileInfo.GetReferenceListStr(m_curSceneplayId);
            }
            else if (nodeParent.Length == 2)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[1]);
                m_curSceneplayId = -1;
                m_curFuncName = "";
                groupFuncRemarks.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                labReference.Text = "";
                remarks.Text = "";
            }
            else
            { 
                groupFuncRemarks.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                remarks.Text = "";
                labReference.Text = "";
            }
        }

        private void paramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paramType.SelectedItem == null)
                return;
            SetParam(paramType.SelectedItem.ToString());
        }

        private void funcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (funcList.SelectedItem == null)
                return;
            m_curFuncName = funcList.SelectedItem.ToString();
            var curTreeNode = SceneTree.SelectedNode;
            curTreeNode.Text = m_curFuncName;
            CreateParamTypeList();
            var sceneplay = m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index];
            if (sceneplay.ActType == "func")
            {
                var Info = sceneplay.ActInfo;
                if (Info.Name == m_curFuncName)
                    return;
            }
            else if (sceneplay.ActType == "talk")
            {
                if (sceneplay.ActType == m_curFuncName)
                    return;
            }
            if (m_curFuncName == "talk")
            {
                sceneplay.ActTalk = "gs_screenplay.";
                sceneplay.ActType = m_curFuncName;
            }
            else
            {
                var funcCfg = m_FileInfo.m_funcCfgList[m_curFuncName];
                sceneplay.ActType = "func";
                var funcInfo = new FuncInfo(m_curFuncName, funcCfg);
                sceneplay.ActInfo = funcInfo;
            }
            //m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index] = sceneplay;
        }

        private void labNodeName_Leave(object sender, EventArgs e)
        {
            var newName = labNodeName.Text;
            int id;
            bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("节点名字必须为数字(＞﹏＜)");
                return;
            }

            var curTreeNode = SceneTree.SelectedNode;
            var list = curTreeNode.FullPath.Split('.');
            switch (list.Length)
            { 
                case 2:
                    if (id == m_curHurdleId)
                        return;
                    if (m_FileInfo.ChangeHurdleid(m_curHurdleId, id))
                    {
                        m_curHurdleId = id;
                        curTreeNode.Text = newName;
                    }
                    break;
                case 3:
                    if (id == m_curSceneplayId)
                        return;
                    if (m_FileInfo.m_play.ContainsKey(id))
                    {
                        var ret = MessageBox.Show("是否重置节点?●﹏●", "id已存在", MessageBoxButtons.YesNo);
                        if (ret == DialogResult.No)
                            return;
                        curTreeNode.Nodes.Clear();
                        CreateSceneplayTree(curTreeNode, id);
                    }
                    else
                    {
                        if (m_FileInfo.m_play2flg[m_curSceneplayId] >= 2)
                        {
                            var ret = MessageBox.Show("是否复制~>_<~","该id被多个地方引用了",MessageBoxButtons.YesNo);
                            switch (ret)
                            { 
                                case DialogResult.Yes:
                                    break;
                                case DialogResult.No:
                                    return;
                            }
                        }
                        m_FileInfo.ChangePlayid1(m_curSceneplayId, id);
                    }
                    m_FileInfo.ChangePlayid2(m_curSceneplayId, m_curHurdleId, curTreeNode.Index, id);

                    m_curSceneplayId = id;
                    labReference.Text = m_FileInfo.GetReferenceListStr(m_curSceneplayId);
                    curTreeNode.Text = newName;
                    break;
                default:
                    return;
            }
        }

        private void actorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnActorAdd.Text = "-";
        }

        private void labActorAdd_TextChanged(object sender, EventArgs e)
        {
            btnActorAdd.Text = "+";
        }

        private void btnActorAdd_Click(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            var objList = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].ObjList;
            if(btnActorAdd.Text == "-")
            {
                if (actorList.SelectedItem == null)
                    return;
                objList.Remove(actorList.SelectedItem.ToString());
                actorList.Items.Remove(actorList.SelectedItem);
            }
            else if(btnActorAdd.Text == "+")
            {
                var actor = labActorAdd.Text;
                if (actor == "")
                    return;
                if(objList.IndexOf(actor)==-1)
                {
                    objList.Add(actor);
                    actorList.Items.Add(actor);
                    labActorAdd.Text = "";
                }
                else
                {
                    MessageBox.Show("该角色已经添加╮(╯▽╰')╭");
                }
            }
        }

        private void labTriggerID_TextChanged(object sender, EventArgs e)
        {
            var newName = labTriggerID.Text;
            int id;
            bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
            var curTreeNode = SceneTree.SelectedNode;
            if (!result)
            {
                MessageBox.Show("触发器id必须为数字(￣︶￣)↗");
                labTriggerID.Text = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].TriggerID.ToString();
                return;
            }
            m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].TriggerID = id;
        }

        private void remarks_TextChanged(object sender, EventArgs e)
        {
            if (paramType.SelectedItem != null)
                return;
            var curTreeNode = SceneTree.SelectedNode;
            if(m_curFuncName !="")
            {
                m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Describe = remarks.Text;
            }
            else if(m_curSceneplayId != -1)
            {
                m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Index].Describe = remarks.Text;
            }
        }

        private void headIconPath_TextChanged(object sender, EventArgs e)
        {
            if (m_curFuncName == "")
                return;
            var curTreeNode = SceneTree.SelectedNode;
            m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].IconPath = headIconPath.Text;
        }

        private void audioId_TextChanged(object sender, EventArgs e)
        {
            if (m_curFuncName == "")
                return;
            var newId = audioId.Text;
            int id;
            var curTreeNode = SceneTree.SelectedNode;
            bool result = Int32.TryParse(newId, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("audio id什么时候可以用非数字了？？！！<(‵^′)>");
                audioId.Text = m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Audio.ToString();
                return;
            }
            m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Audio = id;
        }

        private void pos_CheckedChanged(object sender, EventArgs e)
        {
            var curTreeNode = SceneTree.SelectedNode;
            if (pos1.Checked)
                m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Pos = 0;
            if (pos2.Checked)
                m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Pos = 1;
            if (pos3.Checked)
                m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].Pos = 2;
        }

        private void actor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actor.SelectedItem == null)
                return;
            var name = actor.SelectedItem.ToString();
            var curTreeNode = SceneTree.SelectedNode;
            var actorList = m_FileInfo.m_hurdle[m_curHurdleId][curTreeNode.Parent.Index].ObjList;
            var index = actorList.IndexOf(name);
            m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].ActorID = index+1;
        }

        private void switchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = switchList.SelectedIndex;
            if (i < 0)
                return;
            var curTreeNode = SceneTree.SelectedNode;
            m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index].SetSwitch(i, switchList.GetItemChecked(i));
        }

        private void param_TextChanged(object sender, EventArgs e)
        {
            if (paramType.SelectedItem == null)
                return;
            var curTreeNode = SceneTree.SelectedNode;
            var obj = m_FileInfo.m_play[m_curSceneplayId][curTreeNode.Index];
            if(obj.ActType == "func")
            {
                var funcInfo = obj.ActInfo;
                var paramName = paramType.SelectedItem.ToString();
                funcInfo.ChangeParam(paramName, param.Text);
            }
            else if (obj.ActType == "talk")
            {
                obj.ActTalk = param.Text;
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
                    var funcName = "talk";
                    m_FileInfo.CreateFunc(m_curSceneplayId, funcName);
                    curTreeNode.Nodes.Add(funcName);
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
                    var list = m_FileInfo.m_play[m_curSceneplayId];
                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (i == curTreeNode.Index)
                        {
                            m_FileInfo.DeleteFunc(m_curSceneplayId, i);
                            break;
                        }
                    }
                    break;
                default:
                    MessageBox.Show("别乱删结点啊喂！！(╯‵□′)╯︵┴─┴");
                    break;
            }
            curTreeNode.Remove();
            groupFuncRemarks.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
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
                            CreateSceneplayTree(nodeSceneplay, hurdle.SceneplayID);
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
                            TreeNode node = null;
                            if (func.ActType == "func")
                            {
                                var obj = func.ActInfo;
                                node = new TreeNode(obj.Name.ToString());
                                parentNode.Nodes.Add(node);
                            }
                            else if (func.ActType == "talk")
                            {
                                node = new TreeNode("talk");
                                parentNode.Nodes.Add(node);
                            }
                            if (func == curNode && node != null)
                                SceneTree.SelectedNode = node;
                        }
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
                            CreateSceneplayTree(nodeSceneplay, hurdle.SceneplayID);
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
                            TreeNode node = null;
                            if (func.ActType == "func")
                            {
                                var obj = func.ActInfo;
                                node = new TreeNode(obj.Name.ToString());
                                parentNode.Nodes.Add(node);
                            }
                            else if (func.ActType == "talk")
                            {
                                node = new TreeNode("talk");
                                parentNode.Nodes.Add(node);
                            }
                            if (func == curNode && node != null)
                                SceneTree.SelectedNode = node;
                        }
                    }
                    break;
            }
        }

    }
}
