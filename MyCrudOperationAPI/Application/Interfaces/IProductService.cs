using Application.Utilities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResult> GetAllAsync();
        Task<ServiceResult> GetByIdAsync(int id);
        Task<ServiceResult> AddAsync(Product product);
        Task<ServiceResult> UpdateAsync(int id ,Product product);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
