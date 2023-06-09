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
    public class SubOrderReturn
    {
        [Key]
        public int SubOrderReturnId { get; set; }

        [ForeignKey("OrderDetails")]
        public int SubOrderId { get; set; }

        public OrderDetails OrderDetails { get; set; }

        public int OrderReturnUnits { get; set; }

        public Status Status { get; set; }

    }
}
