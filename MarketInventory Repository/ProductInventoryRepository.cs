using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketInventory.Repository.Models;

namespace MarketInventory.Repository
{
    class ProductInventoryRepository : IProductInventoryRepository
    {
        DbContext Context { get; set; }

       

        internal ProductInventoryRepository(DbContext Context)
        {
            this.Context = Context;
        }

      

        public async Task<IEnumerable<ProductInventory>> GetProductsAsync()
        {
            return await Context.Products
                 .AsNoTracking()
                 .ToArrayAsync()
                 ;
        }

        public async Task<IEnumerable<ProductInventory>> GetProductsSorted(SortType sortedBy)
        {
            switch (sortedBy)
            {
                case SortType.Name:
                    return await Context.Products
                        .OrderBy(r => r.ProductName)
                        .Skip(0)
                        .Take(5)
                        .AsNoTracking()
                        .ToArrayAsync()
                ;
                case SortType.Price:
                    return await Context.Products
                       .OrderBy(r => r.Price)
                       .Skip(0)
                       .Take(5)
                       .AsNoTracking()
                       .ToArrayAsync()
               ;
                case SortType.Quantity:
                    return await Context.Products
                      .OrderBy(r => r.InventoryQuantity)
                      .Skip(0)
                      .Take(5)
                      .AsNoTracking()
                      .ToArrayAsync();
                default:
                    return await Context.Products
                 .AsNoTracking()
                 .ToArrayAsync()
                 ;
            }

           
        }

        public async Task<ProductInventory> GetProductsByProductId(int ProductId)
        {
            return await Context.Products
                 .Where(p => p.ProductID == ProductId)
                 .FirstOrDefaultAsync()
                ;
        }

        public ProductInventory AddProductInventoryData(ProductInventory Product)
        {
            Context.Products.Add(Product);
            return Product;
        }

        public ProductInventory UpdateProductInventoryData(ProductInventory Product)
        {
            Context.Products.Attach(Product);
            Context.Entry(Product).State = EntityState.Modified;
            return Product;
        }

        public void DeleteProductInventoryData(ProductInventory Product)
        {
            Context.Products.Attach(Product);
            Context.Entry(Product).State = EntityState.Deleted;
        }
    }
}
