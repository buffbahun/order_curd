﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Models
{
    public class OderSummaryModel
    {
        public int Id { get; set; }
        public int PaymentFormId { get; set; }
        public int OrderId { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Discount { get; set; }
    }
}
