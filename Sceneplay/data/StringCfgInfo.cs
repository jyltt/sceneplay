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
        private Dictionary<string,Dictionary<string, string>> m_StringList = new Dictionary<string,Dictionary<string,string>>();

        public StringCfgInfo(string file_path)
        {
            m_FilePath = file_path;
            ReadFile(m_FilePath,"screenplay.txt");
        }

        void ReadFile(string file_path, string file_name)
        {
            try
            {
                var _match = Regex.Match(file_name, @"([a-zA-Z0-9_]+).txt");
                if (_match.Groups.Count <= 1)
                {
                    return;
                }
                StreamReader sr = new StreamReader(file_path+file_name, Encoding.Default);
                String line;
                var name = _match.Groups[1].ToString();
                m_StringList[name] = new Dictionary<string, string>();
                var StringList = m_StringList[name];
                while ((line = sr.ReadLine()) != null)
                {
                    var match = Regex.Match(line, @"([a-zA-Z0-9_]+)\t(.+)");
                    if (match.Groups.Count > 1)
                    {
                        StringList[match.Groups[1].ToString()] = match.Groups[2].ToString().Replace("\\n","\n");
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
                var fileName = "screenplay";
                StreamWriter sw = new StreamWriter(m_FilePath+fileName+".txt", false, Encoding.UTF8);
                var _stringList = m_StringList[fileName];
                foreach (var id in _stringList.Keys)
                {
                    string str = id + "\t" + _stringList[id].Replace("\n","\\n");
                    sw.WriteLine(str);
                }
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
            }
        }

        public string GetString(string file, string key)
        {
            if (!m_StringList.ContainsKey(file))
                return "";
            var _stringList = m_StringList[file];
            if (!_stringList.ContainsKey(key))
                return "";
            return _stringList[key];
        }

        public bool ChangeString(string file, string id, string str)
        {
            if(m_StringList.ContainsKey(file))
            {
                var _stringList = m_StringList[file];
                if (_stringList.ContainsKey(id))
                {
                    _stringList[id] = str;
                    return true;
                }
            }
            return false;
        }

    }
}
