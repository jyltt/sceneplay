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
        List<SceneplayInfo> m_ScreenplayInfoList;

        Dictionary<int, string> _needUpdateNode = new Dictionary<int,string>();
        public ScreenplayTreeNode(int screenplay_id, int hurdle_id):base(screenplay_id.ToString())
        {
            m_screenplayId = screenplay_id;
            SetCallFunc(m_screenplayId);
            m_hurdleId = hurdle_id;
            m_ScreenplayInfoList = FileManager.ContentMgr.GetInfoList(m_screenplayId);
        }
        public void CreateSceneplayTree(int screenplay_id, int hurdle_id = -1)
        {
            if (screenplay_id != m_screenplayId && hurdle_id == m_hurdleId)
            {
                SetCallFunc(screenplay_id, m_screenplayId);
                m_screenplayId = screenplay_id;
                m_ScreenplayInfoList = FileManager.ContentMgr.GetInfoList(m_screenplayId);
                Text = m_screenplayId.ToString();
            }
            CreateSceneplayTree();
        }
        public void UpdateFunc(int index)
        {
            if (m_ScreenplayInfoList == null)
                return;
            if (m_ScreenplayInfoList.Count <= index)
                return;
            var func = m_ScreenplayInfoList[index];
            var obj = func.ActInfo;
            string name = obj.Name;
            string text = obj.Name + "(" + func.Describe + ")";
            TreeNode nodeFuncName = Nodes[index];
            if (text == nodeFuncName.Text)
                return;
            nodeFuncName.Tag = name;
            if(IsExpanded)
            {
                _needUpdateNode[index] = text;
                UpdateUI();
            }
            else
            {
                _needUpdateNode[index] = text;
            }
        }
        public void UpdateUI()
        {
            foreach (var info in _needUpdateNode)
            {
                var index = info.Key;
                var text = info.Value;
                TreeNode nodeFuncName = Nodes[index];
                nodeFuncName.Text = text;
            }
            _needUpdateNode.Clear();
        }
        private void SetCallFunc(int new_id,int old_id=-1)
        {
            if (new_id != -1)
            {
                if (!FileManager.ContentMgr.m_UpdateScreenplay.ContainsKey(new_id))
                    FileManager.ContentMgr.m_UpdateScreenplay[new_id] = null;
                FileManager.ContentMgr.m_UpdateScreenplay[new_id] += CreateSceneplayTree;
                if (!FileManager.ContentMgr.m_UpdateFunc.ContainsKey(new_id))
                    FileManager.ContentMgr.m_UpdateFunc[new_id] = null;
                FileManager.ContentMgr.m_UpdateFunc[new_id] += UpdateFunc;
            }
            if (old_id != -1)
            {
                if(FileManager.ContentMgr.m_UpdateScreenplay.ContainsKey(old_id))
                    FileManager.ContentMgr.m_UpdateScreenplay[old_id] -= CreateSceneplayTree;
                if (FileManager.ContentMgr.m_UpdateFunc.ContainsKey(old_id))
                    FileManager.ContentMgr.m_UpdateFunc[old_id] -= UpdateFunc;
            }
        }
        private void CreateSceneplayTree()
        {
            var _bExpanded = false;
            if (IsExpanded)
                _bExpanded = IsExpanded;
            Nodes.Clear();
            if (m_ScreenplayInfoList == null)
                return;
            var isSelect = (m_hurdleId == DataCenter.curHurdleId && m_screenplayId == DataCenter.curScreenplayId);
            for (int i = 0; i < m_ScreenplayInfoList.Count; i++)
            {
                var func = m_ScreenplayInfoList[i];
                var obj = func.ActInfo;
                string name = obj.Name;
                string text = obj.Name + "(" + func.Describe + ")";
                TreeNode nodeFuncName = new TreeNode(text);
                nodeFuncName.Tag = name;
                Nodes.Add(nodeFuncName);
                if (isSelect && i == DataCenter.curFuncIndex)
                {
                    TreeView.SelectedNode = nodeFuncName;
                    _bExpanded = true;
                }
            }
            if (_bExpanded)
                Expand();
            else
                Collapse();
        }

        ~ScreenplayTreeNode()
        {
            SetCallFunc(-1, m_screenplayId);
        }
    }
}
