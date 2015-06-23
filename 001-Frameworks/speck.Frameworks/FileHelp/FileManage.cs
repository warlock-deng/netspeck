using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace speck.Frameworks.FileHelp
{
    /// <summary>
    /// 文件操作
    /// </summary>
    public static class FileManage
    {
        /// <summary>
        /// 读取文件对象
        /// </summary>
        private static StreamReader _reader = null;

        /// <summary>
        /// 写文件对象 
        /// </summary>
        private static StreamWriter _writer = null;

        /// <summary>
        /// 读取文件信息
        /// </summary>
        /// <param name="filePath">文件路径，带文件名</param>
        /// <param name="encoding">读取编码方式，默认utf8</param>
        /// <returns></returns>
        public static string Read(string filePath, Encoding encoding = null)
        {
            string strRes = null;
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                try
                {
                    _reader = new StreamReader(filePath, encoding ?? Encoding.UTF8);
                    strRes = _reader.ReadToEnd();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_reader != null)
                    {
                        _reader.Dispose();
                        _reader = null;
                    }
                }
            }
            return strRes;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="strContent">文件内容</param>
        /// <param name="isAppend">是否追加(true追加，false覆盖)</param>
        /// <param name="encoding">编码方式，默认utf8</param>
        public static void Write(string filePath, string strContent, bool isAppend = false, Encoding encoding = null)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath) && !string.IsNullOrWhiteSpace(strContent))
            {
                try
                {
                    _writer = new StreamWriter(filePath, isAppend, encoding ?? Encoding.UTF8);
                    _writer.Write(strContent);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (_writer != null)
                    {
                        _writer.Dispose();
                        _writer = null;
                    }
                }
            }
        }
    }
}
