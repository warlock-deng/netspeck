using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using speck.Frameworks;
using speck.Admin.Contract.Entitys;
using speck.Frameworks.DataHelp;
using System.Data;
using speck.Frameworks.LogHelp;

namespace speck.Admin.Data.SqlServer
{
    /// <summary>
    /// 管理用户数据操作层
    /// </summary>
    public class AdminDataProvider : IAdminDataProvider
    {
        #region sql文本或存储过程名称(私有变量)

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string _sqlConnection = null;

        /// <summary>
        /// 添加数据的sql文本
        /// </summary>
        private const string _addSqlText = "INSERT INTO [tb_Admin]([vc_name],[vc_pass],[vc_mobile],[vc_phone],[vc_realname]) VALUES (@vc_name,@vc_pass,@vc_mobile,@vc_phone,@vc_realname)";

        /// <summary>
        /// 删除数据的sql文本
        /// </summary>
        private const string _deleteSqlText = "delete from [tb_Admin] where i_id=@i_id";

        #endregion

        public AdminDataProvider(string sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        #region 新增、修改、删除

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="adminEntity">管理员实体</param>
        /// <returns></returns>
        public int Add(AdminEntity adminEntity)
        {
            int nRes = 0;
            if (!string.IsNullOrWhiteSpace(_sqlConnection) && adminEntity != null && !string.IsNullOrWhiteSpace(adminEntity.Name) && !string.IsNullOrWhiteSpace(adminEntity.Pass))
            {
                try
                {
                    var dataManage = DataManage.GetDataManage(_sqlConnection, _addSqlText);
                    nRes = dataManage.ExExecuteNonQuery(adminEntity);
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(new LogEntity { Title = "", LogType = LogType.Exception, Content = string.Format("sqlConnection={0};_addSqlText={1};ex={2}", _sqlConnection, _addSqlText, ex) });
                }
            }
            return nRes;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="adminEntity">管理员实体</param>
        /// <returns></returns>
        public int Update(AdminEntity adminEntity)
        {
            int nRes = 0;
            if (!string.IsNullOrWhiteSpace(_sqlConnection) && adminEntity != null && adminEntity.Id > 0)
            {
                try
                {
                    var dataManage = DataManage.GetDataManage(_sqlConnection, _addSqlText);
                    nRes = dataManage.ExExecuteNonQuery(adminEntity);
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(new LogEntity { Title = "", LogType = LogType.Exception, Content = string.Format("sqlConnection={0};_addSqlText={1};ex={2}", _sqlConnection, _addSqlText, ex) });
                }
            }
            return nRes;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int Delete(int id)
        {
            int nRes = 0;
            if (!string.IsNullOrWhiteSpace(_sqlConnection) && id > 0)
            {
                try
                {
                    var dataManage = DataManage.GetDataManage(_sqlConnection, _deleteSqlText);
                    nRes = dataManage.ExExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(new LogEntity { Title = "", LogType = LogType.Exception, Content = string.Format("sqlConnection={0};_addSqlText={1};ex={2}", _sqlConnection, _addSqlText, ex) });
                }
            }
            return nRes;
        }


        #endregion

        #region   查询及搜索

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="id">管理员编号</param>
        /// <returns></returns>
        public AdminEntity GetEntity(int id)
        {
            AdminEntity adminEntity = null;
            if (!string.IsNullOrWhiteSpace(_sqlConnection) && id > 0)
            {
                try
                {
                    var dataManage = DataManage.GetDataManage(_sqlConnection);
                    adminEntity = dataManage.ExExecuteEntity<AdminEntity>(id);
                }
                catch (Exception ex)
                {
                    LogManage.WriteLog(new LogEntity { Title = "", LogType = LogType.Exception, Content = string.Format("sqlConnection={0};_addSqlText={1};ex={2}", _sqlConnection, _addSqlText, ex) });
                }
            }
            return adminEntity;
        }

        #endregion

    }
}
