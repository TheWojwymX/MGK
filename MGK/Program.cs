using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Vector4 v = new Vector4(1, 0, 0, 1);
            Matrix4x4 m1 = new Matrix4x4();
            m1.setRotationY(90);
            v = m1.multiplyVector4(v);
            Console.WriteLine($"{v.x}, {v.y}, {v.z}, {v.w}");
        }
    }
}