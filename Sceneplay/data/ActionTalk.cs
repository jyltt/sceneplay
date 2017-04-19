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
        int m_nId;
        public ActionTalk()
        {
        }

        public ActionTalk(string str_id)
        {
            Name = "talk";
            var match = Regex.Match(str_id, @"str([0-9]+)");
            if (match.Groups.Count > 1)
            {
                m_nId = System.Int32.Parse(match.Groups[1].ToString());
            }
            else
            {
                MessageBox.Show("对话名字解析失败。id："+str_id);
            }
        }

        public ActionTalk(int id)
        {
            m_nId = id;
        }

        public ActionTalk(ActionTalk at)
        {
            m_nId = at.m_nId;
        }

        int ID { set { m_nId = value; } }

        public string ToText()
        {
            return m_nId.ToString();
        }

        override public string ToString()
        {
            return "gs_screenplay.str" + m_nId;
        }
    }
}
