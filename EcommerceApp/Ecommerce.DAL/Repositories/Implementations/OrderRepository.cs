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
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context): base(context) { }
        
    }
}
