namespace UnitTestMaths3D;

public class Vector3
{
    public float x, y, z;

    public Vector3()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }
    public Vector3(Vector3 v)
    {
        this.x = v.x;
        this.y = v.y;
        this.z = v.z;
    }
    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vector3 operator *(Vector3 v, MatrixFloat m)
    {
        Vector3 result = new Vector3(v);
        
        MatrixFloat tempMatrix = new MatrixFloat(4, 1);
        
        tempMatrix[0, 0] = v.x;
        tempMatrix[1, 0] = v.y;
        tempMatrix[2, 0] = v.z;
        tempMatrix[3, 0] = 0f;
        
        tempMatrix = m * tempMatrix;
        
        result.x = tempMatrix[0, 0];
        result.y = tempMatrix[1, 0];
        result.z = tempMatrix[2, 0];

        return result;
    }
    
    public static Vector3 operator *(MatrixFloat m, Vector3 v)
    {
        return v * m;
    }
}