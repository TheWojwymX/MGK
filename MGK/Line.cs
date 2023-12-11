namespace MGK
{
    public class Line
    {
        public Vector3 Direction { get; private set; }
        public Vector3 Point { get; private set; }

        public Line()
        {
            
        }
        
        public Line(Vector3 direction, Vector3 point)
        {
            Direction = direction;
            Point = point;
        }
    }
}