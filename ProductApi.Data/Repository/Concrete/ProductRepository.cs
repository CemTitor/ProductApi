using ProductApi.Data.Context;
using ProductApi.Data.Model;

namespace ProductApi.Data.Repository.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext Context) : base(Context)
        {

        }
    }
}