using Biltävlingen.Models;
using System.Diagnostics;

namespace Biltävlingen;
class Program
{
    static async Task Main(string[] args)
    {
        await StartSimulation();
    }

    public static async Task StartSimulation()
    {
        Console.WriteLine(" ============================================");
        Console.WriteLine(" |                                          |");
        Console.WriteLine(" |            Car Race Simulation           |");
        Console.WriteLine(" |                                          |");
        Console.WriteLine(" ============================================");

        Console.Write("\n Press any key to start the simulation..");
        Console.ReadLine();

        Car Car1 = new Car(1, "Audi Quattro", 0, 120, null);
        Car Car2 = new Car(2, "Toyota Supra", 0, 120, null);   

        var carSim1 = CarRace(Car1);
        var carSim2 = CarRace(Car2);
        var carSims = new List<Task> { carSim1, carSim2 };

        bool Winner = false;

        while (carSims.Count > 0)
        {
            Task finishedSim = await Task.WhenAny(carSims);

            if (finishedSim == carSim1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (Winner == false)
                {
                    Winner = true;
                    Console.Write($"\n {Car1.Model} is the Winner!\n");
                }
                PrintCar(Car1);
            }
            else if (finishedSim == carSim2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Winner == false)
                {
                    Winner = true;
                    Console.Write($"\n {Car2.Model} is the Winner!\n");
                }
                PrintCar(Car2);
            }
            await finishedSim;
            carSims.Remove(finishedSim);
            Console.ForegroundColor = ConsoleColor.White;
        }
    } 

    public static async Task<Car> CarRace(Car car)
    {
        bool simActive = true;
        int raceDistance = 10;
        int randomNumber;
        decimal kmPerSecond, distanceTraveled;
        var timer = new Stopwatch();
        Random randomEvent = new Random();

        Console.Clear();
        Console.WriteLine(" ============================================");
        Console.WriteLine(" |                                          |");
        Console.WriteLine(" |            Car Race Simulation           |");
        Console.WriteLine(" |                                          |");
        Console.WriteLine(" ============================================");

        Console.WriteLine("\n Car race simulation is active.\n");
        // Timer start
        timer.Start();

        while (simActive)
        {
            // Car reached finish line or not
            if (car.DistanceTraveled < raceDistance)
            {
                randomNumber = randomEvent.Next(1, 51);

                kmPerSecond = car.Speed / (60 * 60);
                distanceTraveled = kmPerSecond * 30;     
                
                decimal timeRemaining = (raceDistance - car.DistanceTraveled) / kmPerSecond;

                // Last 30 seconds
                if (car.DistanceTraveled + distanceTraveled >= raceDistance)
                {
                    await Wait((int)timeRemaining);
                    // Timer stop
                    timer.Stop();

                    car.DistanceTraveled += timeRemaining * kmPerSecond;
                    car.FinishTime = timer.Elapsed * 10;
                }
                // Random encounters
                else
                {
                    await Wait(30);

                    if (randomNumber == 1)
                    {
                        Console.WriteLine($" {car.Model} gas tank need refillment (30 seconds delay).");
                        await Wait(30);
                    }
                    else if (randomNumber <= 3)
                    {
                        Console.WriteLine($" {car.Model} tires need changing (20 seconds delay).");
                        await Wait(20);
                    }
                    else if (randomNumber <= 8)
                    {
                        Console.WriteLine($" {car.Model} windshield need cleaning (10 seconds delay).");
                        await Wait(10);
                    }
                    else if (randomNumber <= 18)
                    {
                        Console.WriteLine($" {car.Model} engine is tearing (speed reduced by 1 km/h).");
                        car.Speed -= 1;
                        kmPerSecond = car.Speed / (60 * 60);
                        distanceTraveled = kmPerSecond * 30;
                        car.DistanceTraveled += distanceTraveled;
                    }
                    else
                    {
                        car.DistanceTraveled += distanceTraveled;
                    }
                }            
            }
            else
            {
                simActive = false;
            }   
        }
        return car;
    }

    public static async Task PrintStatus(List<Task> car)
    {

    }

    public static void PrintCar(Car car)
    {
        string time = string.Format("{0:mm\\:ss\\:ff}", car.FinishTime);

        Console.WriteLine("\n ========================================================================================");
        Console.WriteLine($" {car.Model} crossed the finish line at {time}." +
                          $"\n Speed of {car.Speed} km/h and traveled a total of {(int)car.DistanceTraveled} km.");
        Console.WriteLine(" ========================================================================================\n");
    }

    public async static Task Wait(int delay = 30)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay / 10));
    }
}