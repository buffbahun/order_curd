using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Models;
using Order_CRUD.Reposatery.Repo;
using Order_CRUD.Services;

namespace Order_CRUD.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        private IOrderRepo _orderRepo;
        private IOrderDetailRepo _detailRepo;
        public OrderController(IOrderService service, IOrderRepo repo, IOrderDetailRepo detailRepo)
        {
            _service = service;
            _orderRepo = repo;
            _detailRepo = detailRepo;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var orderEntityLst = _orderRepo.GetAll().ToList();
            var orderModelLst = new List<OrderViewModel>();
            orderEntityLst.ForEach(data =>
            {
                var model = new OrderViewModel();
                entityToModelMap(model, data);
                orderModelLst.Add(model);
            });
            return Ok(orderModelLst);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var orderEntity = _orderRepo.GetById(id);

            var detailEntityLst = _detailRepo.GetAll().Where(obj => obj.OrderId == id).ToList();

            var detailModelLst = new List<OrderDetailViewModel>();
            detailEntityLst.ForEach(data => 
            {
                var model = new OrderDetailViewModel();
                detailEntityToModelMap(model, data);
                detailModelLst.Add(model);
            });

            var model = new OrderViewModel();
            entityToModelMap(model, orderEntity);
            model.OrderDetails = detailModelLst;

            return Ok(model);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Orderdto order)
        {
            _service.save(order);
            return Ok(true);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.delete(id);
            return Ok(true);
        }

        [HttpPost("update/{id}")]
        public IActionResult Update([FromBody] Orderdto order, int id)
        {
            _service.update(id, order);
            return Ok(true);
        }

        private void entityToModelMap(OrderViewModel model, OrderEntity entity)
        {
            model.Id = entity.Id;
            model.CostomerId = entity.CostomerId;
            model.Date = entity.Date;
            model.NepaliDate = entity.NepaliDate;
            model.Remarks = entity.Remarks;
        }

        private void detailEntityToModelMap(OrderDetailViewModel model, OrderDetailEntity entity)
        {
            model.Id = entity.Id;
            model.OrderId = entity.OrderId;
            model.ItemId = entity.ItemId;
            model.UnitId = entity.UnitId;
            model.Rate = entity.Rate;
            model.Quantity = entity.Quantity;
        }

    }
}
