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
    public class PurchaseReturn
    {
        [Key]
        public int PurchaseReturnId { get; set; }

        [ForeignKey("Purchase")]
        public int PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        public int PR_Units { get; set; }
        
        public DateTime PR_Date { get; set; }

        public Status Status { get; set; }

        public int vendorId { get; set; }

        public int PurchaseCost { get; set; }

    }
}
