using System;
using System.Collections.Generic;

namespace VectorsAndMatrix
{
    public class Matrix
    {
        private readonly double[][] _matrix;
        public readonly int _rows;
        public readonly int _columns;

        public Matrix(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                _matrix[row] = new double[columns];
            }
        }

        public Matrix(int rows, int columns, IList<double> list) : this(rows, columns)
        {
            for (var row = 0; row < rows; row++)
                for (var column = 0; column < columns; column++)
                    _matrix[row][column] = list[row * rows + column];
        }

        public Matrix(Matrix m)
        {
            _rows = m._rows;
            _columns = m._columns;
            _matrix = new double[_rows][];
            for (int row = 0; row < _rows; row++)
            {
                _matrix[row] = new double[_columns];
            }
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    set(row, column, m.get(row, column));
                }
            }
        }

        public double[][] get() { return _matrix; }
        public void set(int row, int column, double x)
        {
            _matrix[row][column] = x;
        }
        public double get(int row, int column)
        {
            return _matrix[row][column];
        }

        public void Print()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                    Console.Write($"{this.get(row, column)}  ");
                Console.WriteLine();
            }
        }

        /*Matrix multiplication by number*/
        public Matrix MultiNumber(int a)
        {
            Matrix v1 = new Matrix(this);
            for (int i = 0; i < v1._rows; i++)
                for (int j = 0; j < v1._columns; j++)
                { v1._matrix[i][j] = v1._matrix[i][j] * a; }
            return v1;
        }

        /*Matrix addition*/
        public static Matrix operator +(Matrix v1, Matrix v2)
        {
            Matrix v3 = new Matrix(v1._rows, v1._columns);
            for (int i = 0; i < v1._rows; i++)
                for (int j = 0; j < v1._columns; j++)
                {
                    v3.set(i, j, v1.get(i, j) + v2.get(i, j));
                }
            return v3;
        }

        /*Finding a determinant*/
        public double det()
        {
            return Determinant(_matrix, _rows);
        }
        public double Determinant(double[][] mas, int m)
        {
            int i, j, k, n;
            double d;
            double[][] p;
            p = new double[m][];
            for (i = 0; i < m; i++)
                p[i] = new double[m];
            j = 0; d = 0;
            k = 1; //(-1) в степени i
            n = m - 1;
            if (m < 1) Console.WriteLine("Determinant cannot be calculated!");
            if (m == 1)
            {
                d = mas[0][0];
                return (d);
            }
            if (m == 2)
            {
                d = mas[0][0] * mas[1][1] - (mas[1][0] * mas[0][1]);
                return (d);
            }
            if (m > 2)
            {
                for (i = 0; i < m; i++)
                {
                    GetMatr(mas, p, i, 0, m);
                    d = d + k * mas[i][0] * Determinant(p, n);
                    k = -k;
                }
            }
            return (d);
        }

        /*Matrix transpose*/
        public Matrix Transposition()
        {
            Matrix m = new Matrix(this);
            double temp;
            for (int row = 0; row < m._rows; ++row)
            {
                for (int column = row; column < m._columns; ++column)
                {
                    temp = m._matrix[row][column];
                    m._matrix[row][column] = m._matrix[column][row];
                    m._matrix[column][row] = temp;
                }
            }
            return m;
        }

        /*Matrix-vector multiplication*/
        public static Vector MultiMatrix(Matrix m1, Vector v1)
        {
            int rows = m1._rows;
            int columns = m1._columns;
            Vector v2 = new Vector(rows);
            for (int i = 0; i < rows; i++)
            {
                double s = 0;
                for (int j = 0; j < columns; j++)
                {
                    s += m1.get(i, j) * v1.get(j);
                }
                v2.set(i, s);
            }
            return v2;
        }

        /*Vector-matrix multiplication*/
        public static Vector MultiVector(Matrix m1, Vector v1)
        {
            int rows = m1._rows;
            int columns = m1._columns;
            Vector v2 = new Vector(rows);
            for (int j = 0; j < columns; j++)
            {
                double s = 0;
                for (int i = 0; i < rows; i++)
                {
                    s += m1.get(i, j) * v1.get(i);
                }
                v2.set(j, s);
            }
            return v2;
        }

        /*Finding the inverse matrix by the Gaussian method*/
        public int Gauss(int n, double[] vectorB, double[] x)
        {
            int i, j, k, r;
            double c, M, max, s;
            double[][] a = new double[n][];
            for (i = 0; i < n; i++)
                a[i] = new double[n];
            double[] b = new double[n];
            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                    a[i][j] = _matrix[i][j];
            for (i = 0; i < n; i++)
                b[i] = vectorB[i];
            for (k = 0; k < n; k++)
            {
                max = Math.Abs(a[k][k]);
                r = k;
                for (i = k + 1; i < n; i++)
                    if (Math.Abs(a[i][k]) > max)
                    {
                        max = Math.Abs(a[i][k]);
                        r = i;
                    }
                for (j = 0; j < n; j++)
                {
                    c = a[k][j];
                    a[k][j] = a[r][j];
                    a[r][j] = c;
                }
                c = b[k]; b[k] = b[r]; b[r] = c;
                for (i = k + 1; i < n; i++)
                {
                    for (M = a[i][k] / a[k][k], j = k; j < n; j++)
                        a[i][j] -= M * a[k][j]; b[i] -= M * b[k];
                }
            }
            if (a[n - 1][n - 1] == 0)
                if (b[n - 1] == 0)
                    return -1;
                else return -2;
            for (i = n - 1; i >= 0; i--)
            {
                for (s = 0, j = i + 1; j < n; j++)
                    s += a[i][j] * x[j]; x[i] = (b[i] - s) / a[i][i];
            }
            return 0;
        }

        public Matrix Inverse()
        {
            var a = new Matrix(this);
            var n = _rows;
            double res = 0;
            var b = new double[n];
            var x = new double[n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                    if (j == i) b[j] = 1;
                    else b[j] = 0;
                res = Gauss(n, b, x);
                if (res != 0)
                    break;
                for (var j = 0; j < n; j++)
                    a._matrix[j][i] = Math.Round(x[j], 1);
            }
            if (res != 0)
                return null;
            return a;
        }

        /*Matrix multiplication*/
        public static Matrix MatrixProduct(Matrix matrixA, Matrix matrixB)
        {
            var aRows = matrixA._rows;
            var aCols = matrixA._columns;
            var bRows = matrixB._rows;
            var bCols = matrixB._columns;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            Matrix result = new Matrix(aRows, bCols);
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result._matrix[i][j] += matrixA._matrix[i][k] * matrixB._matrix[k][j];
            return result;
        }

        /*Getting matrix without i-th row и j-th column*/
        public void GetMatr(double[][] mas, double[][] p, int i, int j, int m)
        {
            int ki, kj, di, dj;
            di = 0;
            for (ki = 0; ki < m - 1; ki++)
            {
                if (ki == i) di = 1;
                dj = 0;
                for (kj = 0; kj < m - 1; kj++)
                {
                    if (kj == j) dj = 1;
                    p[ki][kj] = mas[ki + di][kj + dj];
                }
            }
        }
    };
}
