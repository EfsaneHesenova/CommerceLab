using Ecommerce.BL.DTOs.OrderDto;
using Ecommerce.BL.DTOs.OrderItemDto;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Abstractions
{
    public interface IOrderItemService
    {
        Task<ICollection<OrderItem>> GetAllAsync();
        Task<OrderItem> CreateAsync(OrderItemCreateDto entityDto);
        Task<OrderItem> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, OrderItemUpdateDto entityDto);
    }
}
