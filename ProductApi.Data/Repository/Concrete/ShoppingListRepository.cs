using ProductApi.Data.Context;
using ProductApi.Data.Model;

namespace ProductApi.Data.Repository.Concrete
{
    public class ShoppingListRepository : GenericRepository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(AppDbContext Context) : base(Context)
        {

        }
    }
}