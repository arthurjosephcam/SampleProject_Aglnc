using MarketInventory.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Repository
{
    public interface IProductInventoryRepository
    {
        Task<IEnumerable<ProductInventory>> GetProductsAsync();
        Task<ProductInventory> GetProductsByProductId(Int32 ProductId);
        ProductInventory UpdateProductInventoryData(ProductInventory Product);
        ProductInventory AddProductInventoryData(ProductInventory Product);
        void DeleteProductInventoryData(ProductInventory Product);
    }
}
