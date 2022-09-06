using Order_CRUD.DTO;
using Order_CRUD.Entities;
using Order_CRUD.Reposatery.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public class PaymentFormService : IPaymentFormService
    {
        private IPaymentFormRepo _repo = null;
        private IOrderSummaryRepo _summaryRepo = null;
        public PaymentFormService(IPaymentFormRepo repo, IOrderSummaryRepo summaryRepo)
        {
            _repo = repo;
            _summaryRepo = summaryRepo;
        }
        public void save(PaymentFormdto dto)
        {
            var form = new PaymentFormEntity() { CreatedDate = DateTime.Now, CustomerId = dto.CustomerId, Paid = dto.PaidAmount };
            _repo.Insert(form);
            _repo.Save();
            int formId = form.Id;
            dto.OderSummary.ForEach(dt => 
            {
                _summaryRepo.Insert(new OderSummaryEntity() { OrderId = dt.OrderId, RemainingBalance = dt.RemainingBalance, PaidAmount = dt.PaidAmount, PaymentFormId = formId});
                _summaryRepo.Save();
            });
        }
    }
}
