using System;
using System.IO;
using System.Text;

namespace Justec.Alcohol.Pulse.Utils
{
    /// <summary>
    /// 错误日志输出帮助类; CreateTime:2020/4/16 Founder:冯阳阳
    /// </summary>
    public static class LogHelper
    {
        static readonly string _logPath = AppDomain.CurrentDomain.BaseDirectory + "LogFile\\";

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void WriteErrorLog(string errorMessage)
        {
            if (!Directory.Exists(_logPath)) Directory.CreateDirectory(_logPath);
            string filePath = _logPath + DateTime.Now.ToString("yyyyMMdd-") + "error.log";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + "  错误日志信息:\r\n");
                sb.Append(errorMessage);
                sb.Append("\r\n----------------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }

       /// <summary>
       /// 输出普通日志信息
       /// </summary>
       /// <param name="infoMessage"></param>
       public static void WriteInfoLog(string infoMessage)
        {
            if (!Directory.Exists(_logPath)) Directory.CreateDirectory(_logPath);
            string filePath = _logPath + DateTime.Now.ToString("yyyyMMdd-") + "info.log";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + "  普通日志信息:\r\n");
                sb.Append(infoMessage);
                sb.Append("\r\n----------------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }


        /// <summary>
        /// 输出下载日志信息
        /// </summary>
        /// <param name="infoMessage"></param>
        public static void WriteDownloadLog(string infoMessage)
        {
            if (!Directory.Exists(_logPath)) Directory.CreateDirectory(_logPath);
            string filePath = _logPath + DateTime.Now.ToString("yyyyMMdd-") + "download.log";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + "  下载日志信息:\r\n");
                sb.Append(infoMessage);
                sb.Append("\r\n----------------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }


        /// <summary>
        /// 输出普通日志信息
        /// </summary>
        /// <param name="infoMessage"></param>
        public static void WriteUploadLog(string infoMessage)
        {
            if (!Directory.Exists(_logPath)) Directory.CreateDirectory(_logPath);
            string filePath = _logPath + DateTime.Now.ToString("yyyyMMdd-") + "upload.log";
            using (StreamWriter sw = File.AppendText(filePath))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff]") + "  上传日志信息:\r\n");
                sb.Append(infoMessage);
                sb.Append("\r\n----------------------------------------------------------------------\r\n");
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }
    }
}
