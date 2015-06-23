using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using speck.Admin.Contract.Entitys;

namespace speck.Admin.Data
{
    /// <summary>
    /// 数据操作接口
    /// </summary>
    public interface IAdminDataProvider
    {
        /// <summary>
        /// 新增或修改用户
        /// </summary>
        /// <param name="adminEntity">管理员实体</param>
        /// <returns></returns>
        int Add(AdminEntity adminEntity);
    }
}
