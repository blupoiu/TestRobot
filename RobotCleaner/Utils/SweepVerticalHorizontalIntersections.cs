using RobotCleaner.Enums;
using RobotCleaner.Models;
using System.Collections.Generic;

namespace RobotCleaner.Utils
{
    public class SweepVerticalHorizontalIntersections
    {
        List<Event> listEvents = new List<Event>();
        List<SLEvent> setEvents = new List<SLEvent>();


        /// <summary>
        /// Sorts by x-y-type
        /// the type should be set as: start point, vertical line, end point
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int SortEventsByPoints(Event a, Event b)
        {
            var x = a.point1.Coord_X.CompareTo(b.point1.Coord_X);
            if (x != 0)
                return x;

            x = a.point1.Coord_Y.CompareTo(b.point1.Coord_Y);
            if (x != 0)
                return x;

            return a.type.CompareTo(b.type);
        }

        public int GetIntersections(int[][] commandVArrays, int[][] commandHArrays)
        {
            int vert = commandVArrays.Length;
            int horiz = commandHArrays.Length;

            for (int i = 0; i < vert; i++)
            {
                var point1 = new Point(commandVArrays[i][0], commandVArrays[i][1]);
                var point2 = new Point(commandVArrays[i][2], commandVArrays[i][3]);
                //we need the point from the left as Point1
                if (commandVArrays[i][0] < commandVArrays[i][2])
                {
                    listEvents.Add(new Event(point1, point2, EventType.VerticalLine));
                }
                else
                {
                    listEvents.Add(new Event(point2, point1, EventType.VerticalLine));
                }
            }

            for (int i = 0; i < horiz; i++)
            {
                var point1 = new Point(commandHArrays[i][0], commandHArrays[i][1]);
                var point2 = new Point(commandHArrays[i][2], commandHArrays[i][3]);
                //we need the point from the left as Point1
                if (commandHArrays[i][0] < commandHArrays[i][2])
                {
                    listEvents.Add(new Event(point1, point2, EventType.StartPoint));
                    listEvents.Add(new Event(point2, point1, EventType.EndPoint));
                }
                else
                {
                    listEvents.Add(new Event(point2, point1, EventType.StartPoint));
                    listEvents.Add(new Event(point1, point2, EventType.EndPoint));
                }
            }
            listEvents.Sort(SortEventsByPoints);

            return CalculateIntersections();
        }


        #region Private Methods
        private int CalculateIntersections()
        {
            int result = 0;
            foreach (var c in listEvents)
            {
                if (c.type == EventType.StartPoint) setEvents.Add(new SLEvent(c.point1, c.point2));
                else if (c.type == EventType.EndPoint) setEvents.Remove(new SLEvent(c.point1, c.point2));
                else
                {
                    foreach (var el in setEvents)
                    {
                        if (ValueIsBetween(el.point1.Coord_Y, c.point1.Coord_Y, c.point2.Coord_Y) &&
                            ValueIsBetween(c.point1.Coord_X, el.point1.Coord_X, el.point2.Coord_X))
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }


        private bool ValueIsBetween(int value, int a, int b)
        {
            return (a <= value && value <= b) || (b <= value && value <= a);
        }
        #endregion
    }
}

