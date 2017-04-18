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
    public partial class ActionFuncUI : Form
    {
        int m_curScreenplayID;
        int m_curFuncIndex;
        public ActionFuncUI(int screenplay_id, int index)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            InitializeComponent();
            var _funcInfo = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            CreateFuncList();
            m_listFunc.SelectedIndex = FindIndexInFuncList(_funcInfo.ActInfo.Name);
            m_labRemarks.Text = _funcInfo.Describe.Replace("\\n", "\r\n");
            m_labFuncRemarks.Text = FileManager.GetInstance().FuncCfgMgr.GetFuncCfg(_funcInfo.ActInfo.Name).Describe;
        }

        private void CreateFuncList()
        {
            foreach (var dic in FileManager.GetInstance().FuncCfgMgr.FileList)
            {
                var info = FileManager.GetInstance().FuncCfgMgr.GetFuncCfg(dic);
                BoxItem item = new BoxItem();
                item.Text = info.Name + info.DescribeSimple;
                item.Value = info.Name;
                m_listFunc.Items.Add(item);
            }
        }

        private int FindIndexInFuncList(string func_name)
        {
            for (int i = 0; i < m_listFunc.Items.Count; ++i)
            {
                BoxItem item = (BoxItem)m_listFunc.Items[i];
                string name = (string)item.Value;
                if (name == func_name)
                    return i;
            }
            return -1;
        }

        private void m_listFunc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_labRemarks_TextChanged(object sender, EventArgs e)
        {
            var _funcInfo = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            _funcInfo.Describe = m_labRemarks.Text.Replace("\r\n", "\\n");
        }

        private void m_listParamType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
