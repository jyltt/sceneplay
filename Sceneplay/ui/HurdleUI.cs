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
    public partial class HurdleUI : Form
    {
        int m_curHurdleID;
        TreeNode m_curNode;
        public HurdleUI(int hurdle_id, TreeNode node)
        {
            InitializeComponent();
            m_curHurdleID = hurdle_id;
            m_curNode = node;
            m_labID.Text = hurdle_id.ToString();
        }

        private void m_labID_Leave(object sender, EventArgs e)
        {
            var newName = m_labID.Text;
            if (newName == m_curHurdleID.ToString())
                return;
            int id;
            bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("节点名字必须为数字(＞﹏＜)");
                m_labID.Text = m_curHurdleID.ToString();
                return;
            }
            if (FileManager.ConfigMgr.ExchangeHurdleID(m_curHurdleID, id))
            {
                m_curHurdleID = id;
                DataCenter.curHurdleId = id;
                m_curNode.Text = newName;
            }
            else
            {
                m_labID.Text = m_curHurdleID.ToString();
            }
        }
    }
}
