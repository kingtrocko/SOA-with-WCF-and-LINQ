using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWCF.EasyNorthwind.BusinessEntities;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWCF.EasyNorthwind.DataAccess
{
    public class ProductDAL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        public ProductEntity GetProduct(int id)
        {
            ProductEntity p = null;
            using (SqlConnection conn =
            new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "select * from Products where ProductID=" + id;
                comm.Connection = conn;
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = new ProductEntity();
                    p.ProductID = id;
                    p.ProductName = (string)reader["ProductName"];
                    p.QuantityPerUnit = (string)reader["QuantityPerUnit"];
                    p.UnitPrice = (decimal)reader["UnitPrice"];
                    p.UnitsInStock = (short)reader["UnitsInStock"];
                    p.UnitsOnOrder = (short)reader["UnitsOnOrder"];
                    p.ReorderLevel = (short)reader["ReorderLevel"];
                    p.Discontinued = (bool)reader["Discontinued"];
                }
            }
            return p;
        }

    }
}
