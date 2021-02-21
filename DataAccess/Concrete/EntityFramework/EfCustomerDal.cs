using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarContext>, ICustomerDal
    {
        public List<CustomerDetailDTO> GetCustomerDetailDTOs()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDTO { CustomerId = c.CustomerId, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName };
                return result.ToList();
            }
        }       
    }
}
