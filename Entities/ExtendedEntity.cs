using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class ExtendedEntity: BaseEntity
    {
        public bool IsInactive { get; set; } = false;
    }
}
