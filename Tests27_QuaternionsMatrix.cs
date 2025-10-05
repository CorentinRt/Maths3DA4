// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests27_QuaternionsMatrix
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.That(result.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            Assert.That(invertedResult.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMatrixIdentity()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.Identity;
            
            Assert.That(q.Matrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}