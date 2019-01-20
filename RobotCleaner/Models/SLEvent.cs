namespace RobotCleaner.Models
{
    public class SLEvent
    {
        public Point point1, point2;
        public SLEvent(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }
    };
}
