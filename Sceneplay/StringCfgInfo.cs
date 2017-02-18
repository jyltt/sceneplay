using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay
{
    class StringCfgInfo
    {
        private string m_FilePath;
        private Dictionary<int, string> m_StringList = new Dictionary<int,string>();

        public StringCfgInfo(string file_path)
        {
            m_FilePath = file_path;
            ReadFile();
        }

        void ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(m_FilePath, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    var match = Regex.Match(line, @"str([0-9]+)\t([\S]+)");
                    if (match.Groups.Count > 1)
                    {
                        var index = System.Int32.Parse(match.Groups[1].ToString());
                        m_StringList[index] = match.Groups[2].ToString();
                    }
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
            }
        }

        public void Save()
        {
            try
            {
                StreamWriter sw = new StreamWriter(m_FilePath, false, Encoding.UTF8);
                foreach (var id in m_StringList.Keys)
                {
                    string str = "str" + id.ToString() + "\t" + m_StringList[id];
                    sw.WriteLine(str);
                }
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
            }
        }

        public string GetString(int id)
        {
            if (m_StringList.ContainsKey(id))
                return m_StringList[id];
            else
                return "";
        }

        public string GetString(string str)
        {
            var match = Regex.Match(str, @"str([0-9]+)");
            if (match.Groups.Count > 1)
            {
                var index = System.Int32.Parse(match.Groups[1].ToString());
                return GetString(index);
            }
            return null;
        }

        public int GetStringId()
        {
            int i = 1;
            while (m_StringList.ContainsKey(i))
            {
                ++i;
            }
            return i;
        }

        public void ChangeString(int id, string str)
        {
            if(m_StringList.ContainsKey(id))
            {
                if (str == "")
                {
                    m_StringList.Remove(id);
                    return;
                }
            }
            m_StringList[id] = str;
        }

        public void ChangeString(string id, string str)
        {
            var match = Regex.Match(id, @"str([0-9]+)");
            if (match.Groups.Count > 1)
            {
                var index = System.Int32.Parse(match.Groups[1].ToString());
                ChangeString(index, str);
            }
        }
    }
}
