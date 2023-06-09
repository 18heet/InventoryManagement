using InventoryManagement.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Data_Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set;}

        [ForeignKey("Vendor")]
        public int VendorId { get; set;}

        public Vendor Vendor { get; set;}

        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }

        public ProductVariant ProductVariant { get; set; }

        public int PurchasedUnits { get; set; }

        public int TotalAmount { get; set; }

        public ProductStatus Status { get; set; }
    }
}
