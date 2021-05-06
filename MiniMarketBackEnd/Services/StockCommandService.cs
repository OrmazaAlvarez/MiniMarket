using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Models;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Services.DTOs;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services
{

    public interface IStockCommandService
    {
        Task CreateAsync(StockDto stock);
        Task UpdateAsync(StockDto stock);
    }

    public class StockCommandService : IStockCommandService
    {
        private readonly MiniMarketDbContext _context;

        public StockCommandService(MiniMarketDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StockDto stock)
        {

            await _context.AddAsync(stock.MapTo<Stock>());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StockDto stock)
        {
            _context.Entry(stock.MapTo<Stock>()).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
