﻿using System;
using System.Collections.Specialized;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            // Macierze
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
            Console.WriteLine("");

            
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
            Console.WriteLine("");

            
            
            // Kwaterniony
            Console.WriteLine("1. Klasa Quaternion.cs");
            
            Quaternion q1 = new Quaternion(1, new Vector3(1, 1, 1));
            Quaternion q2 = new Quaternion(5, new Vector3(5, 5, 5));
            Console.WriteLine($"Quaternion 1: {q1.printQuaternion()}");
            Console.WriteLine($"Quaternion 2: {q2.printQuaternion()}");
            Console.WriteLine("");
            
            Console.WriteLine("2. Dodawanie i odejmowanie Kwaternionów");
            Quaternion sum = q1.addQuaternion(q2);
            q1 = new Quaternion(1, new Vector3(1, 1, 1));
            Console.WriteLine($"Dodawanie: {sum.printQuaternion()}");
            Quaternion sub = q1.subQuaternion(q2);
            Console.WriteLine($"Odejmowanie: {sub.printQuaternion()}");
            Console.WriteLine("");

            
            Console.WriteLine("Mnozenie i dzielenie");
            Quaternion mul = q1.MulQuaternion(q2);
            q1 = new Quaternion(1, new Vector3(1, 1, 1));
            Console.WriteLine($"Mnozenie: {mul.printQuaternion()}");
            Quaternion div = q1.DivQuaternion(q2);
            Console.WriteLine($"Dzielenie: {div.printQuaternion()}");
            Console.WriteLine("");

            Console.WriteLine("3. Obrot punktu [-1, -1, -1] o 270 wokol osi x");
            Vector3 vector = new Vector3(-1, -1, -1);
            float angle = 270; // degrees
            Vector3 axis = new Vector3(1, 0, 0); // x-axis
            Quaternion quaternion = new Quaternion(0, new Vector3(0, 0, 0));
            Vector3 rotatedVector = quaternion.RotateVector(vector, angle, axis);
            Console.WriteLine($"Rotated Vector: {rotatedVector.x}, {rotatedVector.y}, {rotatedVector.z}");
            Console.WriteLine("");

            
            Console.WriteLine("4. Brak przemiennosci mnozenia");
            q1 = new Quaternion(1, new Vector3(-3 ,-2, 1));
            q2 = new Quaternion(-6, new Vector3(7 ,-3, -5));
            
            Quaternion mul12 = q1.MulQuaternion(q2);
            Quaternion mul21 = q2.MulQuaternion(q1);
            Console.WriteLine($"Quaternion 1: {q1.printQuaternion()}");
            Console.WriteLine($"Quaternion 2: {q2.printQuaternion()}");
            Console.WriteLine($"q1 x q2: {mul12.printQuaternion()}");
            Console.WriteLine($"q2 x q1: {mul21.printQuaternion()}");

        }
    }
}