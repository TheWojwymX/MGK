using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1");
            Console.WriteLine("Klasa Vector i jej metody dostępne w pliku Vector.cs");
            
            Console.WriteLine("");
            Console.WriteLine("Zadanie 2");
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(3, 2, 1);
            v1.AddVector(v2);
            Console.WriteLine("v1 + v2:");
            Console.WriteLine($"{v1.x}, {v1.y}, {v1.z}");
            v1.x = 1;
            v1.y = 2;
            v1.z = 3;
            v2.AddVector(v1);
            Console.WriteLine("");
            Console.WriteLine("v2 + v1:");
            Console.WriteLine($"{v2.x}, {v2.y}, {v2.z}");
            
            Console.WriteLine("");
            Console.WriteLine("Zadanie 3");
            Vector v3 = new Vector(0, 3, 0);
            Console.WriteLine(v3.FindAngle(new Vector(5, 5, 0)));
            
            Console.WriteLine("");
            Console.WriteLine("Zadanie 4");
            Console.WriteLine("Wektor ten obliczamy jako crossProduct podanych wektorów");
            Vector v4 = new Vector(4, 5, 1);
            Vector result = v4.crossProduct(new Vector(4, 1, 3));
            Console.WriteLine($"{result.x}, {result.y}, {result.z}");
            
            Console.WriteLine("");
            Console.WriteLine("Zadanie 5");
            result.VectorNormalize();
            Console.WriteLine($"{result.x}, {result.y}, {result.z}");
            
            Console.WriteLine("");
            float[] entries = { 9, 6, 3, 7, 2, 1}; 
            float[] entries2 = { 1, 4, 6, 8, 2, 4}; 

            
            Matrix m1 = new Matrix(2, 3, entries);
            Matrix m2 = new Matrix(3, 2, entries2);

            Matrix result0 = m1.MultiplyMatrices(m2);
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(result0.entries[i]);
            }
            



















        }
    }
}