using System;

namespace RobotCleaner
{
    class Program
    {
        static string fileName = @"C:\personal\TestRobot-master\TestRobot-master\RobotCleaner\Tests\Test2.txt";
        static void Main(string[] args)
        {
            var date2 = DateTime.Now;


            var robot = new RobotMovements();
            var cleaned = robot.ProcessData(fileName);




            Console.WriteLine($"timp: { DateTime.Now - date2}");
            Console.WriteLine($"Cleaned: {cleaned}");
 
            Console.ReadLine();
        }
    }
}
