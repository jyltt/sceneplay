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
    class ReadFile
    {
        public Dictionary<int, List<HurdleInfo>> m_hurdle = new Dictionary<int, List<HurdleInfo>>();

        public Dictionary<int, List<SceneplayInfo>> m_play = new Dictionary<int, List<SceneplayInfo>>();

        //public Dictionary<string, Dictionary<string, string>> m_func2param = new Dictionary<string, Dictionary<string, string>>();
        //public Dictionary<string, string> m_func2des = new Dictionary<string, string>();
        public Dictionary<string, FuncCfgInfo> m_funcCfgList = new Dictionary<string, FuncCfgInfo>();

        public Dictionary<int, int> m_play2flg = new Dictionary<int, int>();
        public List<string> m_funcList = new List<string>();
        public Dictionary<string, int> m_talk2flg = new Dictionary<string, int>();

        public StringCfgInfo m_StringCfg;

        public ReadFile()
        {
            ReadConfigFile(GetPath() + "screenplay_config.txt");
            ReadContentFile(GetPath() + "screenplay_content.txt");
            ReadFuncCfgFile("func_info.txt");
            m_StringCfg = new StringCfgInfo("string/screenplay.txt");
        }

        public string GetPath()
        {
            return "config/hurdle/hurdle_screenplay/";
        }

        private void ReadFuncCfgFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
                string funcName = "";
                while ((line = sr.ReadLine()) != null)
                {
                    do
                    {
                        var func = Regex.Match(line, @"function (?:TriggerFunc\.)*([\w^( ]+)");
                        if (func.Groups.Count > 1)
                        {
                            funcName = func.Groups[1].ToString();
                            m_funcList.Add(funcName);
                            m_funcCfgList[funcName] = new FuncCfgInfo(funcName);
                            break;
                        }
                        var param = Regex.Match(line, @"([a-zA-Z0-9_]+)=([\S]+) +([\S]+)");
                        if (param.Groups.Count > 1)
                        {
                            var paramType = param.Groups[1].ToString();
                            var paramDefValue = param.Groups[2].ToString();
                            var paramDes = param.Groups[3].ToString();
                            if (m_funcCfgList.ContainsKey(funcName))
                                m_funcCfgList[funcName].AddParam(new ParamInfo(paramType, paramDes, paramDefValue));
                            break;
                        }
                        var param2 = Regex.Match(line, @"([a-zA-Z0-9_]+) +([\S]+)");
                        if (param2.Groups.Count > 1)
                        {
                            var paramType = param2.Groups[1].ToString();
                            var paramDes = param2.Groups[2].ToString();
                            if (m_funcCfgList.ContainsKey(funcName))
                                m_funcCfgList[funcName].AddParam(new ParamInfo(paramType, paramDes));
                            break;
                        }
                        var des = Regex.Match(line, @"^(.+)$");
                        if (des.Groups.Count > 1)
                        {
                            if (m_funcCfgList.ContainsKey(funcName))
                            {
                                m_funcCfgList[funcName].Describe += des.Groups[1].ToString();
                                m_funcCfgList[funcName].Describe += "\n";
                            }
                            break;
                        }
                    }
                    while (false);
                }
                sr.Close();
                m_funcCfgList["talk"] = new FuncCfgInfo("talk");
                m_funcCfgList["talk"].AddParam(new ParamInfo("gs_screenplay","对话内容"));
                m_funcCfgList["talk"].Describe = "对话内容";
                m_funcList.Add("talk");
                m_funcList.Sort();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
        }

        private void ReadContentFile(string path)
        { 
            try
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
                    if (!m_play.ContainsKey(id))
                        m_play[id] = new List<SceneplayInfo>();
                    var si = new SceneplayInfo(id,m_play[id].Count);
                    si.Pos = System.Int32.Parse(str[1]);

                    var match = Regex.Match(str[2], @"[a-z]+_([0-9]+)");
                    if (match.Groups.Count > 1)
                    {
                        var index = System.Int32.Parse(match.Groups[1].ToString());
                        si.ActorID = index;
                    }
                    else 
                    {
                        si.ActorID = 0;
                    }

                    var type = str[3];
                    si.ActType = type;
                    if (type == "func")
                    {
                        si.SetActInfo(str[4]);
                    }
                    else if(type == "talk")
                    {
                        var list = str[4].Split('.');
                        si.ActTalk = list[list.Length-1];
                        if (!m_talk2flg.ContainsKey(si.ActTalk))
                            m_talk2flg[si.ActTalk] = 0;
                        ++m_talk2flg[si.ActTalk];
                    }

                    si.IconPath = str[5];
                    si.Audio = System.Int32.Parse(str[6]);
                    si.SetSwitch(0, System.Int32.Parse(str[7]) == 1);
                    si.SetSwitch(1, System.Int32.Parse(str[8]) == 1);
                    si.SetSwitch(2, System.Int32.Parse(str[9]) == 1);
                    si.SetSwitch(3, System.Int32.Parse(str[10]) == 1);
                    si.SetSwitch(4, System.Int32.Parse(str[11]) == 1);
                    si.Describe = str[12];

                    m_play[id].Add(si);
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
        }

        private void ReadConfigFile(string path)
        {
            try
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
                    if (!m_hurdle.ContainsKey(id))
                        m_hurdle[id] = new List<HurdleInfo>();
                    var hi = new HurdleInfo(id, m_hurdle[id].Count);
                    var list = ReadSceneObj(str[1]);
                    for (int i = 0; i < list.Count; ++i)
                    {
                        hi.AddObj(list[i]);
                    }
                    hi.TriggerID = System.Int32.Parse(str[2]);
                    var play_id = System.Int32.Parse(str[3]);
                    hi.SceneplayID = play_id;
                    if (!m_play2flg.ContainsKey(play_id))
                        m_play2flg[play_id] = 0;
                    ++m_play2flg[play_id];
                    hi.Describe = str[4];
                    m_hurdle[id].Add(hi);
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
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
            try
            {
                StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
                sw.WriteLine("o\ts\tn\tn\tb");
                sw.WriteLine("关卡id\t登场对象\t剧情触发器\t剧情编号\t备注");
                sw.WriteLine("hurdleid\tscene_obj\ttriggerid\tplayid\tb");
                foreach (var hurdle_id in m_hurdle.Keys)
                {
                    for (int i = 0; i < m_hurdle[hurdle_id].Count; ++i)
                    {
                        var linePlayid = m_hurdle[hurdle_id][i].SceneplayID;
                        var lineTriggerid = m_hurdle[hurdle_id][i].TriggerID;
                        var ObjList = m_hurdle[hurdle_id][i].ObjList;
                        var lineDes = m_hurdle[hurdle_id][i].Describe;
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
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
        }

        public void WriteContentFile(string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
                sw.WriteLine("o\tn\ts\ts\tn\ts\tn\tn\tn\tn\tn\tn\ts");
                sw.WriteLine("剧情id：60021000～60050999\t人物位置(0中间 1左边 2右边）\t剧情操作对象\t操作类型\t操作内容\t角色头像路径\t语音id\t是否自动播放下一句剧情（非自动则点击播放下一句）\t是否显示跳过（0无跳过，1有跳过）\t是否开启黑幕\t是否开启暂停（0暂停，1开启）\t是否mmo剧情（0关卡，1mmo）\t备注");
                sw.WriteLine("playid\tactor_pos\tactor\tactiontype\taction\ticon_path\taudio_id\tis_auto\tis_skip\tis_black\tis_pause\tis_mmo\tdes");
                foreach (var playid_id in m_play.Keys)
                {
                    for (int i = 0; i < m_play[playid_id].Count; ++i)
                    {
                        var linePos = m_play[playid_id][i].Pos;
                        var lineActor = m_play[playid_id][i].ActorID;
                        var lineIcon = m_play[playid_id][i].IconPath;
                        var lineAudio = m_play[playid_id][i].Audio;
                        var lineDes = m_play[playid_id][i].Describe;
                        var lineType = m_play[playid_id][i].ActType;
                        var lineAction = m_play[playid_id][i].GetAct();
                        var str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}", 
                            playid_id, linePos, actor2string(lineActor), lineType, lineAction, lineIcon, lineAudio, m_play[playid_id][i].GetSwitchToStr(0), m_play[playid_id][i].GetSwitchToStr(1), m_play[playid_id][i].GetSwitchToStr(2), m_play[playid_id][i].GetSwitchToStr(3), m_play[playid_id][i].GetSwitchToStr(4), lineDes);
                        sw.WriteLine(str);
                    }
                }
                sw.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
        }

        private string actor2string(int id)
        {
            return id == 0 ? "0" : string.Format("aside_{0}", id);
        }

        public SceneplayInfo CreateFunc(int play_id, string funcName)
        {
            var si = new SceneplayInfo(play_id,m_play[play_id].Count);
            m_play[play_id].Add(si);
            return si;
        }

        public void DeleteFunc(int sceneplay_id, int index)
        {
            m_play[sceneplay_id].Remove(m_play[sceneplay_id][index]);
        }

        public void CreatePlayid(int hurdle_id, int play_id)
        {
            var hi = new HurdleInfo(hurdle_id,m_hurdle[hurdle_id].Count);
            hi.SceneplayID = play_id;
            m_hurdle[hurdle_id].Add(hi);

            if (!m_play2flg.ContainsKey(play_id))
                m_play2flg[play_id] = 0;
            ++m_play2flg[play_id];

            m_play[play_id] = new List<SceneplayInfo>();
        }

        public void RemovePlayid(int sceneplay_id, int hurdle_id, int index)
        {
            m_hurdle[hurdle_id].RemoveAt(index);

            if (m_play2flg.ContainsKey(sceneplay_id))
                --m_play2flg[sceneplay_id];
            if (m_play2flg[sceneplay_id] > 0)
                return;

            m_play.Remove(sceneplay_id);
        }

        public void ChangePlayid1(int old_id, int new_id)
        {
            var oldAct = m_play[old_id];
            if(m_play2flg[old_id] >= 2)
            {
                if (m_play.ContainsKey(new_id))
                {
                    for (int i = 0; i < m_play[new_id].Count;++i)
                    {
                        if(m_play[new_id][i].ActTalk == "talk")
                        {
                            --m_talk2flg[m_play[new_id][i].ActTalk];
                        }
                    }
                    m_play[new_id].Clear();
                }
                else
                    m_play[new_id] = new List<SceneplayInfo>();
                for (int i = 0; i < oldAct.Count; ++i)
                {
                    m_play[new_id].Add(new SceneplayInfo(oldAct[i], new_id, i));
                    if (oldAct[i].ActType == "talk")
                    {
                        ++m_talk2flg[oldAct[1].ActTalk];
                    }
                }
            }
            else
                m_play[new_id] = oldAct;
        }

        public void ChangePlayid2(int old_id, int hurdle_id, int id, int new_id)
        { 
            m_hurdle[hurdle_id][id].SceneplayID = new_id;

            if (!m_play2flg.ContainsKey(new_id))
                m_play2flg[new_id] = 0;
            ++m_play2flg[new_id];
            if (m_play2flg.ContainsKey(old_id))
                --m_play2flg[old_id];

            if (m_play2flg[old_id] <= 0)
            {
                m_play.Remove(old_id);
            }
        }

        public bool ChangeHurdleid(int old_id,int new_id)
        {
            if (m_hurdle.ContainsKey(new_id))
            {
                MessageBox.Show("该关卡id已存在\\('o'/)");
                return false;
            }
            var oldDes = m_hurdle[old_id];
            m_hurdle[new_id] = oldDes;

            m_hurdle.Remove(old_id);
            return true;
        }

        public void CreateHurdle(int id)
        {
            m_hurdle[id] = new List<HurdleInfo>();
        }

        public void DeleteHurdle(int id)
        {
            var playid_list = m_hurdle[id];
            for (var i = playid_list.Count - 1; i >= 0; --i)
            {
                RemovePlayid(playid_list[i].SceneplayID, id, i);
            }
            m_hurdle.Remove(id);
        }

        public string GetReferenceListStr(int sceneplay_id)
        {
            string str = "";
            var dic = new Dictionary<int, int>();
            foreach (var hurdleList in m_hurdle)
            {
                foreach (var hurdleInfo in hurdleList.Value)
                {
                    if (hurdleInfo.SceneplayID == sceneplay_id)
                    {
                        dic[hurdleInfo.HurdleID] = 1;
                    }
                }
            }
            foreach (var hurdle_id in dic)
            {
                str += hurdle_id.Key.ToString()+"\n";
            }
            return str;
        }

        public void ChangeString(string str, string param)
        {
            var ret = m_StringCfg.ChangeString(str, param);
            if (ret == -1)
                --m_talk2flg[str];
            if (ret == 1)
            {
                if (!m_talk2flg.ContainsKey(str))
                    m_talk2flg[str] = 0;
                ++m_talk2flg[str];
            }
        }
    }
}
