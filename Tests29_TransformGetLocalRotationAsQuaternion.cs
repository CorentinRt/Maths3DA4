// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests29_TransformGetLocalRotationAsQuaternion
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestTransformGetLocalRotationQuaternionDefault()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Transform t = new Transform();
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(1f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0.259f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.966f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 30f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0.259f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.966f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 0f, 30f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0.259f));
            Assert.That(q.w, Is.EqualTo(0.966f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.That(q.x, Is.EqualTo(0.430f));
            Assert.That(q.y, Is.EqualTo(0.092f));
            Assert.That(q.z, Is.EqualTo(0.561f));
            Assert.That(q.w, Is.EqualTo(0.701f));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}