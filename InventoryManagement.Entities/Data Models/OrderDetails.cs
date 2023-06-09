using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Data_Models
{
    public class OrderDetails
    {
        [Key]
        public int SubOrderId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }


        [ForeignKey("ProductVariant")]
        public int ProductVariantId { get; set; }

        public ProductVariant ProductVariant { get; set; }

        public int OrderedUnits { get; set; }

        public long TotalAmount { get; set; }
    }
}
