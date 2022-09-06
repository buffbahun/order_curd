using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CostomerId { get; set; }
        public DateTime Date { get; set; }
        public string NepaliDate { get; set; }
        public string Remarks { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
