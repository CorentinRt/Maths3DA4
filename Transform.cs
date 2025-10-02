namespace UnitTestMaths3D;

public class Transform
{
    private Vector4 _localPosition;
    private Vector4 _localRotation;
    private Vector4 _localScale;
    
    public Vector4 LocalPosition
    {
        get => _localPosition;
        set
        {
            _localPosition = value;

            CalculTranslationMatrix();
        }
    }

    public Vector4 LocalRotation
    {
        get => _localRotation;
        set
        {
            _localRotation = value;

            CalculRotationMatrix();
        }
    }

    public Vector4 LocalScale
    {
        get => _localScale;
        set => _localScale = value;
    }
    
    public MatrixFloat LocalTranslationMatrix;
    
    public MatrixFloat LocalRotationMatrix;
    public MatrixFloat LocalRotationXMatrix;
    public MatrixFloat LocalRotationYMatrix;
    public MatrixFloat LocalRotationZMatrix;
    
    
    public Transform()
    {
        _localPosition = new Vector4(0f, 0f, 0f, 1f);
        _localRotation = new Vector4();
        _localScale = new Vector4(1f, 1f, 1f, 0f);

        CalculTranslationMatrix();
        
        CalculRotationMatrix();
    }

    public void CalculTranslationMatrix()
    {
        LocalTranslationMatrix = MatrixFloat.Identity(4);

        LocalTranslationMatrix[0, 3] = _localPosition.x;
        LocalTranslationMatrix[1, 3] = _localPosition.y;
        LocalTranslationMatrix[2, 3] = _localPosition.z;
        LocalTranslationMatrix[3, 3] = _localPosition.w;
    }

    public void CalculRotationMatrix()
    {
        // Rotation X
        LocalRotationXMatrix = MatrixFloat.Identity(4);

        float radX = MathF.PI / 180f *  _localRotation.x;
        
        LocalRotationXMatrix[1, 1] = MathF.Cos(radX);
        LocalRotationXMatrix[1, 2] = -MathF.Sin(radX);
        LocalRotationXMatrix[2, 1] = MathF.Sin(radX);
        LocalRotationXMatrix[2, 2] = MathF.Cos(radX);
        
        // Rotation Y
        LocalRotationYMatrix = MatrixFloat.Identity(4);
        
        float radY = MathF.PI / 180f *  _localRotation.y;
        
        LocalRotationYMatrix[0, 0] = MathF.Cos(radY);
        LocalRotationYMatrix[0, 2] = MathF.Sin(radY);
        LocalRotationYMatrix[2, 0] = -MathF.Sin(radY);
        LocalRotationYMatrix[2, 2] = MathF.Cos(radY);
        
        // Rotation Z
        LocalRotationZMatrix = MatrixFloat.Identity(4);
        
        float radZ = MathF.PI / 180f *  _localRotation.z;
        
        LocalRotationZMatrix[0, 0] = MathF.Cos(radZ);
        LocalRotationZMatrix[0, 1] = -MathF.Sin(radZ);
        LocalRotationZMatrix[1, 0] = MathF.Sin(radZ);
        LocalRotationZMatrix[1, 1] = MathF.Cos(radZ);
        
        // Final Rotation Y -> X -> Z
        LocalRotationMatrix = MatrixFloat.Identity(4);
        
        LocalRotationMatrix = LocalRotationYMatrix *  LocalRotationXMatrix * LocalRotationZMatrix;
    }

}