using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHelper
{
    /// <summary>
    /// DataSet帮助类
    /// </summary>
    public static class DataSetHelper
    {
        /// <summary>
        /// DataSet转List泛型
        /// </summary>
        /// <typeparam name="T">List类型</typeparam>
        /// <param name="ds">DataSet</param>
        /// <param name="tableNum">DataSet里面的Table序号，默认为第一个Table</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataSet ds, int tableNum = 0) where T : class, new()
        {
            DataTable dt = ds.Tables[tableNum];
            // 返回值初始化 
            List<T> result = new List<T>();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值 
                        if (pi.Name.Equals(dt.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理 
                            if (dt.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, dt.Rows[j][i], null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }
    }
}
