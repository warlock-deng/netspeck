using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using speck.Admin.Contract;
using speck.Admin.Contract.Entitys;
using speck.Admin.Data;
using speck.Admin.Data.SqlServer;

namespace speck.Admin
{
    public class AdminServices : IAdminServices
    {
        #region  私有变量

        /// <summary>
        /// 数据处理层对象
        /// </summary>
        private static IAdminDataProvider _adminDataProvider = null;

        #endregion

        public AdminServices(string sqlConnection)
        {
            _adminDataProvider = new AdminDataProvider(sqlConnection);
        }

        /// <summary>
        /// 新增加管理员
        /// </summary>
        /// <returns></returns>
        public int Add(AdminEntity adminEntity)
        {
            int nRes = 0;
            if (adminEntity != null)
            {
                nRes = _adminDataProvider.Add(adminEntity);
            }
            return nRes;
        }



    }
}
