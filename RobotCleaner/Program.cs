using System;

namespace RobotCleaner
{
    class Program
    {
        static string fileName = @"f:\Test4.txt";
        static void Main(string[] args)
        {
            
            RobotMovements robot = new RobotMovements();
            robot.ProcessData(fileName);




            var date2 = DateTime.Now;
            Console.WriteLine($"timp: { DateTime.Now - date2}");

            Console.ReadLine();
        }
    }
}
