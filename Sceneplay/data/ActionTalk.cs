using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.data
{
    class ActionTalk : ActionBase
    {
        string m_sId;
        string m_sFile;
        public ActionTalk()
        {
            Name = "talk";
            File = "screenplay";
        }

        public ActionTalk(string str_id)
        {
            Name = "talk";
            var match = Regex.Match(str_id, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
            if (match.Groups.Count > 1)
            {
                m_sFile = match.Groups[1].ToString();
                m_sId = match.Groups[2].ToString();
            }
            else
            {
                MessageBox.Show("对话名字解析失败。id："+str_id);
            }
        }

        public ActionTalk(ActionTalk at)
        {
            Name = "talk";
            m_sId = at.m_sId;
            m_sFile = at.m_sFile;
        }

        public string ID 
        { 
            get { return m_sId; }
            set { m_sId = value; }
        }
        public string File 
        { 
            get { return m_sFile; }
            set 
            { 
                if (m_sFile != value) 
                { 
                    m_sId = "0";
                    m_sFile = value; 
                } 
            }
        }

        override public string ToString()
        {
            return "gs_" + m_sFile + "." + m_sId;
        }
    }
}
