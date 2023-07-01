using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    public class Car
    {
        public string Name { get; set; }
        public decimal Speed { get; set; }
        public decimal Distance { get; set; }
        public decimal DistanceLeft { get; set; }
        public int Time { get; set; }
        

        public decimal Target()
        {
            return decimal.ToInt32(DistanceLeft / (Speed / 3.6m));
        }


        public decimal RemainingTime()
        {
            return decimal.ToInt32(DistanceLeft / (Speed / 3.6m) - Distance);
        }


        public static void OutofGas(Car car)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{car.Name} behöver tanka. Stannar 30 sekunder");
            car.Distance -= 30;
            car.Time += 30;
            Console.WriteLine("-------------------------------------------------");

        }

        public static void Puncture(Car car)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{car.Name} behöver byta däck. Stannar 20 sekunder");
            car.Time += 20;
            car.Distance -= 20;
            Console.WriteLine("-------------------------------------------------");
        }

        public static void BirdOnWindshield(Car car)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"{car.Name} behöver tvätta vindrutan. Stannar 10 sekunder");
            car.Time += 10;
            car.Distance -= 10;
            Console.WriteLine("-------------------------------------------------");
        }

        public static void EngineFailure(Car car)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Hastigheten på {car.Name} sänks med 1 km/h");
            car.Speed -= 1;
            Console.WriteLine("-------------------------------------------------");
        }


      
      
    }
}
