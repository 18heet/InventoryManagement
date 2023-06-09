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
    public class PurchaseRepository : IPurchase
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        public async Task<List<PurchaseVM>> getPurchases()
        {
            List<PurchaseVM> purchases = new List<PurchaseVM>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spGetPurchases", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PurchaseVM purchase = new PurchaseVM();
                        purchase.PurchaseId = (int)reader[1];
                        purchase.ProductName = (string)reader[0];
                        purchase.MeasurementAmount = (int)reader[8];
                        purchase.measurementType = (Entities.Constants.MeasurementType)reader[9];
                        purchase.Units = (int)reader[4];
                        purchase.VendorName = (string)reader[7];
                        purchase.PurchaseCost = (int)reader[5];
                        purchase.ProductVariantId = (int)reader[3];
                        purchase.Stock = (int)reader[10];
                        purchases.Add(purchase);
                    }
                }
                connection.Close();
            }

            return purchases;
        }

        public void addPurchase(int vendorId, int productVariantId, int purchasedUnits, int total)
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spAddPurchase", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorId", SqlDbType.Int).Value = vendorId;
                cmd.Parameters.AddWithValue("@ProductVariantId", SqlDbType.Int).Value = productVariantId;
                cmd.Parameters.AddWithValue("@PurchasedUnits", SqlDbType.Int).Value = purchasedUnits;
                cmd.Parameters.AddWithValue("@Total", SqlDbType.Int).Value = total;

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void addOrder(int customerId , int totalAmount , int productVariantId , int orderedUnits )
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spAddOrder", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerId", SqlDbType.Int).Value = customerId;
                cmd.Parameters.AddWithValue("@ProductVariantId", SqlDbType.Int).Value = productVariantId;
                cmd.Parameters.AddWithValue("@OrderedUnits", SqlDbType.Int).Value = orderedUnits;
                cmd.Parameters.AddWithValue("@TotalAmount", SqlDbType.Int).Value = totalAmount;
                
                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
