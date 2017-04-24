using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.ui
{
    public partial class ParamStringUI : Form
    {
        protected int m_curScreenplayID;
        protected int m_curFuncIndex;
        protected string m_paramName;
        public ParamStringUI(int screenplay_id, int index, string param_name)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            m_paramName = param_name;
            InitializeComponent();
            InitUI();
        }

        virtual protected void InitUI()
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var param = func.GetParamValue(m_paramName);
            var match = Regex.Match(param, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
            if (match.Groups.Count > 1)
            {
                m_btnChangeFile.Text = match.Groups[1].ToString();
                m_btnChangeStr.Text = match.Groups[2].ToString();
            }
            else
            {
                m_btnChangeFile.Text = "screenplay";
                m_btnChangeStr.Text = "";
            }
        }

        virtual protected void m_btnChangeFile_Click(object sender, EventArgs e)
        {

        }

        virtual protected void m_btnChangeStr_Click(object sender, EventArgs e)
        {

        }
    }
}
