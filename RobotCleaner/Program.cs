using System;

namespace RobotCleaner
{
    class Program
    {
        static string fileName = @"Tests\Test4.txt";
        static void Main(string[] args)
        {
            var robot = new RobotMovements();
            var cleaned = robot.ProcessData(fileName);

            Console.WriteLine($"=> Cleaned: {cleaned} ");
            Console.ReadLine();
        }
    }
}
