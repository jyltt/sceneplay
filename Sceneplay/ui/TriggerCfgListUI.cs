using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.ui
{
    public partial class TriggerCfgListUI : Form
    {
        class indexAndTriggerID
        {
            public int TriggerID{get;set;}
            public int Index { get; set; }
            public indexAndTriggerID(int id,int i)
            {
                TriggerID = id;
                Index = i;
            }
        }
        string m_curLab="";
        TreeNode m_RootNode;
        public TriggerCfgListUI()
        {
            InitializeComponent();
            m_RootNode = new TreeNode("root");
            m_listTrigger.Nodes.Add(m_RootNode);
            m_RootNode.Expand();
            CreateTriggerList();
        }

        void CreateTriggerList()
        {
            var list = FileManager.TriggerCfgMgr.GetAllList();
            foreach(var id in list)
            {
                var node = new TreeNode(id.ToString());
                node.Tag = id;
                m_RootNode.Nodes.Add(node);
                CreateTriggerInfoList(id, node);
            }
        }

        void CreateTriggerInfoList(int trigger_id, TreeNode parent_node)
        {
            var _infoListCount = FileManager.TriggerCfgMgr.GetTriggerList(trigger_id);
            for(int i=0;i<_infoListCount;++i)
            {
                var node = new TreeNode(i.ToString());
                node.Tag = new indexAndTriggerID(trigger_id, i);
                parent_node.Nodes.Add(node);
            }
        }

        void UpdateTriggerIDUI(int trigger_id)
        {
            m_labID.Text = trigger_id.ToString();
        }

        void UpdateTriggerInfoUI(int trigger_id, int index)
        {
        }

        private void m_listTrigger_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var curNode = m_listTrigger.SelectedNode;
            string fullPath = curNode.FullPath;
            string[] nodeParent = fullPath.Split('\\');
            int triggerid;
            int index;
            switch(nodeParent.Length)
            {
                case 1:
                    m_panel.Visible = false;
                    m_groupID.Visible = false;
                    break;
                case 2:
                    m_panel.Visible = false;
                    m_groupID.Visible = true;
                    triggerid = (int)curNode.Tag;
                    UpdateTriggerIDUI(triggerid);
                    break;
                case 3:
                    m_panel.Visible = true;
                    m_labID.Visible = true;
                    var info = (indexAndTriggerID)curNode.Tag;
                    triggerid = info.TriggerID;
                    index = info.Index;
                    UpdateTriggerIDUI(triggerid);
                    UpdateTriggerInfoUI(triggerid, index);
                    break;
            }
        }

        private void m_labRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labSelectRemark_TextChanged(object sender, EventArgs e)
        {
            FileManager.TriggerCfgMgr.ChangeTriggerRemark(m_curLab, m_labSelectRemark.Text);
        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labEffect_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labCamp_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labType_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labID_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labID_Enter(object sender, EventArgs e)
        {
            m_curLab = "id";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labCount_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_count";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labType_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_type";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labCamp_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_camp";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labEffect_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_effect";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labRole_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_role";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labParam_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_param";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }
    }
}
