using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Vector3 p1 = new Vector3(-2, 5, 0);
            Vector3 p2 = new Vector3(-2, 4, 0);
            Vector3 d1 = new Vector3(3, 1, 5);
            Vector3 d2 = new Vector3(1, -5, 3);

            EquationSolver es = new EquationSolver();
            Vector3 result = es.CalculateLineIntersection3D(p1, d1, p2, d2);
            if (result == null)
            {
                Console.WriteLine("Rownolegle");
            }
            
            Console.WriteLine("");
            float angle = es.calculateAngleLineLine(d1,d2);
            Console.WriteLine(angle);
            
            Console.WriteLine("");
            Vector3 v1 = new Vector3(-2,2,-1);
            Vector3 v2 = new Vector3(3,-1,2);
            Vector4 plane = new Vector4(2,3,3,-8);
            Vector3 res = es.calculateLinePlaneIntersection(v1, v2, plane);
            Console.WriteLine(res.x);
            Console.WriteLine(res.y);
            Console.WriteLine(res.z);
            
            Console.WriteLine("");
            Vector4 u1 = new Vector4(2, -1, 1, -8);
            Vector4 u2 = new Vector4(4, 3, 1, 14);
            Line l1 = new Line();
            l1 = es.CalculatePlaneIntersectionLine(u1, u2);
            Console.WriteLine(l1.Direction.x);
            Console.WriteLine(l1.Direction.y);
            Console.WriteLine(l1.Direction.z);
            Console.WriteLine(l1.Point.x);
            Console.WriteLine(l1.Point.y);
            Console.WriteLine(l1.Point.z);
            
            Console.WriteLine("");
            Console.WriteLine(es.CalculateAngleBetweenPlanes(u1,u2));
            
            Console.WriteLine("");
            Vector2 A = new Vector2(5, 4);
            Vector2 A_prime = new Vector2(10, 6);
            Vector2 B = new Vector2(5, 5);
            Vector2 B_prime = new Vector2(10, 3);
            Vector2 intersection = new Vector2();
            intersection = es.FindLineSegmentsIntersection(A, A_prime, B, B_prime);
            Console.WriteLine(intersection.x);
            Console.WriteLine(intersection.y);
        }
    }
}