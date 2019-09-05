using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Store.Domain.Interfaces.Repository;
using Store.Domain.Interfaces.Services;
using Store.Infra.Context;
using Store.Infra.Repository;
using Store.Service;

namespace Store.Web.API {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddCors ();
            services.AddDbContext<StoreContext> (
                options => options.UseNpgsql (Configuration.GetConnectionString ("Database"))
            );
            services.AddTransient<IProductRepository, ProductRepository> ();
            services.AddTransient<IProductService, ProductService> ();

            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer (options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "StoreCore",
                    ValidAudience = "StoreCore",
                    IssuerSigningKey = new SymmetricSecurityKey (
                    Encoding.UTF8.GetBytes (Configuration["SecurityKey"])
                    )
                    };

                    options.Events = new JwtBearerEvents {
                        OnAuthenticationFailed = context => {
                                Console.WriteLine ("Invalid Token : " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context => {
                                Console.WriteLine ("Token Valid : " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                    };
                });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseCors (option => option.AllowAnyOrigin ());
            app.UseAuthentication();
            app.UseMvc ();
        }
    }
}