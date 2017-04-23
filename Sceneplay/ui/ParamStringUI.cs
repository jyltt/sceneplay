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
    public partial class ParamStringUI : Form
    {
        int m_curScreenplayID;
        int m_curFuncIndex;
        string m_paramName;
        public ParamStringUI(int screenplay_id, int index, string param_name)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            m_paramName = param_name;
            InitializeComponent();
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (ActionTalk)screenplay.ActInfo;
            m_btnChangeStr.Text = func.ToText();
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(func.ToText());
        }

        private void m_btnChangeFile_Click(object sender, EventArgs e)
        {

        }

        private void m_btnChangeStr_Click(object sender, EventArgs e)
        {

        }
    }
}
