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
    class TriggerCfgManager
    {
        string m_FilePath;
        Dictionary<int, List<TriggerCfg>> m_TriggerCfgList = new Dictionary<int, List<TriggerCfg>>();
        Dictionary<string, string> m_TriggerRemarkList = new Dictionary<string,string>();
        List<string> m_FileTitle = new List<string>();

        public TriggerCfgManager(string file_path)
        {
            m_FileTitle.Add("id");
            m_FileTitle.Add("panning_remark");
            m_FileTitle.Add("trigger_camp");
            m_FileTitle.Add("trigger_role");
            m_FileTitle.Add("trigger_type");
            m_FileTitle.Add("trigger_count");
            m_FileTitle.Add("trigger_param");
            m_FileTitle.Add("trigger_effect");
            m_FilePath = file_path;
            ReadFile(m_FilePath);
        }

        void ReadFile(string file_path)
        {
            try
            {
                StreamReader sr = new StreamReader(file_path, Encoding.Default);
                String line;
                sr.ReadLine();
                line = sr.ReadLine();
                var _remarkList = line.Split('\t');
                line = sr.ReadLine();
                var _idList = line.Split('\t');
                for (int i = 0; i < _idList.Length; ++i)
                {
                    m_TriggerRemarkList[_idList[i]] = _remarkList[i];
                }
                while ((line = sr.ReadLine()) != null)
                {
                    var cfg = new TriggerCfg(line);
                    if (!m_TriggerCfgList.ContainsKey(cfg.ID))
                        m_TriggerCfgList[cfg.ID] = new List<TriggerCfg>();
                    m_TriggerCfgList[cfg.ID].Add(cfg);
                }
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
                StreamWriter sw = new StreamWriter(m_FilePath, false, Encoding.UTF8);
                sw.WriteLine("o\ts\tn\ts\tn\tn\ts\ts");
                //sw.WriteLine("触发器编号\t策划备注(隐藏列)\t触发阵营（0全体 1我方 2敌方 3中立）\t触发指定角色(说明参见document/design/配置表说明/trigger_config_触发器说明.xls)\t触发类型(1.进触发器,2.触发器中,3.出触发器 4进战斗 5出战斗 6属性发生改变 7怪物进战斗触发 8怪物组死亡触发 9过场动画结束触发 10玩家使用道具触发 11进范围启动定时器 12进入触发后区域随机Item 13活动3v3战斗结束,14刷怪波数触发，15添加buff触发)\t触发完成次数\t触发参数\t触发效果");
                //sw.WriteLine("id\tpanning_remark\ttrigger_camp\ttrigger_role\ttrigger_type\ttrigger_count\ttrigger_param\ttrigger_effect");
                string t1 = "";
                string t2 = "";
                for (int i = 0; i < m_FileTitle.Count;++i )
                {
                    if (i != 0)
                    {
                        t1 += '\t';
                        t2 += '\t';
                    }
                    var st = m_TriggerRemarkList[m_FileTitle[i]];
                    var kt = m_FileTitle[i];
                    t1 += st;
                    t2 += kt;
                }
                sw.WriteLine(t1);
                sw.WriteLine(t2);
                foreach (var id in m_TriggerCfgList.Keys)
                {
                    var cfgList = m_TriggerCfgList[id];
                    foreach (var cfg in cfgList)
                    {
                        string str_id = cfg.ID.ToString();
                        string str_remark = cfg.Remark.ToString();
                        string str_camp = cfg.Camp.ToString();
                        string str_role = cfg.Role.ToString();
                        string str_type = cfg.Type.ToString();
                        string str_count = cfg.Count.ToString();
                        string str_param = cfg.Param.ToString();
                        string str_effect = cfg.Effect.ToString();
                        string str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",
                            str_id, str_remark, str_camp, str_role, str_type, str_count, str_param, str_effect);
                        sw.WriteLine(str);
                    }
                }
                sw.Close();
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message, "文件被占用了。(─.─|||");
                return false;
            }
        }

        public Dictionary<int, List<TriggerCfg>>.KeyCollection GetAllList()
        {
            return m_TriggerCfgList.Keys;
        }

        public int GetTriggerList(int trigger_id)
        {
            if (m_TriggerCfgList.ContainsKey(trigger_id))
                return m_TriggerCfgList[trigger_id].Count;
            else
                return 0;
        }

        public TriggerCfg GetTriggerInfo(int trigger_id, int index)
        {
            if (!m_TriggerCfgList.ContainsKey(trigger_id))
                return null;
            var list = m_TriggerCfgList[trigger_id];
            if (list.Count <= index)
                return null;
            if (index < 0)
                return list[0];
            return list[index];
        }

        public string GetTriggerRemark(string key)
        {
            if (m_TriggerRemarkList.ContainsKey(key))
                return m_TriggerRemarkList[key];
            return "";
        }

        public bool ChangeTriggerRemark(string key, string str)
        {
            if (m_TriggerRemarkList.ContainsKey(key))
            {
                m_TriggerRemarkList[key] = str;
                return true;
            }
            return false; 
        }

        public bool ChangeTriggerID(int index, int old_id, int new_id)
        {
            if (!m_TriggerCfgList.ContainsKey(old_id))
                return false;
            var cfgList = m_TriggerCfgList[old_id];
            if (cfgList.Count <= index)
                return false;
            if (m_TriggerCfgList.ContainsKey(new_id))
            {
                var ret = MessageBox.Show("新触发器id(" + new_id.ToString() + ")已存在,是否合并", "触发器id冲突", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No)
                    return false;
            }
            else
            {
                m_TriggerCfgList[new_id] = new List<TriggerCfg>();
            }
            if (index < 0)
            {
                foreach(var cfg in cfgList)
                {
                    cfg.ID = new_id;
                    m_TriggerCfgList[new_id].Add(cfg);
                }
                m_TriggerCfgList.Remove(old_id);
            }
            else
            {
                var cfg = cfgList[index];
                cfg.ID = new_id;
                m_TriggerCfgList[new_id].Add(cfg);
                m_TriggerCfgList[old_id].RemoveAt(index);
                if (m_TriggerCfgList[old_id].Count == 0)
                    m_TriggerCfgList.Remove(old_id);
            }
            return true;
        }

        public void CreateNewTrigger(int new_id)
        {
            List<TriggerCfg> _cfgList;
            if (m_TriggerCfgList.ContainsKey(new_id))
            {
                _cfgList = m_TriggerCfgList[new_id];
            }
            else
            {
                _cfgList = new List<TriggerCfg>();
                m_TriggerCfgList[new_id] = _cfgList;
            }
            _cfgList.Add(new TriggerCfg(new_id));
        }

        public bool DeleteTrigger(int trigger_id, int index)
        {
            if (!m_TriggerCfgList.ContainsKey(trigger_id))
                return false;
            var _cfgList = m_TriggerCfgList[trigger_id];
            if (index >= _cfgList.Count)
                return false;
            if (index < 0)
            {
                m_TriggerCfgList.Remove(trigger_id);
            }
            else
            {
                _cfgList.RemoveAt(index);
                if (_cfgList.Count == 0)
                    m_TriggerCfgList.Remove(trigger_id);
            }
            return true;
        }
    }
}
