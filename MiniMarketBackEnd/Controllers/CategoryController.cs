using Microsoft.AspNetCore.Mvc;
using MiniMarketBackEnd.Services;
using MiniMarketBackEnd.Services.DTOs;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Controllers
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryQueryService _categoryQuery;

        public CategoryController(ICategoryQueryService categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAll()
        {
            return Ok(_categoryQuery.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategory(int id)
        {
            return _categoryQuery.GetCategory(id);
        }
    }
}
