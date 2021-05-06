using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMarketBackEnd.Models;
using System;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Persistence.Configuration
{
    public class CategoryConfiguration
    {
        public CategoryConfiguration(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.CategoryId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            string[] NameList = {"SEDAN", "SUV", "ALL TERRAIN" };
            var categories = new List<Category>();
            foreach(string name in NameList)
            {
                short id = Convert.ToInt16(categories.Count + 1);
                categories.Add(new Category
                {
                    CategoryId = id,
                    Name = name,
                    Description = $"Category {name} {id}"
                });
            }
            entityBuilder.HasData(categories);
        }
    }
}
