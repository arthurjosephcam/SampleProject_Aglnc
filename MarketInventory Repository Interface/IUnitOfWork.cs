using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Repository
{
    public interface IUnitOfWork
    {
        IProductInventoryRepository ProductInventoryRepository { get; }
        Task SaveChangesAsync();

        void SaveChanges();
    }
}
