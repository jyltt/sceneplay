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
    class FuncCfgManager
    {
        string m_FilePath;
        List<string> m_funcList = new List<string>();
        Dictionary<string, FuncCfgInfo> m_funcCfgList = new Dictionary<string, FuncCfgInfo>();
        
        public FuncCfgManager(string file_path)
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
                string funcName = "";
                while ((line = sr.ReadLine()) != null)
                {
                    do
                    {
                        var func = Regex.Match(line, @"function\t(?:TriggerFunc\.)*([\w^( ]+)");
                        if (func.Groups.Count > 1)
                        {
                            funcName = func.Groups[1].ToString();
                            m_funcList.Add(funcName);
                            m_funcCfgList[funcName] = new FuncCfgInfo(funcName);
                            break;
                        }
                        var param = Regex.Match(line, @"param\t([a-zA-Z0-9]+)\t([a-zA-Z0-9_]+)=([\S]+)\t([\S]+)");
                        if (param.Groups.Count > 1)
                        {
                            var paramType = param.Groups[1].ToString();
                            var paramName = param.Groups[2].ToString();
                            var paramDefValue = param.Groups[3].ToString();
                            var paramDes = param.Groups[4].ToString();
                            if (m_funcCfgList.ContainsKey(funcName))
                                m_funcCfgList[funcName].AddParam(new ParamInfo(paramType, paramName, paramDes, paramDefValue));
                            break;
                        }
                        var param2 = Regex.Match(line, @"param\t([a-zA-Z0-9]+)\t([a-zA-Z0-9_]+)\t([\S]+)");
                        if (param2.Groups.Count > 1)
                        {
                            var paramType = param2.Groups[1].ToString();
                            var paramName = param2.Groups[2].ToString();
                            var paramDes = param2.Groups[3].ToString();
                            if (m_funcCfgList.ContainsKey(funcName))
                                m_funcCfgList[funcName].AddParam(new ParamInfo(paramType, paramName, paramDes));
                            break;
                        }
                        var des = Regex.Match(line, @"^(.+)$");
                        if (des.Groups.Count > 1)
                        {
                            if (m_funcCfgList.ContainsKey(funcName))
                            {
                                m_funcCfgList[funcName].Describe += des.Groups[1].ToString();
                                m_funcCfgList[funcName].Describe += "\n";
                            }
                            break;
                        }
                    }
                    while (false);
                }
                sr.Close();
                m_funcCfgList["talk"] = new FuncCfgInfo("talk");
                m_funcCfgList["talk"].AddParam(new ParamInfo("string","gs_screenplay","对话内容"));
                m_funcCfgList["talk"].Describe = "对话内容";
                m_funcList.Add("talk");
                m_funcList.Sort();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Msg:" + ex.Message,"文件被占用了。(─.─|||");
            }
        }

        public List<string> FileList
        {
            get { return m_funcList; } 
        }
        public FuncCfgInfo GetFuncCfg(string name)
        {
            if (m_funcCfgList.ContainsKey(name))
                return m_funcCfgList[name];
            else
                return null;
        }
    }
}
