using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Implementation;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepo _orderRepo = null;
        private IUnitService _unitServ = null;
        private IItemService _itemServ = null;
        private IPaymentFormService _paymentFormService = null;
        public OrderDetailService(IOrderDetailRepo orderRepo, IUnitService unitServ, IItemService itemServ, IPaymentFormService paymentFormService)
        {
            _orderRepo = orderRepo;
            _unitServ = unitServ;
            _itemServ = itemServ;
            _paymentFormService = paymentFormService;
        }

        //public void HandelUpdate(int id, List<OrderDetaildto> lst)
        //{
        //    var allEntLst = _repo.GetAll().Where(obj => obj.OrderId == id).ToList();
        //    var itemIds = lst.Select(obj => obj.ItemId).ToList().Distinct().ToList();
        //    var allItemIds = allEntLst.Select(obj => obj.ItemId).ToList();
        //    var unitIds = new List<int>();

        //    itemIds.ForEach(i => unitIds.Add(lst.Where(obj => obj.ItemId == i).FirstOrDefault().UnitId));

        //    var toDeleteItems = allItemIds.Except(itemIds).ToList();
        //    var toAddItems = itemIds.Except(allItemIds).ToList();
        //    var toUpdateItems = itemIds.Except(toAddItems).ToList();


        //    if(toDeleteItems.Any())
        //    {
        //        toDeleteItems.ForEach(itm => _repo.Delete(allEntLst.Where(obj => obj.ItemId == itm).FirstOrDefault().ID));
        //        _repo.Save();

        //    }
        //    if (toAddItems.Any())
        //    {
        //        toAddItems.ForEach(itm => {
        //            int total = lst.Where(obj => obj.ItemId == itm).ToList().Sum(itm => itm.Quantity);
        //            decimal rate = lst.Where(obj => obj.ItemId == itm).FirstOrDefault().Rate;
        //            int unitId = lst.Where(obj => obj.ItemId == itm).FirstOrDefault().UnitId;
        //            _repo.Insert(new OrderDetailEntity { ItemId = itm, Quantity = total, OrderId = id, Rate = rate, UnitId = unitId});
        //            _repo.Save();

        //        });
        //    }
        //    if (toUpdateItems.Any())
        //    {
        //        toUpdateItems.ForEach(itm =>
        //        {
        //            int total = lst.Where(obj => obj.ItemId == itm).ToList().Sum(itm => itm.Quantity);
        //            decimal rate = lst.Where(obj => obj.ItemId == itm).FirstOrDefault().Rate;
        //            int unitId = lst.Where(obj => obj.ItemId == itm).FirstOrDefault().UnitId;

        //            var data = allEntLst.Where(obj => obj.ItemId == itm).FirstOrDefault();
        //            data.Quantity = total;
        //            data.Rate = rate;
        //            data.UnitId = unitId;
        //            _repo.Update(data);
        //            _repo.Save();

        //        });
        //    }    
            
        //}


        public void save(int id, List<OrderDetaildto> dtos)
        {
            try
            {
                dtos.ForEach(dto =>
                {
                    dto.OrderId = id;
                    OrderDetailEntity entity = new OrderDetailEntity();
                    mapDtoAndEntity(entity, dto);
                    _orderRepo.Insert(entity);
                    _orderRepo.Save();
                });
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void delete(int id)
        {
            var mapLst = _orderRepo.GetAll().Where(obj => obj.OrderId == id).Select(obj => obj.Id).ToList();
            mapLst.ForEach(dtlId => 
            {
                _orderRepo.Delete(dtlId);
                _orderRepo.Save();
            });
        }

        public void update(int id, List<OrderDetaildto> dtoLst)
        {
            var dtoIdLst = dtoLst.Select(obj => obj.Id).ToList();
            var EntityLst = _orderRepo.GetAll().Where(obj => obj.OrderId == id);
            var EntityIdLst = EntityLst.Select(obj => obj.Id).ToList();
            //decimal updatedPrice = 0;
            var detailLst = new List<OrderDetailEntity>();
            //detailIdLst.ForEach(dtlId => detailLst.Add(_orderRepo.GetById(dtlId)));

            var toDeleteIdLst = EntityIdLst.Except(dtoIdLst).ToList();

            if (toDeleteIdLst.Any())
            {
                toDeleteIdLst.ForEach(dtlId => 
                {
                    //var toCalc = EntityLst.Where(obj => obj.Id == dtlId).FirstOrDefault();
                    //updatedPrice -= toCalc.Rate * toCalc.Quantity;
                    _orderRepo.Delete(dtlId);
                    _orderRepo.Save();
                });
            }

            //dtoLst.Where(obj => obj.Id == 0).ToList().ForEach(obj => 
            //{
                //updatedPrice += obj.Rate * obj.Quantity;
            //});
            save(id, dtoLst.Where(obj => obj.Id == 0).ToList());


            var updateList = dtoLst.Where(a => a.Id != 0).ToList();

            updateList.ForEach(orderDtl =>
            {
                var data = _orderRepo.GetById(orderDtl.Id);
                mapDtoAndEntity(data, orderDtl);

                //updatedPrice += orderDtl.Rate * orderDtl.Quantity;

                _orderRepo.Update(data);
                _orderRepo.Save();

            });

            //_paymentFormService.Update(id, updatedPrice);
        }

        private void mapDtoAndEntity(OrderDetailEntity data, OrderDetaildto orderDtl)
        {
            data.OrderId = orderDtl.OrderId;
            data.ItemId = orderDtl.ItemId;
            data.Quantity = orderDtl.Quantity;
            data.Rate = orderDtl.Rate;
            data.UnitId = orderDtl.UnitId;  
        }
    }
}
