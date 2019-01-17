using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner
{
    public class RobotMovementsNoBF
    {
        private List<int> elX = new List<int>();
        private List<int> elY = new List<int>();
        private Mathematics math = new Mathematics();


        #region Process Data

        public int ProcessData(int commands, int[] startingPosition, string[] alllines)
        {
            int[][] commandVArrays = new int[CountOccurences(alllines, 'N', 'S') + 1][];
            int[][] commandHArrays = new int[CountOccurences(alllines, 'E', 'W')][];

            StringBuilder str = new StringBuilder();
            startingPosition = startingPosition.Concat(startingPosition).ToArray();

            commandVArrays[0] = startingPosition.ToArray();


            int vIndex = 1;
            int hIndex = 0;

            var total = 1; //Initialize with 1 from the first place cleaned

            var intersections = 0;
            for (int i = 0; i < commands; i++)
            {
                int.TryParse(alllines[i].Substring(1), out int movementLength);
                total += movementLength;
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
                str.AppendLine(string.Join(",", nextPosition));
            }


            Comparer<int> comparer = Comparer<int>.Default;
            Array.Sort<int[]>(commandVArrays, (x, y) => comparer.Compare(x[0], y[0]));
            Array.Sort<int[]>(commandHArrays, (x, y) => comparer.Compare(x[0], y[0]));


            for (int i = 0; i < hIndex - 1; i++)
            {
                for (int j = i + 1; j < hIndex; j++)
                {
                    var rezultat = math.UnionHH(commandHArrays[i], commandHArrays[j]);
                    if (rezultat != 0)
                    {
                        intersections += rezultat;
                    }
                }
            }

            for (int i = 0; i < vIndex - 1; i++)
            {
                for (int j = i + 1; j < vIndex; j++)
                {
                    var rezultat = math.UnionVV(commandVArrays[i], commandVArrays[j]);
                    if (rezultat != 0)
                    {
                        intersections += rezultat;
                    }
                }
            }

            for (int i = 0; i < hIndex; i++)
            {
                for (int j = 1; j < vIndex; j++)
                {
                    var rezultat = math.UnionVH(commandHArrays[i], commandVArrays[j], false);
                    if (rezultat != 0)
                    {
                        intersections += rezultat;
                    }
                }
            }

            return total - intersections;
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

        private void InitList(int a, int b)
        {
            elX.Add(a);
            elY.Add(b);

        }
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

        private static int CountOccurences(String[] someString, char searchedChar1, char searchedChar2)
        {
            var count = 0;

            for (int i = 0; i < someString.Length; i++)
            {
                if ((someString[i][0] == searchedChar1) || (someString[i][0] == searchedChar2))
                {
                    count++;
                }
            }

            return count;
        }
        #endregion


    }
}
