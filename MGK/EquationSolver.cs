using System;

namespace MGK
{
    public class EquationSolver
    {
        public Vector3 CalculateLineIntersection3D(Line line1, Line line2)
        {
            Vector3 p1 = line1.Point;
            Vector3 d1 = line1.Direction;
            Vector3 p2 = line2.Point;
            Vector3 d2 = line2.Direction;
            
            // Calculate the cross product of the direction vectors
            Vector3 p3 = d1;
            p3 = p3.crossProduct(d2);
            
            // If the cross product is (0,0,0), the lines are parallel or collinear
            if (p3.x == 0 && p3.y == 0 && p3.z == 0)
            {
                return null; 
            }

            // Construct the coefficients matrix and the constant vector
            float[,] coefficients =
            {
                { d1.x, -d2.x, p2.x - p1.x },
                { d1.y, -d2.y, p2.y - p1.y },
                { d1.z, -d2.z, p2.z - p1.z }
            };

            // Solve for 't' and 's' using Cramer's rule (eew... Math)
            float detCoeff = Determinant(coefficients, 0, 1);
            float detT = Determinant(coefficients, 0, 2);
            float detS = Determinant(coefficients, 1, 2);

            // Check to avoid division by zero
            if (detCoeff == 0)
                return null;

            float t = detT / detCoeff;
            float s = detS / detCoeff;

            // Calculate the potential intersection points on each line
            Vector3 intersection1 = new Vector3(p1.x + t * d1.x,
                p1.y + t * d1.y,
                p1.z + t * d1.z);

            Vector3 intersection2 = new Vector3(p2.x + s * d2.x,
                p2.y + s * d2.y,
                p2.z + s * d2.z);

            if (ApproximatelyEqual(intersection1, intersection2))
            {
                return intersection1;
            }
            else
            {
                return null; 
            }
        }

        private float Determinant(float[,] matrix, int col1, int col2)
        {
            return matrix[0, col1] * matrix[1, col2] - matrix[1, col1] * matrix[0, col2];
        }

        private bool ApproximatelyEqual(Vector3 a, Vector3 b)
        {
            float tolerance = 1e-5f;
            return Math.Abs(a.x - b.x) < tolerance &&
                   Math.Abs(a.y - b.y) < tolerance &&
                   Math.Abs(a.z - b.z) < tolerance;
        }

        public float calculateAngleLineLine(Line line1, Line line2)
        {
            Vector3 v = line1.Direction;
            Vector3 u = line2.Direction;
            if (CalculateLineIntersection3D(line1, line2) != null)
            {
                return v.FindAngle(u);
            }
            else
            {
                Console.WriteLine("Lines do not intersect");
                return 0;
            }
            
        }

        public Vector3 calculateLinePlaneIntersection(Line line, Vector4 plane)
        {
            Vector3 v1 = line.Point;
            Vector3 v2 = line.Direction;
            
            float total_n = v1.x * plane.x + v1.y * plane.y + v1.z * plane.z + plane.w;
            float total_t = v2.x * plane.x + v2.y * plane.y + v2.z * plane.z;
            float t = -total_n / total_t;

            return new Vector3((v1.x + v2.x * t), (v1.y + v2.y * t), (v1.z + v2.z * t));
        }
        
        public float calculateAngleLinePlane(Line line, Vector4 plane)
        {
            Vector3 lineDirection = line.Direction;
            Vector3 planeNormal = new Vector3(plane.x, plane.y, plane.z);

            return lineDirection.FindAngle(planeNormal);
        }
        
        public Line CalculatePlaneIntersectionLine(Vector4 planeA, Vector4 planeB)
        {
            Vector3 normalA = new Vector3(planeA.x, planeA.y, planeA.z);
            Vector3 normalB = new Vector3(planeB.x, planeB.y, planeB.z);
            
            Vector3 lineDirection = normalA.crossProduct(normalB);

            if (lineDirection.x == 0 && lineDirection.y == 0 && lineDirection.z == 0)
            {
                return null;
            }
            
            float determinant = normalA.x * normalB.y - normalA.y * normalB.x;

            if (Math.Abs(determinant) < 1e-5)
            {
                return null; 
            }

            // Setting z = 0
            float x = (normalB.y * planeA.w - normalA.y * planeB.w) / determinant;
            float y = (normalA.x * planeB.w - normalB.x * planeA.w) / determinant;

            Vector3 pointOnLine = new Vector3(x, y, 0);

            return new Line(lineDirection, pointOnLine);
        }
        
        public float CalculateAngleBetweenPlanes(Vector4 planeA, Vector4 planeB)
        {
            Vector3 normalA = new Vector3(planeA.x, planeA.y, planeA.z);
            Vector3 normalB = new Vector3(planeB.x, planeB.y, planeB.z);

            float dotProduct = normalA.dotProduct(normalB);

            float magnitudeA = normalA.VectorLength();
            float magnitudeB = normalB.VectorLength();

            float cosTheta = dotProduct / (magnitudeA * magnitudeB);
            float angleRadians = (float)Math.Acos(cosTheta);
            float angleDegrees = angleRadians * (180f / (float)Math.PI);

            return angleDegrees;
        }

        public Vector3 FindLineSegmentsIntersection3D(Vector3 A, Vector3 A_prime, Vector3 B, Vector3 B_prime)
        {
            Vector3 d1 = A_prime.SubVectors(A);
            Vector3 d2 = B_prime.SubVectors(B); 

            Vector3 r = A.SubVectors(B);
            float a = d1.dotProduct(d1);
            float e = d2.dotProduct(d2);
            float f = d2.dotProduct(r);

            if (a <= 1e-5 || e <= 1e-5)
            {
                return null; // Degenerate cases
            }

            float b = d1.dotProduct(d2);
            float c = d1.dotProduct(r);
            float s = (b * f - c * e) / (a * e - b * b);

            if (s < 0 || s > 1)
            {
                return null; 
            }

            float t = (b * s + f) / e;

            if (t < 0 || t > 1)
            {
                return null; 
            }

            Vector3 intersection = A.AddVectors(d1.MulVectorByScalar(s));
            return intersection;
        }

        public Vector3[] FindSphereLineIntersections(Vector3 sphereCenter, float radius, Line line)
        {
            Vector3 d = line.Direction; // Use the direction directly
            Vector3 f = line.Point.SubVectors(sphereCenter);

            float a = d.dotProduct(d);
            float b = 2 * f.dotProduct(d);
            float c = f.dotProduct(f) - radius * radius;

            float discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return new Vector3[0]; 
            }

            float t1 = (-b - (float)Math.Sqrt(discriminant)) / (2 * a);
            float t2 = (-b + (float)Math.Sqrt(discriminant)) / (2 * a);

            Vector3 intersection1 = line.Point.AddVectors(d.MulVectorByScalar(t1));
            Vector3 intersection2 = line.Point.AddVectors(d.MulVectorByScalar(t2));

            if (discriminant == 0)
            {
                return new Vector3[] { intersection1 }; 
            }
            else
            {
                return new Vector3[] { intersection1, intersection2 }; 
            }
        }
        
    }
}