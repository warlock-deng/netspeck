using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speck.Frameworks.LogHelp
{
    public enum LogType
    {
        /// <summary>
        /// 程序级异常
        /// </summary>
        Exception = 1,

        /// <summary>
        /// 错误
        /// </summary>
        Error = 2,

        /// <summary>
        /// 信息
        /// </summary>
        Message = 3,

        /// <summary>
        /// 调试信息
        /// </summary>
        Debug = 4
    }
}
