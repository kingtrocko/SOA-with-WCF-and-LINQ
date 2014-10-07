using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyWCFServices.RealNorthwindEntities;
using System.Data.SqlClient;
using System.Configuration;

namespace MyWCFServices.RealNorthwindDAL
{
    public class ProductDAL
    {
        string connectionString = ConfigurationManager.AppSettings["NorthwindConnectionString"];

        public ProductEntity GetProduct(int id)
        {
            /*
            // TODO: connect to DB to retrieve product
            ProductEntity p = new ProductEntity();
            p.ProductID = id;
            p.ProductName = "fake product name from data access layer";
            p.UnitPrice = (decimal)30.00;
            if (id > 50) p.UnitsOnOrder = 30;
            return p;
            */
            ProductEntity p = null;
            using (SqlConnection conn =new SqlConnection(connectionString))
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

        public bool UpdateProduct(ProductEntity product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE products SET ProductName=@name,QuantityPerUnit=@unit,UnitPrice=@price,Discontinued=@discontinued WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@name", product.ProductName);
                cmd.Parameters.AddWithValue("@unit", product.QuantityPerUnit);
                cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                cmd.Parameters.AddWithValue("@discontinued", product.
                Discontinued);
                cmd.Parameters.AddWithValue("@id", product.ProductID);
                conn.Open();
                int numRows = cmd.ExecuteNonQuery();
                if (numRows != 1)
                    return false;
            }
            return true;
        }

    }
}
