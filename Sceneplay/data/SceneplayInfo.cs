using Sceneplay.data;
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
        const int m_SwitchNum = 5;
        int m_SceneplayID;
        int m_Index;
        int m_Pos = 0;
        int m_ActorID = 1;
        int m_Audio = 0;
        string m_IconPath = "0";
        string m_Describe = "0";
        string m_ActType = "talk";
        ActionBase m_ActInfo = new ActionTalk();
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
            if (m_ActType == "func")
                m_ActInfo = new FuncInfo((FuncInfo)si.m_ActInfo);
            else if (m_ActType == "talk")
                m_ActInfo = new ActionTalk((ActionTalk)si.m_ActInfo);

            for (int i = 0; i < si.m_Switch.Count; ++i)
            {
                m_Switch.Add(si.m_Switch[i]);
            }
        }
        public void SetSwitch(int index, bool isOpen)
        {
            if (m_Switch.Count <= index)
                return;
            m_Switch[index] = isOpen;
        }
        public bool GetSwitch(int index)
        { 
            if (m_Switch.Count <= index)
                return false;
            return m_Switch[index];
        }
        public string GetSwitchToStr(int index)
        { 
            return GetSwitch(index) ? "1" : "0";
        }
        public void SetActInfo(string str)
        {
            if (m_ActType == "talk")
                m_ActInfo = new ActionTalk(str);
            else if (m_ActType == "func")
                m_ActInfo = new FuncInfo(str);
        }
        public ActionBase ActInfo 
        { 
            get { return m_ActInfo; }
        }
        public int SwitchNum { get { return m_SwitchNum; } }
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
