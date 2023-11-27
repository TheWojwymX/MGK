using System;

namespace MGK
{
    public class Quaternion
    {
        private float a;
        private Vector3 v;

        public Quaternion(float a, Vector3 v)
        {
            this.a = a;
            this.v = v;
        }

        public Quaternion addQuaternion(Quaternion q)
        {
            float s = a + q.a;
            Vector3 u = v.AddVectors(q.v);

            return new Quaternion(s, u);
        }

        public Quaternion subQuaternion(Quaternion q)
        {
            float s = a - q.a;
            Vector3 u = v.SubVectors(q.v);

            return new Quaternion(s, u);
        }

        public Quaternion MulQuaternion(Quaternion q)
        {
            float s = a * q.a - v.dotProduct(q.v);
            Vector3 u = v.crossProduct(q.v).AddVectors(v.MulVectorByScalar(q.a))
                                            .AddVectors(q.v.MulVectorByScalar(a));
            
            return new Quaternion(s, u);
        }

        public Quaternion DivQuaternion(Quaternion q)
        {
            Quaternion qConjugate = new Quaternion(q.a, new Vector3(-q.v.x, -q.v.y, -q.v.z));
            float normSq = q.a * q.a + q.v.dotProduct(q.v);
            
            if (normSq == 0)
            {
                throw new Exception("Cannot divide by 0");
            }
            
            Quaternion qInverse = new Quaternion(qConjugate.a / normSq, new Vector3(qConjugate.v.x / normSq, qConjugate.v.y / normSq, qConjugate.v.z / normSq));
            
            return MulQuaternion(qInverse);
        }
        
        public Quaternion RotationQuaternion(float angle, Vector3 axis)
        {
            float rad = angle * (float)Math.PI / 180;
            float s = (float)Math.Cos(rad / 2);
            Vector3 u = axis.VectorNormalize().MulVectorByScalar((float)Math.Sin(rad / 2));
            return new Quaternion(s, u);
        }
        
        public Vector3 RotateVector(Vector3 vector, float angle, Vector3 axis)
        {
            Quaternion rotationQuat = RotationQuaternion(angle, axis);
            Quaternion rotationQuatConjugate = new Quaternion(rotationQuat.a, new Vector3(-rotationQuat.v.x, -rotationQuat.v.y, -rotationQuat.v.z));

            Quaternion vectorQuat = new Quaternion(0, vector);

            Quaternion rotatedVectorQuat = rotationQuat.MulQuaternion(vectorQuat).MulQuaternion(rotationQuatConjugate);

            return rotatedVectorQuat.v;
        }

        public string printQuaternion()
        {
            string vx = v.x == 0 ? "" : (v.x > 0 ? " + " : " - ") + Math.Abs(v.x) + "i";
            string vy = v.y == 0 ? "" : (v.y > 0 ? " + " : " - ") + Math.Abs(v.y) + "j";
            string vz = v.z == 0 ? "" : (v.z > 0 ? " + " : " - ") + Math.Abs(v.z) + "k";

            return $"{a}{vx}{vy}{vz}";
        }
    }
}