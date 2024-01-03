using System;

namespace MGK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Raycaster r1 = new Raycaster();
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            do
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.A:
                            r1.pitch += 5; 
                            break;
                        case ConsoleKey.D:
                            r1.pitch -= 5; 
                            break;
                        case ConsoleKey.W:
                            r1.yaw += 5; 
                            break;
                        case ConsoleKey.S:
                            r1.yaw -= 5; 
                            break;
                        case ConsoleKey.Q:
                            r1.roll += 5; 
                            break;
                        case ConsoleKey.E:
                            r1.roll -= 5; 
                            break;
                        case ConsoleKey.Z:
                            r1.zoom += 0.05f; 
                            break;
                        case ConsoleKey.X:
                            r1.zoom -= 0.05f; 
                            break;
                    }

                    r1.castRays();
                }

            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}