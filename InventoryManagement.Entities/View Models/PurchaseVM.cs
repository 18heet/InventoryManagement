using InventoryManagement.Entities.Constants;
using InventoryManagement.Entities.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.View_Models
{
    public class PurchaseVM
    {
        public int ProductVariantId { get; set; }
        public int PurchaseId { get; set; }
        public int VendorId { get; set; }
        public string ProductName { get; set; } 

        public string VendorName { get; set; }
        public MeasurementType measurementType { get; set; }

        public int MeasurementAmount { get; set; }

        public int PurchaseCost { get; set; }

        public int Units { get; set; }

        public List<Vendor> vendors { get; set; }

        public int Stock { get; set; }

        public List<ProductVariantVM> products { get; set; }


    }
}
