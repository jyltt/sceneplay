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
            get { return FuncCfgMgr; }
        }
        ContentManager m_ContentMgr;
        public FuncCfgManager ContentMgr
        {
            get { return ContentMgr; }
        }

        public void ReadFile()
        {
            m_StringCfg = new StringCfgInfo("string/screenplay.txt");
            m_FuncCfgMgr = new FuncCfgManager("func_info.txt");
            m_ContentMgr = new ContentManager("config/hurdle/hurdle_screenplay/screenplay_config.txt");
        }

    }
}
