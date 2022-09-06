using Order_CRUD.data;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Reposatery.Implementation
{
    public class ItemRepo : GenericRepo<ItemSetupEntity>, IItemRepo
    {
        private readonly ApplicationDbContex context;

        public ItemRepo(ApplicationDbContex context) : base(context)
        {
            this.context = context;
        }
    }
}
