using System;

namespace MGK
{
    public class Matrix4x4
    {
        public float[] entries = new float[16];

        public Matrix4x4()
        {
            
        }

        public Matrix4x4(float[] values)
        {
            if (values.Length == 16)
            {
                for (int i = 0; i < 16; i++)
                {
                    entries[i] = values[i];
                }
            }
            else
            {
                throw new ArgumentException("Matrix needs exactly 16 values.");
            }
        }

        public Matrix4x4 AddMatrix(Matrix4x4 m)
        {
            float[] sum = new float[16];
            for (int i = 0; i < 16; i++)
            {
                sum[i] = m.entries[i] + entries[i];
            }

            return new Matrix4x4(sum);
        }

        public Matrix4x4 SubMatrix(Matrix4x4 m)
        {
            float[] sum = new float[16];
            for (int i = 0; i < 16; i++)
            {
                sum[i] = m.entries[i] - entries[i];
            }

            return new Matrix4x4(sum);
        }

        public Matrix4x4 MultiplyByScalar(float f)
        {
            float[] mul = new float[16];
            for (int i = 0; i < 16; i++)
            {
                mul[i] = entries[i] * f;
            }

            return new Matrix4x4(mul);
        }

        public Matrix4x4 Multiply(Matrix4x4 m)
        {
            Matrix4x4 result = new Matrix4x4(new float[16]);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    result.entries[row * 4 + col] =
                        entries[row * 4] * m.entries[col] +
                        entries[row * 4 + 1] * m.entries[col + 4] +
                        entries[row * 4 + 2] * m.entries[col + 8] +
                        entries[row * 4 + 3] * m.entries[col + 12];
                }
            }

            return result;
        }

        public void setToIdentity()
        {
            for (int i = 0; i < 16; i++)
            {
                entries[i] = 0;
            }

            entries[0] = 1.0f;
            entries[5] = 1.0f;
            entries[10] = 1.0f;
            entries[15] = 1.0f;
        }

        public Matrix4x4 Transpose()
        {
            Matrix4x4 result = new Matrix4x4(new float[16]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.entries[j * 4 + i] = entries[i * 4 + j];
                }
            }

            return result;
        }

        public Matrix4x4 Inverse()
        {
            float det = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    det += entries[i] * GetSubDeterminant(i);
                }
                else
                {
                    det -= entries[i] * GetSubDeterminant(i);
                }
            }

            if (det == 0)
            {
                throw new InvalidOperationException("Matrix is not invertible.");
            }

            var inverse = new float[16];
            for (int i = 0; i < 16; i++)
            {
                int row = i / 4;
                int col = i % 4;
                float cofactor = GetSubDeterminant(4 * col + row) / det;
                if ((row + col) % 2 != 0)
                {
                    cofactor = -cofactor;
                }

                inverse[i] = cofactor;
            }

            return new Matrix4x4(inverse);
        }

        private float GetSubDeterminant(int excludeIndex)
        {
            int[] indices = new int[9];
            int index = 0;
            for (int i = 4; i < 16; i++)
            {
                if (i / 4 != excludeIndex / 4 && i % 4 != excludeIndex % 4)
                {
                    indices[index++] = i;
                }
            }

            float subDet = 0;
            for (int i = 0; i < 3; i++)
            {
                float part = entries[indices[i]] *
                             (entries[indices[3 + ((i + 1) % 3)]] * entries[indices[6 + ((i + 2) % 3)]] -
                              entries[indices[3 + ((i + 2) % 3)]] * entries[indices[6 + ((i + 1) % 3)]]);
                if (i % 2 == 0)
                {
                    subDet += part;
                }
                else
                {
                    subDet -= part;
                }
            }

            return subDet;
        }

        public void setTranslation(Vector3 v)
        {
            entries[12] = v.x;
            entries[13] = v.y;
            entries[14] = v.z;
        }

        public void setScale(Vector3 v)
        {
            setToIdentity();
            entries[0] = v.x;
            entries[5] = v.y;
            entries[10] = v.z;
        }

        public void setUniformScale(float scaleFactor)
        {
            setToIdentity();
            entries[0] = entries[5] = entries[10] = scaleFactor;
        }

        public void setRotationAxis(float angle, Vector3 v)
        {
            v.VectorNormalize();
            float sinAngle = (float)Math.Sin(Math.PI * angle / 180);
            float cosAngle = (float)Math.Cos(Math.PI * angle / 180);
            float oneMinusCosAngle = 1.0f - cosAngle;
            
            setToIdentity();

            entries[0] = v.x * v.x + cosAngle * (1 - v.x * v.x);
            entries[4] = v.x * v.y * oneMinusCosAngle - sinAngle * v.z;
            entries[8] = v.x * v.z * oneMinusCosAngle + sinAngle * v.y;

            entries[1] = v.x * v.y * oneMinusCosAngle + sinAngle * v.z;
            entries[5] = v.y * v.y + cosAngle * (1 - v.y * v.y);
            entries[9] = v.y * v.z * oneMinusCosAngle - sinAngle * v.x;

            entries[2] = v.x * v.z * oneMinusCosAngle - sinAngle * v.y;
            entries[6] = v.y * v.z * oneMinusCosAngle + sinAngle * v.x;
            entries[10] = v.z * v.z + cosAngle * (1 - v.z * v.z);
        }

        public void setRotationX(float angle)
        {
            setToIdentity();
            entries[5] = (float)Math.Cos(Math.PI * angle / 180);
            entries[6] = (float)Math.Sin(Math.PI * angle / 180);
            entries[9] = -entries[6];
            entries[10] = entries[5];
        }
        
        public void setRotationY(float angle)
        {
            setToIdentity();
            entries[0] = (float)Math.Cos(Math.PI * angle / 180);
            entries[2] = -(float)Math.Sin(Math.PI * angle / 180);
            entries[8] = -entries[2];
            entries[10] = entries[0];
        }

        public void setRotationZ(float angle)
        {
            setToIdentity();
            entries[0] = (float)Math.Cos(Math.PI * angle / 180);
            entries[1] = (float)Math.Sin(Math.PI * angle / 180);
            entries[4] = -entries[1];
            entries[5] = entries[0];
        }

        public Vector4 multiplyVector4(Vector4 v)
        {
            return new Vector4(
                entries[0] * v.x + entries[1] * v.y + entries[2] * v.z + entries[3] * v.w,
                entries[4] * v.x + entries[5] * v.y + entries[6] * v.z + entries[7] * v.w,
                entries[8] * v.x + entries[9] * v.y + entries[10] * v.z + entries[11] * v.w,
                entries[12] * v.x + entries[13] * v.y + entries[14] * v.z + entries[15] * v.w);
        }
    }
}