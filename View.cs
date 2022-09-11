using System;
namespace VectorsAndMatrix
{
    static class View
    {
        static void Main()
        {
            InitialConditions Init = new InitialConditions();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hi,my dear friend! What about math?");
            Console.WriteLine("Let's see what i did");
            Console.WriteLine("Note. Initial parameters can be changed in the file InitialConditions.cs");
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 70;

            //VECTORS
            Console.Write("Vector 1: ");
            Init.v1.print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Vector 2: ");
            Init.v2.print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Vector 3: ");
            Init.v3.print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Vector 1 multiplication by number 4 =  \n");
            Init.v1.MultiNumber(4).print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Vector 1 length = ");
            Console.WriteLine(Init.v1.Length());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("vector 2 + vector 3 = ");
            if (Verification.CompareVectors(Init.v2, Init.v3))
            {
                (Init.v2 + Init.v3).print();
            }
            else
            {
                Console.WriteLine("Opps... different vectors");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("vector 2 - vector 3 = ");
            if (Verification.CompareVectors(Init.v2, Init.v3))
            {
                (Init.v2 - Init.v3).print();
            }
            else
            {
                Console.WriteLine("Opps... different vectors");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            if (Verification.CompareVectors(Init.v2, Init.v3))
            {
                Console.WriteLine($"Scalar product of vector 2 and vector 3 = \n {Init.v2 * Init.v3}");
            }
            else
            {
                Console.WriteLine("Scalar product of vector 2 and vector 3 =");
                Console.WriteLine("Opps... different vectors");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Vector product of vector 2 and vector 3 =");
            if (Verification.CheckNumberVector(Init.v2, Init.v3))
            {
                (Init.v2 % Init.v3).print();
            }
            else
            {
                Console.WriteLine("Opps... different vectors");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            if (Verification.CompareVectorsThree(Init.v1, Init.v2, Init.v3))
            {
                Console.WriteLine($"Combined product of vector 1, vector 2 and vector 3 = \n {(Init.v1 % Init.v2) * Init.v3} ");
            }
            else
            {
                Console.WriteLine("Combined product of vector 1, vector 2 and vector 3 = ");
                Console.WriteLine("Opps... different vectors");
            }

            //MATRIX
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Matrix 1:");
            Init.m1.Print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Matrix 2:");
            Init.m2.Print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Matrix 3:");
            Init.m3.Print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Matrix 1 multiplication by number 4 = \n");
            (Init.m1.MultiNumber(4)).Print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("Sum of matrix 1 and matrix 2 =");
            if (Verification.CompareMatrix(Init.m3, Init.m2))
            {
                (Init.m3 + Init.m2).Print();
            }
            else Console.WriteLine("Impossible to sum(The reason is in size)");
            //(Init.m1 + Init.m2).Print();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Finding a determinant matrix 1 =");
            if (Verification.CompareElementsMatrix(Init.m1))
            {
                Console.WriteLine($"{Init.m1.det()}");
            }
            else Console.WriteLine("Opps... Matrix is not square");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Product of Matrix 3 and vector 1 =");
            if (Verification.CompareMatrixVector(Init.m3, Init.v1))
            {
                Matrix.MultiMatrix(Init.m3, Init.v1).print();
            }
            else Console.WriteLine("Impossible to multiply(The reason is in size)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Product of Vector 1 and matrix 3 =");
            if (Verification.CompareMatrixVector(Init.m3, Init.v1))
            {
                Matrix.MultiVector(Init.m3, Init.v1).print();
            }
            else Console.WriteLine("Impossible to multiply(The reason is in size)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Product of matrix 2 and matrix 3 =");
            if (Verification.CompareMatrix(Init.m2, Init.m3))
            {
                Matrix.MatrixProduct(Init.m2, Init.m3).Print();
            }
            else Console.WriteLine("Impossible to multiply(The reason is in size)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Matrix 1 transpose =");
            if (Verification.CompareElementsMatrix(Init.m1))
            {
                Init.m1.Transposition().Print();
            }
            else Console.WriteLine("Opps... Matrix is not square");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Inversion of a symmetric matrix using the Cholesky decomposition m3 = ");
            if ((Verification.CompareElementsMatrix(Init.m3) && (Init.m3.det() != 0)) && (Verification.SymmetricMatrix(Init.m3)))
            {
                CholetskyDecomposition cd = new CholetskyDecomposition(Init.m3.get(), Init.m3._columns);
                cd.Inverse();
            }
            else Console.WriteLine("Opps... The matrix does not have the required parameters");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Gaussian matrix inversion for matrix 1 =");
            if (Verification.CompareElementsMatrix(Init.m1) && (Init.m1.det() != 0))
            {
                Init.m1
                    .Inverse().Print();
            }
            else Console.WriteLine("Opps... Matrix is not square or determinant = 0");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**********************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Rotate by Q");
            
        }
    }
}
