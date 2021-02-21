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
            GetCarDetailsTest();
            //BrandTest();
            //ColorTest();
            //CarTest();
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}",
                "ID", "Brand Name", "Car Name", "Model Year", "Color", "Daily Price"));
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}",
                        item.CarId, item.BrandName, item.CarName, item.ModelYear, item.ColorName, item.DailyPrice));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Yeni araç ekleme
            var carAdded = carManager.Add(new Car
            {
                BrandId = 8,
                ColorId = 1,
                DailyPrice = 600,
                ModelYear = 2019,
                Description = "Otomatik"
            });
            Console.WriteLine(carAdded.Message);

            //Araç silme ve güncelleme
            var deleted = carManager.Delete(new Car { Id = 1 });
            Console.WriteLine(deleted.Message);
            var updated = carManager.Update(new Car { Id = 1, BrandId = 17, ColorId = 3, DailyPrice = 485, ModelYear = 2019, Description = "Otomatik" });
            Console.WriteLine(updated.Message);

            //Araçların tümünün ve marka/renk id'ye göre listelenmesi
            Console.WriteLine("--------------------Tümünü listele-----------------------");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("------------------Arabalar listeleri  marka id leri ------------------------");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(car.Id + " " + car.Description + " Marka ID:  " + car.BrandId);
            }

            Console.WriteLine("--------------Arabalar listeleri  renk  id leri ----------------------------");
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(car.Id + car.Description + " Color ID " + car.ColorId);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Yeni Marka Ekleme
            var brandAdded = brandManager.Add(new Brand
            {
                BrandName = "mazda"
            });
            Console.WriteLine(brandAdded.Message);

            //Marka Silme ve Güncelleme
            var updatedBrand = brandManager.Update(new Brand { BrandId = 9, BrandName = "nissan" });
            Console.WriteLine(updatedBrand.Message);
            var deletedBrand = brandManager.Delete(new Brand { BrandId = 16 });
            Console.WriteLine(deletedBrand.Message);

            //Markaların tümünün ve ID'ye göre listelenmesi
            Console.WriteLine("--------------Araba markaları listelendi-------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("--------------marka id leri -------------");
            Console.WriteLine(brandManager.GetById(4).Data);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Yeni renk ekleme
            var colorAdded = colorManager.Add(new Color
            {
                ColorName = "Sarı"
            });
            Console.WriteLine(colorAdded.Message);
            

            //Renk silme ve güncelleme
            var colorUpdated = colorManager.Update(new Color { ColorId = 5, ColorName = "Kırmızı" });
            Console.WriteLine(colorUpdated.Message);
            var colorDeleted = colorManager.Delete(new Color { ColorId = 7 });
            Console.WriteLine(colorDeleted.Message);

            //Renklerin tümünün ve ID'ye göre istenen rengin listelenmesi
            Console.WriteLine("--------------Tüm renkler listelendi-------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("--------------Renk idleri-------------");
            Console.WriteLine(colorManager.GetById(2).Data);
        }
    }
}
