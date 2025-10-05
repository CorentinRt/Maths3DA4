// Corentin Remot

namespace UnitTestMaths3D;

public struct Quaternion
{
    public float x;
    public float y;
    public float z;
    public float w;

    public Quaternion(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static Quaternion Identity
    {
        get
        {
            return new Quaternion(0, 0, 0, 1);
        }
    }

    public static Quaternion AngleAxis(float angle, Vector3 axis)
    {
        Quaternion q = Quaternion.Identity;

        Vector3 axisNormalized = Vector3.Normalize(axis);
        
        float angleRad = angle * MathF.PI / 180f;
        
        float cosAngleHalf = MathF.Cos(angleRad / 2f);
        float sinAngleHalf = MathF.Sin(angleRad / 2f);
        
        q.x = axisNormalized.x * sinAngleHalf;
        q.y = axisNormalized.y * sinAngleHalf;
        q.z = axisNormalized.z * sinAngleHalf;
        q.w = cosAngleHalf;
        
        return q;
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        Quaternion q3 = new Quaternion();

        q3.x = (q1.w * q2.x) + (q1.x * q2.w) + (q1.y * q2.z) - (q1.z * q2.y);
        q3.y = (q1.w * q2.y) - (q1.x * q2.z) + (q1.y * q2.w) + (q1.z * q2.x);
        q3.z = (q1.w * q2.z) + (q1.x * q2.y) - (q1.y * q2.x) + (q1.z * q2.w);
        
        q3.w = (q1.w * q2.w) - (q1.x * q2.x) - (q1.y * q2.y) - (q1.z * q2.z);
        
        return q3;
    }
    
}