// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests25_QuaternionsMultiplication
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.That(result.x, Is.EqualTo(0.5f));
            Assert.That(result.y, Is.EqualTo(0.5f));
            Assert.That(result.z, Is.EqualTo(0.5f));
            Assert.That(result.w, Is.EqualTo(0.5f));
            
            result = rotationYAxis * rotationXAxis;
            Assert.That(result.x, Is.EqualTo(0.5f));
            Assert.That(result.y, Is.EqualTo(0.5f));
            Assert.That(result.z, Is.EqualTo(-0.5f));
            Assert.That(result.w, Is.EqualTo(0.5f));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            Assert.That(result.x, Is.EqualTo(0.5f));
            Assert.That(result.y, Is.EqualTo(-0.5f));
            Assert.That(result.z, Is.EqualTo(0.5f));
            Assert.That(result.w, Is.EqualTo(0.5f));
            
            result = rotationZAxis * rotationXAxis;
            Assert.That(result.x, Is.EqualTo(0.5f));
            Assert.That(result.y, Is.EqualTo(0.5f));
            Assert.That(result.z, Is.EqualTo(0.5f));
            Assert.That(result.w, Is.EqualTo(0.5f));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationYAxis;
            Assert.That(result.x, Is.EqualTo(-0.5f));
            Assert.That(result.y, Is.EqualTo(0.5f));
            Assert.That(result.z, Is.EqualTo(0.5f));
            Assert.That(result.w, Is.EqualTo(0.5f));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionMultiplyIdentity()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            Assert.That(result.x, Is.EqualTo(0f));
            Assert.That(result.y, Is.EqualTo(0.71f));
            Assert.That(result.z, Is.EqualTo(0f));
            Assert.That(result.w, Is.EqualTo(0.71f));

            result = qIdentity * rotationYAxis;
            Assert.That(result.x, Is.EqualTo(0f));
            Assert.That(result.y, Is.EqualTo(0.71f));
            Assert.That(result.z, Is.EqualTo(0f));
            Assert.That(result.w, Is.EqualTo(0.71f));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
