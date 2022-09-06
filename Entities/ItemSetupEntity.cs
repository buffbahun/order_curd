using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class ItemSetupEntity: ExtendedEntity
    {
        public int ParentId { get; set; }
        public string Name { get; set; }
        public decimal DefaultRate { get; set; }
        public int DefaultUnitId { get; set; }
        public bool IsTaxable { get; set; }
        public int TypeId { get; set; }
    }
}
