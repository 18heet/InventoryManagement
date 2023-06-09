using InventoryManagement.Entities.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.IRepository
{
    public interface IProducts
    {
        public List<Product> getProducts();

        public void addProducts(string productName , int productStatus);
    }
}
