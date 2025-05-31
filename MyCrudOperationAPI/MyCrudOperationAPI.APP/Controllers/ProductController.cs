using Application.Interfaces;
using Application.Utilities;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyCrudOperation.API.Models;

namespace MyCrudOperation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService _productService;

            public ProductsController(IProductService productService)
            {
                _productService = productService;
            }
            [HttpGet]
            public async Task<IActionResult> Get()
            {
              var result = await _productService.GetAllAsync();
                return Ok(new ApisResponse(result));
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> Get(int id)
            {
                var result = await _productService.GetByIdAsync(id);
                return Ok(new ApisResponse(result));
            }

            [HttpPost]
            public async Task<IActionResult> Post(Product product)
            {
                var result =await _productService.AddAsync(product);
                return Ok(new ApisResponse(result));

            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(int id, Product product)
            {
               var result = await _productService.UpdateAsync(id,product);
                return Ok(new ApisResponse(result));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
               var result = await _productService.DeleteAsync(id);
                return Ok(new ApisResponse(result));
            }
        }
    }

