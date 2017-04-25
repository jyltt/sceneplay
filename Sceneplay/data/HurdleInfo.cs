using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay
{
    class HurdleInfo
    {
        int m_hurdleID;
        int m_Index;
        int m_TriggerID = 0;
        int m_SceneplayID = 0;
        string m_Describe = "0";
        List<string> m_ObjList = new List<string>();

        public HurdleInfo(int hurdle_id, int index, int screenplay_id) 
        {
            m_Index = index;
            m_hurdleID = hurdle_id;
            m_SceneplayID = screenplay_id;
        }

        public HurdleInfo(HurdleInfo hi,int hurdle_id, int index)
        {
            m_hurdleID = hi.m_hurdleID;
            m_TriggerID = hi.m_TriggerID;
            m_SceneplayID = hi.m_SceneplayID;
            m_Describe = hi.m_Describe;
            for (int i = 0; i < hi.m_ObjList.Count; ++i)
            {
                m_ObjList.Add(hi.ObjList[i]);
            }
        }

        public bool AddObj(string objName)
        {
            if (m_ObjList.IndexOf(objName) == -1)
            { 
                m_ObjList.Add(objName);
                return true;
            }
            return false;
        }


        public bool RemoveObj(string objName)
        {
            return m_ObjList.Remove(objName);
        }

        public List<string> ObjList { get { return m_ObjList; } }

        public int HurdleID 
        { 
            set { m_hurdleID = value; }
            get { return m_hurdleID; }
        }

        public int TriggerID 
        {
            set { m_TriggerID = value; }
            get { return m_TriggerID; }
        }

        public int SceneplayID 
        { 
            set { m_SceneplayID = value; }
            get { return m_SceneplayID; }
        }

        public string Describe 
        { 
            set { m_Describe = value; }
            get { return m_Describe; }
        }
    }
}
