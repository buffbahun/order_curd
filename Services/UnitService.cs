using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public class UnitService: IUnitService
    {

        private IUnitRepo _repo = null;
        public UnitService(IUnitRepo repo)
        {
            _repo = repo;
        }

        public void addUnit(Unitdto unit)
        {
            _repo.Insert(new UnitSetupEntity { Name = unit.Name });
            _repo.Save();
        }

       

        public void deleteUnit(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public void updateUnit(int id, Unitdto unit)
        {
            _repo.Update(new UnitSetupEntity { Id = id, Name = unit.Name});
            _repo.Save();
        }
    }
}
