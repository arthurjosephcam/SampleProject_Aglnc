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
            var result = await UnitOfWork.ProductInventoryRepository.GetProductsSorted((Repository.Models.SortType)sortedBy);

            return Mapper.Map<IEnumerable<ProductInventory>>(result);

            /*
             * first I was sorted here but it was meaningless sorting and returning just five, after bringing the all data.
             * So I moved it to repository. But left the commented code here to indicate this. 
             */
            //var sorted = result;

            //switch (sortedBy)
            //{
            //    case SortType.Name:
            //        sorted = result.OrderBy(r => r.ProductName).Skip(0).Take(5);
            //        break;
            //    case SortType.Price:
            //        sorted = result.OrderBy(r => r.Price).Skip(0).Take(5);
            //        break;
            //    case SortType.Quantity:
            //        sorted = result.OrderBy(r => r.InventoryQuantity).Skip(0).Take(5);
            //        break;
            //    default:
            //        break;
            //}



            //return Mapper.Map<IEnumerable<ProductInventory>>(sorted);
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
