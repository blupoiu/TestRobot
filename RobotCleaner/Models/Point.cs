namespace RobotCleaner.Models
{
    public class Point
    {
        public int Coord_X { get; set; }
        public int Coord_Y { get; set; }
        public Point(int coord_X, int coord_Y)
        {
            Coord_X = coord_X;
            Coord_Y = coord_Y;
        }
        public static bool operator >(Point left, Point right) => ((left.Coord_X > right.Coord_X && left.Coord_Y == right.Coord_Y) || (left.Coord_X > right.Coord_X && left.Coord_Y == right.Coord_Y));
        public static bool operator <(Point left, Point right) => ((left.Coord_X <= right.Coord_X && left.Coord_Y == right.Coord_Y) || (left.Coord_X <= right.Coord_X && left.Coord_Y == right.Coord_Y));
    }

}
