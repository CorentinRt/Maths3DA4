namespace UnitTestMaths3D;

public class Transform
{
    private Vector4 _localPosition;
    public MatrixFloat LocalTranslationMatrix;
    
    
    private Vector3 _localRotation;
    
    public MatrixFloat LocalRotationMatrix;
    public MatrixFloat LocalRotationXMatrix;
    public MatrixFloat LocalRotationYMatrix;
    public MatrixFloat LocalRotationZMatrix;
    
    
    private Vector4 _localScale;
    
    public MatrixFloat LocalScaleMatrix;

    
    private MatrixFloat _localToWorldMatrix;

    public MatrixFloat LocalToWorldMatrix
    {
        get
        {
            CalculLocalToWorldMatrix();
            return _localToWorldMatrix;
        }
        set
        {
            _localToWorldMatrix = value;
            CalculLocalToWorldMatrix();
        }
    }

    private Vector4 _worldPosition;
    
    public Vector4 WorldPosition
    {
        get
        {
            CalculWorldPosition();
            
            return _worldPosition;
        }
        set
        {
            if (_parent != null)
            {
                Vector4 newLocal = _parent.WorldToLocalMatrix * value;
                LocalPosition = newLocal;
            }
            else
            {
                LocalPosition = value;
            }

            CalculLocalToWorldMatrix();
            CalculWorldPosition();
        }
    }
    
    private MatrixFloat _worldToLocalMatrix;
    public MatrixFloat WorldToLocalMatrix
    {
        get
        {
            CalculWorldToLocalMatrix();
            return _worldToLocalMatrix;
        }
        set
        {
            _worldToLocalMatrix = value;
            CalculWorldToLocalMatrix();
        }
    }
    
    public Vector4 LocalPosition
    {
        get => _localPosition;
        set
        {
            _localPosition = value;

            CalculTranslationMatrix();
        }
    }

    public Vector3 LocalRotation
    {
        get => _localRotation;
        set
        {
            _localRotation = value;

            CalculRotationMatrix();
        }
    }

    private Quaternion _localRotationQuaternion;
    
    public Quaternion LocalRotationQuaternion
    {
        get
        {
            _localRotationQuaternion = Quaternion.Euler(LocalRotation.x, LocalRotation.y, LocalRotation.z);
            return  _localRotationQuaternion;
        }
        set
        {
            _localRotationQuaternion = value;

            _localRotation = _localRotationQuaternion.EulerAngles;
            
            CalculRotationMatrix();
        }
    }

    public Vector4 LocalScale
    {
        get => _localScale;
        set
        {
            _localScale = value;

            CalculLocalScaleMatrix();
        }
    }

    private Transform _parent;
    
    public void SetParent(Transform parent)
    {
        _parent = parent;
    }
    
    public Transform()
    {
        _localPosition = new Vector4(0f, 0f, 0f, 1f);
        _localRotation = new Vector3();
        _localRotationQuaternion =  new Quaternion();
        _localScale = new Vector4(1f, 1f, 1f, 0f);
        
        CalculTranslationMatrix();
        
        CalculRotationMatrix();
        
        CalculLocalScaleMatrix();

        CalculLocalToWorldMatrix();
        CalculWorldToLocalMatrix();

        _worldPosition = new Vector4();
        
        CalculWorldPosition();
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

    private void CalculLocalScaleMatrix()
    {
        LocalScaleMatrix =  MatrixFloat.Identity(4);
        
        LocalScaleMatrix[0, 0] =  _localScale.x;
        LocalScaleMatrix[1, 1] =  _localScale.y;
        LocalScaleMatrix[2, 2] =  _localScale.z;
    }

    private void CalculLocalToWorldMatrix()
    {
        _localToWorldMatrix = MatrixFloat.Identity(4);
        
        _localToWorldMatrix = LocalTranslationMatrix * LocalRotationMatrix * LocalScaleMatrix;

        if (_parent != null)
        {
            _localToWorldMatrix = _parent.LocalToWorldMatrix * _localToWorldMatrix;
        }
    }

    private void CalculWorldToLocalMatrix()
    {
        _worldToLocalMatrix = MatrixFloat.Identity(4);
        
        CalculLocalToWorldMatrix();
        
        _worldToLocalMatrix = MatrixFloat.InvertByDeterminant(_localToWorldMatrix);
    }

    private void CalculWorldPosition()
    {
        CalculLocalToWorldMatrix();
        
        _worldPosition.x = _localToWorldMatrix[0, 3];
        _worldPosition.y = _localToWorldMatrix[1, 3];
        _worldPosition.z = _localToWorldMatrix[2, 3];
        _worldPosition.w = _localToWorldMatrix[3, 3];
    }
}