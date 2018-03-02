# 1.功能介绍
统计单个或多个doc、docx、pdf文件中指定关键字出现的次数（比如统计分析海量简历中，指定技术点出现的次数）

# 2.效果图
薪资3-8k的195个程序员简历中，掌握的技术点出现次数：
> ![](http://p27z4ahy7.bkt.clouddn.com/TIM%E5%9B%BE%E7%89%8720180302173147.png)

# 3.运行效率
使用线程池的方式，多文件同时进行读取匹配，运行效率较之传统单线程方式提高数十倍；

# 4.需要的三方库
1. itextsharp库，下载后解压itextsharp-dll-core.zip，程序引用itextsharp.dll。
下载地址：`https://sourceforge.net/projects/itextsharp/files/latest/download`

2. 微软自带的word库，添加引用->com->microsoft word 12.0 object libary，引入可读取word的dll库。

# 5.使用方法
1. 打开文件目录（会递归查找目录下的所有文件）
2. 设置需要匹配查找的关键字
3. 点击`开始查找匹配`按钮

注意：程序可能出现wps.exe残余未能正确退出，可使用命令强制退出：`taskkill /F /IM wps.exe`；或者在程序中使用process对象调用cmd执行上述命令。
