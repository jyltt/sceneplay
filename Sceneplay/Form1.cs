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
        TreeNode m_curNode;
        ReadFile m_FileInfo = new ReadFile();
        int m_curHurdleId = -1;
        int m_curSceneplayId = -1;
        string m_curFuncName = "";

        public Form1()
        {
            InitializeComponent();
            CreateTree();
            CreateFuncList();
        }

        private void CreateFuncList()
        {
            funcList.Items.Add("chat");
            foreach(var dic in m_FileInfo.m_func2param)
            {
                funcList.Items.Add(dic.Key.ToString());
            }
        }

        private void ClearParamTypeList()
        {
            paramType.Items.Clear();
        }

        private void CreateTree()
        {
            foreach (var dic in m_FileInfo.m_hurdle2play)
            {
                TreeNode nodeHurdle = new TreeNode(dic.Key.ToString());
                foreach(var sceneplay_id in dic.Value)
                {
                    TreeNode nodeSceneplay = new TreeNode(sceneplay_id.ToString());
                    if (m_FileInfo.m_play2act.ContainsKey(sceneplay_id))
                    {
                        foreach (var func in m_FileInfo.m_play2act[sceneplay_id])
                        {
                            if (func.ContainsKey("func"))
                            {
                                var obj = (KeyValuePair<string,Dictionary<string,string>>)func["func"];
                                TreeNode nodeFuncName = new TreeNode(obj.Key.ToString());
                                nodeSceneplay.Nodes.Add(nodeFuncName);
                            }
                        }
                    }
                    //nodeSceneplay.Nodes.Add(new TreeNode("+"));
                    nodeHurdle.Nodes.Add(nodeSceneplay);
                }
                //nodeHurdle.Nodes.Add(new TreeNode("+"));
                SceneTree.Nodes.Add(nodeHurdle);
            }
            //SceneTree.Nodes.Add(new TreeNode("+"));
        }

        private void CreateParamTypeList(int hurdleId, int sceneplayId, string funcName, int index)
        {
            ClearParamTypeList();
            if (!m_FileInfo.m_func2param.ContainsKey(funcName))
                return;
            foreach (var type in m_FileInfo.m_func2param[funcName])
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = type.Key.ToString();
                var value = new List<string>();
                value.Add(hurdleId.ToString());
                value.Add(sceneplayId.ToString());
                value.Add(funcName);
                value.Add((index+1).ToString());
                item.Value = value;
                paramType.Items.Add(item);
            }
        }

        private void SetParam(string funcName, string p)
        {
            //param.Text = m_FileInfo.[funcName][p];
        }

        private void SelectFunc(int hurdleId, int sceneplayId, string funcName, int index)
        {
            int id = funcList.Items.IndexOf(funcName);
            funcList.SelectedIndex = id;
            CreateParamTypeList(hurdleId, sceneplayId, funcName, index);
        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            m_curNode = e.Node;
            string nodeName = e.Node.Text;
            string fullPath = e.Node.FullPath;
            string[] nodeParent = fullPath.Split('.');
            if (nodeParent.Length == 3)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                m_curHurdleId = System.Int32.Parse(nodeParent[0]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[1]);
                m_curFuncName = nodeParent[2];
                SelectFunc(m_curHurdleId, m_curSceneplayId, m_curFuncName, m_curNode.Index);
            }
            else if(nodeParent.Length == 2)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[0]);
                m_curSceneplayId = System.Int32.Parse(nodeParent[1]);
                m_curFuncName = "";
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = true;
            }
            else if(nodeParent.Length == 1)
            {
                m_curHurdleId = System.Int32.Parse(nodeParent[0]);
                m_curSceneplayId = -1;
                m_curFuncName = "";
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {

        }

        private void paramType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (ComboBoxItem)paramType.SelectedItem;
            var funcInfo = (List<string>)item.Value;
            var sceneplayId = funcInfo[0];
            var funcName = funcInfo[1];
            var funcIndex = funcInfo[2];
            SetParam(sceneplayId+funcName + funcIndex, item.Text);
        }

        private void funcList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nodeName = funcList.SelectedItem.ToString();
            CreateParamTypeList(m_curHurdleId, m_curSceneplayId, nodeName, m_curNode.Index);
        }
    }
}
