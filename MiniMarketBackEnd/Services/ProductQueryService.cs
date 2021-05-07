using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Models;
using System.Linq;
using System.Threading.Tasks;
using MiniMarketBackEnd.Services.DTOs;

namespace MiniMarketBackEnd.Services
{

    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take);
        Task<ProductDto> GetAsync(int id);
    }


    public class ProductQueryService : IProductQueryService
    {
        private readonly MiniMarketDbContext _context;

        public ProductQueryService(MiniMarketDbContext context)
        {
            _context = context;
        }
        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take)
        {
            int TotalRow = await _context.Products.CountAsync();
            var list = await _context.Products.FromSqlInterpolated($"EXECUTE [dbo].Get_Products NULL, {page}, {take}").ToListAsync();
            var colletion = list.GetPaged(page, take, TotalRow);
            return colletion.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var list = await _context.Products.FromSqlInterpolated($"EXECUTE [dbo].Get_Products {id}").ToListAsync();
            return list.First().MapTo<ProductDto>();
        }
    }
}
