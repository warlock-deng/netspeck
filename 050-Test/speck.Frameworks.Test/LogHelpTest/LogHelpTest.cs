using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace speck.Frameworks.Test.LogHelpTest
{
    /// <summary>
    /// LogHelpTest 的摘要说明
    /// </summary>
    [TestClass]
    public class LogHelpTest
    {

        [TestMethod]
        public void WriteLogTest()
        {
            LogHelp.LogManage.WriteLog(new LogHelp.LogEntity { LogType = LogHelp.LogType.Exception, Title = "dyh", Content = "dengyouhua" });

        }

        [TestMethod]
        public void Test()
        {
            var url = "http://rdapi.zpidc.com/Customer/SetBlackInfo";
            var a = 10;
            var b = 19;
            a = a + b;
            b = a - b;
            a = a - b;



        }

    }
}
