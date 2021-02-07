using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Yeni bir araba ekle");
            carManager.Add(new Car
            {
                Id=1,
                ColorId=2,
                CarName="Volvo",           
                BrandId=3,
                DailyPrice=250,
                ModelYear=2019,
                Description ="Volvo"
            });
            Console.WriteLine("Araç tablosundaki  Açıklamaları Listele");

            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine("Araba Adı:" + " " + c.Description);
            }
            Console.WriteLine("Listedeli arabaların marka ıd leri");

            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
