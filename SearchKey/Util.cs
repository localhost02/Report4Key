using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Word;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace SearchKey
{
    class Util
    {
        /// <summary>  
        /// 获取路径下所有文件以及子文件夹中文件  
        /// </summary>  
        /// <param name="path">全路径根目录</param>  
        /// <param name="FileList">存放所有文件的全路径</param>  
        /// <param name="RelativePath"></param>  
        /// <returns></returns>  
        public static List<FileInfo> GetFile(string path, List<FileInfo> fileList)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            fileList.AddRange(dir.GetFiles());

            DirectoryInfo[] dii = dir.GetDirectories();
            //获取子文件夹内的文件列表，递归遍历  
            foreach (DirectoryInfo d in dii)
            {
                GetFile(d.FullName, fileList);
            }
            return fileList;
        }

        /// <summary>  
        /// 读取 txt文档 返回内容
        /// </summary>  
        /// <param name="path"></param>
        /// <returns></returns>
        public static string readFile(String filePath)
        {
            string str = "";

            //获取文件内容  
            if (System.IO.File.Exists(filePath))
            {
                System.IO.StreamReader file1 = new System.IO.StreamReader(filePath);//读取文件中的数据  
                str = file1.ReadToEnd();                                          

                file1.Close();
                file1.Dispose();
            }
            return str;
        }

        /// <summary>  
        /// 保存数据data到文件
        /// </summary>
        /// <param name="text">数据</param>
        /// <param name="fileName">文件名</param>
        /// <returns>保存的文件全路径</returns>
        public static String saveFile(String text, String fileName)
        {
            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!System.IO.Directory.Exists(CurDir)) 
                System.IO.Directory.CreateDirectory(CurDir);

            String filePath = CurDir + fileName;
            //文件以覆盖方式添加内容  
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(filePath, false);
            //保存数据到文件  
            file1.Write(text);

            file1.Close();
            file1.Dispose();

            return filePath;
        }

        /// <summary>
        /// 读取 pdf文档 返回内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetPdfContent(string filePath)
        {
            PdfReader pdfReader = new PdfReader(filePath);
            return PdfTextExtractor.GetTextFromPage(pdfReader, pdfReader.NumberOfPages);
        }

        /// <summary>
        /// 读取 word文档 返回内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetWordContent(string filePath)
        {
            try
            {
                Word._Application app = new Word.Application();
                Type wordType = app.GetType();
                Word._Document doc = null;
                object unknow = Type.Missing;
                app.Visible = false;
                object file = filePath;
                doc = app.Documents.Open(ref file,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow);
                int count = doc.Paragraphs.Count;
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= count; i++)
                {
                    sb.Append(doc.Paragraphs[i].Range.Text.Trim());
                }

                doc.Close(ref unknow, ref unknow, ref unknow);
                wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, app, null);
                doc = null;
                app = null;
                //垃圾回收
                //GC.Collect();
                //GC.WaitForPendingFinalizers();
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
