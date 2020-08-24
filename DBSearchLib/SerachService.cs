using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DBSearchLib
{
    public class SerachService
    {
        /// <summary>
        /// Search in Db
        /// </summary>
        /// <typeparam name="T">Model Data Transter</typeparam>
        /// <param name="model">Model Data Transter</param>
        /// <param name="tableName">Database Table Name</param>
        /// <param name="connectionString">Database Connection string</param>
        public IEnumerable<T> Search<T>(T model, string tableName, string connectionString) where T : class
        {
            Type tModelType = model.GetType();
            PropertyInfo[] propInfos1 = tModelType.GetProperties();
            var props = propInfos1;
            var selectQuery = new StringBuilder($"SELECT * FROM {tableName}");
            selectQuery.Append($" WHERE");
            string typeVariant = string.Empty;
            var list = new List<T>();

            foreach (var item in props)
            {
                if (item.GetValue(model) != null)
                {
                    typeVariant = item.PropertyType.Name == "String" || item.PropertyType.Name == "Nullable`1" ? 
                                $" [{item.Name}] = '{item.GetValue(model)}' AND" :
                                $" [{item.Name}] = { TypeConverter(item, model) } AND";
                    selectQuery.Append(typeVariant);
                }
            }

            selectQuery.Remove(selectQuery.Length - 3, 3);
            Console.Write(selectQuery);
            using (var conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = selectQuery.ToString();
                    command.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery.ToString(), conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, tableName);
 
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            T item = GetItem<T>(row);
                            list.Add(item);
                        }
                    }
                    return list;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        object value = null;
                        value = dr[column.ColumnName];
                        if (value == DBNull.Value)
                        {
                            value = null;
                        }
                        pro.SetValue( obj, value, null);
                    }                       
                    else
                        continue;
                }
            }
            return obj;
        }

        private static object TypeConverter<T>(PropertyInfo propertyInfo, T obj)
       {
            if (propertyInfo.PropertyType.Name == "Nullable`1")
            {
                var val = propertyInfo.GetValue(obj).ToString();
                return val;
            }
            else if(propertyInfo.PropertyType.Name == "Decimal")
            {
                var val = decimal.Parse(propertyInfo.GetValue(obj).ToString());
                return val;
            }
            else if (propertyInfo.PropertyType.Name == "Int32" || propertyInfo.PropertyType.Name == "Int16" || propertyInfo.PropertyType.Name == "Int64")
            {
                return int.Parse(propertyInfo.GetValue(obj).ToString());
            }
            else
            {
                return propertyInfo.GetValue(obj).ToString();
            }
            
        }
    }
}
