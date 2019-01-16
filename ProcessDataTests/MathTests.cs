using NUnit.Framework;
using RobotCleaner;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessDataTests
{
    [TestFixture]
    class MathTests
    {
        private Mathematics math;

        public MathTests()
        {
            math = new Mathematics();


        }

        [TestCase(3, 5, 4, 6, 1)]
        [TestCase(3, 5, 2, 6, 3)]
        [TestCase(3, 5, 4, 4, 1)]
        [TestCase(3, 5, 5, 5, 1)]
        [TestCase(3, 5, 3, 3, 1)]
        [TestCase(3, 5, -2, 2, 0)]
        [TestCase(3, 5, 6, 9, 0)]
        public void TestSegment_Intersection(int x1, int y1, int x2, int y2, int result)
        {
            var t = math.Intersection(1, 2, 3, 4);
            Assert.IsTrue(t == 0);

        }


        [TestCase(new int[] { 2, 5, 2, 6 })]
        [TestCase(new int[] { 4, 5, 4, 6 })]
        [TestCase(new int[] { 7, 5, 7, 6 })]
        public void Test_IsVerticalLine_True(int[] segment)
        {
            Assert.IsTrue(math.IsV(segment));
        }


        [TestCase(new int[] { 5, 2, 6, 2 })]
        [TestCase(new int[] { 5, 4, 6, 4 })]
        [TestCase(new int[] { 5, 7, 6, 7 })]
        public void Test_IsVerticalLine_False(int[] segment)
        {
            Assert.IsFalse(math.IsV(segment));
        }



        [TestCase(new int[] { 2, 3, 2, 5 }, new int[] { 2, 4, 2, 6 }, 2)]
        [TestCase(new int[] { 2, 3, 2, 5 }, new int[] { 2, 0, 2, 6 }, 3)]
        [TestCase(new int[] { 2, 3, 2, 5 }, new int[] { 4, 6, 4, 0 }, 0)]
        [TestCase(new int[] { 4, 1, 4, -1 }, new int[] { 4, 6, 4, 0 }, 2)]
        [TestCase(new int[] { 4, 7, 4, -1 }, new int[] { 4, 6, 4, 0 }, 7)]
        [TestCase(new int[] { 4, 7, 4, 9 }, new int[] { 4, 6, 4, 0 }, 0)]
        public void Test_Union(int[] segment1, int[] segment2, int resultExpected)
        {
            var result = math.Union(segment1, segment2);

            Assert.IsTrue(result == resultExpected);
        }



    }
}
