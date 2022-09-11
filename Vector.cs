using System;
using MoreLinq;

namespace VectorsAndMatrix
{
    public partial class Vector
    {
        private readonly double[] m;

        public int n => m.Length;

        public Vector(params double[] xs) => m = xs;

        public Vector(int n) => m = new double[n];

        public Vector(Vector v)
        {
            m = new double[n];
            for (int i = 0; i < n; i++)
                set(i, v.get(i));
        }

        public void set(int i, double value)
        {
            m[i] = value;
        }

        public double get(int i)
        {
            return m[i];
        }

        public double this[int i]
        {
            get => m[i];
            set => m[i] = value;
        }


        public void print()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{get(i)} ");
            }

            Console.WriteLine();
        }

        /*Vector multiplication by number*/
        public Vector MultiNumber(int a)
        {
            var v1 = new Vector(this);
            for (int i = 0; i < v1.n; i++)
                v1.m[i] = v1.m[i] * a;
            return v1;
        }

        /*Vector length*/
        public double Length()
        {
            double norma = 0;
            for (int i = 0; i < n; i++)
                norma += m[i] * m[i];
            return Math.Sqrt(norma);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            var v3 = new Vector(v1.n);
            for (var i = 0; i < v1.n; i++)
                v3.set(i, v1.get(i) + v2.get(i));
            return v3;
        }

        /*Subtraction vectors*/
        public static Vector operator -(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            for (int i = 0; i < v1.n; i++)
            {
                v3.set(i, v1.get(i) - v2.get(i));
            }

            return v3;
        }


        public static Vector operator *(double x, Vector v1) => v1 * x;

        public static Vector operator *(Vector v1, double s) => v1.Map(x => x * s);

        public static Vector operator /(Vector v1, double s) => v1.Map(x => x / s);

        private Vector Map(Func<double, double> map)
        {
            var v = new Vector(n);
            for (var i = 0; i < n; i++)
                v[i] = map(this[i]);
            return v;
        }

        public static double operator *(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            double sum = 0;
            for (int i = 0; i < v1.n; i++)
                sum += v1.get(i) * v2.get(i);
            return sum;
        }

        public static Vector create(int[] values, int n)
        {
            Vector v = new Vector(n);
            for (int i = 0; i < n; i++)
            {
                v.set(i, values[i]);
            }

            return v;
        }

        /*Vector product of vectors*/
        public static Vector operator %(Vector v1, Vector v2)
        {
            Vector v3 = new Vector(v1.n);
            // v3.set(1, v1.get(1) * v2.get(2) - v1.get(2) * v2.get(1));
            // v3.set(0, v1.get(2) * v2.get(0) - v1.get(0) * v2.get(2));
            v3.set(0, v1.get(1) * v2.get(2) - v1.get(2) * v2.get(1));
            v3.set(1, v1.get(2) * v2.get(0) - v1.get(0) * v2.get(2));
            v3.set(2, v1.get(0) * v2.get(1) - v1.get(1) * v2.get(0));
            return v3;
        }

        /*Mixed product of vectors*/
        static double combined(Vector v1, Vector v2, Vector v3)
        {
            return (v1 % v2) * v3;
        }

        public Matrix tensor(Vector v1, Vector v2)
        {
            int rows = v1.n;
            int columns = v2.n;
            Matrix m = new Matrix(rows, columns);
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    m.set(row, column, v1.get(row) * v2.get(column));
                }
            }

            return m;
        }

        public Vector Copy()
        {
            var v = new Vector(n);
            Array.Copy(m, v.m, n);
            return v;
        }

        public Vector Normalize()
        {
            var l = Length();
            return Map(x => x / l);
        }

        public override string ToString() => $"({m.ToDelimitedString("|")})";
    }

    public partial class Vector
    {
        public Vector RotateByRodrigFormula(Vector e, double phi)
        {
            e = e.Normalize();
            phi = phi * Math.PI / 180.0;
            return
                e * this *
                (1 - Math.Cos(phi)) *
                e
                +
                Math.Sin(phi) *
                (e % this)
                +
                Math.Cos(phi) * this;
        }

        public Vector RotateByQuaternion(Quaternion Q)
        {
            Q.Normalization();
            var x = Q * this;
            return (x * Q.Conjugate().Normalization())
                .Q.Copy();
        }
    }
}