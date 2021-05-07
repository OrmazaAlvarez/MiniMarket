using Microsoft.AspNetCore.Mvc;
using MiniMarketBackEnd.Services;
using MiniMarketBackEnd.Services.DTOs;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Controllers
{
    [ApiController]
    [Route("suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierQueryService _supplierQuery;

        public SupplierController(ISupplierQueryService supplierQuery)
        {
            _supplierQuery = supplierQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> GetAll()
        {
            return Ok(_supplierQuery.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<SupplierDto> GetSupplier(int id)
        {
            return Ok(_supplierQuery.GetSuplier(id));
        }
    }
}
