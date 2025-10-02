// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests18_TransformLocalRotations
    {
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //Default Rotation
            Assert.That(t.LocalRotation.x, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.y, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.z, Is.EqualTo(0f));

            //Default Matrices
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationYMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationZMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationXAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            Assert.That(t.LocalRotationXMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            Assert.That(t.LocalRotationMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        /*
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationYAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 30f, 0f);
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationZAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            t.LocalRotation = new Vector3(0f, 0f, 30f);
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeRotationMultipleAxis()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            
            //For LocalRotationMatrix attribute =>
            //Rotations are performed around the Z axis, the X axis, and the Y axis, in that order.
            //Like Unity => https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
            //So the operation order is => RY * RX * RZ

            //Rotation to Multiple Axis
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            Assert.AreEqual(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        */
        
    }
}