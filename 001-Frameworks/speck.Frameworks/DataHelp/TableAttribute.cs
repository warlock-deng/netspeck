using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speck.Frameworks.DataHelp
{
    /// <summary>
    /// 
    /// </summary>
    public class TableAttribute : Attribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
    }
}
