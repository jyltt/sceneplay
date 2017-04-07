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
        public static FileManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileManager();
            }
            return _instance;
        }
        private FileManager()
        {
            ReadFile();
        }

        StringCfgInfo m_StringCfg;
        public StringCfgInfo StringCfg
        {
            get { return m_StringCfg; }
        }
        FuncCfgManager m_FuncCfgMgr;
        public FuncCfgManager FuncCfgMgr
        {
            get { return m_FuncCfgMgr; }
        }
        ContentManager m_ContentMgr;
        public ContentManager ContentMgr
        {
            get { return m_ContentMgr; }
        }
        ConfigManager m_ConfigMgr;
        public ConfigManager ConfigMgr
        {
            get { return m_ConfigMgr; }
        }

        public void ReadFile()
        {
            m_StringCfg = new StringCfgInfo("string/screenplay.txt");
            m_FuncCfgMgr = new FuncCfgManager("func_info.txt");
            m_ContentMgr = new ContentManager("config/hurdle/hurdle_screenplay/screenplay_content.txt");
            m_ConfigMgr = new ConfigManager("config/hurdle/hurdle_screenplay/screenplay_config.txt");
        }

    }
}
