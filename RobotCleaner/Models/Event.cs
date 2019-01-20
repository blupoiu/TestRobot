using RobotCleaner.Enums;

namespace RobotCleaner.Models
{
    public class Event
    {
        public Point point1, point2;
        public EventType type;
        public Event(Point point1, Point point2, EventType type)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.type = type;
        }

        public static bool operator >(Event left, Event right) => left.point1.Coord_X >= right.point1.Coord_X;
        public static bool operator <(Event left, Event right) => left.point1.Coord_X < right.point1.Coord_X;
    };
}
