// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests24_QuaternionsAngleAxis
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisX()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around X axis
            float angle = 90f;
            Vector3 axis = new Vector3(1f, 0f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.That(q.x, Is.EqualTo(0.71f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.71f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisY()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around Y axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 1f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0.71f));
            Assert.That(q.z, Is.EqualTo(0f));
            Assert.That(q.w, Is.EqualTo(0.71f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionAngleAxisZ()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //90 degree around Z axis
            float angle = 90f;
            Vector3 axis = new Vector3(0f, 0f, 1f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0f));
            Assert.That(q.z, Is.EqualTo(0.71f));
            Assert.That(q.w, Is.EqualTo(0.71f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestQuaternionCustomAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            //60 degree around Vector(0,3,4)
            float angle = 60f;
            Vector3 axis = new Vector3(0f, 3f, 4f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.That(q.x, Is.EqualTo(0f));
            Assert.That(q.y, Is.EqualTo(0.3f));
            Assert.That(q.z, Is.EqualTo(0.4f));
            Assert.That(q.w, Is.EqualTo(0.87f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}