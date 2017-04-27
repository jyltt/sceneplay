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
        private string m_FilePath;
        private Dictionary<int, List<TriggerCfg>> m_TriggerCfgList = new Dictionary<int, List<TriggerCfg>>();

        public TriggerCfgManager(string file_path)
        {
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
                sr.ReadLine();
                sr.ReadLine();
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
                sw.WriteLine("触发器编号\t策划备注(隐藏列)\t触发阵营（0全体 1我方 2敌方 3中立）\t触发指定角色(说明参见document/design/配置表说明/trigger_config_触发器说明.xls)\t触发类型(1.进触发器,2.触发器中,3.出触发器 4进战斗 5出战斗 6属性发生改变 7怪物进战斗触发 8怪物组死亡触发 9过场动画结束触发 10玩家使用道具触发 11进范围启动定时器 12进入触发后区域随机Item 13活动3v3战斗结束,14刷怪波数触发，15添加buff触发)\t触发完成次数\t触发参数\t触发效果");
                sw.WriteLine("id\tpanning_remark\ttrigger_camp\ttrigger_role\ttrigger_type\ttrigger_count\ttrigger_param\ttrigger_effect");
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
                        string str = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}",
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
    }
}
