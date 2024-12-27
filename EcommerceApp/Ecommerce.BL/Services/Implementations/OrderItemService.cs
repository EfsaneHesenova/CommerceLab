using AutoMapper;
using Ecommerce.BL.DTOs.OrderItemDto;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepo;
    private readonly IMapper _mapper;

    public OrderItemService(IOrderItemRepository orderItemRepo, IMapper mapper)
    {
        _orderItemRepo = orderItemRepo;
        _mapper = mapper;
    }

    public async Task<OrderItem> CreateAsync(OrderItemCreateDto entityDto)
    {
        OrderItem createdOrderItem = _mapper.Map<OrderItem>(entityDto);
        createdOrderItem.CreatedAt = DateTime.Now;
        var entity = await _orderItemRepo.CreateAsync(createdOrderItem);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            OrderItem orderItem = await _orderItemRepo.GetByIdAsync(id);
            _orderItemRepo.Delete(orderItem);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ICollection<OrderItem>> GetAllAsync()
    {
        return await _orderItemRepo.GetAllAsync();
    }

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        if (!await _orderItemRepo.IsExistAsync(id))
        {
            throw new Exception();
        }
        return await _orderItemRepo.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var orderItemtEntity = await GetByIdAsync(id);
        _orderItemRepo.SoftDelete(orderItemtEntity);
        await _orderItemRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, OrderItemUpdateDto entityDto)
    {
        var orderItemEntity = await GetByIdAsync(id);
        _orderItemRepo.Update(orderItemEntity);
        Product updatedOrderItem = _mapper.Map<Product>(orderItemEntity);
        updatedOrderItem.Id = id;
        await _orderItemRepo.SaveChangesAsync();
        return true;
    }
}
