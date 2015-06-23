using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace speck.Web.Common
{
    /// <summary>
    /// 用户cookie
    /// </summary>
    public class UserCookie
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// 用户类型
        /// 0普通用户
        /// 1管理员
        /// 2超级管理员
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int UserType { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        /// <summary>
        /// 用户真实名称
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户联系电话
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string UserPhone { get; set; }

        /// <summary>
        /// 用户权限，用户","分开
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string UserControll { get; set; }


    }
}
