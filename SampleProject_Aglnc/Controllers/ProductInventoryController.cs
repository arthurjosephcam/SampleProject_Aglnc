using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketInventory.Service;
using Microsoft.AspNetCore.Mvc;

namespace MarketInventory.Controllers
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
       
    }
}
