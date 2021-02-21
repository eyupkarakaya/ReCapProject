using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
                             join cr in context.Cars on r.CarId equals cr.CarId
                             join b in context.Brands on cr.BrandId equals b.BrandId
                             join c in context.Customers on r.CustomerId equals c.CustomerId
                             join u in context.Users on c.UserId equals u.UserId
                             select new RentalDetailDTO { RentalId = r.RentalId, BrandName = b.BrandName, CustomerName = u.FirstName + " " + u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
