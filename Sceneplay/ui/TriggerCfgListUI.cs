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
            m_RootNode.Nodes.Clear();
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
            parent_node.Nodes.Clear();
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
            m_labID.Tag = new indexAndTriggerID(trigger_id, -1);
        }

        void UpdateTriggerInfoUI(int trigger_id, int index)
        {
            var info = FileManager.TriggerCfgMgr.GetTriggerInfo(trigger_id, index);
            if (info == null)
                return;
            var param = new indexAndTriggerID(trigger_id, index);
            m_labCamp.Text = info.Camp.ToString();
            m_labCamp.Tag = param;
            m_labCount.Text = info.Count.ToString();
            m_labCount.Tag = param;
            m_labEffect.Text = info.Effect;
            m_labEffect.Tag = param;
            m_labParam.Text = info.Param;
            m_labParam.Tag = param;
            m_labRemark.Text = info.Remark;
            m_labRemark.Tag = param;
            m_labRole.Text = info.Role;
            m_labRole.Tag = param;
            m_labType.Text = info.Type.ToString();
            m_labType.Tag = param;
            m_labID.Tag = param;
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
                    m_groupID.Visible = true;
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
            var param = (indexAndTriggerID)m_labRemark.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            cfg.Remark = m_labRemark.Text;
        }

        private void m_labSelectRemark_TextChanged(object sender, EventArgs e)
        {
            FileManager.TriggerCfgMgr.ChangeTriggerRemark(m_curLab, m_labSelectRemark.Text);
        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labParam.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            cfg.Param = m_labParam.Text;

        }

        private void m_labRole_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labRole.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            cfg.Role = m_labRole.Text;

        }

        private void m_labEffect_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labEffect.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            cfg.Effect = m_labEffect.Text;

        }

        private void m_labCamp_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labCamp.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            int camp;
            bool result = Int32.TryParse(m_labCamp.Text, out camp);
            if (!result)
            {
                MessageBox.Show("此处应该是数字");
                m_labCamp.Text = cfg.Camp.ToString();
                return;
            }
            cfg.Camp = camp;
        }

        private void m_labType_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labType.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            int type;
            bool result = Int32.TryParse(m_labType.Text, out type);
            if (!result)
            {
                MessageBox.Show("此处应该是数字");
                m_labType.Text = cfg.Type.ToString();
                return;
            }
            cfg.Type = type;
        }

        private void m_labCount_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labCount.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            int count;
            bool result = Int32.TryParse(m_labCount.Text, out count);
            if (!result)
            {
                MessageBox.Show("此处应该是数字");
                m_labCount.Text = cfg.Count.ToString();
                return;
            }
            cfg.Count = count;
        }

        private void m_labID_TextChanged(object sender, EventArgs e)
        {
            var param = (indexAndTriggerID)m_labID.Tag;
            if (param == null)
                return;
            var cfg = FileManager.TriggerCfgMgr.GetTriggerInfo(param.TriggerID, param.Index);
            int id;
            bool result = Int32.TryParse(m_labID.Text, out id);
            if (!result)
            {
                MessageBox.Show("此处应该是数字");
                m_labID.Text = cfg.ID.ToString();
                return;
            }
            var vRet = FileManager.TriggerCfgMgr.ChangeTriggerID(param.Index, param.TriggerID, id);
            if(vRet)
            {
                m_labID.Text = id.ToString();
                if (param.Index >= 0)
                {
                    TreeNode newNode = null;
                    foreach (var obj in m_RootNode.Nodes)
                    {
                        var node = (TreeNode)obj;
                        if((int)node.Tag == id)
                        {
                            newNode = node;
                            break;
                        }
                    }
                    var changeNode = m_listTrigger.SelectedNode;
                    CreateTriggerInfoList(param.TriggerID, changeNode.Parent);
                    CreateTriggerInfoList(id, newNode);
                }
                else
                {
                    TreeNode newNode = null;
                    foreach (var obj in m_RootNode.Nodes)
                    {
                        var node = (TreeNode)obj;
                        var tag = (indexAndTriggerID)node.Tag;
                        if(tag.TriggerID == id)
                        {
                            newNode = node;
                            break;
                        }
                    }
                    CreateTriggerInfoList(param.TriggerID, newNode);
                    m_listTrigger.Nodes.Remove(m_listTrigger.SelectedNode);
                }
            }
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

        private void m_btnSure_Click(object sender, EventArgs e)
        {
            FileManager.TriggerCfgMgr.Save();
            Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            m_listTrigger.SelectedNode = null;
            Close();
        }

        private void m_listTrigger_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }

        public int GetChoseTriggerID()
        {
            var curNode = m_listTrigger.SelectedNode;
            if (curNode == null)
                return -1;
            string fullPath = curNode.FullPath;
            string[] nodeParent = fullPath.Split('\\');
            switch(nodeParent.Length)
            {
                case 2:
                    return (int)curNode.Tag;
                case 3:
                    var info = (indexAndTriggerID)curNode.Tag;
                    return info.TriggerID;
            }
            return -1;
        }
    }
}
