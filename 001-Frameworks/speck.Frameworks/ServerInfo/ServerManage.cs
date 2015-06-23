using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Management;

namespace speck.Frameworks.ServerInfo
{
    /// <summary>
    /// 获取服务器信息
    /// </summary>
    public static class ServerManage
    {
        /// <summary>
        /// 获取服务器ip地址
        /// </summary>
        /// <returns></returns>
        public static string GetIpAddress()
        {
            string stRes = null;
            var strHostName = GetServerName(); //得到本机的主机名  
            var ipEntry = Dns.GetHostAddresses(strHostName); //取得本机IP  
            if (ipEntry != null && ipEntry.Length > 0)
            {
                stRes = ipEntry.Length > 1 ? ipEntry[1].ToString() : ipEntry[0].ToString();
            }
            return stRes;
        }

        /// <summary>
        /// 获取机器名
        /// </summary>
        /// <returns></returns>
        public static string GetServerName()
        {
            return Dns.GetHostName();
        }

    }
}
