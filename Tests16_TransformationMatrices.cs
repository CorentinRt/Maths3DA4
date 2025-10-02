// Corentin Remot

using System;
using NUnit.Framework;
using UnitTestMaths3D;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests16_TransformationMatrices
    {
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTranslatePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.That(6f, Is.EqualTo(vTransformed.x));
            Assert.That(3f, Is.EqualTo(vTransformed.y));
            Assert.That(1f, Is.EqualTo(vTransformed.z));

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(0f));

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(0f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTranslateDirection()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 0f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });
            Vector4 vTransformed = m * v;

            Assert.That(vTransformed.x, Is.EqualTo(1f));
            Assert.That(vTransformed.y, Is.EqualTo(0f));
            Assert.That(vTransformed.z, Is.EqualTo(0f));

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(0f));

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestScalePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(2f, 1f, 3f, 1f);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { 0.5f, 0f, 0f, 0f },
                { 0.0f, 2f, 0f, 0f },
                { 0.0f, 0f, 3f, 0f },
                { 0.0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.That(vTransformed.x, Is.EqualTo(1f));
            Assert.That(vTransformed.y, Is.EqualTo(2f));
            Assert.That(vTransformed.z, Is.EqualTo(9f));

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(2f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(3f));

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(2f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(3f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestRotatePoint()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 4f, 7f, 1f);
            double a = Math.PI / 2d;
            float cosA = (float)Math.Cos(a);
            float sinA = (float)Math.Sin(a);
            MatrixFloat m = new MatrixFloat(new[,]
            {
                { cosA, -sinA, 0f, 0f },
                { sinA, cosA, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.That(vTransformed.x, Is.EqualTo(-4f));
            Assert.That(vTransformed.y, Is.EqualTo(1f));
            Assert.That(vTransformed.z, Is.EqualTo(7f));

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(4f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(7f));

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
            Assert.That(vTransformedInverted.y, Is.EqualTo(4f));
            Assert.That(vTransformedInverted.z, Is.EqualTo(7f));

            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}