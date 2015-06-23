using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using speck.Frameworks.DataHelp;
using speck.Admin.Contract.Entitys;

namespace speck.Frameworks.Test.DataHelpTest
{
    [TestClass]
    public class DataManageTest
    {
        private const string sqlConnect = "server=(local);database=db_speck;uid=sa;pwd=123456;";

        [TestMethod]
        public void ExExecuteEntityTest()
        {
            const string sqlText = "select * from tb_admin where i_id=1";
            var dataManage = DataManage.GetDataManage(sqlConnect, sqlText);
            var admin = dataManage.ExExecuteEntity<AdminEntity>();
            Assert.IsTrue(admin != null);
            Assert.IsTrue(admin.Id == 1);
        }

        [TestMethod]
        public void ExExecuteListsTest()
        {
            const string sqlText = "select * from tb_admin";
            var dataManage = DataManage.GetDataManage(sqlConnect, sqlText);
            var lis = dataManage.ExExecuteLists<AdminEntity>();

            var dataManaget = DataManage.GetDataManage(sqlConnect, sqlText);
            var a = dataManaget.ExExecuteDataTable();
            Assert.IsTrue(lis != null);
        }

        [TestMethod]
        public void ExExecuteNonQueryTest()
        {
            const string sqlText = "update tb_admin set vc_pass=@vc_pass where i_id=@i_id";
            var dataManage = DataManage.GetDataManage(sqlConnect, sqlText);
            var nres = dataManage.ExExecuteNonQuery(new AdminEntity { Id = 3, Pass = "dengyou" });
            Assert.IsTrue(nres == 1);
        }

        [TestMethod]
        public void ExExecuteNonQueryAddTest()
        {
            var n = 3 % 10;
            const string sqlText = "INSERT INTO [tb_Admin] ([vc_name] ,[vc_pass],[vc_mobile] ,[vc_phone],[vc_realname] ,[vc_apps]) VALUES(@vc_name ,@vc_pass,@vc_mobile ,@vc_phone,@vc_realname ,@vc_apps)";
            var dataManage = DataManage.GetDataManage(sqlConnect, sqlText);
            var nres = dataManage.ExExecuteNonQuery(new AdminEntity { Name = "test1", Pass = "dengyou", Mobile = "15210101010", Phone = "0108888888", Apps = "1;2;5;6;9;8;7;5;2;5", RealName = "dengyouhua" });
            Assert.IsTrue(nres == 1);
        }

        [TestMethod]
        public void ExExecuteEntityByPkTest()
        {
            var dataManage = DataManage.GetDataManage(sqlConnect);
            var adminEntity = dataManage.ExExecuteEntity<AdminEntity>(1);
            Assert.IsTrue(adminEntity != null);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(adminEntity.Name));
        }
        [TestMethod]
        public void ExExecuteEntityByConditionTest()
        {
            var dataManage = DataManage.GetDataManage(sqlConnect);
            var adminEntity = dataManage.ExExecuteEntity<AdminEntity>("vc_name='dengyouhua'");
            Assert.IsTrue(adminEntity != null);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(adminEntity.Name));
        }
    }
}
