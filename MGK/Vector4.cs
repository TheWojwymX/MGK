using System;

namespace MGK
{
    public class Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void AddVector(Vector4 v)
        {
            x += v.x;
            y += v.y;
            z += v.z;
            w += v.w;
        }
        
        public void SubVector(Vector4 v)
        {
            x -= v.x;
            y -= v.y;
            z -= v.z;
            w -= v.w;
        }

        public void MulVectorByScalar(float a)
        {
            x *= a;
            y *= a;
            z *= a;
            w *= a;
        }

        public void DivVectorByScalar(float a)
        {
            if (a != 0)
            {
                x /= a;
                y /= a;
                z /= a;
                w /= a;
            }
            else
            {
                Console.WriteLine("Can't divide by 0");
            }
        }

        public float VectorLength()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public void VectorNormalize()
        {
            float length = VectorLength();
            if (length != 0)
            {
                DivVectorByScalar(length);
            }
            else
            {
                Console.WriteLine("Can't normalize a zero vector");
            }
        }
        
        public float DotProduct(Vector4 v)
        {
            return x * v.x + y * v.y + z * v.z + w * v.w;
        }
        
        public float FindAngle(Vector4 v)
        {
            float dot = DotProduct(v);
            float lengths = VectorLength() * v.VectorLength();
            if (lengths == 0)
            {
                Console.WriteLine("Can't find an angle with a zero-length vector");
                return 0;
            }
            float RadAngle = (float)Math.Acos(dot / lengths);
            return (float)(RadAngle * 180 / Math.PI);
        }
    }
}
