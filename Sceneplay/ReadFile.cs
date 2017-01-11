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

        public Dictionary<int, List<int>> m_play2pos = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> m_play2actor = new Dictionary<int, List<int>>();
        public Dictionary<int, List<string>> m_play2Icon = new Dictionary<int, List<string>>();
        public Dictionary<int, List<int>> m_play2audio = new Dictionary<int, List<int>>();
        public Dictionary<int, List<string>> m_play2Des = new Dictionary<int, List<string>>();
        public Dictionary<int, List<List<bool>>> m_play2switch = new Dictionary<int, List<List<bool>>>();
        public Dictionary<int, List<KeyValuePair<string,object>>> m_play2act = new Dictionary<int,List<KeyValuePair<string,object>>>();

        public Dictionary<string, Dictionary<string, string>> m_func2param = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<string, string> m_func2des = new Dictionary<string, string>();

        public ReadFile()
        {
            string path = "";
            ReadConfigFile(path + "screenplay_config.txt");
            ReadContentFile(path + "screenplay_content.txt");
            ReadFuncCfgFile(path + "func_info.txt");

            WriteConfigFile(path + "a.txt");
            WriteContentFile(path + "b.txt");
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
            m_func2param["chat"] = new Dictionary<string, string>();
            m_func2param["chat"]["gs_screenplay"] = "对话内容";
            m_func2des["chat"] = "对话内容";
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

                if (!m_play2act.ContainsKey(id))
                    m_play2act[id] = new List<KeyValuePair<string, object>>();
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
                var act = new KeyValuePair<string, object>(type, obj);
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
            }
            sr.Close();
        }

        private KeyValuePair<string,Dictionary<string,string>> ReadContentFunc(int sceneplayId, string str, int index)
        {
            var list = str.Split(';');
            var funcName = list[0];
            var paramList = new Dictionary<string, string>();
            int paramIndex = 2;
            for(var i=1;i<list.Length;i++)
            {
                var param = list[i];
                var match = Regex.Match(param, @"([\w]+) *= *([\w ]+)");
                if (match.Groups.Count > 1)
                {
                    var paramType = match.Groups[1].ToString();
                    var paramStr = match.Groups[2].ToString();
                    paramList[paramType] = paramStr;
                }
                else
                {
                    paramList[paramIndex.ToString()] = param;
                    ++paramIndex;
                }
            }
            return new KeyValuePair<string, Dictionary<string, string>>(funcName,paramList);
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
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("o\ts\tn\tn\tb");
            sw.WriteLine("关卡id\t登场对象\t剧情触发器\t剧情编号\t备注");
            sw.WriteLine("hurdleid\tscene_obj\ttriggerid\tplayid\tb");
            sw.Close();
        }

        public void WriteContentFile(string path)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("o\tn\ts\ts\tn\ts\tn\tn\tn\tn\tn\tn\ts");
            sw.WriteLine("剧情id：60021000～60050999\t人物位置(0中间 1左边 2右边）\t剧情操作对象\t操作类型\t操作内容\t角色头像路径\t语音id\t是否自动播放下一句剧情（非自动则点击播放下一句）\t是否显示跳过（0无跳过，1有跳过）\t是否开启黑幕\t是否开启暂停（0暂停，1开启）\t是否mmo剧情（0关卡，1mmo）\t备注");
            sw.WriteLine("playid\tactor_pos\tactor\tactiontype\taction\ticon_path\taudio_id\tis_auto\tis_skip\tis_black\tis_pause\tis_mmo\tdes");
            sw.Close();
        }
    }
}
