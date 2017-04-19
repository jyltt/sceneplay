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
        }

        private void m_listParamType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_labParam_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
