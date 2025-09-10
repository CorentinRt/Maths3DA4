using NUnit.Framework;
using UnitTestMaths3D;
// ReSharper disable All

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests01_NewMatrices
    {
        [Test]
        public void TestNewEmptyMatrices()
        {
            MatrixInt m1 = new MatrixInt(3, 2);
            Assert.That(m1.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0 },
                { 0, 0 },
                { 0, 0 }
            }));
            Assert.That(m1.NbLines, Is.EqualTo(3));
            Assert.AreEqual(2, m1.NbColumns);

            MatrixInt m2 = new MatrixInt(2, 3);
            Assert.That(m2.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
            }));
            Assert.That(m2.NbLines, Is.EqualTo(2));
            Assert.That(m2.NbColumns, Is.EqualTo(3));
        }

        [Test]
        public void TestNewMatricesFrom2DArray()
        {
            //See GetLength documentation to retrieve length of a multi-dimensional array
            //https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength
            MatrixInt m = new MatrixInt(new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 },
                }
            );
            Assert.That(m.NbLines, Is.EqualTo(3));
            Assert.That(m.NbColumns, Is.EqualTo(3));

            //See Indexers Documentation =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/indexers/
            Assert.AreEqual(1, m[0, 0]);
            Assert.AreEqual(2, m[0, 1]);
            Assert.AreEqual(3, m[0, 2]);
            Assert.AreEqual(4, m[1, 0]);
            Assert.AreEqual(5, m[1, 1]);
            Assert.AreEqual(6, m[1, 2]);
            Assert.AreEqual(7, m[2, 0]);
            Assert.AreEqual(8, m[2, 1]);
            Assert.AreEqual(9, m[2, 2]);
        }
    }
}