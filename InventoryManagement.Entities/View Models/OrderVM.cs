using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.View_Models
{
    public class OrderVM
    {

        public int CustomerId { get; set; }
        public int OrderID { get; set; }

        public int ProductVariantId { get; set; }

        public int PurchasedUnits { get; set; }

        public int Total { get; set; }
    }
}
