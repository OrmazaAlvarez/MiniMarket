using Microsoft.EntityFrameworkCore;
using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Models;
using System.Linq;
using System.Threading.Tasks;
using MiniMarketBackEnd.Services.DTOs;

namespace MiniMarketBackEnd.Services
{

    public interface IProductCommandService
    {
        Task CreateAsync(ProductDto product);
        Task UpdateAsync(ProductDto product);
    }


    public class ProductCommandService : IProductCommandService
    {
        private readonly MiniMarketDbContext _context;

        public ProductCommandService(MiniMarketDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductDto product)
        {

            await _context.AddAsync(product.MapTo<Product>());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto product)
        {
            _context.Entry(product.MapTo<Product>()).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
