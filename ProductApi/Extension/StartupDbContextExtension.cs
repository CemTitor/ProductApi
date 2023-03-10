using Microsoft.EntityFrameworkCore;
using ProductApi.Data.Context;

namespace ProductApi.Extension
{
    public static class StartupDbContextExtension
    {
        public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbtype = configuration.GetConnectionString("DbType");
            if (dbtype == "SQL")
            {
                var dbConfig = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options => options
                   .UseSqlServer(dbConfig,b=>b.MigrationsAssembly("ProductApi")));
            }
            else if (dbtype == "PostgreSQL")
            {
                var dbConfig = configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<AppDbContext>(options => options
                   .UseNpgsql(dbConfig)
                   );
            }
        }
    }
}