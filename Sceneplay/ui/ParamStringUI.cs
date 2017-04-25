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
            var list = FileManager.GetInstance().StringCfg.GetFileList();
            foreach(var file in list)
            {
                m_listFile.Items.Add(file);
            }
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
            m_listFile.SelectedItem = file;
            m_btnChangeStr.Text = id;
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(file, id);
        }

        virtual protected void m_btnChangeStr_Click(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
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
            var select = w.GetSelectItem();
            m_btnChangeStr.Text = select;
            func.ChangeParam(m_paramName, "gs_" + file + "." + select);
            m_labString.Text = FileManager.GetInstance().StringCfg.GetString(file, id);
        }

        virtual protected void m_ListFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var screenplay = FileManager.GetInstance().ContentMgr.GetFuncInfo(m_curScreenplayID, m_curFuncIndex);
            if (screenplay == null)
                return;
            var func = (FuncInfo)screenplay.ActInfo;
            var file = (string)m_listFile.SelectedItem;
            var select = m_btnChangeStr.Text;
            func.ChangeParam(m_paramName, "gs_" + file + "." + select);
        }
    }
}
