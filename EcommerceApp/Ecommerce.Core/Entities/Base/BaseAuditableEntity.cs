using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities.Base
{
    public class BaseAuditableEntity: BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? UptadatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? DeletedBy { get; set; }
    }
}
