using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sceneplay
{
    class ReadFile
    {
        public Dictionary<int, List<List<string>>> m_hurdle2Obj = new Dictionary<int, List<List<string>>>();
        public Dictionary<int, List<int>> m_hurdle2Trigger = new Dictionary<int,List<int>>();
        public Dictionary<int, List<int>> m_hurdle2play = new Dictionary<int,List<int>>();
        public Dictionary<int, List<string>> m_hurdle2des = new Dictionary<int, List<string>>();

        public Dictionary<int, List<int>> m_play2pos = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> m_play2actor = new Dictionary<int, List<int>>();
        public Dictionary<int, List<string>> m_play2Icon = new Dictionary<int, List<string>>();
        public Dictionary<int, List<int>> m_play2audio = new Dictionary<int, List<int>>();
        public Dictionary<int, List<string>> m_play2Des = new Dictionary<int, List<string>>();
        public Dictionary<int, List<List<bool>>> m_play2switch = new Dictionary<int, List<List<bool>>>();
        public Dictionary<int, List<KeyValue<string,object>>> m_play2act = new Dictionary<int,List<KeyValue<string,object>>>();

        public Dictionary<string, Dictionary<string, string>> m_func2param = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<string, string> m_func2des = new Dictionary<string, string>();

        public ReadFile()
        {
            ReadConfigFile(GetPath() + "screenplay_config.txt");
            ReadContentFile(GetPath() + "screenplay_content.txt");
            ReadFuncCfgFile("func_info.txt");
        }

        public string GetPath()
        {
            return "config/hurdle/hurdle_screenplay/";
        }

        private void ReadFuncCfgFile(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            string funcName="";
            while ((line = sr.ReadLine()) != null)
            {
                do
                {
                    var func = Regex.Match(line, @"function (?:TriggerFunc\.)*([\w^( ]+)");
                    if (func.Groups.Count > 1)
                    {
                        funcName = func.Groups[1].ToString();
                        m_func2param[funcName] = new Dictionary<string, string>();
                        m_func2des[funcName] = "";
                        break;
                    }
                    var param = Regex.Match(line, @"([a-zA-Z0-9_]+) +([\w ]+)");
                    if (param.Groups.Count > 1)
                    {
                        var paramType = param.Groups[1].ToString();
                        var paramDes = param.Groups[2].ToString();
                        if (m_func2param.ContainsKey(funcName))
                            m_func2param[funcName][paramType] = paramDes;
                        break;
                    }
                    var des = Regex.Match(line, @"^(.+)$");
                    if (des.Groups.Count > 1)
                    {
                        if (m_func2des.ContainsKey(funcName))
                        {
                            m_func2des[funcName] += des.Groups[1].ToString();
                            m_func2des[funcName] += "\n";
                        }
                        break;
                    }
                }
                while (false) ;
            }
            sr.Close();
            m_func2param["talk"] = new Dictionary<string, string>();
            m_func2param["talk"]["gs_screenplay"] = "对话内容";
            m_func2des["talk"] = "对话内容";
        }

        private void ReadContentFile(string path)
        { 
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split('\t');
                var id = System.Int32.Parse(str[0]);
                if (!m_play2pos.ContainsKey(id))
                    m_play2pos[id] = new List<int>();
                m_play2pos[id].Add(System.Int32.Parse(str[1]));

                if (!m_play2actor.ContainsKey(id))
                    m_play2actor[id] = new List<int>();
                var match = Regex.Match(str[2], @"[a-z]+_([0-9]+)");
                if (match.Groups.Count > 1)
                {
                    var index = System.Int32.Parse(match.Groups[1].ToString());
                    m_play2actor[id].Add(index);
                }
                else 
                {
                    m_play2actor[id].Add(0);
                }

                if (!m_play2act.ContainsKey(id))
                    m_play2act[id] = new List<KeyValue<string, object>>();
                var type = str[3];
                object obj = null;
                if (type == "func")
                {
                    obj = ReadContentFunc(id, str[4], m_play2act[id].Count);
                }
                else if(type == "talk")
                {
                    obj = str[4];
                }
                var act = new KeyValue<string, object>(type, obj);
                m_play2act[id].Add(act);

                if (!m_play2Icon.ContainsKey(id))
                    m_play2Icon[id] = new List<string>();
                m_play2Icon[id].Add(str[5]);

                if (!m_play2audio.ContainsKey(id))
                    m_play2audio[id] = new List<int>();
                m_play2audio[id].Add(System.Int32.Parse(str[6]));

                if (!m_play2switch.ContainsKey(id))
                    m_play2switch[id] = new List<List<bool>>();
                var list = new List<bool>();
                list.Add(System.Int32.Parse(str[7]) == 1);
                list.Add(System.Int32.Parse(str[8]) == 1);
                list.Add(System.Int32.Parse(str[9]) == 1);
                list.Add(System.Int32.Parse(str[10]) == 1);
                list.Add(System.Int32.Parse(str[11]) == 1);
                m_play2switch[id].Add(list);

                if (!m_play2Des.ContainsKey(id))
                    m_play2Des[id] = new List<string>();
                m_play2Des[id].Add(str[12]);
            }
            sr.Close();
        }

        private void ReadConfigFile(string path)
        { 
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] str = line.Split('\t');
                var id = System.Int32.Parse(str[0]);
                if (!m_hurdle2Obj.ContainsKey(id))
                    m_hurdle2Obj[id] = new List<List<string>>();
                m_hurdle2Obj[id].Add(ReadSceneObj(str[1]));
                if (!m_hurdle2Trigger.ContainsKey(id))
                    m_hurdle2Trigger[id] = new List<int>();
                m_hurdle2Trigger[id].Add(System.Int32.Parse(str[2]));
                if (!m_hurdle2play.ContainsKey(id))
                    m_hurdle2play[id] = new List<int>();
                m_hurdle2play[id].Add(System.Int32.Parse(str[3]));
                if (!m_hurdle2des.ContainsKey(id))
                    m_hurdle2des[id] = new List<string>();
                m_hurdle2des[id].Add(str[4]);
            }
            sr.Close();
        }

        private KeyValue<string,Dictionary<string,string>> ReadContentFunc(int sceneplayId, string str, int index)
        {
            var list = str.Split(';');
            var funcName = list[0];
            var paramList = new Dictionary<string, string>();
            int paramIndex = 2;
            for(var i=1;i<list.Length;i++)
            {
                var param = list[i];
                var match = Regex.Match(param, @"([\w]+) *= *(.+)");
                if (match.Groups.Count > 1)
                {
                    var paramType = match.Groups[1].ToString();
                    var paramStr = match.Groups[2].ToString();
                    paramList[paramType] = paramStr.Replace(',','\n');
                }
                else
                {
                    if (param == "")
                        continue;
                    paramList[paramIndex.ToString()] = param;
                    ++paramIndex;
                }
            }
            return new KeyValue<string, Dictionary<string, string>>(funcName,paramList);
        }

        private List<string> ReadSceneObj(string str)
        {
            var list = new List<string>();
            string[] p = str.Split(';');
            foreach(var s in p)
            {
                var match = Regex.Match(s, @"[a-z]+_([0-9]+) *= *[0-9]+ *, *([\w ]+)");
                if (match.Groups.Count > 1)
                {
                    var id = System.Int32.Parse(match.Groups[1].ToString());
                    var name = match.Groups[2].ToString();
                    list.Add(name);
                }

            }
            return list;
        }

        public void WriteConfigFile(string path)
        {
            StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
            sw.WriteLine("o\ts\tn\tn\tb");
            sw.WriteLine("关卡id\t登场对象\t剧情触发器\t剧情编号\t备注");
            sw.WriteLine("hurdleid\tscene_obj\ttriggerid\tplayid\tb");
            foreach (var hurdle_id in m_hurdle2play.Keys)
            {
                for (int i = 0; i < m_hurdle2play[hurdle_id].Count; ++i)
                {
                    var linePlayid = m_hurdle2play[hurdle_id][i];
                    var lineTriggerid = m_hurdle2Trigger[hurdle_id][i];
                    var ObjList = m_hurdle2Obj[hurdle_id][i];
                    var lineDes = m_hurdle2des[hurdle_id][i];
                    var lineObj = "";
                    for (int j = 0; j < ObjList.Count; ++j)
                    {
                        lineObj += string.Format("aside_{0}=1,{1};",j+1,ObjList[j]);
                    }
                    if (lineObj == "")
                        lineObj = "aside_1=1, ;";
                    string line = string.Format("{0}\t{1}\t{2}\t{3}\t{4}",hurdle_id,lineObj,lineTriggerid,linePlayid,lineDes);
                    sw.WriteLine(line);
                }
            }
            sw.Close();
        }

        public void WriteContentFile(string path)
        {
            StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
            sw.WriteLine("o\tn\ts\ts\tn\ts\tn\tn\tn\tn\tn\tn\ts");
            sw.WriteLine("剧情id：60021000～60050999\t人物位置(0中间 1左边 2右边）\t剧情操作对象\t操作类型\t操作内容\t角色头像路径\t语音id\t是否自动播放下一句剧情（非自动则点击播放下一句）\t是否显示跳过（0无跳过，1有跳过）\t是否开启黑幕\t是否开启暂停（0暂停，1开启）\t是否mmo剧情（0关卡，1mmo）\t备注");
            sw.WriteLine("playid\tactor_pos\tactor\tactiontype\taction\ticon_path\taudio_id\tis_auto\tis_skip\tis_black\tis_pause\tis_mmo\tdes");
            foreach (var playid_id in m_play2pos.Keys)
            {
                for (int i = 0; i < m_play2pos[playid_id].Count; ++i)
                {
                    var linePos = m_play2pos[playid_id][i];
                    var lineActor = m_play2actor[playid_id][i];
                    var lineIcon = m_play2Icon[playid_id][i];
                    var lineAudio = m_play2audio[playid_id][i];
                    var lineDes = m_play2Des[playid_id][i];
                    var listSwitch = m_play2switch[playid_id][i];
                    var act = m_play2act[playid_id][i];
                    var str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}", 
                        playid_id, linePos, actor2string(lineActor), act.Key, func2string(act), lineIcon, lineAudio, bool2int(listSwitch[0]), bool2int(listSwitch[1]), bool2int(listSwitch[2]), bool2int(listSwitch[3]), bool2int(listSwitch[4]), lineDes);
                    sw.WriteLine(str);
                }
            }
            sw.Close();
        }

        private string actor2string(int id)
        {
            return id == 0 ? "0" : string.Format("aside_{0}", id);
        }

        private string func2string(KeyValue<string,object> act)
        { 
            if (act.Key == "func")
            {
                var info = (KeyValue<string, Dictionary<string, string>>)act.Value;
                var funcName = info.Key;
                var paramList = info.Value;
                var str = string.Format("{0};",funcName);
                foreach(var param in paramList.Keys)
                {
                    var value = paramList[param];
                    str = string.Format("{0}{1}={2};", str, param, value.Replace('\n',','));
                }
                return str;
            }
            else if (act.Key == "talk")
            {
                return (string)act.Value;
            }
            else
            {
                return "0";
            }
        }

        private int bool2int(bool b)
        {
            return b ? 1 : 0;
        }
    }
}
