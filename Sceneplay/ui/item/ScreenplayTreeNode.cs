using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.ui.item
{
    class ScreenplayTreeNode: TreeNode
    {
        int m_screenplayId;
        int m_hurdleId;
        public ScreenplayTreeNode(int screenplay_id, int hurdle_id):base(screenplay_id.ToString())
        {
            m_screenplayId = screenplay_id;
            if (!FileManager.GetInstance().ContentMgr.m_UpdateFunc.ContainsKey(screenplay_id))
                FileManager.GetInstance().ContentMgr.m_UpdateFunc[screenplay_id] = null;
            FileManager.GetInstance().ContentMgr.m_UpdateFunc[screenplay_id] += CreateSceneplayTree;
            m_hurdleId = hurdle_id;
        }
        public void CreateSceneplayTree(int screenplay_id, int hurdle_id)
        {
            if (screenplay_id != m_screenplayId && hurdle_id == m_hurdleId)
            {
                FileManager.GetInstance().ContentMgr.m_UpdateFunc[m_screenplayId] -= CreateSceneplayTree;
                FileManager.GetInstance().ContentMgr.m_UpdateFunc[screenplay_id] += CreateSceneplayTree;
                m_screenplayId = screenplay_id;
                Text = m_screenplayId.ToString();
            }
            CreateSceneplayTree();
        }
        private void CreateSceneplayTree()
        {
            Nodes.Clear();
            var list = FileManager.GetInstance().ContentMgr.GetInfoList(m_screenplayId);
            var isSelect = (m_hurdleId == DataCenter.curHurdleId && m_screenplayId == DataCenter.curScreenplayId);
            for (int i = 0; i < list.Count; i++)
            {
                var func = list[i];
                var obj = func.ActInfo;
                string name = obj.Name;
                string text = obj.Name + "(" + func.Describe + ")";
                TreeNode nodeFuncName = new TreeNode(text);
                nodeFuncName.Tag = name;
                Nodes.Add(nodeFuncName);
                if (isSelect && i == DataCenter.curFuncIndex)
                    TreeView.SelectedNode = nodeFuncName;
            }
        }

        private void AddFunc()
        {
            CreateSceneplayTree();
        }

        private void DelFunc()
        {
            CreateSceneplayTree();
        }

        private void ChangeFunc()
        {
        }

        private void ChangeScreenplayId(int new_id)
        {
        }

        ~ScreenplayTreeNode()
        {
            FileManager.GetInstance().ContentMgr.m_UpdateFunc[m_screenplayId] -= CreateSceneplayTree;
        }
    }
}
