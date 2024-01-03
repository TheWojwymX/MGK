namespace MGK
{
    public class Plane
    {
        public Vector3 Normal;
        public Vector3 Point;

        public Plane(Vector3 Normal, Vector3 Point)
        {
            this.Normal = Normal;
            this.Point = Point;
        }

        public Vector3 planeWithLineIntersection(Line l1)
        {
            float t = (-1 * Normal.dotProduct(l1.Point.SubVectors(Point))) / Normal.dotProduct(l1.Direction);
            return l1.Point.AddVectors(l1.Direction.MulVectorByScalar(t));
        }
    }
}