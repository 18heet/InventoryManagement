using InventoryManagement.Entities.Constants;
using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Entities.View_Models;
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
    public class ProductVariantRepository : IProductVariants
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        public async Task<List<ProductVariantVM>> getProductVariants(int productId)
        {

            List<ProductVariantVM> productVarients = new List<ProductVariantVM>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spGetProductVariants", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                if (productId > 0)
                {
                    cmd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
                }
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductVariantVM producVariant = new ProductVariantVM();
                        producVariant.ProductName = reader[0].ToString();
                        producVariant.ProductVariantId = (int)reader[1];
                        producVariant.measurementType = (MeasurementType)reader[3];
                        producVariant.MeasurementAmount = (int)reader[4];
                        producVariant.PurchaseCost = (int)reader[5];
                        producVariant.Stock = (int)reader[6];
                        producVariant.status = (ProductStatus)reader[7];

                        productVarients.Add(producVariant);
                    }
                }
                connection.Close();
            }

            return productVarients;
        }

        public void addProductVariants(int productId, MeasurementType measurementType, int measurementAmount, int purchaseCost, ProductStatus status)
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spAddProductVariant", sqlConnection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
                cmd.Parameters.AddWithValue("@MeasurementType", SqlDbType.Int).Value = measurementType;
                cmd.Parameters.AddWithValue("@MeasurementAmount", SqlDbType.Int).Value = measurementAmount;
                cmd.Parameters.AddWithValue("@PurchaseCost", SqlDbType.Int).Value = purchaseCost;
                cmd.Parameters.AddWithValue("@status", SqlDbType.Int).Value = status;


                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
