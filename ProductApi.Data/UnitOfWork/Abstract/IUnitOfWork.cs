using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;

namespace ProductApi.Data.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<ShoppingList> ShoppingListRepository { get; }
        IGenericRepository<ListItem> ListItemRepository { get; }

        Task CompleteAsync();
    }
}