using System;

namespace VectorsAndMatrix
{
    public class CholetskyDecomposition
    {
        private readonly double[][] L;
        private int n;
        private bool positiveDefinite;

        public CholetskyDecomposition(double[][] value, int n)
        {
            this.n = n;
            L = new double[n][];
            for (int i = 0; i < n; i++) L[i] = new double[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) L[i][j] = value[i][j];
            LLt();
        }

        public void print(double[][] B)
        {
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                    Console.Write($"{Math.Round(B[row][column],1)} ");
                Console.WriteLine();
            }
        }
        public double[][] Inverse()
        {
            if (!positiveDefinite)
                throw new Exception("Decomposed matrix is not positive definite.");

            var B = new double[n][];
            for (int i = 0; i < n; i++) B[i] = new double[n];
            for (int i = 0; i < n; i++)
                B[i][i] = 1;

            int m = n;

            // Solve L*Y = B;
            for (int k = 0; k < n; k++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < k; i++)
                        B[k][j] -= B[i][j] * L[k][i];
                    B[k][j] /= L[k][k];
                }
            }

            // Solve L'*X = Y;
            for (int k = n - 1; k >= 0; k--)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int i = k + 1; i < n; i++)
                        B[k][j] -= B[i][j] * L[i][k];

                    B[k][j] /= L[k][k];
                }
            }
            print(B);
            return B;
        }

        private void LLt()
        {
            positiveDefinite = true;

            for (int j = 0; j < n; j++)
            {
                double s = 0;
                for (int k = 0; k < j; k++)
                {
                    var t = L[k][j];
                    for (int i = 0; i < k; i++)
                        t -= L[j][i] * L[k][i];
                    t = t / L[k][k];

                    L[j][k] = t;
                    s += t * t;
                }

                s = L[j][j] - s;

                // Use a tolerance for positive-definiteness
                positiveDefinite &= (s > 1e-14 * Math.Abs(L[j][j]));
                L[j][j] = Math.Sqrt(s);
                //if (positiveDefinite == true) { Console.WriteLine("URAAAAAAAAAAAAAAAAAA"); }
                //else Console.WriteLine("BEEEEEEEEEEEEEEEEE");
            }
        }
    }
}