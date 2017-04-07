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
    class ConfigManager
    {
        string m_FilePath;
        Dictionary<int, List<HurdleInfo>> m_hurdle = new Dictionary<int, List<HurdleInfo>>();
        public ConfigManager(string file_path)
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
                    hi.Describe = str[4];
                    m_hurdle[id].Add(hi);
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
            }
        }

        List<string> ReadSceneObj(string str)
        {
            var list = new List<string>();
            string[] p = str.Split(';');
            foreach (var s in p)
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

        public void Save()
        {
            try
            {
                StreamWriter sw = new StreamWriter(m_FilePath,false,Encoding.UTF8);
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

        public Dictionary<int, List<HurdleInfo>>.KeyCollection GetHurdleList()
        {
            return m_hurdle.Keys;
        }

        public List<HurdleInfo> GetContList(int hurdle_id)
        {
            if (m_hurdle.ContainsKey(hurdle_id))
                return m_hurdle[hurdle_id];
            else
                return new List<HurdleInfo>();
        }
    }
}
