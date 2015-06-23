using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using speck.Frameworks.DataHelp;


namespace speck.Admin.Contract.Entitys
{
    /// <summary>
    /// 管理员用户实体
    /// </summary>
    [DataContract]
    [Table(TableName = "tb_Admin")]
    public class AdminEntity
    {
        /// <summary>
        /// 用户编号
        /// </summary>

        [DataMaping(ColumnName = "i_id", ColumnType = DbType.Int32,IsPk = true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMaping(ColumnName = "vc_name", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [DataMaping(ColumnName = "vc_pass", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Pass { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [DataMaping(ColumnName = "vc_mobile", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }

        /// <summary>
        /// 联系座机
        /// </summary>
        [DataMaping(ColumnName = "vc_phone", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [DataMaping(ColumnName = "vc_realname", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string RealName { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        [DataMaping(ColumnName = "vc_apps", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Apps { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [DataMaping(ColumnName = "dt_addtime", ColumnType = DbType.String, Length = 20)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime AddTime { get; set; }

    }
}
