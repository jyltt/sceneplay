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
    public partial class ActionStringUI : Form
    {
        int m_curScreenplayID;
        int m_curFuncIndex;
        public ActionStringUI(int screenplay_id, int index)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            InitializeComponent();
            // init ui
            var list = FileManager.GetInstance().StringCfg.GetFileList();
            foreach (var file in list)
            {
                m_listFile.Items.Add(file);
            }
            var hurdleInfo = FileManager.GetInstance().ConfigMgr.GetScreenplayInfo(DataCenter.curHurdleId, m_curScreenplayID);
            for (int i = 0; i < hurdleInfo.ObjList.Count; i++)
            {
                m_listActor.Items.Add(hurdleInfo.ObjList[i]);
            }

            // set ui;
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            m_labAudioID.Text = screenplay.Audio.ToString();
            m_labHeadIconPath.Text = screenplay.IconPath.ToString();
            switch (screenplay.Pos)
            {
                case 0:
                    m_pos1.Checked = true;
                    m_pos2.Checked = false;
                    m_pos3.Checked = false;
                    break;
                case 1:
                    m_pos1.Checked = false;
                    m_pos2.Checked = true;
                    m_pos3.Checked = false;
                    break;
                case 2:
                    m_pos1.Checked = false;
                    m_pos2.Checked = false;
                    m_pos3.Checked = true;
                    break;
                default:
                    m_pos1.Checked = false;
                    m_pos2.Checked = false;
                    m_pos3.Checked = false;
                    break;
            }
            for (int i = 0; i < 5; i++)
            {
                m_switchList.SetItemChecked(i, screenplay.GetSwitch(i));
            }
            if (m_listActor.Items.Count > screenplay.ActorID - 1)
                m_listActor.SelectedIndex = screenplay.ActorID - 1;
            else
                MessageBox.Show("你把登场角色列表里的角色删了，我找不到之前的角色了ψ(╰_╯)");
            var func = (ActionTalk)screenplay.ActInfo;
            m_btnChangeStr.Text = func.ID;
            m_listFile.SelectedItem = func.File;
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(func.File, func.ID);
        }

        private void m_listFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (ActionTalk)screenplay.ActInfo;
            func.File = (string)m_listFile.SelectedItem;
        }

        private void m_btnChangeStr_Click(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (ActionTalk)screenplay.ActInfo;
            var w = new StringCfgListUI(func.File, func.ID);
            w.ShowDialog();
            var select = w.GetSelectItem();
            if (select == null)
                return;
            m_btnChangeStr.Text = select;
            func.ID = select;
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(func.File, func.ID);
        }

        private void pos_CheckedChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            if (m_pos1.Checked)
                screenplay.Pos = 0;
            if (m_pos2.Checked)
                screenplay.Pos = 1;
            if (m_pos3.Checked)
                screenplay.Pos = 2;
        }

        private void m_listActor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var name = m_listActor.SelectedItem.ToString();
            var screenplayInfo = FileManager.GetInstance().ConfigMgr.GetScreenplayInfo(DataCenter.curHurdleId,m_curScreenplayID);
            var actorList = screenplayInfo.ObjList;
            var index = actorList.IndexOf(name);
            screenplay.ActorID = index + 1;
        }

        private void m_labAudioID_TextChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var newId = m_labAudioID.Text;
            int id;
            bool result = Int32.TryParse(newId, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("audio id什么时候可以用非数字了？？！！<(‵^′)>");
                m_labAudioID.Text = screenplay.Audio.ToString();
                return;
            }
            screenplay.Audio = id;
        }

        private void m_switchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var i = m_switchList.SelectedIndex;
            if (i < 0)
                return;
            screenplay.SetSwitch(i, m_switchList.GetItemChecked(i));
        }

        private void m_labHeadIconPath_TextChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            screenplay.IconPath = m_labHeadIconPath.Text;
        }
    }
}
