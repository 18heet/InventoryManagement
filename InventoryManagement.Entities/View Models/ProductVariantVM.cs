using InventoryManagement.Entities.Constants;
using InventoryManagement.Entities.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.View_Models
{
    public class ProductVariantVM
    {
        public List<Product> products { get; set;}

        public int ProductID { get; set;}

        public int ProductVariantId { get; set;}
        public string ProductName { get; set;}
        public MeasurementType measurementType { get; set;}

        public int MeasurementAmount { get; set;}

        public int PurchaseCost { get; set;}

        public int Stock { get; set;}

        public ProductStatus status { get; set;}
    }
}
