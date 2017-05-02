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
    public partial class SceenplayUI : Form
    {
        int m_curHurdleID;
        int m_curSceenplayID;
        TreeNode m_curNode;

        public SceenplayUI(int hurdle_id, int screenplay_id, TreeNode node)
        {
            m_curHurdleID = hurdle_id;
            m_curSceenplayID = screenplay_id;
            m_curNode = node;
            InitializeComponent();
            m_labID.Text = screenplay_id.ToString();
            var _screenplayInfo = FileManager.ConfigMgr.GetScreenplayInfo(hurdle_id, screenplay_id);
            var _actor = _screenplayInfo.ObjList;
            foreach (var name in _actor)
            {
                m_listActor.Items.Add(name);
            }
            m_btnTrigger.Text = _screenplayInfo.TriggerID.ToString();
            m_labRemarks.Text = _screenplayInfo.Describe.Replace("\\n","\r\n");
            UpdateReferenceList();
        }

        void UpdateReferenceList()
        {
            var list = FileManager.ConfigMgr.GetSceenplayReferenceList(m_curSceenplayID);
            string str = "";
            foreach(var id in list)
            {
                str += id.ToString();
                str += "\r\n";
            }
            m_labReference.Text = str;
        }

        private void m_labID_Leave(object sender, EventArgs e)
        {
            var newName = m_labID.Text;
            int id;
            bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("节点名字必须为数字(＞﹏＜)");
                m_labID.Text = m_curHurdleID.ToString();
                return;
            }
            if (id == m_curSceenplayID)
                return;
            bool res = FileManager.ContentMgr.ExchangeSceenplayID(m_curHurdleID, id, m_curSceenplayID);
            if(!res)
            {
                m_labID.Text = m_curSceenplayID.ToString();
            }
            else
            {
                m_curSceenplayID = id;
                UpdateReferenceList();
            }
        }

        private void m_listActor_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_btnAddActor.Text = "-";
        }

        private void m_labActor_TextChanged(object sender, EventArgs e)
        {
            m_btnAddActor.Text = "+";
        }

        private void m_btnAddActor_Click(object sender, EventArgs e)
        {
            var objList = FileManager.ConfigMgr;
            if (m_btnAddActor.Text == "-")
            {
                if (m_listActor.SelectedItem == null)
                    return;
                objList.RemoveActor(m_curHurdleID, m_curSceenplayID, m_listActor.SelectedItem.ToString());
                m_listActor.Items.Remove(m_listActor.SelectedItem);
            }
            else if (m_btnAddActor.Text == "+")
            {
                var actor = m_labActor.Text;
                if (actor == "")
                    return;
                if (objList.AddActor(m_curHurdleID, m_curSceenplayID, actor))
                {
                    m_listActor.Items.Add(actor);
                    m_labActor.Text = "";
                }
                else
                {
                    MessageBox.Show("该角色已经添加╮(╯▽╰')╭");
                }
            }
        }

        //private void m_labTriggerID_TextChanged(object sender, EventArgs e)
        //{
        //    var newName = m_labTriggerID.Text;
        //    int id;
        //    bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
        //    var _screenplayInfo = FileManager.ConfigMgr.GetScreenplayInfo(m_curHurdleID,m_curSceenplayID);
        //    if (!result)
        //    {
        //        MessageBox.Show("触发器id必须为数字(￣︶￣)↗");
        //        m_labTriggerID.Text = _screenplayInfo.TriggerID.ToString();
        //        return;
        //    }
        //    _screenplayInfo.TriggerID = id;
        //}

        private void m_labRemarks_TextChanged(object sender, EventArgs e)
        {
            var _screenplayInfo = FileManager.ConfigMgr.GetScreenplayInfo(m_curHurdleID,m_curSceenplayID);
            _screenplayInfo.Describe = m_labRemarks.Text.Replace("\r\n", "\\n");
        }

        private void m_btnTrigger_Click(object sender, EventArgs e)
        {
            var w = new TriggerCfgListUI();
            w.ShowDialog();
            var id = w.GetChoseTriggerID();
            if (id == -1)
                return;
            var _screenplayInfo = FileManager.ConfigMgr.GetScreenplayInfo(m_curHurdleID, m_curSceenplayID);
            m_btnTrigger.Text = id.ToString();
            _screenplayInfo.TriggerID = id;
        }
    }
}
