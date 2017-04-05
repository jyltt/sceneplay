using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.data
{
    class ConfigManager
    {
        string m_FilePath;
        public Dictionary<int, List<HurdleInfo>> m_hurdle = new Dictionary<int, List<HurdleInfo>>();
        public ConfigManager(string file_path)
        {
            m_FilePath = file_path;
            ReadFile();
        }

        void ReadFile()
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
    }
}
