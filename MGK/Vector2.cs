using System;

namespace MGK
{
    public class Vector2
    {
        public float x, y;

        public Vector2()
        {
            
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void AddVector(Vector2 v)
        {
            x += v.x;
            y += v.y;
        }
        
        public Vector2 AddVectors(Vector2 v)
        {
            return new Vector2(x + v.x, y + v.y);
        }
        
        public void SubVector(Vector2 v)
        {
            x -= v.x;
            y -= v.y;
        }
        
        public Vector2 SubVectors(Vector2 v)
        {
            return new Vector2(x - v.x, y - v.y);
        }

        public Vector2 MulVectorByScalar(float a)
        {
            return new Vector2(x * a, y * a);
        }

        public void DivVectorByScalar(float a)
        {
            if (a != 0)
            {
                x /= a;
                y /= a;
            }
            else
            {
                Console.WriteLine("Can't divide by 0");
            }
        }

        public float VectorLength()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public Vector2 VectorNormalize()
        {
            float v = VectorLength();
            if (v == 0)
            {
                throw new Exception("Can't normalize a zero vector");
            }
            else
            {
                return new Vector2(x / v, y / v);
            }
        }

        public float DotProduct(Vector2 v)
        {
            return x * v.x + y * v.y;
        }

        public float FindAngle(Vector2 v)
        {
            float RadAngle = (float)Math.Acos(DotProduct(v) / (VectorLength() * v.VectorLength()));
            return (float)(RadAngle * 180 / Math.PI);
        }
        
    }
}