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
        // 配置文件信息
        //Dictionary<int, List<int>> m_FileInfo = new Dictionary<int, List<int>>(); // hurdleid sceneplayid
        //Dictionary<int, List<string>> m_SceneplayInfo = new Dictionary<int, List<string>>(); // sceneplayid funcname
        //Dictionary<string, Dictionary<string, string>> m_FuncInfo = new Dictionary<string, Dictionary<string, string>>();//sceneplayid+funcname+index list<type, value>
        // 相应函数信息
        Dictionary<string, List<string>> m_FuncCfg = new Dictionary<string, List<string>>();// funcname paramList

        // 
        TreeNode m_curNode;
        ReadFile m_FileInfo = new ReadFile();

        public Form1()
        {
            InitializeComponent();
            ReadFuncListFile();
            CreateTree();
            CreateFuncList();
        }

        private void ReadFuncListFile()
        {
            var list = new List<string>();
            list.Add("param1");
            list.Add("param2");
            m_FuncCfg.Add("play", list);
            var list1 = new List<string>();
            list1.Add("p1");
            list1.Add("p2");
            m_FuncCfg.Add("play2", list1);
        }

        private void CreateFuncList()
        {
            funcList.Items.Add("chat");
            foreach(var dic in m_FuncCfg)
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
                                var obj = (Dictionary<string,Dictionary<string,string>>)func["func"];
                                foreach (var info in obj)
                                {
                                    TreeNode nodeFuncName = new TreeNode(info.Key.ToString());
                                    nodeSceneplay.Nodes.Add(nodeFuncName);
                                }
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

        private void CreateParamTypeList(int sceneplayId, string funcName, int index)
        {
            ClearParamTypeList();
            if (!m_FuncCfg.ContainsKey(funcName))
                return;
            foreach (var type in m_FuncCfg[funcName])
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = type;
                var value = new List<string>();
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
            CreateParamTypeList(sceneplayId, funcName, index);
        }

        //////////////////////////回调函数/////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void SceneTreeClickItem(object sender, TreeViewEventArgs e)
        {
            m_curNode = e.Node;
            var index = e.Node.Index;
            string nodeName = e.Node.Text;
            string fullPath = e.Node.FullPath;
            string[] nodeParent = fullPath.Split('.');
            if (nodeParent.Length == 3)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                int hurdleId = System.Int32.Parse(nodeParent[0]);
                int sceneplayId = System.Int32.Parse(nodeParent[1]);
                string funcName = nodeParent[2];
                SelectFunc(hurdleId, sceneplayId, funcName, index);
            }
            else if(nodeParent.Length == 2)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = true;
            }
            else if(nodeParent.Length == 1)
            {
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
    }
}
