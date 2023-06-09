using InventoryManagement.Entities.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.IRepository
{
    public interface IPurchase
    {
        public void addPurchase(int vendorId ,int productVariantId , int purchasedUnits , int total);

        public Task<List<PurchaseVM>> getPurchases();

        public void addOrder(int customerId , int totalAmount , int productVariantId , int orderedUnits );
    }
}
