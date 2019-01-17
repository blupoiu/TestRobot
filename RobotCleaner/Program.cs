using System;

namespace RobotCleaner
{
    class Program
    {
        static string fileName = @"f:\Test4.txt";
        static void Main(string[] args)
        {
            var date2 = DateTime.Now;


            RobotMovementsNoBF robot = new RobotMovementsNoBF();
            var cleaned = robot.ProcessData(fileName);




            Console.WriteLine($"timp: { DateTime.Now - date2}");
            Console.WriteLine($"Cleaned: {cleaned}");
 
            Console.ReadLine();
        }
    }
}
