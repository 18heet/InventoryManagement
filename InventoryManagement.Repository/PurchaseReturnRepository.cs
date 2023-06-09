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
    public class PurchaseReturnRepository : IPurchaseReturn
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";

        public void purchaseReturn(int productVariantId , int purchaseId , int pr_units)
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spReturnPurchase", sqlConnection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductVariantId", SqlDbType.Int).Value = productVariantId;
                cmd.Parameters.AddWithValue("@PurchaseId", SqlDbType.Int).Value = purchaseId;
                cmd.Parameters.AddWithValue("@PR_Units", SqlDbType.Int).Value = pr_units;
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
