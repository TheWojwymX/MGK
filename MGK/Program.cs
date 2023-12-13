using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EquationSolver es = new EquationSolver();
            
            Console.WriteLine("Zadanie 1");
            Line line1 = new Line(new Vector3(3, 1, 5), new Vector3(-2, 5, 0)); 
            Line line2 = new Line(new Vector3(1, -5, 3), new Vector3(-2, 4, 0)); 
            Vector3 intersectionResult = es.CalculateLineIntersection3D(line1, line2);
            if (intersectionResult == null)
            {
                Console.WriteLine("Lines are parallel or collinear.");
            }
            else
            {
                Console.WriteLine($"Intersection: {intersectionResult}");
            }
            Console.WriteLine("");
            
            Console.WriteLine("Zadanie 2");
            float angleBetweenLines = es.calculateAngleLineLine(line1, line2);
            Console.WriteLine($"Angle between lines: {angleBetweenLines}");
            Console.WriteLine("");
            
            Console.WriteLine("Zadanie 3");
            Line lineForPlaneIntersection = new Line(new Vector3(3, -1, 2), new Vector3(-2, 2, -1)); 
            Vector4 plane = new Vector4(2, 3, 3, -8); 
            Vector3 linePlaneIntersection = es.calculateLinePlaneIntersection(lineForPlaneIntersection, plane);
            Console.WriteLine($"Line-Plane Intersection: X: {linePlaneIntersection.x}, Y: {linePlaneIntersection.y}, Z: {linePlaneIntersection.z}");
            Console.WriteLine("");


            Console.WriteLine("Zadanie 4");
            float angleLinePlane = es.calculateAngleLinePlane(lineForPlaneIntersection, plane);
            Console.WriteLine($"Angle between line and plane: {angleLinePlane} degrees");
            Console.WriteLine("");
            
            Console.WriteLine("Zadanie 5");
            Vector4 u1 = new Vector4(2, -1, 1, -8);
            Vector4 u2 = new Vector4(4, 3, 1, 14);
            Line l1 = new Line();
            l1 = es.CalculatePlaneIntersectionLine(u1, u2);
            l1.PrintInfo();
            Console.WriteLine("");

            Console.WriteLine("Zadanie 6");
            Console.WriteLine(es.CalculateAngleBetweenPlanes(u1,u2));
            Console.WriteLine("");
            
            Console.WriteLine("Zadanie 7");
            Vector3 directionA = new Vector3(10, 10, 6).SubVectors(new Vector3(5, 5, 4)); 
            Vector3 directionB = new Vector3(10, 10, 3).SubVectors(new Vector3(5, 5, 5));
            Line lineA = new Line(directionA, new Vector3(5, 5, 4)); 
            Line lineB = new Line(directionB, new Vector3(5, 5, 5)); 
            
            Vector3 intersectionPoint = es.FindLineSegmentsIntersection3D(
                lineA.Point, lineA.Point.AddVectors(lineA.Direction),
                lineB.Point, lineB.Point.AddVectors(lineB.Direction));
            if (intersectionPoint!=null)
            {
                Vector3 point = intersectionPoint;
                Console.WriteLine($"Intersection Point: (X: {point.x}, Y: {point.y}, Z: {point.z})");
            }
            else
            {
                Console.WriteLine("No intersection found or segments are not within bounds.");
            }
            Console.WriteLine("");
            
            Console.WriteLine("Zadanie 8");
            Vector3 point1 = new Vector3(3, -1, -2);
            Vector3 point2 = new Vector3(5, 3, -4);
            Vector3 direction = point2.SubVectors(point1); // Direction is point2 - point1
            Line lineForSphereIntersection = new Line(direction, point1);

            Vector3[] sphereIntersections = es.FindSphereLineIntersections(new Vector3(0,0,0), (float)Math.Sqrt(26), lineForSphereIntersection);
            foreach (var point in sphereIntersections)
            {
                Console.WriteLine($"Sphere Intersection point: ({point.x}, {point.y}, {point.z})");
            }
        }
    }
}