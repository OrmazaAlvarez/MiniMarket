using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services
{
    public interface ICategoryQueryService
    {
        IEnumerable<CategoryDto> GetAll();
        CategoryDto GetCategory(int id);
    }
    public class CategoryQueryService : ICategoryQueryService
    {
        private readonly MiniMarketDbContext _context;

        public CategoryQueryService(MiniMarketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var list = _context.Categories.AsEnumerable();
            return list.MapTo<IEnumerable<CategoryDto>>();
        }

        public CategoryDto GetCategory(int id)
        {
            var list = _context.Categories.Single(c => c.CategoryId == id);
            return list.MapTo<CategoryDto>();
        }
    }
}
