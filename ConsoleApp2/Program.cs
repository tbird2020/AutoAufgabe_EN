// See https://aka.ms/new-console-template for more information

namespace ClassExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Erstelle erstes Auto");

            //first car, is filled with 50l and has a consumption of 4l / 10km.
            var firstCar = new Car(50, 4);
            firstCar.Drive(10);
            firstCar.Drive(30);
            firstCar.Status();
            firstCar.Drive(50);
            firstCar.Refuel();
            firstCar.Drive(100);
            firstCar.Drive(400);
            firstCar.Status();
            firstCar.Drive(30);
            firstCar.Drive(600);
            firstCar.Refuel();
            firstCar.Status();
            firstCar.Drive(300);
            firstCar.Status();

            Console.WriteLine("\n\nErstelle zweites Auto");

            //second car. creation by default constructor.
            var secondCar = new Car();
            secondCar.Drive(10);
            secondCar.Drive(30);
            secondCar.Status();
            secondCar.Drive(50);
            secondCar.Refuel();
            secondCar.Drive(100);
            secondCar.Drive(400);
            secondCar.Status();
            secondCar.Drive(30);
            secondCar.Drive(600);
            secondCar.Refuel();
            secondCar.Status();
            secondCar.Drive(300);
            secondCar.Status();
        }
    }
}