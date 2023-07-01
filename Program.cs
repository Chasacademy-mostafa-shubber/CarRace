
namespace CarRace
{

    class Program
    {
        static async  Task Main(string[] args)
        {


            //Console.WriteLine("Tryck enter för att starta tävlingen\n");
            //Console.ReadKey();

            Console.WriteLine("Tävlingen har nu börjat. Alla bilar startade samtidigt\n");
            
            var firstCar = new Car
            {
                Name = "Volvo",
                Speed = 120,
                Distance = 0,
                DistanceLeft = 10000,
                Time = 0
               
                
            };

            var secondCar = new Car
            {
                Name = "Kia",
                Speed = 120,
                Distance = 0,
                DistanceLeft = 10000,
                Time = 0
                
            };

            var thirdCar = new Car
            {
                Name = "Tesla",
                Speed = 120,
                Distance = 0,
                DistanceLeft = 10000,
                Time = 0
               
            };

            var firstCarTask = DriveCar(firstCar);
            var secondCarTask = DriveCar(secondCar);
            var thirdCarTask = DriveCar(thirdCar);
            var statusCarTask = CarStatus(new List<Car> { firstCar, secondCar, thirdCar });

            var carTasks = new List<Task> { firstCarTask, secondCarTask, thirdCarTask, statusCarTask };

            while (carTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(carTasks);

                if (finishedTask == firstCarTask)
                {
                    
                    PrintCar(firstCar);

                }

                else if (finishedTask == secondCarTask)
                {
                    
                    PrintCar(secondCar);
                }

                else if (finishedTask == thirdCarTask)
                {
                   
                    PrintCar(thirdCar);
                }

               else if (finishedTask == statusCarTask)
                {

                    Console.WriteLine("Tävlingen är över\n");


                    //Bilen som har minst antal sekunder vinner. Om alla bilar eller två bilar hamnar i mål samtidigt, ingen vinner
                    
                    if(firstCar.Time<secondCar.Time && firstCar.Time < thirdCar.Time)
                    {
                        Console.WriteLine($"{firstCar.Name} vann tävlingen");
                    }

                    else if (secondCar.Time < firstCar.Time && secondCar.Time < thirdCar.Time)
                    {
                        Console.WriteLine($"{secondCar.Name} vann tävlingen");
                    }

                    else if (thirdCar.Time < firstCar.Time && thirdCar.Time < secondCar.Time)
                    {
                        Console.WriteLine($"{thirdCar.Name} vann tävlingen");
                    }

                    

                }

                await finishedTask;
                carTasks.Remove(finishedTask);
            }
        }



        public async static Task<Car> DriveCar(Car car)
        {
            
            int seconds = 0;
            while (true)
            {

                await Task.Delay(TimeSpan.FromSeconds(1));
                car.Time +=1;
                car.Distance+=1;
                seconds += 1;

               
                if (seconds == 30) 
                {

                  Random rd = new Random();
                  var random = rd.Next(1, 21);


                    if (random == 2) // 2%
                    {
                        Car.OutofGas(car);
                    }

                    else if (random == 4) // 4%
                    {
                        Car.Puncture(car);
                    }

                    else if (random == 10) // 10%
                    {
                        Car.BirdOnWindshield(car);
                    }

                    else if (random == 20) // 20%
                    {
                        Car.EngineFailure(car);
                    }


                }



                if (car.Distance ==car.Target())
                {
                    return car;
                }


            }
        }

        public async static Task CarStatus(List<Car> cars)
        {


            //Personen måste trycka på knappen för att se tävlingen i komandot
            Console.WriteLine("Tryck enter för att se statusen för tävlingen");
            Console.ReadKey();

            while (true)
            {

                   Console.Clear();

                   Console.WriteLine("Statusen uppdateras varje 20 sekunder");
                   Console.WriteLine("-------------------------------------\n");

                   foreach (var car in cars)
                    {

                   
                    if (car.RemainingTime() == 0)
                    {
                        Console.WriteLine($"{car.Name} är i mål"); 

                    }
                    else
                    {

                        Console.WriteLine($"{car.Name} kör {car.Speed} km/h och har {car.RemainingTime()} sekunder kvar");

                    }

                    }

                Console.WriteLine();

                await Task.Delay(TimeSpan.FromSeconds(20));

                var totalRemaining = cars.Select(car => car.RemainingTime()).Sum();
   

                if (totalRemaining == 0)
                {
                    return;
                }

 
                
            }


        }


        public static void PrintCar(Car car)
        {
            
            Console.WriteLine($"{car.Name} hamnade i mål inom {car.Time} sekunder");
            
        }

        



    }

}

