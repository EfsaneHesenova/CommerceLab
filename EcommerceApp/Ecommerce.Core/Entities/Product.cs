﻿using Ecommerce.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities
{
    public class Product: BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
