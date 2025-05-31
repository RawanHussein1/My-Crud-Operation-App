using Application.Interfaces;
using Application.Utilities;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResult> GetAllAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return new ServiceResult(products);
        }

        public async Task<ServiceResult> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product is not null)
                return new ServiceResult(product);
            return new ServiceResult(new ServiceError(nameof(Product.Id), "Product is not exist"));


        }

        public async Task<ServiceResult> AddAsync(Product product)
        {
            try
            {
                await _productRepository.AddProductAsync(product);
                return new ServiceResult(product.Id);
            }
            catch (Exception ex)
            {
                return new ServiceResult(new ServiceError(nameof(Product),$"Failed to insert product : {ex.Message}"));
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id,Product product)
        {
            try
            {
                if (id != product.Id)
                    return new ServiceResult(new ServiceError(nameof(Product.Id), "ID Mismatch"));
                await _productRepository.UpdateProductAsync(product);
                return new ServiceResult(product);
            }
            catch (Exception ex)
            {
                return new ServiceResult(new ServiceError(nameof(Product), $"Failed to update product : {ex.Message}"));

            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return new ServiceResult();
            }
            catch (Exception ex)
            {
                return new ServiceResult(new ServiceError(nameof(Product), $"Failed to update product : {ex.Message}"));
            }
        }
    }
}
