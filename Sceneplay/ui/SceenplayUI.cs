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
    public partial class SceenplayUI : Form
    {
        int m_curHurdleID;
        int m_curSceenplayID;
        TreeNode m_curNode;

        public SceenplayUI(int hurdle_id, int sceenplay_id, TreeNode node)
        {
            m_curHurdleID = hurdle_id;
            m_curSceenplayID = sceenplay_id;
            m_curNode = node;
            InitializeComponent();
            m_labID.Text = sceenplay_id.ToString();
        }

        private void m_labID_Leave(object sender, EventArgs e)
        {
            var newName = m_labID.Text;
            int id;
            bool result = Int32.TryParse(newName, out id); // return bool value hint y/n
            if (!result)
            {
                MessageBox.Show("节点名字必须为数字(＞﹏＜)");
                m_labID.Text = m_curHurdleID.ToString();
                return;
            }
            if (id == m_curSceenplayID)
                return;
            bool res = FileManager.GetInstance().ContentMgr.ExchangeSceenplayID(m_curHurdleID, id, m_curSceenplayID);
            if(!res)
            {
                m_labID.Text = m_curHurdleID.ToString();
            }
            //if (m_FileInfo.m_play.ContainsKey(id))
            //{
            //    var ret = MessageBox.Show("是否重置节点?●﹏●", "id已存在", MessageBoxButtons.YesNo);
            //    if (ret == DialogResult.No)
            //        return;
            //    curTreeNode.Nodes.Clear();
            //    CreateSceneplayTree(curTreeNode, id, m_curHurdleId);
            //}
            //else
            //{
            //    if (m_FileInfo.m_play2flg[m_curSceneplayId] >= 2)
            //    {
            //        var ret = MessageBox.Show("是否复制~>_<~", "该id被多个地方引用了", MessageBoxButtons.YesNo);
            //        switch (ret)
            //        {
            //            case DialogResult.Yes:
            //                break;
            //            case DialogResult.No:
            //                return;
            //        }
            //    }
            //    m_FileInfo.ChangePlayid1(m_curSceneplayId, id);
            //}
            //m_FileInfo.ChangePlayid2(m_curSceneplayId, m_curHurdleId, curTreeNode.Index, id);

            //m_curSceneplayId = id;
            //labReference.Text = m_FileInfo.GetReferenceListStr(m_curSceneplayId);
            //curTreeNode.Text = newName;
        }

        private void m_listActor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_labActor_TextChanged(object sender, EventArgs e)
        {

        }

        private void m_btnAddActor_Click(object sender, EventArgs e)
        {

        }

        private void m_labTriggerID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
