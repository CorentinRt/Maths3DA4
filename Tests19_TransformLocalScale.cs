// Corentin Remot

using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests19_TransformLocalScale
    {
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Default Scale
            Assert.That(t.LocalScale.x, Is.EqualTo(1f));
            Assert.That(t.LocalScale.y, Is.EqualTo(1f));
            Assert.That(t.LocalScale.z, Is.EqualTo(1f));
            
            //Default Matrix
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestChangeScale()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            Assert.That(t.LocalScaleMatrix.ToArray2D(), Is.EqualTo(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}