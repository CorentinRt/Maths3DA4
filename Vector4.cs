namespace UnitTestMaths3D;

public class Vector4
{
    public float x, y, z, w;

    public Vector4()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
        this.w = 0;
    }
    public Vector4(Vector4 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
        this.w = v.w;
    }
    public Vector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    public static Vector4 operator *(Vector4 v, MatrixFloat m)
    {
        Vector4 result = new Vector4(v);
        
        MatrixFloat tempMatrix = new MatrixFloat(4, 1);
        
        tempMatrix[0, 0] = v.x;
        tempMatrix[1, 0] = v.y;
        tempMatrix[2, 0] = v.z;
        tempMatrix[3, 0] = v.w;
        
        tempMatrix = m * tempMatrix;
        
        result.x = tempMatrix[0, 0];
        result.y = tempMatrix[1, 0];
        result.z = tempMatrix[2, 0];
        result.w = tempMatrix[3, 0];

        return result;
    }
    
    public static Vector4 operator *(MatrixFloat m, Vector4 v)
    {
        return v * m;
    }
}