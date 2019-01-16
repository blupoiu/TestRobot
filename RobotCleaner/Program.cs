using System;

namespace RobotCleaner
{
    class Program
    {
        static string fileName = @"f:\Test4.txt";
        static void Main(string[] args)
        {
            
            RobotMovements robot = new RobotMovements();
            var cleaned = robot.ProcessData(fileName);




            var date2 = DateTime.Now;
            Console.WriteLine($"timp: { DateTime.Now - date2}");


            Console.WriteLine($"Cleaned: {cleaned}");
 
            Console.ReadLine();
        }
    }
}
