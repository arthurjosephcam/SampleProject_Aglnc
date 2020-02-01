using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketInventory.Service;
using MarketInventory.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketInventory.WebApplication
{
    //[Authorize] //we would use that, if we wanted to authorize.

    [Route("api/[controller]")]
    public class ProductInventoryController : Controller
    {
        IProductInventoryService ProductInventoryService;

        public ProductInventoryController(IProductInventoryService ProductInventoryService)
        {
            this.ProductInventoryService = ProductInventoryService;
        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductInventory>> GetAllProducts()
        {
            var products = await ProductInventoryService.GetProductsAsync();

            try
            {
                return Mapper.Map<IEnumerable<ProductInventory>>(products);
            }
            catch (Exception ex) { throw ex; }


        }


        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductInventory>> GetProductsSorted(SortType sortedBy)
        {
            var products = await ProductInventoryService.GetProductsSorted((Service.Models.SortType)sortedBy);

            try
            {
                return Mapper.Map<IEnumerable<ProductInventory>>(products);
            }
            catch (Exception ex) { throw ex; }

        }


        [HttpGet("[action]")]
        public  ProductInventory AddProduct(ProductInventory Product)
        {
            var product2 =  ProductInventoryService.AddProductInventoryData(Mapper.Map<Service.Models.ProductInventory>(Product));

            try
            {
                return Mapper.Map<ProductInventory>(product2);
            }
            catch (Exception ex) { throw ex; }

        }

        [HttpGet("[action]")]
        public ProductInventory UpdateProduct(ProductInventory Product)
        {
            var product2 = ProductInventoryService.UpdateProductInventoryData(Mapper.Map<Service.Models.ProductInventory>(Product));

            try
            {
                return Mapper.Map<ProductInventory>(product2);
            }
            catch (Exception ex) { throw ex; }

        }

    }
}
