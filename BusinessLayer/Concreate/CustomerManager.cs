using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class CustomerManager :ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void CustomerAdd(Customer cus)
        {
            _customerDal.Insert(cus);
        }

        public void CustomerUpdate(Customer cus)
        {
            throw new NotImplementedException();
        }
    }
}
