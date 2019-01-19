using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Utils
{
    public class PairedValues
    {
        // These are just simple ways of creating a getter and setter in c#
        public int valueX { get; set; }
        public int valueY { get; set; }
        public bool isEnd { get; set; }

        // A constructor which sets all your getters and setters
        public PairedValues(int valueX, int valueY, bool isEnd)
        {
            this.valueX = valueX;
            this.valueY = valueY;
            this.isEnd = isEnd;
        }
    }
    public class VH
    {

     
        static int CompareXY(PairedValues a, PairedValues b)
        {
            var x=a.valueX.CompareTo(b.valueX);
            if (x != 0)
                return x;

            return a.valueY.CompareTo(b.valueY);
        }

        public int GetIntersections(int[][] segments)
        {
            var n = segments.Count();
            int firstY = segments[0][1];
            List<PairedValues> pairedValues = new List<PairedValues>();

            for (int i = 0; i < n; i++)
            {
                if (segments[i][0] <= segments[i][2])
                {
                    pairedValues.Add(new PairedValues(segments[i][0], segments[i][1], false));
                    pairedValues.Add(new PairedValues(segments[i][2], segments[i][3], true));
                }
            }
            pairedValues.Sort(CompareXY);



            return 0;
        }

        public void GetUniqueV(int[][] segments)
        {

        }



    }
}
