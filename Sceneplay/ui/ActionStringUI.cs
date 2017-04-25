using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay.ui
{
    class ActionStringUI:ParamStringUI
    {
        public ActionStringUI(int screenplay_id, int index)
            :base(screenplay_id, index, "")
        { }
        protected override void InitUI()
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (ActionTalk)screenplay.ActInfo;
            m_btnChangeStr.Text = func.ID;
            m_listFile.SelectedItem = func.File;
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(func.File, func.ID);
        }

        protected override void m_btnChangeStr_Click(object sender, EventArgs e)
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

        protected override void m_ListFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (ActionTalk)screenplay.ActInfo;
            func.File = (string)m_listFile.SelectedItem;
        }
    }
}
