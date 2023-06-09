using InventoryManagement.Entities.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InventoryManagement.Repository.IRepository
{
    public interface ICustomers
    {
        public List<Customer> getCustomers();

        public void addCustomer(string userName, string contactNumber);
    }
}
