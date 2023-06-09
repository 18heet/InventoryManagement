using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Entities.Data_Models
{
    public partial class InventoryManagementDBContext : DbContext
    {
        public InventoryManagementDBContext()
        {
        }
        public InventoryManagementDBContext(DbContextOptions<InventoryManagementDBContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<OrderReturn> OrderReturn { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseReturn> PurchasesReturn { get; set; }

        public DbSet<SubOrderReturn> SubOrderReturn { get; set; }


    }

}
