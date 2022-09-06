using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class UnitSetupEntity: ExtendedEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
