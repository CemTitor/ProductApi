using ProductApi.Data.Context;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;

namespace ProductApi.Data.Repository.Concrete
{
    public class ListItemRepository : GenericRepository<ListItem>, IListItemRepository
    {
        public ListItemRepository(AppDbContext Context) : base(Context)
        {

        }
    }
}