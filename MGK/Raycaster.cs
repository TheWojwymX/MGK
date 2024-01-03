using System;
using System.Collections.Generic;

namespace MGK
{
    public class Raycaster
    {
        public List<Plane> faces;
        private int width = 60;
        private int height = 60;
        private Grid grid;
        public float zoom;
        public Vector3 cameraPos;
        public float pitch;
        public float yaw;
        public float roll; 


        public Raycaster()
        {
            zoom = 0.7f;
            pitch = 0.0f;
            yaw = 0.0f;
            roll = 0.0f;
            
            faces = new List<Plane>();
            faces.Add(new Plane(new Vector3(0, 0, 0.5f), new Vector3(0, 0, 0.5f)));
            faces.Add(new Plane(new Vector3(0, 0, -0.5f), new Vector3(0, 0, -0.5f)));
            faces.Add(new Plane(new Vector3(0.5f, 0, 0), new Vector3(0.5f, 0, 0)));
            faces.Add(new Plane(new Vector3(0.5f, 0, 0), new Vector3(-0.5f, 0, 0)));
            faces.Add(new Plane(new Vector3(0, 0.5f, 0), new Vector3(0, 0.5f, 0)));
            faces.Add(new Plane(new Vector3(0, -0.5f, 0), new Vector3(0, -0.5f, 0)));
        }
        
        public void castRays()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            
            cameraPos = new Vector3(3, 0, 0);
            Matrix4x4 m = new Matrix4x4();
            
            m.setRotationFromVector(new Vector3(pitch, yaw, roll));
            Vector4 temp = m.multiplyVector4(new Vector4(cameraPos.x, cameraPos.y, cameraPos.z, 1));
            cameraPos = new Vector3(temp.x, temp.y, temp.z);
            
            grid = new Grid(width, height);
            for (int i = 0; i < width * height; i++)
            {
                Vector4 gridPoint = new Vector4(grid.grid[i].x * zoom, grid.grid[i].y * zoom, grid.grid[i].z * zoom, 1);
                Vector4 rotatedPoint = m.multiplyVector4(gridPoint);
                grid.grid[i] = new Vector3(rotatedPoint.x, rotatedPoint.y, rotatedPoint.z);
            }

            char[] gridBuffer = new char[width * height];
            for (int i = 0; i < width * height; i++)
            {
                gridBuffer[i] = '.';
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < width * height; j++)
                {
                    Vector3 pixel = grid.grid[j];
                    Vector3 point = cameraPos;
                    Vector3 dir = (pixel.SubVectors(cameraPos)).VectorNormalize();
                    Vector3 intersection = faces[i].planeWithLineIntersection(new Line(dir, point));

                    bool doesIntersect = !(Math.Abs(intersection.x) > 0.50 + 0.00001 || Math.Abs(intersection.y) > 0.50 + 0.00001||
                                           Math.Abs(intersection.z) > 0.50 + 0.00001);
                    
                    if (doesIntersect)
                    {
                        gridBuffer[j] = '0';
                    }
                }
            }
            
            for (int i = 0; i < width * height; i++)
            {
                Console.Write(gridBuffer[i] + " ");
                if (i % width == width - 1)
                    Console.WriteLine();
            }

        }
    }
}