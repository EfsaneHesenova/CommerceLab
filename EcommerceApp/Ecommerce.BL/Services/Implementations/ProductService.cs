using Ecommerce.BL.DTOs.ProductDto;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        public Task<Product> CreateAsync(ProductCreateDto entityDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, ProductUpdateDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
