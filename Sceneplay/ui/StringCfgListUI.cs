using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.ui
{
    public partial class StringCfgListUI : Form
    {
        string m_strFileName;
        string m_strDefItem;
        public StringCfgListUI(string file_name, string def_item = "")
        {
            m_strDefItem = def_item;
            InitializeComponent();
            var _fileList = FileManager.StringCfg.GetFileList();
            foreach (var _file_name in _fileList)
            {
                m_listFile.Items.Add(_file_name);
            }
            m_listFile.SelectedItem = file_name;
            UpdateReferenceList();
        }

        void UpdateReferenceList()
        {
            if (m_listStrID.SelectedItem == null)
                return;
            var list = FileManager.StringCfg.GetStringReferenceList(m_strFileName);
            var select = (string)m_listStrID.SelectedItem;
            if (list.ContainsKey(select))
                m_labReference.Text = list[select];
            else
                m_labReference.Text = "";
        }

        public string GetSelectItem()
        {
            return (string)m_listStrID.SelectedItem;
        }

        public string GetSelectFile()
        {
            return (string)m_listFile.SelectedItem;
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            if (m_labAdd.Text == "")
                return;
            var ret = FileManager.StringCfg.AddString(m_strFileName, m_labAdd.Text);
            if (ret)
            {
                m_listStrID.Items.Add(m_labAdd.Text);
            }
            else
            {
                MessageBox.Show("文件找不到，或id已存在", "添加失败");
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            var ret = FileManager.StringCfg.DelString(m_strFileName, _selectItem);
            if (ret)
            {
                m_listStrID.Items.Remove(_selectItem);
            }
        }

        private void m_listStrID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            m_labText.Text = FileManager.StringCfg.GetString(m_strFileName, _selectItem);
            UpdateReferenceList();
        }

        private void m_labText_TextChanged(object sender, EventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            FileManager.StringCfg.ChangeString(m_strFileName, _selectItem, m_labText.Text);
        }

        private void m_btnSure_Click(object sender, EventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            Close();
        }

        private void m_listStrID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            Close();
        }

        private void m_labSearch_TextChanged(object sender, EventArgs e)
        {
            m_listStrID.Items.Clear();
            var _fileList = FileManager.StringCfg.GetStringListByFile(m_strFileName);
            var _searchText = m_labSearch.Text;
            if(_searchText == "")
            {
                foreach(var _id in _fileList.Keys)
                {
                    m_listStrID.Items.Add(_id);
                }
            }
            else
            {
                foreach(var _id in _fileList.Keys)
                {
                    var res = Regex.Match(_id, @"(.*"+_searchText + @".*)");
                    if (res.Groups.Count > 1)
                    {
                        m_listStrID.Items.Add(_id);
                        continue;
                    }
                }
            }
        }

        private void m_listFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var file_name = m_listFile.SelectedItem as string;
            if (m_strFileName == file_name)
                return;
            m_strFileName = file_name;
            var _fileList = FileManager.StringCfg.GetStringListByFile(m_strFileName);
            m_listStrID.Items.Clear();
            foreach(var _id in _fileList.Keys)
            {
                m_listStrID.Items.Add(_id);
            }
            m_listStrID.SelectedItem = m_strDefItem;
        }
    }
}
