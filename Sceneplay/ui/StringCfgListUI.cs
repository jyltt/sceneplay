﻿using Sceneplay.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sceneplay.ui
{
    public partial class StringCfgListUI : Form
    {
        string m_strFileName;
        public StringCfgListUI(string file_name, string def_item = "")
        {
            m_strFileName = file_name;
            InitializeComponent();
            var _fileList = FileManager.GetInstance().StringCfg.GetStringListByFile(file_name);
            foreach(var _id in _fileList.Keys)
            {
                m_listStrID.Items.Add(_id);
            }
            m_listStrID.SelectedItem = def_item;
        }

        public string GetSelectItem()
        {
            return (string)m_listStrID.SelectedItem;
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            if (m_labAdd.Text == "")
                return;
            var ret = FileManager.GetInstance().StringCfg.AddString(m_strFileName, m_labAdd.Text);
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
            var ret = FileManager.GetInstance().StringCfg.DelString(m_strFileName, _selectItem);
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
            m_labText.Text = FileManager.GetInstance().StringCfg.GetString(m_strFileName, _selectItem);
        }

        private void m_labText_TextChanged(object sender, EventArgs e)
        {
            string _selectItem = (string)m_listStrID.SelectedItem;
            if (_selectItem == null)
                return;
            FileManager.GetInstance().StringCfg.ChangeString(m_strFileName, _selectItem, m_labText.Text);
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
    }
}