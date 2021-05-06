using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniMarketBackEnd.Models;
using System;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Persistence.Configuration
{
    public class StockConfiguration
    {
        public StockConfiguration(EntityTypeBuilder<Stock> entityBuilder)
        {
            entityBuilder.HasIndex(s => s.StockId);

            var stocks = new List<Stock>();
            var random = new Random();
            for (int c = 1; c <10; c++)
            {
                stocks.Add(new Stock
                {
                    StockId = c,
                    ProductId = c,
                    Count = random.Next(20, 50)
                });
            }
            entityBuilder.HasData(stocks);
        }
    }
}
