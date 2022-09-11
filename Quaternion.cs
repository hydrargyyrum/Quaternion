using System;
using System.Runtime.CompilerServices;

namespace VectorsAndMatrix
{
    public class Quaternion
    {
        private double q = 0;
        public Vector Q { get; }

        public double this[int i]
        {
            get => i == 0 ? q : Q[i - 1];
            set
            {
                if (i == 0)
                    q = value;
                else
                    Q[i - 1] = value;
            }
        }

        public double i => this[1];
        public double j => this[2];
        public double k => this[3];

        /// <summary>
        /// Internal ctor
        /// </summary>
        /// <param name="q"></param>
        /// <param name="Q"></param>
        private Quaternion(double q, Vector Q)
        {
            this.q = q;
            this.Q = Q;
        }

        public Quaternion() => Q = new(3);

        public Quaternion(Quaternion quaternion) :
            this(quaternion.q, quaternion.Q.Copy())
        { }

        public Quaternion(double p1, double p2, double p3, double p4) : this()
        {
            this[0] = p1;
            this[1] = p2;
            this[2] = p3;
            this[3] = p4;
        }

        /// <summary>
        /// Rotate ctor
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="phi"></param>
        public Quaternion(Vector vector, double phi)
        {
            phi = phi * Math.PI / 180.0;
            phi /= 2.0;
            q = Math.Cos(phi);
            Q = Math.Sin(phi) * vector.Normalize();
        }

        public static Quaternion operator +(Quaternion q1, Quaternion q2) => new(q1.q + q2.q, q1.Q + q2.Q);

        public static Quaternion operator *(Quaternion q, Vector v) => q * new Quaternion(0, v[0], v[1], v[2]);

        public static Quaternion operator *(Quaternion q1, Quaternion q2) =>
            new(
                q1.q * q2.q - q1.Q * q2.Q,
                q2.q * q1.Q + q1.q * q2.Q + q1.Q % q2.Q
            );

        public double Norma() => q * q + Q[0] * Q[0] + Q[1] * Q[1] + Q[2] * Q[2];

        public Quaternion Normalization()
        {
            var norma = Norma();
            if (norma == 0)
                return Copy();
            var sqrtNorma = Math.Sqrt(norma);
            return new Quaternion(
                q / sqrtNorma,
                Q / sqrtNorma);
        }

        private Quaternion Copy() => new(q, Q.Copy());

        public Quaternion Conjugate() => new(q, -1 * Q);

        public override string ToString() => $"({q}| i : {i} | j : {j} | {k})";
    }
}