using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Model;
using System.Reflection;

namespace ProductApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShoppingList> ShoppingList { get; set; }
        public DbSet<ListItem> ListItem { get; set; }
        ///How database tables are created is defined.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /// Specifies the compiled code file of the running application 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}