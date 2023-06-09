using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.IRepository
{
    public interface IPurchaseReturn
    {
         public void purchaseReturn(int productVariantId , int purchaseId , int pr_units);
    }
}
