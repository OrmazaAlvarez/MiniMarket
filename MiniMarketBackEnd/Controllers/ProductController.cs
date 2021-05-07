using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniMarketBackEnd.Common;
using MiniMarketBackEnd.Services;
using MiniMarketBackEnd.Services.DTOs;
using MiniMarketBackEnd.Services.DTOs.Validators;
using FluentValidation;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniMarketBackEnd.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryService _productQuery;
        private readonly IProductCommandService _productCommand;

        public ProductController( IProductQueryService productQuery, IProductCommandService productCommand)
        {
            _productQuery = productQuery;
            _productCommand = productCommand;
        }

        [HttpGet]
        public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10)
        {
            return await _productQuery.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(int id)
        {
            return await _productQuery.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDto newProduct)
        {
            var result = await new ProductValidator(true).ValidateAsync(newProduct);
            if (!result.IsValid)
            {
                var Properties = new List<string>();
                foreach (var error in result.Errors)
                {
                    Properties.Add(error.ErrorMessage);
                }
                var Message = new { descrption = "Validation errors", Properties };
                return BadRequest(Message);
            }
            await _productCommand.CreateAsync(newProduct);
            base.StatusCode(201);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductDto Product)
        {
            var result = await new ProductValidator(false).ValidateAsync(Product);
            if (!result.IsValid)
            {
                var Properties = new List<string>();
                foreach (var error in result.Errors)
                {
                    Properties.Add(error.ErrorMessage);
                }
                var Message = new { descrption = "Validation errors", Properties };
                return BadRequest(Message);
            }
            await _productCommand.UpdateAsync(Product);
            return Ok();
        }
    }
}
