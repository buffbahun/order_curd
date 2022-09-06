using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public class ItemService: IItemService
    {
        private IItemRepo _repo = null;
        public ItemService(IItemRepo repo)
        {
            _repo = repo;
        }

        public void addUnit(Itemdto unit)
        {
            _repo.Insert(new ItemSetupEntity { Name = unit.Name, DefaultRate = unit.Rate });
            _repo.Save();
        }



        public void deleteUnit(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public void updateUnit(int id, Itemdto unit)
        {
            _repo.Update(new ItemSetupEntity { Id = id, Name = unit.Name, DefaultRate = unit.Rate });
            _repo.Save();
        }
    }
}
