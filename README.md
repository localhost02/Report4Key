# 功能介绍
统计单个或多个doc、docx、pdf文件中指定关键字出现的次数（比如统计分析海量简历中，指定技术点出现的次数）

# 效果图


# 运行效率
使用线程池的方式，多文件同时进行读取匹配，运行效率较之传统方式提高5.6倍左右。
```csharp
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
```

# 需要的三方库
1. itextsharp库，下载后解压itextsharp-dll-core.zip，程序引用itextsharp.dll。
下载地址：`https://sourceforge.net/projects/itextsharp/files/latest/download`

2. 微软自带的word库，添加引用->com->microsoft word 12.0 object libary，引入可读取word的dll库。

