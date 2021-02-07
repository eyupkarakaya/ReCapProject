using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMomoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMomoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=10,DailyPrice=200,ModelYear=2021,Description="Audi"},
                new Car{Id=2,BrandId=2,ColorId=11,DailyPrice=120,ModelYear=2015,Description="Opel"},
                new Car{Id=3,BrandId=3,ColorId=12,DailyPrice=100,ModelYear=2010,Description="Nissan"},
                new Car{Id=4,BrandId=4,ColorId=13,DailyPrice=170,ModelYear=2020,Description="Toyota"},
                new Car{Id=5,BrandId=5,ColorId=14,DailyPrice=190,ModelYear=2018,Description="BMW"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id ==Id).ToList();
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
