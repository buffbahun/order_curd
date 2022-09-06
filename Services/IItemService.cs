using Order_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public interface IItemService
    {
        public void addUnit(Itemdto unit);
        public void deleteUnit(int id);
        public void updateUnit(int id, Itemdto unit);
    }
}
