using System;
using NUnit.Framework;

namespace VectorsAndMatrix.Test
{
    public class Tests
    {
        private readonly Vector vMain = new Vector(3, 0, 0);
        private readonly Vector vRotate = new Vector(0, 2, 0);
        private double degree = 90.0;
        private Vector vExpected = new Vector(0, 0, -3);
        private double eps = 0.000000001;

        [Test]
        public void rotate_rodriges()
        {
            var vActual = vMain.RotateByRodrigFormula(vRotate, degree);
            AssertActual(vActual);
        }

        [Test]
        public void rotate_quat()
        {
            var q = new Quaternion(vRotate, degree);
            var vActual = vMain.RotateByQuaternion(q);
            AssertActual(vActual);
        }

        private void AssertActual(Vector vActual)
        {
            var err = Math.Abs((vActual - vExpected).Length());
            TestContext.WriteLine("Vector actual :");
            TestContext.WriteLine(vActual);
            Assert.IsTrue(err < eps);
        }
    }
}