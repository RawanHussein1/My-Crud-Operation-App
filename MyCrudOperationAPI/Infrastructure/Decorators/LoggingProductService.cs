using Application.Interfaces;
using Application.Utilities;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Decorators
{
    public class LoggingProductService: Application.Interfaces.IProductService
    {
        private readonly IProductService _inner;
        private readonly ILogger<LoggingProductService> _logger;

        public LoggingProductService(IProductService inner, ILogger<LoggingProductService> logger)
        {
            _inner = inner;
            _logger = logger;
        }
        public async Task<ServiceResult> GetAllAsync()
        {
            _logger.LogInformation("Fetching all products...");
            var result = await _inner.GetAllAsync();
            _logger.LogInformation($"Returned a list products.");
            return result;
        }

        public async Task<ServiceResult> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching product with ID {id}...");
            var product = await _inner.GetByIdAsync(id);
            if (product == null)
                _logger.LogWarning($"Product with ID {id} not found.");
            else
                _logger.LogInformation($"Product found: {id}");
            return product;
        }

        public async Task<ServiceResult> AddAsync(Product product)
        {
            _logger.LogInformation($"Creating product: {product.Name}");
            var result =await _inner.AddAsync(product);
            _logger.LogInformation("Product created successfully.");
            return result;
        }

        public async Task<ServiceResult> UpdateAsync(int id,Product product)
        {
            _logger.LogInformation($"Updating product ID {product.Id}");
            var result =await _inner.UpdateAsync(id,product);
            _logger.LogInformation("Product updated successfully.");
            return result;
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            _logger.LogInformation($"Deleting product with ID {id}");
            await _inner.DeleteAsync(id);
            _logger.LogInformation("Product deleted successfully.");
            return new ServiceResult();
        }
    }
}