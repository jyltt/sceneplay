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
    public partial class Form1 : Form
    {
        TreeNode m_curTreeNode;
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
            foreach (var dic in m_FileInfo.m_hurdle2play)
            {
                TreeNode nodeHurdle = new TreeNode(dic.Key.ToString());
                foreach(var sceneplay_id in dic.Value)
                {
                    TreeNode nodeSceneplay = new TreeNode(sceneplay_id.ToString());
                    CreateSceneplayTree(nodeSceneplay, sceneplay_id);
                    nodeHurdle.Nodes.Add(nodeSceneplay);
                }
                RootNode.Nodes.Add(nodeHurdle);
            }
            SceneTree.Nodes.Add(RootNode);
        }

        private void CreateSceneplayTree(TreeNode node, int sceneplay_id)
        {
            if (m_FileInfo.m_play2act.ContainsKey(sceneplay_id))
            {
                foreach (var func in m_FileInfo.m_play2act[sceneplay_id])
                {
                    if (func.Key == "func")
                    {
                        var obj = (KeyValue<string, Dictionary<string, string>>)func.Value;
                        TreeNode nodeFuncName = new TreeNode(obj.Key.ToString());
                        node.Nodes.Add(nodeFuncName);
                    }
                    else if (func.Key == "talk")
                    {
                        node.Nodes.Add(new TreeNode("talk"));
                    }
                }
            }
        }

        private void CreateParamTypeList()
        {
            ClearParamTypeList();
            if (!m_FileInfo.m_func2param.ContainsKey(m_curFuncName))
                return;
            foreach (var type in m_FileInfo.m_func2param[m_curFuncName])
            {
                paramType.Items.Add(type.Key.ToString());
            }
            if (!m_FileInfo.m_func2des.ContainsKey(m_curFuncName))
                return;
            labFuncRemarks.Text = m_FileInfo.m_func2des[m_curFuncName];
        }

        private void SetParam(string p)
        {
            if (!m_FileInfo.m_play2act.ContainsKey(m_curSceneplayId))
                return;
            var act = m_FileInfo.m_play2act[m_curSceneplayId];
            if (act.Count <= m_curTreeNode.Index)
                return;
            var funcList = act[m_curTreeNode.Index];
            if (funcList.Key == "func")
            {
                var func = (KeyValue<string,Dictionary<string,string>>)funcList.Value;
                var paramList = func.Value;
                if (paramList.ContainsKey(p))
                    param.Text = paramList[p];
                else
                    param.Text = "";
            }
            else if (funcList.Key == "talk")
            {
                var func = funcList.Value;
                param.Text = func.ToString();
            }
            else
                param.Text = "";
            remarks.Text = "";
            if(!m_FileInfo.m_func2des.ContainsKey(m_curFuncName))
                return;
            var funcDesList = m_FileInfo.m_func2param[m_curFuncName];
            if (!funcDesList.ContainsKey(p))
                return;
            remarks.Text = funcDesList[p];
        }

        private void SelectFunc()
        {
            int id = funcList.Items.IndexOf(m_curFuncName);
            funcList.SelectedIndex = id;
            CreateParamTypeList();

            if (m_FileInfo.m_play2audio.ContainsKey(m_curSceneplayId))
                if (m_FileInfo.m_play2audio[m_curSceneplayId].Count > m_curTreeNode.Index)
                    audioId.Text = m_FileInfo.m_play2audio[m_curSceneplayId][m_curTreeNode.Index].ToString();
                else
                    audioId.Text = "0";
            else
                audioId.Text = "0";

            if (m_FileInfo.m_play2Icon.ContainsKey(m_curSceneplayId))
                if (m_FileInfo.m_play2Icon[m_curSceneplayId].Count > m_curTreeNode.Index)
                    headIconPath.Text = m_FileInfo.m_play2Icon[m_curSceneplayId][m_curTreeNode.Index].ToString();
                else
                    headIconPath.Text = "";
            else
                headIconPath.Text = "";

            if (m_FileInfo.m_play2pos.ContainsKey(m_curSceneplayId))
            {
                if (m_FileInfo.m_play2pos[m_curSceneplayId].Count > m_curTreeNode.Index)
                    switch (m_FileInfo.m_play2pos[m_curSceneplayId][m_curTreeNode.Index])
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
                else
                {
                    pos1.Checked = false;
                    pos2.Checked = false;
                    pos3.Checked = false;
                }
            }
            
            var flg = m_FileInfo.m_play2switch.ContainsKey(m_curSceneplayId);
            for(int i=0;i<5;i++)
            {
                if (flg && m_FileInfo.m_play2switch[m_curSceneplayId].Count > m_curTreeNode.Index)
                    switchList.SetSelected(i, m_FileInfo.m_play2switch[m_curSceneplayId][m_curTreeNode.Index][i]);
                else
                    switchList.SetSelected(i, false);
            }

            actor.Items.Clear();
            if (m_FileInfo.m_hurdle2Obj.ContainsKey(m_curHurdleId))
            {
                if (m_FileInfo.m_hurdle2Obj[m_curHurdleId].Count > m_curTreeNode.Parent.Index)
                { 
                    var sceneplay = m_FileInfo.m_hurdle2Obj[m_curHurdleId][m_curTreeNode.Parent.Index];
                    for (int i = 0; i < sceneplay.Count; i++)
                    {
                        actor.Items.Add(sceneplay[i]);
                    }
                }
            }
            if(m_FileInfo.m_play2actor.ContainsKey(m_curSceneplayId))
            {
                var actorList = m_FileInfo.m_play2actor[m_curSceneplayId];
                if (actorList.Count > m_curTreeNode.Index)
                { 
                    if (actor.Items.Count > actorList[m_curTreeNode.Index]-1)
                        actor.SelectedIndex = actorList[m_curTreeNode.Index]-1;
                    else
                        MessageBox.Show("你把登场角色列表里的角色删了，我找不到之前的角色了ψ(╰_╯)");
                }
            }

            param.Text = "";
            if(m_FileInfo.m_play2Des.ContainsKey(m_curSceneplayId))
            {
                var desList = m_FileInfo.m_play2Des[m_curSceneplayId];
                if(desList.Count > m_curTreeNode.Index)
                    remarks.Text = desList[m_curTreeNode.Index];
            }
            labFuncRemarks.Text = "";
            if (!m_FileInfo.m_func2des.ContainsKey(m_curFuncName))
                return;
            labFuncRemarks.Text = m_FileInfo.m_func2des[m_curFuncName];
        }

        private void SelectSceneplay()
        {
            actorList.Items.Clear();
            if (m_FileInfo.m_hurdle2Obj.ContainsKey(m_curHurdleId))
            {
                if (m_FileInfo.m_hurdle2Obj[m_curHurdleId].Count > m_curTreeNode.Index)
                { 
                    var sceneplay = m_FileInfo.m_hurdle2Obj[m_curHurdleId][m_curTreeNode.Index];
                    for (int i = 0; i < sceneplay.Count; i++)
                    {
                        actorList.Items.Add(sceneplay[i]);
                    }
                }
            }

            if(m_FileInfo.m_hurdle2Trigger.ContainsKey(m_curHurdleId))
            {
                var TriggerList = m_FileInfo.m_hurdle2Trigger[m_curHurdleId];
                if (TriggerList.Count > m_curTreeNode.Index)
                    labTriggerID.Text = TriggerList[m_curTreeNode.Index].ToString();
            }

            remarks.Text = m_FileInfo.m_hurdle2des[m_curHurdleId][m_curTreeNode.Index];
        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_FileInfo.WriteConfigFile(m_FileInfo.GetPath() + "screenplay_config.txt");
            m_FileInfo.WriteContentFile(m_FileInfo.GetPath() + "screenplay_content.txt");
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            m_curTreeNode = SceneTree.SelectedNode;
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
                remarks.Text = "";
            }
            else
            { 
                groupFuncRemarks.Visible = false;
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                remarks.Text = "";
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
            m_curTreeNode.Text = m_curFuncName;
            CreateParamTypeList();
            var obj = m_FileInfo.m_play2act[m_curSceneplayId][m_curTreeNode.Index];
            if (obj.Key == m_curFuncName)
            {
                return;
            }
            else
            {
                if (obj.Key == "func")
                {
                    var oldFuncInfo = (KeyValue<string, Dictionary<string, string>>)obj.Value;
                    if (oldFuncInfo.Key == m_curFuncName)
                        return;
                }
            }
            if (m_curFuncName == "talk")
            {
                obj.Value = "gs_screenplay.";
                obj.Key = m_curFuncName;
            }
            else
            {
                var funcCfg = m_FileInfo.m_func2param[m_curFuncName];
                obj.Key = "func";
                var funcInfo = new KeyValue<string, Dictionary<string, string>>();
                funcInfo.Key = m_curFuncName;
                var paramList = new Dictionary<string,string>();
                foreach (var paramType in funcCfg.Keys)
                {
                    paramList[paramType] = "0";
                }
                funcInfo.Value = paramList;
                obj.Value = funcInfo;
            }
            m_FileInfo.m_play2act[m_curSceneplayId][m_curTreeNode.Index] = obj;
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

            var list = m_curTreeNode.FullPath.Split('.');
            switch (list.Length)
            { 
                case 2:
                    if (id == m_curHurdleId)
                        return;
                    if (m_FileInfo.ChangeHurdleid(m_curHurdleId, id))
                    {
                        m_curHurdleId = id;
                        m_curTreeNode.Text = newName;
                    }
                    break;
                case 3:
                    if (id == m_curSceneplayId)
                        return;
                    if (m_FileInfo.m_play2act.ContainsKey(id)
                    || m_FileInfo.m_play2actor.ContainsKey(id)
                    || m_FileInfo.m_play2audio.ContainsKey(id)
                    || m_FileInfo.m_play2Des.ContainsKey(id)
                    || m_FileInfo.m_play2Icon.ContainsKey(id)
                    || m_FileInfo.m_play2pos.ContainsKey(id)
                    || m_FileInfo.m_play2switch.ContainsKey(id))
                    {
                        var ret = MessageBox.Show("是否重置节点?●﹏●", "id已存在", MessageBoxButtons.YesNo);
                        if (ret == DialogResult.No)
                            return;
                        m_curTreeNode.Nodes.Clear();
                        CreateSceneplayTree(m_curTreeNode, id);
                    }
                    else
                    {
                        if (m_FileInfo.m_play2flg[m_curSceneplayId] >= 2)
                        {
                            var ret = MessageBox.Show("是否复制，若要复制，请保存后重启~>_<~","该id被多个地方引用了",MessageBoxButtons.YesNo);
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
                    m_FileInfo.ChangePlayid2(m_curSceneplayId, m_curHurdleId, m_curTreeNode.Index, id);

                    m_curSceneplayId = id;
                    m_curTreeNode.Text = newName;
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
            var objList = m_FileInfo.m_hurdle2Obj[m_curHurdleId][m_curTreeNode.Index];
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
            if (!result)
            {
                MessageBox.Show("触发器id必须为数字(￣︶￣)↗");
                labTriggerID.Text = m_FileInfo.m_hurdle2Trigger[m_curHurdleId][m_curTreeNode.Index].ToString();
                return;
            }
            m_FileInfo.m_hurdle2Trigger[m_curHurdleId][m_curTreeNode.Index] = id;
        }

        private void remarks_TextChanged(object sender, EventArgs e)
        {
            if (paramType.SelectedItem != null)
                return;
            if(m_curFuncName !="")
            {
                m_FileInfo.m_play2Des[m_curSceneplayId][m_curTreeNode.Index] = remarks.Text;
            }
            else if(m_curSceneplayId != -1)
            {
                m_FileInfo.m_hurdle2des[m_curHurdleId][m_curTreeNode.Index] = remarks.Text;
            }
        }

        private void headIconPath_TextChanged(object sender, EventArgs e)
        {
            if (m_curFuncName == "")
                return;
            m_FileInfo.m_play2Icon[m_curSceneplayId][m_curTreeNode.Index] = headIconPath.Text;
        }

        private void audioId_TextChanged(object sender, EventArgs e)
        {
            if (m_curFuncName == "")
                return;
            var newId = audioId.Text;
            int id;
            bool result = Int32.TryParse(newId, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("audio id什么时候可以用非数字了？？！！<(‵^′)>");
                audioId.Text = m_FileInfo.m_play2audio[m_curSceneplayId][m_curTreeNode.Index].ToString();
                return;
            }
            m_FileInfo.m_play2audio[m_curSceneplayId][m_curTreeNode.Index] = id;
        }

        private void pos_CheckedChanged(object sender, EventArgs e)
        {
            if (pos1.Checked)
                m_FileInfo.m_play2pos[m_curSceneplayId][m_curTreeNode.Index] = 0;
            if (pos2.Checked)
                m_FileInfo.m_play2pos[m_curSceneplayId][m_curTreeNode.Index] = 1;
            if (pos3.Checked)
                m_FileInfo.m_play2pos[m_curSceneplayId][m_curTreeNode.Index] = 2;
        }

        private void actor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actor.SelectedItem == null)
                return;
            var name = actor.SelectedItem.ToString();
            var actorList = m_FileInfo.m_hurdle2Obj[m_curHurdleId][m_curTreeNode.Parent.Index];
            var index = actorList.IndexOf(name);
            m_FileInfo.m_play2actor[m_curSceneplayId][m_curTreeNode.Index] = index+1;
        }

        private void switchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = switchList.SelectedIndex;
            if (i < 0)
                return;
            m_FileInfo.m_play2switch[m_curSceneplayId][m_curTreeNode.Index][i] = switchList.GetItemChecked(i);
        }

        private void param_TextChanged(object sender, EventArgs e)
        {
            if (paramType.SelectedItem == null)
                return;
            var obj = m_FileInfo.m_play2act[m_curSceneplayId][m_curTreeNode.Index];
            if(obj.Key == "func")
            {
                var funcInfo = (KeyValue<string, Dictionary<string, string>>)obj.Value;
                var paramList = funcInfo.Value;
                var paramName = paramType.SelectedItem.ToString();
                if (paramList.ContainsKey(paramName))
                {
                    paramList[paramName] = param.Text;
                }
            }
            else if (obj.Key == "talk")
            {
                obj.Value = param.Text;
            }
        }

        private void btnAddNode_Click(object sender, EventArgs e)
        {
            var nodeList = m_curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 1:
                    var name = 1;
                    m_FileInfo.CreateHurdle(name);
                    m_curTreeNode.Nodes.Add(name.ToString());
                    break;
                case 2:
                    var playsceneid = 1;
                    m_FileInfo.CreatePlayid(m_curHurdleId, playsceneid);
                    m_curTreeNode.Nodes.Add(playsceneid.ToString());
                    break;
                case 3:
                    var funcName = "talk";
                    m_FileInfo.CreateFunc(m_curSceneplayId, funcName);
                    m_curTreeNode.Nodes.Add(funcName);
                    break;
                default:
                    MessageBox.Show("该节点不能创建子节点(─.─|||)");
                    break;
            }
        }
        private void btnDelet_Click(object sender, EventArgs e)
        {
            var nodeList = m_curTreeNode.FullPath.Split('.');
            switch (nodeList.Length)
            { 
                case 2:
                    var nodeName = m_curTreeNode.Text;
                    int hurdle_id;
                    bool result = Int32.TryParse(nodeName, out hurdle_id); // return bool value hint y/n
                    if (!result)
                        return;
                    m_FileInfo.DeleteHurdle(hurdle_id);
                    break;
                case 3:
                    nodeName = m_curTreeNode.Text;
                    int sceneplay_id;
                    result = Int32.TryParse(nodeName, out sceneplay_id); // return bool value hint y/n
                    if (!result)
                        return;
                    m_FileInfo.RemovePlayid(sceneplay_id, m_curHurdleId, m_curTreeNode.Index);
                    break;
                case 4:
                    var list = m_FileInfo.m_play2act[m_curSceneplayId];
                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (i == m_curTreeNode.Index)
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
            m_curTreeNode.Remove();
            m_curTreeNode = null;
            groupFuncRemarks.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void SceneTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

    }
}
