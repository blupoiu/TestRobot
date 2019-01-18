using NUnit.Framework;
using RobotCleaner.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessDataTests
{
    public class SweepLineVHTests
    {

        private VH sl;

        public SweepLineVHTests()
        {
            sl = new VH();

        }



        [TestCase()]
        public void TestH1()
        {
            int[][] commandHArrays = new int[4][];
            commandHArrays[0] = new int[4] { 2, 3, 5, 3 };
            commandHArrays[3] = new int[4] { 2, 4, 5, 4 };
            commandHArrays[1] = new int[4] { 3, 2, 8, 2 };
            commandHArrays[2] = new int[4] { 4, 1, 4, 4 };



            sl.GetIntersections(commandHArrays);

        }


    }



}
