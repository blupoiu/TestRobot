using NUnit.Framework;
using RobotCleaner.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessDataTests
{
    public class SweepLineTests
    {

        private SweepLine sl;

        public SweepLineTests()
        {
            sl = new SweepLine();

        }


        #region Union between two horizontal lines

        [TestCase()]
        public void TestH1()
        {
            int[][] commandHArrays = new int[3][];
            commandHArrays[0] = new int[4] { 2, 2, 5, 2 };
            commandHArrays[1] = new int[4] { 4, 2, 8, 2 };
            commandHArrays[2] = new int[4] { 9, 2, 12, 2 };


            int result = sl.GetUniqueH(commandHArrays);
            Assert.IsTrue(result == 11);
        }


        [TestCase()]
        public void TestH2()
        {
            int[][] commandHArrays = new int[3][];
            commandHArrays[0] = new int[4] { 1, 2, 5, 2 };
            commandHArrays[1] = new int[4] { 3, 2, 9, 2 };
            commandHArrays[2] = new int[4] { 2, 2, 5, 2 };


            int result = sl.GetUniqueH(commandHArrays);
            Assert.IsTrue(result == 9);
        }


        [TestCase()]
        public void TestH3()
        {
            int[][] commandHArrays = new int[7][];
            commandHArrays[0] = new int[4] { 5, 2, 15, 2 };
            commandHArrays[1] = new int[4] { 7, 2, 16, 2 };
            commandHArrays[2] = new int[4] { 4, 2, 20, 2 };
            commandHArrays[3] = new int[4] { 8, 2, 25, 2 };
            commandHArrays[4] = new int[4] { 3, 2, 17, 2 };
            commandHArrays[5] = new int[4] { 0, 2, 30, 2 };
            commandHArrays[6] = new int[4] { 31, 2, 32, 2 };


            int result = sl.GetUniqueH(commandHArrays);
            Assert.IsTrue(result == 33);
        }


        [TestCase()]
        public void TestH4()
        {
            int[][] commandHArrays = new int[7][];
            commandHArrays[0] = new int[4] { 15, 2, 5, 2 };
            commandHArrays[1] = new int[4] { 16, 2, 7, 2 };
            commandHArrays[2] = new int[4] { 20, 2, 4, 2 };
            commandHArrays[3] = new int[4] { 25, 2, 8, 2 };
            commandHArrays[4] = new int[4] { 17, 2, 3, 2 };
            commandHArrays[5] = new int[4] { 30, 2, 0, 2 };
            commandHArrays[6] = new int[4] { 32, 2, 31, 2 };

            int result = sl.GetUniqueH(commandHArrays);
            Assert.IsTrue(result == 33);
        }


        [TestCase()]
        public void Test_TwoLines()
        {
            int[][] commandHArrays = new int[6][];
            commandHArrays[0] = new int[4] { 1, 2, 5, 2 };
            commandHArrays[1] = new int[4] { 3, 2, 9, 2 };
            commandHArrays[2] = new int[4] { 2, 2, 5, 2 };


            commandHArrays[3] = new int[4] { 1, 3, 5, 3 };
            commandHArrays[4] = new int[4] { 3, 3, 9, 3 };
            commandHArrays[5] = new int[4] { 2, 3, 5, 3 };

            int result = sl.GetUniqueH(commandHArrays);
            Assert.IsTrue(result == 18);
        }


        #endregion

        [TestCase()]
        public void TestV1()
        {
            int[][] commandHArrays = new int[3][];
            commandHArrays[0] = new int[4] { 2, 2, 2, 5 };
            commandHArrays[1] = new int[4] { 2, 4, 2, 8 };
            commandHArrays[2] = new int[4] { 2, 9, 2, 12 };


            int result = sl.GetUniqueV(commandHArrays);
            Assert.IsTrue(result == 11);
        }


        [TestCase()]
        public void Test_V_TwoLines()
        {
            int[][] commandHArrays = new int[6][];
            commandHArrays[0] = new int[4] { 2, 1, 2, 5 };
            commandHArrays[1] = new int[4] { 2, 3, 2, 9 };
            commandHArrays[2] = new int[4] { 2, 2, 2, 5 };


            commandHArrays[3] = new int[4] { 3, 1, 3, 5 };
            commandHArrays[4] = new int[4] { 3, 3, 3, 9 };
            commandHArrays[5] = new int[4] { 3, 2, 3, 5 };

            int result = sl.GetUniqueV(commandHArrays);
            Assert.IsTrue(result == 18);
        }
    }



}
