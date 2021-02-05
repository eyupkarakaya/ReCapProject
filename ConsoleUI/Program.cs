using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMomoryCarDal());
            foreach (var c in carManager.GetAll())
            {
                
                Console.WriteLine("Brand Id "+ c.BrandId  +" "+ "Color Id " + c.ColorId + " " + "DailyPrice Id " +" "+ c.DailyPrice + " " + "Model Year" +" "+c.ModelYear + " " + "Description" +" "+c.Description );
               
            }
        }
    }
}
