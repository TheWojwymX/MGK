using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Klasa Matrix4x4");
            Console.WriteLine("");
            Console.WriteLine("2.Tworzenie macierzy i macierz jednostkowa");
            float[] l = new float[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            Matrix4x4 m = new Matrix4x4(l);
            m.printMatrix();
            m.setToIdentity();
            Console.WriteLine("");
            m.printMatrix();
            Console.WriteLine("");
            
            Console.WriteLine("Dodawanie, odejmowanie, mnożenie przez skalar");
            m = new Matrix4x4(l);
            m = m.AddMatrix(m);
            m.printMatrix();
            Console.WriteLine("");
            m = new Matrix4x4(l);
            m = m.SubMatrix(m);
            m.printMatrix();
            Console.WriteLine("");
            m = new Matrix4x4(l);
            m = m.MultiplyByScalar(2);
            m.printMatrix();
            Console.WriteLine("");
            
            Console.WriteLine("Mnozenie macierzy");
            m = new Matrix4x4(l);
            m.Multiply(m);
            m.printMatrix();
            Console.WriteLine("");
            
            Console.WriteLine("Transponowanie i odwrotność");
            m = new Matrix4x4(l);
            m = m.Transpose();
            m.printMatrix();
            Console.WriteLine("");
            m = new Matrix4x4(l);
            m = m.Inverse();
            m.printMatrix();
            
            Console.WriteLine("Translacja, skalowanie, rotacja");
            m = new Matrix4x4(l);
            m.setTranslation(new Vector3(5,5,5));
            m.printMatrix();
            Console.WriteLine("");
            m = new Matrix4x4(l);
            m.setScale(new Vector3(2,2,2));
            m.printMatrix();
            Console.WriteLine("");
            m = new Matrix4x4(l);
            m.setRotationY(90);
            m.printMatrix();
            Console.WriteLine("");
            
            Console.WriteLine("3. Obrót");
            Matrix4x4 m1 = new Matrix4x4();
            m1.setRotationY(90);
            Vector4 v = new Vector4(1, 0, 0, 1);
            Vector4 rotatedV = m1.multiplyVector4(v);
            Console.WriteLine($"{rotatedV.x}, {rotatedV.y}, {rotatedV.z}, {rotatedV.w}");
            Console.WriteLine("");
            
            Console.WriteLine("4.Brak przemienności");
            float[] l2 = new float[16] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            float[] l3 = new float[16] {4,3,2,1,5,6,7,8,12,11,10,9,13,14,15,16};
            Matrix4x4 m2 = new Matrix4x4(l2);
            Matrix4x4 m3 = new Matrix4x4(l3);
            m2 = m2.Multiply(m3);
            m2.printMatrix();
            Console.WriteLine("");
            m2 = new Matrix4x4(l2);
            m3 = m3.Multiply(m2);
            m3.printMatrix();














        }
    }
}