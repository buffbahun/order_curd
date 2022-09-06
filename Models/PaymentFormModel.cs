using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Models
{
    public class PaymentFormModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal PaidAmount { get; set; }
        public List<OderSummaryModel> OderSummary { get; set; }
    }
}
