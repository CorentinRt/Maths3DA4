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
        set =>  _localRotation = value;
    }

    public Vector4 LocalScale
    {
        get => _localScale;
        set => _localScale = value;
    }
    
    public MatrixFloat LocalTranslationMatrix;
    
    public Transform()
    {
        _localPosition = new Vector4(0f, 0f, 0f, 1f);
        _localRotation = new Vector4();
        _localScale = new Vector4(1f, 1f, 1f, 0f);

        CalculTranslationMatrix();
    }

    public void CalculTranslationMatrix()
    {
        LocalTranslationMatrix = MatrixFloat.Identity(4);

        LocalTranslationMatrix[0, 3] = _localPosition.x;
        LocalTranslationMatrix[1, 3] = _localPosition.y;
        LocalTranslationMatrix[2, 3] = _localPosition.z;
        LocalTranslationMatrix[3, 3] = _localPosition.w;
    }

}