using NUnit.Framework;
using RobotCleaner.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessDataTests
{
    public class SweepVerticalHorizontalIntersectionsTests
    {

        private SweepVerticalHorizontalIntersections sl;

        public SweepVerticalHorizontalIntersectionsTests()
        {
        }



        [TestCase()]
        public void TestIntersection_True()
        {
            sl = new SweepVerticalHorizontalIntersections();
            int[][] commandHArrays = new int[2][];
            commandHArrays[0] = new int[4] { 14, 14, 17, 14 };
            commandHArrays[1] = new int[4] { 15, 15, 18, 15 };
          

            int[][] commandVArrays = new int[2][];
            commandVArrays[0] = new int[4] { 16, 10, 16, 18 };
            commandVArrays[1] = new int[4] { 17, 13, 17, 14 };
            
            var result = sl.GetIntersections(commandVArrays, commandHArrays);
            Assert.IsTrue(result == 3);

        }



        [TestCase()]
        public void TestIntersection_False()
        {
            sl = new SweepVerticalHorizontalIntersections();
            int[][] commandHArrays = new int[5][];
            commandHArrays[0] = new int[4] { 15, 14, 17, 14 };
            commandHArrays[1] = new int[4] { 16, 16, 16, 16 };
            commandHArrays[2] = new int[4] { 16, 16, 18, 16 };
            commandHArrays[3] = new int[4] { 17, 13, 18, 13 };
            commandHArrays[4] = new int[4] { 15, 15, 17, 15 };


            int[][] commandVArrays = new int[6][];
            commandVArrays[0] = new int[4] { 14, 14, 14, 14 };
            commandVArrays[1] = new int[4] { 15, 16, 15, 16 };
            commandVArrays[2] = new int[4] { 16, 14, 16, 15 };
            commandVArrays[3] = new int[4] { 16, 13, 16, 13 };
            commandVArrays[4] = new int[4] { 17, 15, 17, 16 };
            commandVArrays[5] = new int[4] { 18, 14, 18, 15 };


            var result = sl.GetIntersections(commandVArrays, commandHArrays);
            Assert.IsFalse(result == 42);

        }


    }



}
