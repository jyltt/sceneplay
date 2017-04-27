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
        int m_curScreenplayID;
        int m_curFuncIndex;
        string m_paramName;
        public ParamStringUI(int screenplay_id, int index, string param_name)
        {
            m_curScreenplayID = screenplay_id;
            m_curFuncIndex = index;
            m_paramName = param_name;
            InitializeComponent();
            InitUI();
        }

        void InitUI()
        {
            var screenplay = FileManager.ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var param = func.GetParamValue(m_paramName);
            var match = Regex.Match(param, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
            string file, id;
            if (match.Groups.Count > 1)
            {
                file = match.Groups[1].ToString();
                id = match.Groups[2].ToString();
            }
            else
            {
                file = "screenplay";
                id = "";
            }
            m_btnChangeStr.Text = "gs_"+file+"."+id;
            m_labString.Text = FileManager.StringCfg.GetString(file, id);
        }

        private void m_btnChangeStr_Click(object sender, EventArgs e)
        {
            var screenplay = FileManager.ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var param = func.GetParamValue(m_paramName);
            var match = Regex.Match(param, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
            string file, id;
            if (match.Groups.Count > 1)
            {
                file = match.Groups[1].ToString();
                id = match.Groups[2].ToString();
            }
            else
            {
                file = "screenplay";
                id = "";
            }
            var w = new StringCfgListUI(file, id);
            w.ShowDialog();
            var selectID = w.GetSelectItem();
            var selectFile = w.GetSelectFile();
            var str = "gs_" + selectFile + "." + selectID;
            m_btnChangeStr.Text = str;
            func.ChangeParam(m_paramName, str);
            m_labString.Text = FileManager.StringCfg.GetString(selectFile, selectID);
        }
    }
}
