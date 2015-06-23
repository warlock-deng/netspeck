using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using speck.Frameworks.ServerInfo;

namespace speck.Frameworks.Test.ServerInfo
{
    [TestClass]
    public class ServerManageTest
    {
        [TestMethod]
        public void GetServerIpTest()
        {
            string str = ServerManage.GetIpAddress();
        }

        public void GetServerNameTest()
        {
            string str = ServerManage.GetServerName();

   
        }

    }
}
