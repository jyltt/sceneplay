using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sceneplay
{
    class FuncInfo
    {
        string m_Name;
        Dictionary<string,string> m_ParamList = new Dictionary<string, string>();
        public FuncInfo(string str)
        { 
            var list = str.Split(';');
            m_Name = list[0];
            int paramIndex = 2;
            for(var i=1;i<list.Length;i++)
            {
                var param = list[i];
                var match = Regex.Match(param, @"([\w]+) *= *(.+)");
                if (match.Groups.Count > 1)
                {
                    var paramType = match.Groups[1].ToString();
                    var paramStr = match.Groups[2].ToString();
                    m_ParamList[paramType] = paramStr.Replace(',','\n');
                }
                else
                {
                    if (param == "")
                        continue;
                    m_ParamList[paramIndex.ToString()] = param;
                    ++paramIndex;
                }
            }
        }
        public FuncInfo(string name, FuncCfgInfo paramList)
        {
            m_Name = name;
            foreach (var param in paramList.GetParamList())
            {
                m_ParamList[param] = paramList.GetParamInfo(param).DefValue;
            }
        }
        public FuncInfo(FuncInfo fi)
        {
            m_Name = fi.m_Name;
            foreach (var param in fi.m_ParamList)
            {
                m_ParamList[param.Key] = param.Value;
            }
        }

        public void ChangeParam(string type, string value)
        {
            m_ParamList[type] = value;
        }
        public string GetParamValue(string type)
        {
            if (m_ParamList.ContainsKey(type))
                return m_ParamList[type];
            return null;
        }
        public Dictionary<string,string>.KeyCollection GetParamType()
        {
            return m_ParamList.Keys;
        }
        public string Name { get { return m_Name; } }
    }
}
