using Order_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public interface IOrderDetailService
    {
        public void delete(int id);
        public void save(int id, List<OrderDetaildto> lst);
        public void update(int id, List<OrderDetaildto> lst);
    }
}
