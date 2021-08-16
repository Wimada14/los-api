using los_api.Model;
using Microsoft.EntityFrameworkCore;

namespace los_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<StockModel> Stock { get; set; }
      
    }
}