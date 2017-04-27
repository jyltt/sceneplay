using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sceneplay.data
{
    class TriggerCfg
    {
        int m_nID = 0;
        public int ID
        {
            get { return m_nID; }
            set { m_nID = value; }
        }
        string m_strRemark = "";
        public string Remark
        {
            get { return m_strRemark; }
            set { m_strRemark = value; }
        }
        int m_nCamp = 0; 
        public int Camp
        {
            get { return m_nCamp; }
            set { m_nCamp = value; }
        }
        string m_strRole = "";
        public string Role
        {
            get { return m_strRole; }
            set { m_strRole = value; }
        }
        int m_nType = 0;
        public int Type
        {
            get { return m_nType; }
            set { m_nType = value; }
        }
        int m_nCount = 0;
        public int Count
        {
            get { return m_nCount; }
            set { m_nCount = value; }
        }
        string m_strParam = "";
        public string Param
        {
            get { return m_strParam; }
            set { m_strParam = value; }
        }
        string m_strEffect = "";
        public string Effect
        {
            get { return m_strEffect; }
            set { m_strEffect = value; }
        }
        public TriggerCfg(string file_line)
        {
            var _info_list = file_line.Split('\t');
            m_nID = System.Int32.Parse(_info_list[0]);
            m_strRemark = _info_list[1];
            m_nCamp = System.Int32.Parse(_info_list[2]);
            m_strRole = _info_list[3];
            m_nType = System.Int32.Parse(_info_list[4]);
            m_nCount = System.Int32.Parse(_info_list[5]);
            m_strParam = _info_list[6];
            m_strEffect = _info_list[7];
        }
    }
}
