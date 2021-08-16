using los_api.Data;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using los_api.Model;
using System.Collections.Generic;

namespace los_api
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
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>  opt.UseInMemoryDatabase("DatabaseLivingOS"));

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                AddProductInStocktData(context);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddProductInStocktData(DataContext context)
        {

            List<ProductModel> listProductModel = new List<ProductModel>() 
            {
                new ProductModel  {
                id = 1,
                name = "Computer1",
                imageUrl = "https://www.thelivingos.com/wp-content/uploads/2021/07/N0.1Proptech-in-Thailand-1024x576.png",
                price = 50000
                },
            
                new ProductModel  {
                id = 2,
                name = "Computer2",
                imageUrl = "https://www.thelivingos.com/wp-content/uploads/2021/07/N0.1Proptech-in-Thailand-1024x576.png",
                price = 80000
                },
            
                new ProductModel  {
                id = 3,
                name = "Computer3",
                imageUrl = "https://www.thelivingos.com/wp-content/uploads/2021/07/N0.1Proptech-in-Thailand-1024x576.png",
                price = 70000
                },
                
                new ProductModel  {
                id = 4,
                name = "Computer4",
                imageUrl = "https://www.thelivingos.com/wp-content/uploads/2021/07/N0.1Proptech-in-Thailand-1024x576.png",
                price = 40000
                },
                
                new ProductModel  {
                id = 5,
                name = "Computer5",
                imageUrl = "https://www.thelivingos.com/wp-content/uploads/2021/07/N0.1Proptech-in-Thailand-1024x576.png",
                price = 90000
                },
            };

            foreach (ProductModel product in listProductModel)
            {
                context.Product.Add(product);
            }

            List<StockModel> listStocktModel = new List<StockModel>()
            {
                new StockModel  {
                id = 1,
                productId = 1,
                amount = 5
                },

                new StockModel  {
                id = 2,
                productId = 2,
                amount = 10
                },

                new StockModel  {
                id = 3,
                productId = 3,
                amount = 20
                },

                new StockModel  {
                id = 4,
                productId = 4,
                amount = 8
                },

                new StockModel  {
                id = 5,
                productId = 5,
                amount = 15
                },
            };

            foreach (StockModel stock in listStocktModel)
            {
                context.Stock.Add(stock);
            }

            context.SaveChanges();
        }
    }
}
