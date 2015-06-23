using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace speck.Frameworks.DataHelp
{
    /// <summary>
    /// 数据读取处理类
    /// </summary>
    public class DataManage
    {
        #region 私有参数
        /// <summary>
        /// 单例对象
        /// </summary>
        private static DataManage _datamanage = null;

        /// <summary>
        /// 线程安全
        /// </summary>
        private static readonly object _obj = new object();

        private DataManage() { }

        /// <summary>
        /// sql文本或存储过程名称
        /// </summary>
        private static string _sqlText = null;

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static string _sqlConnect = null;

        /// <summary>
        ///  执行方便或语句
        /// </summary>
        private static CommandType _commandType = CommandType.Text;

        #endregion

        #region 取单例对象

        /// <summary>
        /// 获取数据处理类实例
        /// </summary>
        /// <param name="sqlConnect">数据库连接字符串</param>
        /// <param name="strSqlText">sql文本或存储过程名称</param>
        /// <param name="commandType">执行文件名语句</param>
        /// <returns></returns>
        public static DataManage GetDataManage(string sqlConnect, string strSqlText = null, CommandType commandType = CommandType.Text)
        {
            _sqlText = strSqlText;
            _sqlConnect = sqlConnect;
            _commandType = commandType;
            if (_datamanage == null)
            {
                lock (_obj)
                {
                    if (_datamanage == null)
                    {
                        _datamanage = new DataManage();
                    }
                }
            }
            return _datamanage;
        }

        #endregion

        #region 数据更新操作

        /// <summary>
        /// 执行修改，删除等操作
        /// </summary>
        /// <param name="sqlParameters">参数</param>
        /// <returns></returns>
        public int ExExecuteNonQuery(SqlParameter[] sqlParameters = null)
        {
            int nRes = 0;
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(_sqlText))
            {
                nRes = SqlHelper.ExecuteNonQuery(_sqlConnect, _commandType, _sqlText, sqlParameters);
            }
            return nRes;
        }

        /// <summary>
        /// 执行增加，修改，删除操作；
        /// </summary>
        /// <typeparam name="T">实体对象</typeparam>
        /// <param name="t">与数据库中字段一一对应的实例</param>
        /// <returns></returns>
        public int ExExecuteNonQuery<T>(T t) where T : new()
        {
            int nRes = 0;
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(_sqlText))
            {
                var sqlParameters = SetSqlParameters<T>(t);
                nRes = ExExecuteNonQuery(sqlParameters);
            }
            return nRes;
        }

        #endregion

        #region 数据查询操作

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sqlParameters">参数</param>
        /// <returns></returns>
        public IList<T> ExExecuteLists<T>(SqlParameter[] sqlParameters = null) where T : new()
        {
            IList<T> lstT = null;
            var ds = ExExecuteDataTable(sqlParameters);
            if (ds != null && ds.Rows.Count > 0)
            {
                lstT = new List<T>();
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    var t = GetT<T>(ds.Rows[i]);
                    if (t != null)
                    {
                        lstT.Add(t);
                    }
                }
            }
            return lstT;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public IList<T> ExExecuteLists<T>(string condition) where T : new()
        {
            IList<T> lstT = null;
            if (!string.IsNullOrWhiteSpace(condition))
            {
                var tem = new T();
                var attribute = Attribute.GetCustomAttribute(tem.GetType(), typeof(TableAttribute)) as TableAttribute;  //获取表名
                if (attribute != null)
                {
                    var tableName = attribute.TableName;
                    _sqlText = string.Format("select * from {0} with(nolock) where {1}", tableName, condition);  //获取sql语句
                }
                var ds = ExExecuteDataTable();
                if (ds != null && ds.Rows.Count > 0)
                {
                    lstT = new List<T>();
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        var t = GetT<T>(ds.Rows[i]);
                        if (t != null)
                        {
                            lstT.Add(t);
                        }
                    }
                }
            }
            return lstT;
        }

        /// <summary>
        /// 返回查询集合
        /// </summary>
        /// <param name="sqlParameters">查询参数</param>
        /// <returns></returns>
        public DataSet ExExecuteDataSet(SqlParameter[] sqlParameters = null)
        {
            DataSet dsSet = null;
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(_sqlText))
            {
                dsSet = SqlHelper.ExecuteDataSet(_sqlConnect, _commandType, _sqlText, sqlParameters);
            }
            return dsSet;
        }

        /// <summary>
        /// 返回搜索表
        /// </summary>
        /// <param name="sqlParameters">参数</param>
        /// <returns></returns>
        public DataTable ExExecuteDataTable(SqlParameter[] sqlParameters = null)
        {
            DataTable dt = null;
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(_sqlText))
            {
                var dsSet = SqlHelper.ExecuteDataSet(_sqlConnect, _commandType, _sqlText, sqlParameters);
                if (dsSet != null && dsSet.Tables.Count > 0)
                {
                    dt = dsSet.Tables[0];
                }
            }
            return dt;
        }

        /// <summary>
        /// 获取entity
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="sqlParameters">参数</param>
        /// <returns></returns>
        public T ExExecuteEntity<T>(SqlParameter[] sqlParameters = null) where T : new()
        {
            var t = default(T);
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(_sqlText))
            {
                var ds = ExExecuteDataTable(sqlParameters);
                if (ds != null && ds.Rows.Count > 0)
                {
                    t = GetT<T>(ds.Rows[0]);
                }
            }
            return t;
        }

        /// <summary>
        /// 根据主键值查询实体(不需要sql语句)
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="obj">主键值</param>
        /// <returns></returns>
        public T ExExecuteEntity<T>(object obj) where T : new()
        {
            var t = default(T);
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && obj != null)
            {
                _sqlText = GetSql<T>(obj); //获取sql语句
                var ds = ExExecuteDataTable();
                if (ds != null && ds.Rows.Count > 0)
                {
                    t = GetT<T>(ds.Rows[0]);
                }
            }
            return t;
        }

        /// <summary>
        /// 根据主键值查询实体(不需要sql语句)
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="condition">条件；如name='dengyouhua'</param>
        /// <returns></returns>
        public T ExExecuteEntity<T>(string condition) where T : new()
        {
            var t = default(T);
            if (!string.IsNullOrWhiteSpace(_sqlConnect) && !string.IsNullOrWhiteSpace(condition))
            {
                var tem = new T();
                var attribute = Attribute.GetCustomAttribute(tem.GetType(), typeof(TableAttribute)) as TableAttribute;  //获取表名
                if (attribute != null)
                {
                    var tableName = attribute.TableName;
                    _sqlText = string.Format("select * from {0} with(nolock) where {1} ", tableName, condition);  //获取sql语句
                }
                var ds = ExExecuteDataTable();
                if (ds != null && ds.Rows.Count > 0)
                {
                    t = GetT<T>(ds.Rows[0]);
                }
            }
            return t;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取根据主键查询数据的sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static string GetSql<T>(object obj) where T : new()
        {
            string strRes = null;
            var t = new T();
            var attribute = Attribute.GetCustomAttribute(t.GetType(), typeof(TableAttribute)) as TableAttribute;  //获取表名
            if (attribute != null)
            {
                var tableName = attribute.TableName;
                var properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Length > 0)
                {
                    foreach (var info in properties)
                    {
                        var attributes = Attribute.GetCustomAttributes(info, typeof(DataMapingAttribute));
                        if (attributes.Length > 0)
                        {
                            var attributet = attributes[0] as DataMapingAttribute;
                            if (attributet != null && attributet.IsPk)  //取主键名及主键数据类型
                            {
                                var columeName = attributet.ColumnName;
                                var type = info.PropertyType;
                                var defaultVal = type.IsValueType ? obj : "'" + obj + "'";
                                strRes = string.Format("select * from {0} with(nolock) where {1}={2}", tableName, columeName, defaultVal);
                                break;
                            }
                        }
                    }
                }
            }
            return strRes;
        }

        /// <summary>
        /// 将获取对象中的字段并且转化为参数
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="t">实例</param>
        /// <returns></returns>
        private static SqlParameter[] SetSqlParameters<T>(T t) where T : new()
        {
            SqlParameter[] sqlParameters = null;
            if (t != null)
            {
                var properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Length > 0)
                {
                    var list = new List<SqlParameter>();
                    foreach (var info in properties)
                    {
                        var attributes = Attribute.GetCustomAttributes(info, typeof(DataMapingAttribute));
                        if (attributes.Length > 0)
                        {
                            var attribute = attributes[0] as DataMapingAttribute;
                            if (attribute != null)
                            {
                                var columeName = attribute.ColumnName;
                                var dbType = attribute.ColumnType;
                                var val = info.GetValue(t);
                                var type = info.PropertyType;
                                var defaultVal = type.IsValueType ? Activator.CreateInstance(type) : null;
                                if (val != null && !val.Equals(defaultVal))
                                {
                                    list.Add(new SqlParameter()
                                    {
                                        DbType = dbType,
                                        ParameterName = string.Format("@{0}", columeName),
                                        Value = val,
                                    });
                                }
                            }
                        }
                    }
                    sqlParameters = list.ToArray();
                }
            }
            return sqlParameters;
        }

        /// <summary>
        /// 将datarow中的行转换为对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="dr">行</param>
        /// <returns></returns>
        private static T GetT<T>(DataRow dr) where T : new()
        {
            var t = new T();
            if (dr != null)
            {
                var properties = t.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var info in properties)
                {
                    var attributes = Attribute.GetCustomAttributes(info, typeof(DataMapingAttribute));
                    if (attributes.Length > 0)
                    {
                        var attribute = attributes[0] as DataMapingAttribute;
                        if (attribute != null)
                        {
                            info.SetValue(t, Convert.IsDBNull(dr[attribute.ColumnName]) ? null : dr[attribute.ColumnName]);
                        }
                    }
                }

            }
            return t;
        }

        #endregion
    }
}
