using AutoMapper;
using Ecommerce.BL.DTOs.OrderDto;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepo, IMapper mapper)
    {
        _orderRepo = orderRepo;
        _mapper = mapper;
    }

    public async Task<Order> CreateAsync(OrderCreateDto entityDto)
    {
        Order createdOrder = _mapper.Map<Order>(entityDto);
        createdOrder.CreatedAt = DateTime.Now;
        var entity = await _orderRepo.CreateAsync(createdOrder);
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Order order = await _orderRepo.GetByIdAsync(id);
            _orderRepo.Delete(order);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ICollection<Order>> GetAllAsync()
    {
        return await _orderRepo.GetAllAsync();
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        if (!await _orderRepo.IsExistAsync(id))
        {
            throw new Exception();
        }
        return await _orderRepo.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var orderEntity = await GetByIdAsync(id);
        _orderRepo.SoftDelete(orderEntity);
        await _orderRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, OrderUpdateDto entityDto)
    {
        var orderEntity = await GetByIdAsync(id);
        _orderRepo.Update(orderEntity);
        Product updatedOrder = _mapper.Map<Product>(orderEntity);
        updatedOrder.Id = id;
        await _orderRepo.SaveChangesAsync();
        return true;
    }
}
