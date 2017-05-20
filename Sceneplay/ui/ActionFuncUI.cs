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
        Form m_curForm;
        public ActionFuncUI(int screenplay_id, int index)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            InitializeComponent();
            CreateParamTypeList();
        }

        private void CreateParamTypeList()
        {
            m_listParamType.Items.Clear();
            var _funcInfo = FileManager.ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (_funcInfo == null)
                return;
            var func = _funcInfo.ActInfo as FuncInfo;
            var funcCfg = FileManager.FuncCfgMgr.GetFuncCfg(func.Name);
            foreach (var type in funcCfg.GetParamList())
            {
                var param = funcCfg.GetParamInfo(type);
                BoxItem item = new BoxItem();
                item.Text = type + param.DescribeSimple;
                item.Value = type;
                m_listParamType.Items.Add(item);
            }
        }

        private void ChangeDlg(Form f)
        {
            if (m_curForm != null)
            {
                m_curForm.Parent = null;
                m_curForm = null;
            }
            if (f == null)
                return;
            m_curForm = f;
            f.TopLevel = false;
            f.Parent = m_paramNode;
            f.Show();
        }

        private void m_listParamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_listParamType.SelectedItem == null)
                return;
            var item = (BoxItem)m_listParamType.SelectedItem;
            var paramName = (string)item.Value;
            var screenplay = FileManager.ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var funcCfg = FileManager.FuncCfgMgr.GetFuncCfg(func.Name);
            if (funcCfg == null)
                return;
            var paramCfg = funcCfg.GetParamInfo(paramName);
            Form f = null;
            if(paramCfg.Type == "value")
            {
                f = new ParamValueUI(m_curScreenplayID, m_curFuncIndex, paramName);
            }
            else if (paramCfg.Type == "string")
            {
                f = new ParamStringUI(m_curScreenplayID, m_curFuncIndex, paramName);
            }
            ChangeDlg(f);
        }
    }
}
