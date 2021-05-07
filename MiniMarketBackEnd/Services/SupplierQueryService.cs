using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Persistence;
using MiniMarketBackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniMarketBackEnd.Services
{
    public interface ISupplierQueryService
    {
        IEnumerable<SupplierDto> GetAll();
        SupplierDto GetSuplier(int id);
    }
    public class SupplierQueryService : ISupplierQueryService
    {
        private readonly MiniMarketDbContext _context;

        public SupplierQueryService(MiniMarketDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SupplierDto> GetAll()
        {
            var list = _context.Suppliers.AsEnumerable();
            return list.MapTo<IEnumerable<SupplierDto>>();
        }

        public SupplierDto GetSuplier(int id)
        {
            var list = _context.Suppliers.Single(s => s.SupplierId == id);
            return list.MapTo<SupplierDto>();
        }
    }
}
