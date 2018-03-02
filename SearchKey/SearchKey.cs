using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;


namespace SearchKey
{
    public partial class SearchKey : Form
    {

        private static List<FileInfo> fileList = new List<FileInfo>();
        private static ConcurrentDictionary<string, int> keyTable = new ConcurrentDictionary<string, int>();
        private static string[] _keys;

        public SearchKey()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            InitializeComponent();

            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory;
            String keys = Util.readFile(CurDir + "keys.txt");
            tb_keys.Text = keys;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Util.saveFile("发生未处理的异常:\r\n" + ex.Message+"\r\n", "error.log");
        }

        private void btn_select_dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string dir = folder.SelectedPath;
                Util.GetFile(dir, fileList);
                btn_select_dir.Text = dir.Substring(0, 24) + "...";
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            keys_reset();

            if (fileList.Count < 1)
            {
                MessageBox.Show("请先选择目标文件所在目录！");
                return;
            }
            if (keyTable.Count < 1)
            {
                MessageBox.Show("请先设置需要匹配的关键字！");
                return;
            }

            btn_start.Text = "查找匹配中...";
            btn_start.Enabled = false;
            ConcurrentDictionary<string, int> result = search_keys(fileList, keyTable);

            btn_start.Text = "开始查找匹配";
            btn_start.Enabled = true;
            chart_result.Series["出现次数"].Points.DataBindXY(result.Keys, result.Values);
        }

        private void cb_single_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_single.Checked)
            {
                cb_multity.Checked = false;
            }
            else
            {
                cb_multity.Checked = true;
            }
        }

        private void cb_multity_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_multity.Checked)
            {
                cb_single.Checked = false;
            }
            else
            {
                cb_single.Checked = true;
            }
        }

        private void keys_reset()
        {
            _keys = tb_keys.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries); //忽略空行    
            foreach (string key in _keys)
            {
                keyTable.TryAdd(key, 0);
            }

            tb_keys.Text = Regex.Replace(tb_keys.Text, "[\t\\ ]+", "");
            Util.saveFile(tb_keys.Text, "keys.txt");
        }

        private static int runningNum;
        private static object locker=new object();
        private ConcurrentDictionary<string, int> search_keys(List<FileInfo> fileList, ConcurrentDictionary<string, int> keyTable)
        {
            ThreadPool.SetMaxThreads(100, 100);

            runningNum = fileList.Count;

            foreach (FileInfo file in fileList)
                ThreadPool.QueueUserWorkItem(new WaitCallback(search), file);

            loopEnd();

            return keyTable;
        }

        private void search(object arg_file)
        {
            FileInfo file = (FileInfo)arg_file;
            string text = "";

            if (Regex.IsMatch(file.Name, "pdf"))
                text = Util.GetPdfContent(file.FullName);
            else if (Regex.IsMatch(file.Name, "(doc|docx)"))
                text = Util.GetWordContent(file.FullName);

            if (cb_single.Checked)
            {
                foreach (string key in _keys)
                    if (Regex.IsMatch(text, key, RegexOptions.IgnoreCase))
                        keyTable[key] = keyTable[key] + 1;
            }
            else
            {
                foreach (string key in _keys)
                    keyTable[key] = keyTable[key] + Regex.Matches(text, key, RegexOptions.IgnoreCase).Count;
            }

             lock (locker)
            {
                runningNum--;
                Monitor.Pulse(locker);
            }
            
        }

        private void loopEnd()
        {
            while (true)
            {
                if (runningNum == 0)
                    break;

                Thread.Sleep(500);
            }
        }

    }
}
