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
        }

        private void m_btnChangeFile_Click(object sender, EventArgs e)
        {

        }

        private void m_btnChangeStr_Click(object sender, EventArgs e)
        {

        }
    }
}
