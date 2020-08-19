using Entities;
using Entities.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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


             string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ASPNetDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Product";
                    command.Connection = conn;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        var x = reader[0];
                        x = reader[1];
                        x = reader[2];
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
            search.Search(new Product { Name = "Sosige", Price = 100 }, "Products");
        }
    }
}
