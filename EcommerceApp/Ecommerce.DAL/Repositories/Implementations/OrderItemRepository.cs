using Ecommerce.Core.Entities;
using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Implementations
{
    public class OrderItemRepository: GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context): base(context) { }
       
    }
}
