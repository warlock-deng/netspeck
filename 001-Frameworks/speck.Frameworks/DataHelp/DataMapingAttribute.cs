using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speck.Frameworks.DataHelp
{
    /// <summary>
    /// 
    /// </summary>
    public class DataMapingAttribute : Attribute
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 列字段类型
        /// </summary>
        public DbType ColumnType { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPk { get; set; }

        public DataMapingAttribute()
        {
            IsPk = false;
        }
    }
}
