using System;

namespace MGK
{
    public class Matrix
    {
        public int r;
        public int c;
        public float[] entries;

        public Matrix(int c, int r, float[] entries)
        {
            this.c = c;
            this.r = r;
            this.entries = entries;
        }

        public Matrix addMatrix(Matrix m1)
        {
            if (m1.r * m1.c != r * c)
            {
                Console.WriteLine("Matrices have different dimensions! Returning original Matrix");
            }
            else
            {
                float[] tempEntries = new float[r*c];
                for (int i = 0; i < r*c; i++)
                {
                    tempEntries[i] = entries[i] + m1.entries[i];
                }
                return new Matrix(r, c, tempEntries);
            }
            return this;
        }

        public Matrix MultiplyByScalar(float f)
        {
            float[] tempEntries = new float[r*c];
            for (int i = 0; i < r*c; i++)
            {
                tempEntries[i] = entries[i] * f;
            }
            return new Matrix(r, c, tempEntries);
        }

        public Matrix MultiplyMatrices(Matrix m1)
        {
            if (r != m1.c)
            {
                Console.WriteLine("Matrices have incorrect dimensions! Returning original Matrix");
                return this;
            }
            float[] resultEntries = new float[this.r * m1.c];
            Matrix result = new Matrix(m1.c, this.r, resultEntries);

            for (int i = 0; i < this.r; i++)
            {
                for (int j = 0; j < m1.c; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < this.c; k++)
                    {
                        sum += this.entries[i * this.c + k] * m1.entries[k * m1.c + j];
                    }
                    result.entries[i * m1.c + j] = sum;
                }
            }

            return result;
        }
    }
}