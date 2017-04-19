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
            SetCallFunc(m_screenplayId);
            m_hurdleId = hurdle_id;
        }
        public void CreateSceneplayTree(int screenplay_id, int hurdle_id = -1)
        {
            if (screenplay_id != m_screenplayId && hurdle_id == m_hurdleId)
            {
                SetCallFunc(screenplay_id, m_screenplayId);
                m_screenplayId = screenplay_id;
                Text = m_screenplayId.ToString();
            }
            CreateSceneplayTree();
        }
        private void SetCallFunc(int new_id,int old_id=-1)
        {
            if (new_id != -1)
            {
                if (!FileManager.GetInstance().ContentMgr.m_UpdateFunc.ContainsKey(new_id))
                    FileManager.GetInstance().ContentMgr.m_UpdateFunc[new_id] = null;
                FileManager.GetInstance().ContentMgr.m_UpdateFunc[new_id] += CreateSceneplayTree;
            }
            if (old_id != -1)
                FileManager.GetInstance().ContentMgr.m_UpdateFunc[old_id] -= CreateSceneplayTree;
        }
        private void CreateSceneplayTree()
        {
            var _bExpanded = false;
            if (IsExpanded)
                _bExpanded = IsExpanded;
            Nodes.Clear();
            var list = FileManager.GetInstance().ContentMgr.GetInfoList(m_screenplayId);
            if (list == null)
                return;
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
            if (_bExpanded)
                Expand();
            else
                Collapse();
        }

        private void ChangeFunc()
        {
        }

        ~ScreenplayTreeNode()
        {
            SetCallFunc(-1, m_screenplayId);
        }
    }
}
