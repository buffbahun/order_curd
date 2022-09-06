using Order_CRUD.data;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Reposatery.Implementation
{
    public class UnitRepo : GenericRepo<UnitSetupEntity>, IUnitRepo
    {
        private readonly ApplicationDbContex context;

        public UnitRepo(ApplicationDbContex context) : base(context)
        {
            this.context = context;
        }
    }
}
