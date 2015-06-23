using System;
using System.Text;
using System.IO;

namespace speck.Frameworks.LogHelp
{
    /// <summary>
    /// 日志操作帮助类
    /// </summary>
    public static class LogManage
    {
        /// <summary>
        /// 分隔符
        /// </summary>
        private const string StrLine = "**********************************************************************************\r\n";

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">日志实体</param>
        public static void WriteLog(LogEntity logEntity)
        {
            WriteLog(null, logEntity);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strPath">日志路径</param>
        /// <param name="logEntity">日志实体</param>
        public static void WriteLog(string strPath, LogEntity logEntity)
        {
            if (logEntity != null)
            {
                try
                {
                    var strPathTem = GetAppPath(logEntity.LogType, strPath);
                    var ipStr = ServerInfo.ServerManage.GetIpAddress();
                    var str = string.Format("date：{0}  \r\ntitle：{1}  \r\ncontent：{2} \r\nserverName:{3}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), logEntity.Title, logEntity.Content, ipStr);
                    var sw = new StreamWriter(strPathTem, true, Encoding.UTF8);
                    sw.WriteLine(str);
                    sw.WriteLine(StrLine);
                    sw.Dispose();
                    sw.Close();
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 取路径
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="strPath">路径,路径后要带\</param>
        /// <returns></returns>
        private static string GetAppPath(LogType logType, string strPath = null)
        {
            if (string.IsNullOrWhiteSpace(strPath))
            {
                strPath = AppDomain.CurrentDomain.BaseDirectory;//获取程序的基目录，结尾不包含\
            }
            var strNow = DateTime.Now.ToString("yyyyMMdd");
            strPath = strPath + "\\logs\\" + strNow;
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            strPath = string.Format("{0}\\{1}.log", strPath, logType.ToString());
            return strPath;
        }
    }
}
