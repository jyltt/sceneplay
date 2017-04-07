using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sceneplay.data
{
    class ActionBase
    {
        string m_Name;
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        override public string ToString()
        {
            return "0";
        }
    }
}
