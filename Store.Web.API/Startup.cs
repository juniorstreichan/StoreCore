using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Interfaces.Repository;
using Store.Domain.Interfaces.Services;
using Store.Infra.Context;
using Store.Infra.Repository;
using Store.Service;

namespace Store.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<StoreContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("Database"))
            );
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IProductService,ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(option => option.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
