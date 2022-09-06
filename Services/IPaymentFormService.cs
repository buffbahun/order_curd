using Order_CRUD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_CRUD.Services
{
    public interface IPaymentFormService
    {
        public void save(PaymentFormdto dto);
        
    }
}
