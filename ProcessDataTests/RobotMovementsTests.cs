using NUnit.Framework;
using RobotCleaner;

namespace ProcessDataTests
{
    [TestFixture]
    class RobotMovementsTests
    {
        private RobotMovements process;

        public RobotMovementsTests()
        {
        }

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Dispose()
        {
            process = null; 
        }


        [TestCase(2, new int[] { 10, 22 }, "E2 N1", 4)]
        public void TestMovement_True(int noCommands, int[] firstLine, string commands, int desiredResult)
        {
            process = new RobotMovements();
            var result = process.ProcessData(noCommands, firstLine, commands.Split(" "));
            Assert.IsTrue(result == desiredResult);
        }


        [TestCase(4, new int[] { 10, 22 }, "E3 N2 W1 S2", 8)]
        public void TestMovement2_True(int noCommands, int[] firstLine, string commands, int desiredResult)
        {
            process = new RobotMovements();
            var result = process.ProcessData(noCommands, firstLine, commands.Split(" "));
            Assert.IsTrue(result == desiredResult);
        }


        [TestCase(10, new int[] { 14, 14 }, "E3 N2 W1 S2 S1 E2 N2 W3 N1 E3", 10)]
        public void TestMovement_False(int noCommands, int[] firstLine, string commands, int desiredResult)
        {
            process = new RobotMovements();
            var result = process.ProcessData(noCommands, firstLine, commands.Split(" "));
            Assert.IsFalse(result == desiredResult);
        }
    }
} 