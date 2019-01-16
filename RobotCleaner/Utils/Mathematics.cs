using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner
{
    public class Mathematics
    {

        #region Public methods
        /// <summary>
        /// checks the movemnt of the line
        /// </summary>
        /// <param name="source"></param>
        /// <returns>
        /// true = vertical move
        /// false = horizontal move
        /// </returns>
        public bool IsV(int[] source)
        {
            if (source[0] == source[2])
                return true;

            return false;
        }

        /// <summary>
        ///  Returns the number of cells common to two segment
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int Union(int[] from, int[] to)
        {
            bool isVFrom = IsV(from);
            bool isTo = IsV(to);
            var result = 0;
            if (isVFrom && isTo)
            {
                result = UnionVV(from, to);
            }
            else if (isVFrom != isTo)
            {
                result = UnionVH(from, to, isVFrom);
            }
            else
            {
                result = UnionHH(from, to);
            }

            return result;
        }

        /// <summary>
        ///  Returns the number of cells common to two segments
        /// </summary>
        /// <param name="xS"></param>
        /// <param name="xE"></param>
        /// <param name="yS"></param>
        /// <param name="yE"></param>
        /// <returns></returns>
        public int Intersection(int xS, int xE, int yS, int yE)
        {
            Change(ref xS, ref xE);
            Change(ref yS, ref yE);

            if ((yS > xE) || (xS > yE))
            {
                return 0;
            }

            int r1 = xS > yS ? xS : yS;
            int r2 = xE < yE ? xE : yE;
            return Math.Abs(r2 - r1) + 1;
        }

        #endregion

        #region Unions
        //x1 = a[0] y1= a[1] x2=a[3] y2=a[4]  
        //x3 = b[0] y3 =b1   x4=b[3] y4=b[4]

        /// <summary>
        /// simplest case. If the have an intersaction it will be just one element
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="isVFrom"></param>
        /// <returns></returns>
        private int UnionVH(int[] a, int[] b, bool isVFrom)
        {
            if (isVFrom)
            {
                //has an intersection if
                //y3 is between y1 and y2 and x1 is between x3 and x4  
                return (IsWithin(b[1], a[1], a[3]) && IsWithin(a[0], b[0], b[2])) ? 1 : 0;
            }
            else
            {
                //has an intersection if
                // x3/4 is between x1 and x2 and y1 is between y3 and y4
                return (IsWithin(b[0], a[0], a[2]) && IsWithin(a[1], b[1], b[3])) ? 1 : 0;
            }
        }

        private int UnionVV(int[] a, int[] b)
        {
            if (a[0] != b[0])
                return 0;

            return Intersection(a[1], a[3], b[1], b[3]);

        }

        private int UnionHH(int[] a, int[] b)
        {
            if (a[1] != b[1])
                return 0;

            return Intersection(a[0], a[2], b[0], b[2]);
        }
        #endregion
        
        #region Private methods
        private void Change(ref int a, ref int b)
        {
            int c = 0;
            if (a > b)
            {
                c = a;
                a = b;
                b = c;
            }
        }
        public bool IsWithin(int value, int a, int b)
        {
            return (value >= a && value <= b) || (value <= a && value >= b);
        } 
        #endregion
    }
}
