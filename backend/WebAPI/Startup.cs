using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            bool useSQLite = Configuration.GetValue<bool>("UseSQLite");
            if (useSQLite == true)
            {
				services
					.AddDbContext<DbCliente>(options => options.UseSqlite(Configuration.GetConnectionString("DB_TALLER_SQLITE")));
				services
					.AddDbContext<DbProducto>(options => options.UseSqlite(Configuration.GetConnectionString("DB_TALLER_SQLITE")));
			}
			else
            {
                services
                    .AddDbContext<DbCliente>(options => options.UseSqlServer(Configuration.GetConnectionString("DB_TALLER_MSSQL")));
            }

            // Politica que permite consultas desde cualquier origen
            services
                .AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder =>
                        {
                            builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        });
                });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
            

        }
    }
}
