using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Service.Models
{
    public class ProductInventory
    {
        public Int32 ProductID { get; set; }
        public String ProductName { get; set; }
        public Int32 InventoryQuantity { get; set; }
        public Decimal Price { get; set; }
    }
}
