using System.Collections.Generic;

namespace MGK
{
    public class Grid
    {
        public List<Vector3> grid;

        public Grid(int w, int h)
        {
            grid = new List<Vector3>();
            float step = 0.05f;

            float startY = (-(w - 1) / 2.0f) * step;
            float startZ = (-(h - 1) / 2.0f) * step;
            for (int i = 0; i < w * h; i++)
            {
                grid.Add(new Vector3(0,0,0));
                int ix = i % w;
                int iy = i / w;
                grid[i].y = startY + ix * step;
                grid[i].z = startZ + iy * step;
                grid[i].x = 2.0f;
            }
        }
    }
}