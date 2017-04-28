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
    public partial class TriggerCfgListUI : Form
    {
        string m_curLab="";
        public TriggerCfgListUI()
        {
            InitializeComponent();
        }

        private void m_listTrigger_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void m_labRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labSelectRemark_TextChanged(object sender, EventArgs e)
        {
            FileManager.TriggerCfgMgr.ChangeTriggerRemark(m_curLab, m_labSelectRemark.Text);
        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labEffect_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labCamp_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labType_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labID_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_labID_Enter(object sender, EventArgs e)
        {
            m_curLab = "id";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labCount_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_count";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labType_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_type";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labCamp_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_camp";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labEffect_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_effect";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labRole_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_role";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }

        private void m_labParam_Enter(object sender, EventArgs e)
        {
            m_curLab = "trigger_param";
            var str = FileManager.TriggerCfgMgr.GetTriggerRemark(m_curLab);
            m_labSelectRemark.Text = str;
        }
    }
}
