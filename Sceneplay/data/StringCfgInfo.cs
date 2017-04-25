using Sceneplay.data;
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
            DirectoryInfo folder = new DirectoryInfo(m_FilePath);
            foreach(FileInfo file in folder.GetFiles())
            {
                ReadFile(m_FilePath, file.Name);
            }
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
                var _stringList = m_StringList[name];
                while ((line = sr.ReadLine()) != null)
                {
                    var match = Regex.Match(line, @"([a-zA-Z0-9_]+)\t(.+)");
                    if (match.Groups.Count > 1)
                    {
                        _stringList[match.Groups[1].ToString()] = match.Groups[2].ToString().Replace("\\n","\n");
                    }
                }
                _stringList.OrderBy(i => i.Value);
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
            }
        }

        public bool Save()
        {
            try
            {
                foreach(var fileName in m_StringList.Keys)
                {
                    var _stringList = m_StringList[fileName];
                    StreamWriter sw = new StreamWriter(m_FilePath + fileName + ".txt", false, Encoding.UTF8);
                    foreach (var id in _stringList.Keys)
                    {
                        string str = id + "\t" + _stringList[id].Replace("\n", "\\n");
                        sw.WriteLine(str);
                    }
                    sw.Close();
                }
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
                return false;
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

        public string GetString(string str)
        {
            var match = Regex.Match(str, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
            string file, id;
            if (match.Groups.Count > 1)
            {
                file = match.Groups[1].ToString();
                id = match.Groups[2].ToString();
            }
            else
            {
                file = "screenplay";
                id = "";
            }
            return GetString(file, id);
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

        public Dictionary<string, string> GetStringListByFile(string file_name)
        {
            if (m_StringList.ContainsKey(file_name))
                return m_StringList[file_name];
            else
                return null;
        }

        public Dictionary<string, string> GetStringReferenceList(string file_name)
        {
            var list = new Dictionary<string, string>();
            var contentMgr = FileManager.GetInstance().ContentMgr;
            foreach (var id in contentMgr.GetSceenplayList())
            {
                var screenplayList = contentMgr.GetInfoList(id);
                foreach(var info in screenplayList)
                {
                    if(info.ActType == "talk")
                    {
                        var talkInfo = (ActionTalk)info.ActInfo;
                        if(file_name == talkInfo.File)
                        {
                            if (!list.ContainsKey(talkInfo.ID))
                                list[talkInfo.ID] = "";
                            list[talkInfo.ID] += id.ToString();
                            list[talkInfo.ID] += "\r\n";
                        }
                    }
                    else if(info.ActType == "func")
                    {
                        var funcInfo = (FuncInfo)info.ActInfo;
                        var funcCfg = FileManager.GetInstance().FuncCfgMgr.GetFuncCfg(funcInfo.Name);
                        foreach(var param in funcCfg.GetParamList())
                        {
                            var paramCfg = funcCfg.GetParamInfo(param);
                            if(paramCfg.Type == "string")
                            {
                                var str = funcInfo.GetParamValue(param);
                                var match = Regex.Match(str, @"gs_([a-zA-Z0-9_]+).([a-zA-Z0-9_]+)");
                                if (match.Groups.Count > 1)
                                {
                                    string file = match.Groups[1].ToString();
                                    string str_id = match.Groups[2].ToString();
                                    if (file == file_name)
                                    {
                                        if (!list.ContainsKey(str_id))
                                            list[str_id] = "";
                                        list[str_id] += id.ToString();
                                        list[str_id] += "\r\n";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public bool AddString(string file, string id)
        {
            if (!m_StringList.ContainsKey(file))
                return false;
            var _stringList = m_StringList[file];
            if (_stringList.ContainsKey(id))
                return false;
            _stringList[id] = "";
            return true;
        }

        public bool DelString(string file, string id)
        {
            if (!m_StringList.ContainsKey(file))
                return false;
            return m_StringList[file].Remove(id);
        }

        public Dictionary<string, Dictionary<string, string>>.KeyCollection GetFileList()
        {
            return m_StringList.Keys;
        }

    }
}
