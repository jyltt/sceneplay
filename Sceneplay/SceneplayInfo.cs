using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sceneplay
{
    class SceneplayInfo
    {
        int m_SceneplayID;
        int m_Index;
        int m_SwitchNum = 5;
        int m_Pos = 0;
        int m_ActorID = 1;
        int m_Audio = 0;
        string m_IconPath = "0";
        string m_Describe = "0";
        string m_ActType = "talk";
        FuncInfo m_ActInfo;
        string m_ActTalk = "0";
        List<bool> m_Switch = new List<bool>();
        public SceneplayInfo(int sceneplay_id,int index) 
        {
            m_SceneplayID = sceneplay_id;
            m_Index = index;
            for (int i = 0; i < m_SwitchNum; ++i)
            {
                m_Switch.Add(false);
            }
        }
        public SceneplayInfo(SceneplayInfo si, int sceneplay_id,int index)
        {
            m_SceneplayID = sceneplay_id;
            m_Index = index;
            m_Pos = si.m_Pos;
            m_ActorID = si.m_ActorID;
            m_Audio = si.m_Audio;
            m_IconPath = si.m_IconPath;
            m_Describe = si.m_Describe;
            m_ActType = si.m_ActType;
            m_ActTalk = si.m_ActTalk;
            if(m_ActType == "func")
                m_ActInfo = new FuncInfo(si.m_ActInfo);
            for (int i = 0; i < si.m_Switch.Count; ++i)
            {
                m_Switch.Add(si.m_Switch[i]);
            }
        }
        public void SetSwitch(int index, bool isOpen)
        {
            if (m_Switch.Count >= index)
                return;
            m_Switch[index] = isOpen;
        }
        public bool GetSwitch(int index)
        { 
            if (m_Switch.Count >= index)
                return false;
            return m_Switch[index];
        }
        public string GetSwitchToStr(int index)
        { 
            return GetSwitch(index) ? "1" : "0";
        }
        public void SetActInfo(string str)
        {
            m_ActInfo = new FuncInfo(str);
        }
        public string GetAct(Dictionary<string, FuncCfgInfo> fciList)
        {
            if (m_ActType == "func")
            {
                var info = m_ActInfo;
                var funcName = info.Name;
                var str = string.Format("{0};",funcName);
                if (!fciList.ContainsKey(funcName))
                {
                    return str;
                }

                foreach(var param in fciList[funcName].GetParamList())
                {
                    var value = info.GetParamValue(param);
                    if (value != null && value != "")
                        str = string.Format("{0}{1}={2};", str, param, value.Replace('\n', ','));
                }
                return str;
            }
            else if (m_ActType == "talk")
            {
                return "gs_screenplay."+m_ActTalk;
            }
            return "0";
        }
        public FuncInfo ActInfo 
        { 
            get { return m_ActInfo; }
            set { m_ActInfo = value; }
        }
        public int SwitchNum { get { return m_SwitchNum; } }
        public string ActTalk
        {
            get { return m_ActTalk.Replace('\n',' '); }
            set { m_ActTalk = value.Replace('\n',' '); }
        }
        public int Pos 
        { 
            set { m_Pos = value; }
            get { return m_Pos; }
        }
        public int ActorID 
        { 
            set { m_ActorID = value; }
            get { return m_ActorID ; }
        }
        public int Audio
        { 
            set { m_Audio = value; }
            get { return m_Audio ; }
        }
        public string IconPath
        { 
            set { m_IconPath = value; }
            get { return m_IconPath ; }
        }
        public string Describe
        { 
            set { m_Describe = value; }
            get { return m_Describe ; }
        }
        public string ActType
        { 
            set { m_ActType = value; }
            get { return m_ActType; }
        }
    }
}
