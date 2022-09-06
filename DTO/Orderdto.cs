using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.DTO
{
    public class Orderdto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string NepaliDate { get; set; }
        public string Remarks { get; set; }
        public List<OrderDetaildto> OrderDetails { get; set; }
    }
}
