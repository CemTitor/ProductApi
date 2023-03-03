
using AutoMapper;
using ProductApi.Data;
using ProductApi.Data.Model;
using ProductApi.Data.Repository.Abstract;
using ProductApi.Data.Repository.Concrete;
using ProductApi.Data.Uow;
using ProductApi.Service;
using ProductApi.Service.Abstract;
using ProductApi.Service.Concrete;


namespace ProductApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}