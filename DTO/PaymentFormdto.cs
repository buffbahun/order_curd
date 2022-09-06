using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.DTO
{
    public class PaymentFormdto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal PaidAmount { get; set; }
        public List<OderSummarydto> OderSummary { get; set; }
    }
}
