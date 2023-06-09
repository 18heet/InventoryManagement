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
    public class ProductVariant
    {
        [Key]
        public int ProductVariantId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public int MeasurementAmount { get; set; }

        public int PurchaseCost { get; set; }

        public int Stock { get; set; }

        public Status Status { get; set; }

    }
}
