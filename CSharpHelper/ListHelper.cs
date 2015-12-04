using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CSharpHelper
{
    /// <summary>
    /// List泛型帮助类
    /// </summary>
    public static class ListHelper
    {
        public static DataSet ToDataSet<T>(this List<T> list) where T : class, new()
        {
            DataSet result = new DataSet();
            DataTable _DataTable = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    _DataTable.LoadDataRow(array, true);
                }
            }
            result.Tables.Add(_DataTable);
            return result;
        }
    }
}