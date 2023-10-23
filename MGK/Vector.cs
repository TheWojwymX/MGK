using System;

namespace MGK
{
    public class Vector
    {
        public float x, y, z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void AddVector(Vector v)
        {
            x += v.x;
            z += v.z;
            y += v.y;
        }
        
        public void SubVector(Vector v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
        }

        public void MulVectorByScalar(float a)
        {
            x *= a;
            y *= a;
            z *= a;
        }

        public void DivVectorByScalar(float a)
        {
            if (a != 0)
            {
                x /= a;
                y /= a;
                z /= a;
            }
            else
            {
                Console.WriteLine("Can't divide by 0");
            }
        }

        public float VectorLength()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public void VectorNormalize()
        {
            float v = VectorLength();
            if (v != 0)
            {
                DivVectorByScalar(v);
            }
            else
            {
                Console.WriteLine("Can't divide by 0");
            }
        }

        public Vector dot(Vector v)
        {
            Vector result = new Vector(0, 0, 0);
            result.x = x * v.x;
            result.y = y * v.y;
            result.z = z * v.z;
            return result;
        }

        public float dotProduct(Vector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vector crossProduct(Vector v)
        {
            return new Vector(y * v.z - z * v.y,
                              z * v.x - x * v.z,
                              x * v.y - y * v.x);
        }

        public float FindAngle(Vector v)
        {
            float RadAngle = (float)Math.Acos(dotProduct(v) / (VectorLength() * v.VectorLength()));
            return (float)(RadAngle * 180 / Math.PI);
        }
        
        
    }
}