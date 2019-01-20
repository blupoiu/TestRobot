using RobotCleaner.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RobotCleaner
{
    public class RobotMovements
    {
        private SweepLinesWithSameDirection sweep = new SweepLinesWithSameDirection();
        private SweepVerticalHorizontalIntersections sl = new SweepVerticalHorizontalIntersections();


        #region Process Data

        public int ProcessData(int commands, int[] startingPosition, string[] alllines)
        {
            int[][] commandVArrays = new int[CountOccurences(alllines, 'N', 'S') + 1][];
            int[][] commandHArrays = new int[CountOccurences(alllines, 'E', 'W')][];

            startingPosition = startingPosition.Concat(startingPosition).ToArray();
            commandVArrays[0] = new int[4];
            startingPosition.CopyTo(commandVArrays[0], 0);


            int vIndex = 1;
            int hIndex = 0;

            var total = 0; //Initialize with 1 from the first place cleaned

            for (int i = 0; i < commands; i++)
            {
                int.TryParse(alllines[i].Substring(1), out int movementLength);
                var nextPosition = FillLists(startingPosition, alllines[i]);
                if ((alllines[i][0] == 'E') || (alllines[i][0] == 'W'))
                {
                    commandHArrays[hIndex++] = nextPosition;
                }
                else
                {
                    commandVArrays[vIndex++] = nextPosition;
                }
                Array.Copy(nextPosition, startingPosition, 4);
            }
            Comparer<int> comparer = Comparer<int>.Default;
            Array.Sort<int[]>(commandVArrays, (x, y) => comparer.Compare(x[0], y[0]));
            Array.Sort<int[]>(commandHArrays, (x, y) => comparer.Compare(x[1], y[1]));

            int intersection = 0;

            total += sweep.GetUniqueHorizontalCells(commandHArrays);
            total += sweep.GetUniqueVerticalCells(commandVArrays);

            Array.Sort<int[]>(commandHArrays, (x, y) => comparer.Compare(x[0], y[0]));
            intersection = sl.GetIntersections(commandVArrays, commandHArrays);

            return total - intersection;
        }
        public int ProcessData(string fileName)
        {
            var alllines = File.ReadAllLines(fileName);
            int.TryParse(alllines[0], out int commands);
            var startingPosition = Array.ConvertAll<string, int>(alllines[1].Split(" "), int.Parse);

            return ProcessData(commands, startingPosition, alllines.Skip(2).ToArray());
        }
        #endregion



        #region Private methods
        /// <summary>
        /// Fills the list based on the step
        /// </summary>
        /// <param name="from"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private int[] FillLists(int[] from, string direction)
        {
            int toX = from[2];
            int startX = from[2];
            int toY = from[3];
            int startY = from[3];
            var movementDirection = direction.Substring(0, 1);
            int.TryParse(direction.Substring(1), out int movementLength);

            switch (movementDirection)
            {
                case "N":
                    toY += movementLength;
                    startY++;
                    break;
                case "S":
                    toY -= movementLength;
                    startY--;
                    break;
                case "E":
                    toX += movementLength;
                    startX++;
                    break;
                case "W":
                    toX -= movementLength;
                    startX--;
                    break;
            }
            return new int[] { startX, startY, toX, toY };
        }

        /// <summary>
        /// gets the number of vertical and horizontal lines
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="ord1"></param>
        /// <param name="ord2"></param>
        /// <returns></returns>
        private int CountOccurences(String[] commandString, char ord1, char ord2)
        {
            var count = 0;

            for (int i = 0; i < commandString.Length; i++)
            {
                if ((commandString[i][0] == ord1) || (commandString[i][0] == ord2))
                {
                    count++;
                }
            }

            return count;
        }
        #endregion


    }
}
