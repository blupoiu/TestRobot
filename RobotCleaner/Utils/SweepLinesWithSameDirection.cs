using System.Collections.Generic;
using System.Linq;

namespace RobotCleaner.Utils
{
    public class SweepLinesWithSameDirection
    {
        static int Compare1(KeyValuePair<int, bool> a, KeyValuePair<int, bool> b)
        {
            return a.Key.CompareTo(b.Key);
        }

        static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public int GetUniqueHorizontalCells(int[][] segments)
        {
            var n = segments.Count();
            int firstY = segments[0][1];
            int result = 0;

            var myList = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < n; i++)
            {
                //we have to sweep for elements of the same y
                if (segments[i][1] != firstY)
                {
                    result += IntersectionBetweenSegments(myList);
                    myList = new List<KeyValuePair<int, bool>>();
                    firstY = segments[i][1];
                }

                myList.Add(new KeyValuePair<int, bool>(Min(segments[i][0], segments[i][2]), false));
                myList.Add(new KeyValuePair<int, bool>(Max(segments[i][0], segments[i][2]), true));
            }
            result += IntersectionBetweenSegments(myList);
            return result;
        }
        public int GetUniqueVerticalCells(int[][] segments)
        {
            var n = segments.Count();
            int firstX = segments[0][0];
            int result = 0;

            var myList = new List<KeyValuePair<int, bool>>();
            for (int i = 0; i < n; i++)
            {
                //we have to sweep for elements of the same y
                if (segments[i][0] != firstX)
                {
                    result += IntersectionBetweenSegments(myList);
                    myList = new List<KeyValuePair<int, bool>>();
                    firstX = segments[i][0];
                }

                myList.Add(new KeyValuePair<int, bool>(Min(segments[i][1], segments[i][3]), false));
                myList.Add(new KeyValuePair<int, bool>(Max(segments[i][1], segments[i][3]), true));
            }
            result += IntersectionBetweenSegments(myList);
            return result;
        }
  

        private int IntersectionBetweenSegments(List<KeyValuePair<int, bool>> myList)
        {
            int result = 0;  
            myList.Sort(Compare1);
            int counter = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                if (counter > 0)
                    result += (myList[i].Key - myList[i - 1].Key);
                else
                    result += 1;

                if (myList[i].Value == true)
                    counter--;
                else
                    counter++;

            }

            return result;
        }
    }
}
