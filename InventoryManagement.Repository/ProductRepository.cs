using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public class ProductRepository : IProducts
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        public List<Product> getProducts()
        {
            
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetProducts", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)reader[0];
                    product.ProductName = reader[1].ToString();
                    product.ProductStatus = (Entities.Constants.ProductStatus)reader[2];
                    
                    products.Add(product);
                }
                connection.Close();
            }
            
            return products;
        }

        public void addProducts(string productName, int productStatus)
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spAddProducts", sqlConnection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductName" , SqlDbType.NVarChar).Value = productName;
                cmd.Parameters.AddWithValue("@ProductStatus" , SqlDbType.Int).Value = productStatus;

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
