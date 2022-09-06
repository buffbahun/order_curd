using Order_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public interface IOrderService
    {
        public void save(Orderdto dto);
        public void delete(int id);
        public void update(int id, Orderdto order);
    }
}
