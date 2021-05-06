using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Persistence;
using Microsoft.OpenApi.Models;
using MiniMarketBackEnd.Services;

namespace MiniMarketBackEnd
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MiniMarket API",
                    Description = "Test Web Api for SINERGIASS"
                });
            });
            services.AddDbContext<MiniMarketDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MiniMarketWebApiDev")));
            services.AddTransient<IProductQueryService, ProductQueryService>();
            services.AddTransient<IProductCommandService, ProductCommandService>();
            services.AddTransient<IStockQueryService, StockQueryService>();
            services.AddTransient<IStockCommandService, StockCommandService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniMarket API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
