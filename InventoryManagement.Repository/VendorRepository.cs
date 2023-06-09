using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository
{
    public class VendorRepository : IVendors
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        public List<Vendor> getVendors()
        {
            
            List<Vendor> vendors = new List<Vendor>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetVendors", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Vendor vendor = new Vendor();
                    vendor.VendorId = (int)reader[0];
                    vendor.VedorName= reader[1].ToString();
                    vendor.ContactNumber = reader[2].ToString();
                    
                    vendors.Add(vendor);
                }
                connection.Close();
            }
            
            return vendors;
        }

        public void addVendors(string userName, string contactNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddVendors", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@VendorName" , SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.AddWithValue("@ContactNumber" , SqlDbType.NVarChar).Value = contactNumber;
                connection.Open();

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
