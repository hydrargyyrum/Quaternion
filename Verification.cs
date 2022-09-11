namespace VectorsAndMatrix
{
    static class Verification
    {
        public static bool CompareVectors(Vector v1, Vector v2)
        {
            if (v1.n == v2.n) return true;
            else return false;
        }
        public static bool CompareVectorsThree(Vector v1, Vector v2, Vector v3)
        {
            if ((v1.n == v2.n) && (v1.n == v3.n)) return true;
            else return false;
        }
        public static bool CheckNumberVector(Vector v1, Vector v2)
        {
            if ((v1.n == v2.n) && (v1.n == 3)) return true;
            else return false;
        }
        public static bool SymmetricMatrix(Matrix m1)
        {
            bool flag = true;
            for (int i = 0; i < m1._rows; i++)
            {
                for (int j = 0; j < m1._columns; j++)
                {
                    if (m1.get(i, j) != m1.get(j, i))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }
        public static bool CompareMatrix(Matrix m1, Matrix m2)
        {
            if (m1._columns == m2._rows) return true;
            else return false;
        }
        public static bool CompareElementsMatrix(Matrix m1)
        {
            if (m1._rows == m1._columns) return true;
            else return false;
        }
        public static bool CompareMatrixVector(Matrix m1, Vector v1)
        {
            if (m1._rows == v1.n) return true;
            else return false;
        }
    }
}
