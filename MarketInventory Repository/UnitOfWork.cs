using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketInventory.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext Context { get; set; }

        public UnitOfWork(String ConnectionString)
        {
            if (ConnectionString == null)
                throw new ArgumentNullException("ConnectionString", "ConnectionString cannot be null");

            this.Context = new DbContext(ConnectionString);

            InitializeRepositories();

        }

        #region Generate Properties

        private Lazy<IProductInventoryRepository> productInventoryRepository;
        public IProductInventoryRepository ProductInventoryRepository
        {
            get { return productInventoryRepository.Value; }
        }
        #endregion

        private void InitializeRepositories()
        {
            productInventoryRepository = new Lazy<IProductInventoryRepository>(() => new ProductInventoryRepository(Context));
            //salesDataRepository = new Lazy<ISalesDataRepository>(() => new SalesDataRepository(Context));
            //tileDataRepository = new Lazy<ITileDataRepository>(() => new TileDataRepository(Context));
        }



        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
           await Context.SaveChangesAsync();
        }
    }
}
