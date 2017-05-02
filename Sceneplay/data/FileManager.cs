using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay.data
{
    class FileManager
    {
        private static FileManager _instance = null;
        public static FileManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FileManager();
                }
                return _instance;
            }
        }
        private FileManager()
        {
        }

        StringCfgInfo m_StringCfg = null;
        public static StringCfgInfo StringCfg
        {
            get {
                if (Instance.m_StringCfg == null)
                    Instance.m_StringCfg = new StringCfgInfo("string/");
                return Instance.m_StringCfg; 
            }
        }
        FuncCfgManager m_FuncCfgMgr = null;
        public static FuncCfgManager FuncCfgMgr
        {
            get { 
                if (Instance.m_FuncCfgMgr == null)
                    Instance.m_FuncCfgMgr = new FuncCfgManager("func_info.txt");
                return Instance.m_FuncCfgMgr;
            }
        }
        ContentManager m_ContentMgr = null;
        public static ContentManager ContentMgr
        {
            get { 
                if(Instance.m_ContentMgr == null)
                    Instance.m_ContentMgr = new ContentManager("config/hurdle/hurdle_screenplay/screenplay_content.txt");
                return Instance.m_ContentMgr;
            }
        }
        ConfigManager m_ConfigMgr = null;
        public static ConfigManager ConfigMgr
        {
            get {
                if(Instance.m_ConfigMgr == null)
                    Instance.m_ConfigMgr = new ConfigManager("config/hurdle/hurdle_screenplay/screenplay_config.txt");
                return Instance.m_ConfigMgr;
            }
        }

        TriggerCfgManager m_TriggerCfgMgr = null;
        public static TriggerCfgManager TriggerCfgMgr
        {
            get {
                if(Instance.m_TriggerCfgMgr == null)
                    Instance.m_TriggerCfgMgr = new TriggerCfgManager("config/trigger_config.txt");
                return Instance.m_TriggerCfgMgr;
            }
        }
        public void ReadFile()
        {
            m_StringCfg = null;
            m_FuncCfgMgr = null;
            m_ContentMgr = null;
            m_ConfigMgr = null;
            m_TriggerCfgMgr = null;
        }

        public bool Save()
        {
            var ret2 = m_ConfigMgr.Save();
            var ret3 = m_ContentMgr.Save();
            return ret2 && ret3;
        }

    }
}
