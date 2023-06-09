﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Data_Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        public string VedorName { get; set; }

        [Required]
        public string ContactNumber { get; set; }
    }
}
