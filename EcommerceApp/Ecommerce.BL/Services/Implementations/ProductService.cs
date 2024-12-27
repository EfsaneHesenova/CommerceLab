using AutoMapper;
using Ecommerce.BL.DTOs.ProductDto;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<Product> CreateAsync(ProductCreateDto entityDto)
        {
            Product createdProduct = _mapper.Map<Product>(entityDto);
            createdProduct.CreatedAt = DateTime.Now;
            var createdEntity = await _productRepo.CreateAsync(createdProduct);
            return createdEntity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Product product = await GetByIdAsync(id);
                _productRepo.Delete(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if(!await _productRepo.IsExistAsync(id))
            {
                throw new Exception();
            }
           return await _productRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var productEntity = await GetByIdAsync(id);
            _productRepo.SoftDelete(productEntity);
            await _productRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDto entityDto)
        {
            var productEntity = await GetByIdAsync(id);
            _productRepo.Update(productEntity);
            Product updatedProduct = _mapper.Map<Product>(productEntity);
            updatedProduct.Id = id;
            await _productRepo.SaveChangesAsync();
            return true;

        }
    }
}
