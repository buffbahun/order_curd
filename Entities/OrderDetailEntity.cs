using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class OrderDetailEntity: BaseEntity
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }


    }
}
