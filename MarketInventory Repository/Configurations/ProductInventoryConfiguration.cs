using MarketInventory.Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Repository
{
    public class ProductInventoryConfiguration : EntityTypeConfiguration<ProductInventory>
    {
        public ProductInventoryConfiguration()
        {
            ToTable("ProductInventory", "dbo");
            HasKey(f => f.ProductID);

            Property(f => f.ProductID).HasColumnName(@"ProductID").IsRequired().HasColumnType("int");//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(f => f.ProductName).HasColumnName(@"ProductName").IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            Property(f => f.Price).HasColumnName(@"Price").IsRequired().HasColumnType("money");
            Property(f => f.InventoryQuantity).HasColumnName(@"InventoryQuantity").HasColumnType("int");

            //HasMany(f => f.Sales).WithRequired(f => f.CustomerData).HasForeignKey(f => f.CustomerNumber);

        }
    }
}
