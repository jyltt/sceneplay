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
    public partial class ParamValueUI : Form
    {
        int m_curScreenplayID;
        int m_curFuncIndex;
        string m_paramName;
        public ParamValueUI(int screenplay_id, int index, string param_name)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            m_paramName = param_name;
            InitializeComponent();
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var funcCfg = FileManager.GetInstance().FuncCfgMgr.GetFuncCfg(func.Name);
            if (funcCfg == null)
                return;
            m_labParam.Text = func.GetParamValue(param_name);
            m_labRemarks.Text = funcCfg.GetParamInfo(param_name).Describe;
        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            func.ChangeParam(m_paramName, m_labParam.Text);
        }
    }
}
