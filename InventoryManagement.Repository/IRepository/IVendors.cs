using InventoryManagement.Entities.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.IRepository
{
    public interface IVendors
    {
         public List<Vendor> getVendors();
        
        public void addVendors(string userName, string contactNumber);
    }
}
