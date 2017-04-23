using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay
{
    class ParamInfo
    {
        public ParamInfo(string type, string name, string des, string def_value)
        {
            m_Name = name;
            m_Describe = des;
            m_Type = type;
            var desList = des.Split(';');
            if (desList.Length == 2)
            {
                m_DescribeSimple = desList[0];
                m_Describe = desList[1];
            }
            m_DefaultValue = def_value;
        }
        public ParamInfo(string type, string name, string des)
        {
            m_Name = name;
            m_Type = type;
            var desList = des.Split(';');
            m_Describe = des;
            if (desList.Length == 2)
            {
                m_DescribeSimple = desList[0];
                m_Describe = desList[1];
            }
        }
        string m_Describe;
        string m_DescribeSimple = null;
        string m_DefaultValue;
        string m_Name;
        string m_Type;
        public string Name
        {
            get { return m_Name; }
        }

        public string Describe
        {
            get { return m_Describe; }
        }

        public string DescribeSimple
        {
            get 
            {
                if (m_DescribeSimple == null)
                    return "";
                else
                    return "("+m_DescribeSimple+")";
            }
        }

        public string DefValue
        {
            get { return m_DefaultValue; }
        }
        public string Type
        {
            get { return m_Type; }
        }

    }
    class FuncCfgInfo
    {
        string m_Name;
        string m_Describe;
        string m_DescribeSimple = null;
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
            set 
            {
                if (m_DescribeSimple == null)
                    m_DescribeSimple = value;
                m_Describe = value; 
            }
        }

        public string DescribeSimple
        {
            get 
            {
                if (m_DescribeSimple == null)
                    return "";
                else
                    return "("+m_DescribeSimple+")";
            }
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
