using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Context;
using ProductApi.Data.Model;

namespace ProductApi.Data.Repository.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext Context) : base(Context) { }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.User.CountAsync();
        }
    }
}