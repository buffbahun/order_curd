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
    public class OrderService : IOrderService
    {
        private IOrderRepo _repo = null;
        private IOrderDetailService _detailServe = null;
        public OrderService(IOrderRepo repo, IOrderDetailService serv)
        {
            _repo = repo;
            _detailServe = serv;
        }
        public void save(Orderdto dto)
        {
            OrderEntity data = new OrderEntity();
            orderMap(data, dto);
            data.CreatedDate = DateTime.Now;

            _repo.Insert(data);
            _repo.Save();

            int id = data.Id;
            _detailServe.save(id, dto.OrderDetails);
        }

        public void delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            _detailServe.delete(id);
        }

        public void update(int id, Orderdto order)
        {
            var data = _repo.GetById(id);
            orderMap(data, order);
            data.ModifiedDate = DateTime.Now;

            _repo.Update(data);
            _repo.Save();

            _detailServe.update(id, order.OrderDetails);
        }

        private void orderMap(OrderEntity entity, Orderdto dto)
        {
            entity.CostomerId = dto.CustomerId;
            entity.Date = dto.Date;
            entity.NepaliDate = dto.NepaliDate;
            entity.Remarks = dto.Remarks;
        }

        private void detailMap(OrderDetailEntity entity, OrderDetaildto dto)
        {
            entity.ItemId = dto.ItemId;
            entity.UnitId = dto.UnitId;
            entity.Rate = dto.Rate;
            entity.Quantity = dto.Quantity;
        }

    }
}
