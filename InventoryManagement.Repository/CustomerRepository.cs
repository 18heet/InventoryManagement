

using FluentAssertions.Common;
using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;

namespace InventoryManagement.Repository
{
    public class CustomerRepository : ICustomers
    {
        string ConnectionString = @"Data source=PCT23\SQL2019;Initial Catalog=Inventory_Management;User ID=sa;Password=Tatva@123;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";
        public List<Customer> getCustomers()
        {

            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUsers", connection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                //DataTable dataTable = ;
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                //DataSet dataSet = new DataSet();
                //sqlDataAdapter.SelectCommand = cmd;
                //sqlDataAdapter.Fill(dataSet);
                
                //foreach (DataRow item in dataSet.Tables[0].Rows)
                //{
                //    var tem2 = item.ToString();
                //    Customer customer = new Customer();
                //    customer.CustomerName = item[0].ToString();
                //    customer.ContactNumber = "Heet";
                //}
                //foreach(DataRow row in dataTable.Rows)
                //{
                //    var Item = row.ItemArray;
                //    Customer customer = new Customer();
                //    customer.CustomerName = "qwe";                    
                //    customer.ContactNumber = "Heet";                    

                //    customers.Add(customer);
                //}

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerName = reader[0].ToString();
                    customer.ContactNumber = reader[1].ToString();
                    
                    customers.Add(customer);
                }

                connection.Close();
            }

            return customers;
        }

        public void addCustomer(string userName, string contactNumber)
        {
            SqlConnection sqlConnection = null;

            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("spAddCustomers", sqlConnection)
                {

                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerName", SqlDbType.NVarChar).Value = userName;
                cmd.Parameters.AddWithValue("@ContactNumber", SqlDbType.NVarChar).Value = contactNumber;

                cmd.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}
