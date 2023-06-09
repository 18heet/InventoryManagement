using InventoryManagement.Entities.Constants;
using InventoryManagement.Entities.Data_Models;
using InventoryManagement.Entities.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.IRepository
{
    public interface IProductVariants
    {
        public Task<List<ProductVariantVM>> getProductVariants(int productId);
        public void addProductVariants(int productId, MeasurementType measurementType , int measurementAmount , int purchaseCost , ProductStatus status);
    }
}
