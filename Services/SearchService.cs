using Entities;
using Entities.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Services
{
    public class SearchService
    {
        //https://docs.microsoft.com/ru-ru/dotnet/framework/data/adonet/ado-net-code-examples
        public void Search<T>(T ps, string tableName) where T : class
        {
            Type t = typeof(T);
            PropertyInfo[] propInfos1 = t.GetProperties();
            var props = propInfos1;
            var propsNames = new Dictionary<string, string>();
            var selectQuery = new StringBuilder($"SELECT * FROM {tableName} ");

            var res = ps;


            //foreach (var prop in props)
            //{
            //    if (ps != null)
            //    {
            //        selectQuery.Append(prop.Name + $" = 'string' OR ");
            //    }

            //}
            //var ee = selectQuery.ToString();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASPNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM {tableName} ";
                    command.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery.ToString(), conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

          
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (var item in props)
                        {
                            propsNames.Add(key: item.Name, value: reader[item.Name].ToString());
                        }
                      
                      
                    }

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

        public static void GetFromParams()
        {
            var search = new SearchService();
            search.Search(new Product { Name = "Sosige", Price = 100 }, "Product");
        }
    }
}
