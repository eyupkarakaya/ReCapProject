using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetRentalDetailDTOs(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars on r.CarId equals cr.Id
                             join c in context.Customers on r.CustomerId equals c.CustomerId
                             join u in context.Users on c.UserId equals u.UserId
                             select new RentalDetailDTO { RentalId = r.RentalId, CompanyName =c.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
