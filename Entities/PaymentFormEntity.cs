using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class PaymentFormEntity: BaseEntity
    {
        public int CustomerId { get; set; }
        public decimal Paid { get; set; }
        public int PaymentNo { get; set; }
    }
}
