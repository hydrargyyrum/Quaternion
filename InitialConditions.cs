namespace VectorsAndMatrix
{
    class InitialConditions
    {
        public Vector v1;
        public Vector v2;
        public Vector v3;
        public Matrix m1;
        public Matrix m2;
        public Matrix m3;
        public Quaternion q1;
        public Quaternion q2;

        public InitialConditions()
        {
            q1 = new Quaternion(1, 2, 3, 4);
            q2 = new Quaternion(1, 0, 0, 3);
            /*Set the coordinates of the vector 1*/
            int[] x1 = { 1, 2 }; //coordinates
            int n1 = 2; //number of components
            v1 = Vector.create(x1, n1);

            /*Set the coordinates of the vector 1*/
            int[] x2 = { 4, 5, 6 };
            int n2 = 3;
            v2 = Vector.create(x2, n2);

            /*Set the coordinates of the vector 1*/
            int[] x3 = { 7, 8, 9 };
            int n3 = 3;
            v3 = Vector.create(x3, n3);

            /*Set matrix 1 size of matrix in the constructor
            and the elements in set(№row,№column,value)*/
            m3 = new Matrix(2, 2); //rows,columns
            m3.set(0, 0, 10);
            m3.set(0, 1, -2);
            m3.set(1, 0, -2);
            m3.set(1, 1, 2);

            m1 = new Matrix(3, 3); //rows,columns
            m1.set(0, 0, 1);
            m1.set(0, 1, 2);
            m1.set(0, 2, 3);
            m1.set(1, 0, 4);
            m1.set(1, 1, 8);
            m1.set(1, 2, 10);
            m1.set(2, 0, 7);
            m1.set(2, 1, 8);
            m1.set(2, 2, 9);

            /*Set matrix 2 size of matrix in the constructor
          and the elements in set(№row,№column,value)*/
            m2 = new Matrix(2, 2);
            // m2 = new Matrix(2, 3);
            m2.set(0, 0, 1);
            m2.set(0, 1, 2);
            //  m2.set(0, 2, 2);
            m2.set(1, 0, 3);
            m2.set(1, 1, 4);
            //  m2.set(1, 2, 4);
        }
    }
}
