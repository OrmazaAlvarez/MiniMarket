using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Services.DTOs;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services
{

    public interface IStockQueryService
    {
        Task<DataCollection<StockDto>> GetAllAsync(int page, int take, int? productId = null);
    }

    public class StockQueryService : IStockQueryService
    {
        private readonly MiniMarketDbContext _context;

        public StockQueryService(MiniMarketDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<StockDto>> GetAllAsync(int page, int take, int? productId = null)
        {
            int TotalRow = await _context.Stocks.CountAsync(); 
            var list = await _context.Stocks.FromSqlInterpolated($"EXECUTE [dbo].Get_Stocks {productId}, {page}, {take}").ToListAsync();
            var collection = list.GetPaged(page, take, TotalRow);
            return collection.MapTo<DataCollection<StockDto>>();
        }
    }
}
