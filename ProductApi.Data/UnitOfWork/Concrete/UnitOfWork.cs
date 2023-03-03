using ProductApi.Data.Context;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Repository.Concrete;

namespace ProductApi.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public IGenericRepository<Product> ProductRepository { get; private set; }
        public IGenericRepository<User> UserRepository { get; private set; }
        public IGenericRepository<Category> CategoryRepository { get; private set; }


        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            ProductRepository = new GenericRepository<Product>(dbContext);
            UserRepository = new GenericRepository<User>(dbContext);
            CategoryRepository = new GenericRepository<Category>(dbContext);
        }

        ///Database operations are executed in a transaction, making it easy to detect and recover from errors.
        public async Task CompleteAsync()
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        /// Clearing cached data
        protected virtual void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        /// Ensuring that the objects is not tracked by the finalizer method
        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}