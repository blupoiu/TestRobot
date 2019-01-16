using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner
{
    public class RobotMovements
    {
        private List<int> elX = new List<int>();
        private List<int> elY = new List<int>();
        private Mathematics math = new Mathematics();


        #region Process Data

        public int ProcessData(int commands, int[] startingPosition, string[] alllines)
        {
            int[][] commandArrays = new int[commands + 1][];

            StringBuilder str = new StringBuilder();
            startingPosition = startingPosition.Concat(startingPosition).ToArray();

            commandArrays[0] = startingPosition.Concat(startingPosition).ToArray();



            var total = 1; //Initialize with 1 from the first place cleaned

            var intersections = 0;
            for (int i = 0; i < commands; i++)
            {
                int.TryParse(alllines[i].Substring(1), out int movementLength);
                total += movementLength;
                var nextPosition = FillLists(startingPosition, alllines[i]);
                commandArrays[i + 1] = nextPosition;

                Array.Copy(nextPosition, startingPosition, 4);
                str.AppendLine(string.Join(",", nextPosition));
            }


            for (int i = 0; i < commands; i++)
            {
                for (int j = i + 1; j < commands + 1; j++)
                {
                    var rezultat = math.Union(commandArrays[i], commandArrays[j]);
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

            return ProcessData(commands, startingPosition, alllines);
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

        #endregion


    }
}
