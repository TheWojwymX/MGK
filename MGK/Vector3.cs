using System;

namespace MGK
{
    public class Vector3
    {
        public float x, y, z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void AddVector(Vector3 v)
        {
            x += v.x;
            z += v.z;
            y += v.y;
        }
        
        public Vector3 AddVectors(Vector3 v)
        {
            return new Vector3(x + v.x, y + v.y, z + v.z);
        }
        
        public void SubVector(Vector3 v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
        }
        
        public Vector3 SubVectors(Vector3 v)
        {
            return new Vector3(x - v.x, y - v.y, z - v.z);
        }

        public Vector3 MulVectorByScalar(float a)
        {
            return new Vector3(x * a, y * a, z * a);
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

        public Vector3 VectorNormalize()
        {
            float v = VectorLength();
            if (v == 0)
            {
                throw new Exception("Can't normalize a zero vector");
            }
            else
            {
                return new Vector3(x / v, y / v, z / v);
            }
        }

        public Vector3 dot(Vector3 v)
        {
            Vector3 result = new Vector3(0, 0, 0);
            result.x = x * v.x;
            result.y = y * v.y;
            result.z = z * v.z;
            return result;
        }

        public float dotProduct(Vector3 v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public Vector3 crossProduct(Vector3 v)
        {
            return new Vector3(y * v.z - z * v.y,
                              z * v.x - x * v.z,
                              x * v.y - y * v.x);
        }

        public Quaternion ToQuaternion()
        {
            return new Quaternion(0, this);
        }

        public float FindAngle(Vector3 v)
        {
            float RadAngle = (float)Math.Acos(dotProduct(v) / (VectorLength() * v.VectorLength()));
            return (float)(RadAngle * 180 / Math.PI);
        }
    }
}