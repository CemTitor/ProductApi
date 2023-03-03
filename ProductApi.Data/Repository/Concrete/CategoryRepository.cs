using ProductApi.Data.Context;
using ProductApi.Data.Model;

namespace ProductApi.Data.Repository.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext Context) : base(Context)
        {

        }
    }
}