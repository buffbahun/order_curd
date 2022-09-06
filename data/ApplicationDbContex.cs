using Microsoft.EntityFrameworkCore;
using Order_CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.data
{
    public class ApplicationDbContex: DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> option) : base(option)
        {

        }

        public DbSet<OrderDetailEntity> orderDetailEntities { get; set; }
        public DbSet<OrderEntity> orderEntities { get; set; }
        public DbSet<UnitSetupEntity> unitEntities { get; set; }
        public DbSet<ItemSetupEntity> itemEntities { get; set; }
        public DbSet<CostomerEntity> costomerEntities { get; set; }
        public DbSet<ItemUnitMapEntity> itemUnitMapEntities { get; set; }
        public DbSet<PaymentFormEntity> paymentFormEntities { get; set; }
        public DbSet<OderSummaryEntity> oderSummaryEntities { get; set; }
       // public DbSet<OrderToOrderDetailMapEntity> orderToOrderDetailMapEntities { get; set; }
    }
}
