using Microsoft.OpenApi.Models;
using ProductApi.Base;
using ProductApi.Extension;
using ProductApi.Extension;

namespace ProductApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static JwtConfig JwtConfig { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddMemoryCache(); // memory cashe 

            services.AddDbContextDI(Configuration);
            /// Add Services to DI Container
            services.AddServicesDI();

            services.AddJwtBearerAuthentication();

            services.AddControllers();
            services.AddCustomizeSwagger();

        }

        /// Configure the how HTTP requests are handled by the application.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            /// Determines how API requests are routed
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}