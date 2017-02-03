using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay
{
    class ParamInfo
    {
        public ParamInfo(string name, string des, string def_value)
        {
            m_Name = name;
            m_Describe = des;
            m_DefaultValue = def_value;
        }
        public ParamInfo(string name, string des)
        {
            m_Name = name;
            m_Describe = des;
        }
        string m_Describe;
        string m_DefaultValue;
        string m_Name;
        public string Name
        {
            get { return m_Name; }
        }

        public string Describe
        {
            get { return m_Describe; }
        }

        public string DefValue
        {
            get { return m_DefaultValue; }
        }

    }
    class FuncCfgInfo
    {
        string m_Name;
        string m_Describe;
        Dictionary<string, ParamInfo> m_ParamList = new Dictionary<string,ParamInfo>();
        public FuncCfgInfo(string name)
        {
            m_Name = name;
        }

        public string Name
        {
            get { return m_Name; }
        }

        public string Describe
        {
            get { return m_Describe; }
            set { m_Describe = value; }
        }

        public void AddParam(ParamInfo pi)
        {
            m_ParamList[pi.Name] = pi;
        }

        public Dictionary<string, ParamInfo>.KeyCollection GetParamList()
        {
            return m_ParamList.Keys;
        }

        public ParamInfo GetParamInfo(string key)
        {
            if (m_ParamList.ContainsKey(key))
                return m_ParamList[key];
            else
                return null;
        }
    }
}
