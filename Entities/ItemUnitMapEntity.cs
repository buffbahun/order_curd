using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class ItemUnitMapEntity: BaseEntity
    {
        public int ItemId { get; set; }
        public int UnitId { get; set; }
    }
}
