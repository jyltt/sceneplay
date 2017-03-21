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

        public void ReadFile()
        {
        }
    }
}
