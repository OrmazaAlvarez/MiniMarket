using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Models;
using MiniMarketBackEnd.Persistence.Configuration;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Persistence
{
    public class MiniMarketDbContext : DbContext
    {
        public MiniMarketDbContext(DbContextOptions<MiniMarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }
        private void ModelConfig(ModelBuilder builder)
        {
            new CategoryConfiguration(builder.Entity<Category>());
            new SupplierConfiguration(builder.Entity<Supplier>());
            new ProductConfiguration(builder.Entity<Product>());
            new StockConfiguration(builder.Entity<Stock>());
        }
    }
}
