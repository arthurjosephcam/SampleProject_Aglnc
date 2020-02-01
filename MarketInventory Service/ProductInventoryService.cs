using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketInventory.Repository;
using MarketInventory.Service.Models;

namespace MarketInventory.Service
{
    public class ProductInventoryService : IProductInventoryService
    {
        private readonly IUnitOfWork UnitOfWork;

        public ProductInventoryService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public ProductInventory AddProductInventoryData(ProductInventory Product)
        {
            var result = UnitOfWork.ProductInventoryRepository.AddProductInventoryData(Mapper.Map<Repository.Models.ProductInventory>(Product));
            return Mapper.Map<ProductInventory>(result);
        }

        public void DeleteProductInventoryData(ProductInventory Product)
        {
            UnitOfWork.ProductInventoryRepository.DeleteProductInventoryData(Mapper.Map<Repository.Models.ProductInventory>(Product));

        }

        public async Task<IEnumerable<ProductInventory>> GetProductsAsync()
        {
            var result = await UnitOfWork.ProductInventoryRepository.GetProductsAsync();
            return Mapper.Map<IEnumerable<ProductInventory>>(result);
        }


        public async Task<IEnumerable<ProductInventory>> GetProductsSorted(SortType sortedBy)
        {
            var result = await UnitOfWork.ProductInventoryRepository.GetProductsAsync();
            return Mapper.Map<IEnumerable<ProductInventory>>(result);
        }

        public async Task<ProductInventory> GetProductsByProductId(int ProductId)
        {
            var result = await UnitOfWork.ProductInventoryRepository.GetProductsByProductId(ProductId);
            return Mapper.Map<ProductInventory>(result);
        }

        public ProductInventory UpdateProductInventoryData(ProductInventory Product)
        {
            var result = UnitOfWork.ProductInventoryRepository.UpdateProductInventoryData(Mapper.Map<Repository.Models.ProductInventory>(Product));
            return Mapper.Map<ProductInventory>(result);
        }
    }
}
