using MarketInventory.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Service
{
    public interface IProductInventoryService
    {
        Task<IEnumerable<ProductInventory>> GetProductsAsync();
        Task<IEnumerable<ProductInventory>> GetProductsSorted(SortType sortedBy);
        Task<ProductInventory> GetProductsByProductId(Int32 ProductId);
        ProductInventory UpdateProductInventoryData(ProductInventory Product);
        ProductInventory AddProductInventoryData(ProductInventory Product);
        void DeleteProductInventoryData(ProductInventory Product);
    }
}
