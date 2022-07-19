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

        public void CustomerDelete(Customer job)
        {
            throw new NotImplementedException();
        }

        public List<Customer> CustomerList()
        {
            return _customerDal.GetListAll();
        }

        public void CustomerUpdate(Customer cus)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
