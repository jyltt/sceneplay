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
            var list = FileManager.GetInstance().StringCfg.GetFileList();
            foreach (var file in list)
            {
                m_listFile.Items.Add(file);
            }
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
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
    }
}
