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
    public class OrderReturn
    {
        [Key]
        public int OrderReturnId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public DateTime OR_Date { get; set; }

        public Status Status { get; set;}
    }
}
