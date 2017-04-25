using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.data
{
    class ContentManager
    {
        string m_FilePath;
        Dictionary<int, List<SceneplayInfo>> m_play = new Dictionary<int, List<SceneplayInfo>>();
        public delegate void UpdateScreenplayNode(int screenplay_id, int hurdle_id=-1);
        public Dictionary<int, UpdateScreenplayNode> m_UpdateScreenplay = new Dictionary<int,UpdateScreenplayNode>();
        public delegate void UpdateFuncNode(int index);
        public Dictionary<int, UpdateFuncNode> m_UpdateFunc = new Dictionary<int, UpdateFuncNode>();
        public ContentManager(string file_path)
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
                    si.SetActInfo(str[4]);

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

        public bool Save()
        {
            try
            {
                StreamWriter sw = new StreamWriter(m_FilePath,false,Encoding.UTF8);
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
                        var lineAction = m_play[playid_id][i].ActInfo.ToString();
                        var str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}", 
                            playid_id, linePos, actor2string(lineActor), lineType, lineAction, lineIcon, lineAudio, m_play[playid_id][i].GetSwitchToStr(0), m_play[playid_id][i].GetSwitchToStr(1), m_play[playid_id][i].GetSwitchToStr(2), m_play[playid_id][i].GetSwitchToStr(3), m_play[playid_id][i].GetSwitchToStr(4), lineDes);
                        sw.WriteLine(str);
                    }
                }
                sw.Close();
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
                return false;
            }
        }

        private string actor2string(int id)
        {
            return id == 0 ? "0" : string.Format("aside_{0}", id);
        }

        public List<SceneplayInfo> GetInfoList(int sceenplay_id)
        {
            if (m_play.ContainsKey(sceenplay_id))
                return m_play[sceenplay_id];
            else
                return null;
        }

        public SceneplayInfo GetFuncInfo(int screenplay_id,int index)
        {
            var _screenplay = GetInfoList(screenplay_id);
            if (_screenplay == null)
                return null;
            if (_screenplay.Count <= index)
                return null;
            return _screenplay[index];
        }

        public Dictionary<int, List<SceneplayInfo>>.KeyCollection GetSceenplayList()
        {
            return m_play.Keys;
        }

        public void CreateNewAction(int screenplay_id)
        {
            if (!m_play.ContainsKey(screenplay_id))
                return;
            var act = new SceneplayInfo(screenplay_id, m_play[screenplay_id].Count);
            m_play[screenplay_id].Add(act);
            if (m_UpdateScreenplay.ContainsKey(screenplay_id))
                m_UpdateScreenplay[screenplay_id](screenplay_id);
        }

        public bool CreateNewScreenplay(int screenplay_id)
        {
            if (m_play.ContainsKey(screenplay_id))
                return false;
            else
            {
                m_play[screenplay_id] = new List<SceneplayInfo>();
                return true;
            }
        }

        public void RemoveSceenplay(int id)
        {
            int count = FileManager.GetInstance().ConfigMgr.GetSceenplayCount(id);
            if (count == 0)
            {
                m_play.Remove(id);
            }
        }

        public bool RemoveAction(int screenplay_id, int index)
        {
            if (!m_play.ContainsKey(screenplay_id))
                return false;
            var screenplay = m_play[screenplay_id];
            if (screenplay.Count <= index)
                return false;
            screenplay.RemoveAt(index);
            if (m_UpdateScreenplay.ContainsKey(screenplay_id))
                m_UpdateScreenplay[screenplay_id](screenplay_id);
            return true;
        }

        public bool ExchangeSceenplayID(int hurdle_id, int new_id, int old_id)
        {
            if (m_play.ContainsKey(new_id))
            {
                var ret = MessageBox.Show("是否重置节点?●﹏●", "id已存在", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No)
                    return false;
            }
            else
            {
                int count = FileManager.GetInstance().ConfigMgr.GetSceenplayCount(old_id);
                if (count >= 2)
                {
                    var ret = MessageBox.Show("是否复制~>_<~", "该id被多个地方引用了", MessageBoxButtons.YesNo);
                    switch (ret)
                    {
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            return false;
                    }
                    if (m_play.ContainsKey(new_id))
                        m_play[new_id].Clear();
                    else
                        m_play[new_id] = new List<SceneplayInfo>();
                    for(int i=0;i<m_play[old_id].Count;++i)
                    {
                        m_play[new_id].Add(new SceneplayInfo(m_play[old_id][i], new_id, i));
                    }
                }
                else
                {
                    if(m_play.ContainsKey(old_id))
                        m_play[new_id] = m_play[old_id];
                }
            }
            FileManager.GetInstance().ConfigMgr.ChangeSceenplay(hurdle_id, old_id, new_id);
            RemoveSceenplay(old_id);
            if (m_UpdateScreenplay.ContainsKey(old_id))
                m_UpdateScreenplay[old_id](new_id, hurdle_id);
            return true;
        }

        public void MoveDownFunc(int screenplay_id, int func_index)
        {
            if (!m_play.ContainsKey(screenplay_id))
                return;
            var screenplay = m_play[screenplay_id];
            if (func_index + 1 >= screenplay.Count)
                return;
            var curNode = screenplay[func_index];
            screenplay.RemoveAt(func_index);
            screenplay.Insert(func_index + 1, curNode);
            ++DataCenter.curFuncIndex;
            if (m_UpdateScreenplay.ContainsKey(screenplay_id))
                m_UpdateScreenplay[screenplay_id](screenplay_id);
        }

        public void MoveUpFunc(int screenplay_id, int func_index)
        {
            if (!m_play.ContainsKey(screenplay_id))
                return;
            var screenplay = m_play[screenplay_id];
            if (func_index <= 0)
                return;
            var curNode = screenplay[func_index];
            screenplay.RemoveAt(func_index);
            screenplay.Insert(func_index - 1, curNode);
            --DataCenter.curFuncIndex;
            if (m_UpdateScreenplay.ContainsKey(screenplay_id))
                m_UpdateScreenplay[screenplay_id](screenplay_id);
        }

        public void ChangeFunc(int screenplay_id, int index, string new_func_name)
        {
            var _funcInfo = GetFuncInfo(screenplay_id, index);
            if(_funcInfo.ActInfo.Name != new_func_name)
            {
                if (new_func_name == "talk")
                {
                    var at = new ActionTalk();
                    at.File = "screenplay";
                    _funcInfo.ActInfo = at;
                    _funcInfo.ActType = "talk";
                }
                else
                {
                    var funcCfg = FileManager.GetInstance().FuncCfgMgr.GetFuncCfg(new_func_name);
                    _funcInfo.ActType = "func";
                    _funcInfo.ActInfo = new FuncInfo(new_func_name, funcCfg);
                }
                if (m_UpdateFunc.ContainsKey(screenplay_id))
                    m_UpdateFunc[screenplay_id](index);
            }
        }

        public void ChangeFuncRemark(int screenplay_id, int index, string text)
        {
            var _funcInfo = GetFuncInfo(screenplay_id, index);
            _funcInfo.Describe = text;
            if (m_UpdateFunc.ContainsKey(screenplay_id))
                m_UpdateFunc[screenplay_id](index);
        }

    }
}
