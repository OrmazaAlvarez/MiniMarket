using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMarketBackEnd.Models;
using System;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Persistence.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasIndex(p => p.ProductId);
            entityBuilder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            entityBuilder.Property(p => p.CategoryId).IsRequired();
            entityBuilder.Property(p => p.SupplierId).IsRequired();
            entityBuilder.Property(p => p.Brand).IsRequired().HasMaxLength(50);
            entityBuilder.Property(p => p.Model).IsRequired().HasMaxLength(50);
            entityBuilder.Property(p => p.Measure).IsRequired().HasMaxLength(100);
            entityBuilder.Property(p => p.Price).IsRequired().HasColumnType("decimal(10, 2)");

            string[] BrandList = { "LEXUS", "RENAULT", "Ford" };
            string[] ModelList = { "RX", "KOLEOS", "FX-150" };
            string[] MeasureList = { "L: 4.354mm, W: 1.563mm, H: 1.360", "L: 4.399mm, W: 1.652, H: 1.390", "L: 4.518mm, W: 1.799, H: 1.480" };
            var products = new List<Product>();
            var random = new Random();
            for (int id = 1; id<10; id++)
            {
                int index = random.Next(1, 3);
                products.Add(new Product
                {
                    ProductId = id,
                    Description= $"Description for {ModelList[index]}",
                    CategoryId = Convert.ToInt16(index),
                    SupplierId = 1,
                    Brand = BrandList[index],
                    Model = ModelList[index],
                    Measure = MeasureList[index],
                    Price = random.Next(10000,15000)
                });
            }
            entityBuilder.HasData(products);
        }
    }
}