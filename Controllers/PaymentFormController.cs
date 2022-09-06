using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Models;
using Order_CRUD.Reposatery.Repo;
using Order_CRUD.Services;

namespace Order_CRUD.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentFormController : ControllerBase
    {
        private IPaymentFormService _service;
        private IPaymentFormRepo _repo;
        private IOrderSummaryRepo _orderSummaryRepo;
        private IOrderRepo _orderRepo;
        private IOrderDetailRepo _orderDetailRepo;
        public PaymentFormController(IOrderDetailRepo orderDetailRepo, IOrderRepo orderRepo, IPaymentFormRepo repo, IPaymentFormService service, IOrderSummaryRepo orderSummaryRepo)
        {
            _service = service;
            _repo = repo;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
            _orderSummaryRepo = orderSummaryRepo;
        }

        [HttpGet("getById/{costomerId}")]
        public IActionResult GetById(int costomerId)
        {
            var orderIdLst = _orderRepo.GetAll().Where(obj => obj.CostomerId == costomerId).Select(obj => obj.Id).ToList();
            var formLst = _repo.GetAll().Where(obj => obj.CustomerId == costomerId);
            var summaryModelLst = new List<OderSummaryModel>();
            orderIdLst.ForEach(orderId =>
            {
                decimal remainingBalance = _orderDetailRepo.GetAll().Where(obj => obj.OrderId == orderId).Aggregate(0, (acc, obj) => (int)(acc + obj.Quantity * obj.Rate));
                if (formLst.Any())
                {
                    var latestFormId = formLst.Select(obj => obj.Id).ToList().Max();
                    var savedSummary = _orderSummaryRepo.GetAll().Where(obj => obj.OrderId == orderId && obj.PaymentFormId == latestFormId).FirstOrDefault();
                    var ifSavedRemaining = savedSummary != null ? remainingBalance - savedSummary.RemainingBalance : remainingBalance - 0;
                    summaryModelLst.Add(new OderSummaryModel() { RemainingBalance = ifSavedRemaining, PaidAmount = remainingBalance - ifSavedRemaining, OrderId = orderId });
                }
                else
                {
                    summaryModelLst.Add(new OderSummaryModel() { RemainingBalance = remainingBalance, PaidAmount = 0, OrderId = orderId });
                }
            });
            return Ok(new PaymentFormModel() { PaidAmount = 0, CustomerId = costomerId, OderSummary = summaryModelLst });
        }

        [HttpPost("addPayment")]
        public IActionResult AddPayment([FromBody] PaymentFormdto dto)
        {
            _service.save(dto);
            return Ok("Success");
        }

        //public dynamic getJsonData(List<OrderEntity> orders)
        //{


        //    List<dynamic> datas = new List<dynamic>();
        //    foreach (var order in orders)
        //    {
        //        var orderDetailQueryable = _orderDetailRepo.getQueryable().Where(a => a.OrderId == order.Id);//.ToList();

        //        orderDetailQueryable = orderDetailQueryable.OrderByDescending(a => a.CreatedDate).Take(1);

        //        var details = orderDetailQueryable.ToList();

        //        var data = new
        //        {

        //        };

        //        datas.Add(data);
        //    }
        //    return datas;

        //}
    }
}
