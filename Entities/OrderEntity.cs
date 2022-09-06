using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Entities
{
    public class OrderEntity: BaseEntity
    {
        internal object sum;

        public int CostomerId { get; set; }
        public DateTime Date { get; set; }
        public string NepaliDate { get; set; }
        public string Remarks { get; set; }

    }
}
