// Corentin Remot

namespace UnitTestMaths3D;

public class MatrixFloat
{
    public int NbLines = 0;
    public int NbColumns = 0;

    public float[,] matrix;
    
    public MatrixFloat(int lines, int columns)
    {
        this.NbLines = lines;
        this.NbColumns = columns;
        
        matrix = new float[lines, columns];
    }

    public MatrixFloat(float[,] m)
    {
        this.NbLines = m.GetLength(0);
        this.NbColumns = m.GetLength(1);
        
        this.matrix = m;
    }

    public MatrixFloat(MatrixFloat m)
    {
        this.NbLines = m.matrix.GetLength(0);
        this.NbColumns = m.matrix.GetLength(1);
        
        this.matrix = m.matrix.Clone() as float[,];
    }
    
    public float this[int i, int j]
    {
        get =>  this.matrix[i, j];
        set =>  this.matrix[i, j] = value;
    }
    
    public float[,] ToArray2D()
    {
        return matrix;
    }

    public static MatrixFloat Identity(int size)
    {
        MatrixFloat identity = new MatrixFloat(size, size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == j)
                {
                    identity[i, j] = 1;
                }
                else
                {
                    identity[i, j] = 0;
                }
            }
        }
        
        return identity;
    }

    public bool IsIdentity()
    {
        if (NbLines != NbColumns)
            return false;
        
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                if (i == j)
                {
                    if (matrix[i, j] != 1f)
                        return false;
                }
                else
                {
                    if (matrix[i, j] != 0)
                        return false;
                }
            }
        }

        return true;
    }

    public void Multiply(int value)
    {
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                this.matrix[i, j] *= value;
            }
        }
    }

    public static MatrixFloat Multiply(MatrixFloat m1, int value)
    {
        MatrixFloat result =  new MatrixFloat(m1);

        result.Multiply(value);
        
        return result;
    }
    
    public static MatrixFloat operator *(MatrixFloat m, int value)
    {
        return MatrixFloat.Multiply(m, value);
    }
    public static MatrixFloat operator *(int value, MatrixFloat m)
    {
        return MatrixFloat.Multiply(m, value);
    }
    public static MatrixFloat operator -(MatrixFloat m)
    {
        return MatrixFloat.Multiply(m, -1);
    }

    public void Add(MatrixFloat m)
    {
        if (this.NbLines != m.NbLines || this.NbColumns != m.NbColumns)
        {
            throw new MatrixSumException("Can't add matrix. Size don't match !");
        }

        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                this.matrix[i, j] +=  m[i, j];
            }
        }
    }

    public static MatrixFloat Add(MatrixFloat m1, MatrixFloat m2)
    {
        if (m1.NbLines != m2.NbLines || m1.NbColumns != m2.NbColumns)
        {
            throw new MatrixSumException("Can't add matrix. Size don't match !");
        }
        
        MatrixFloat result = new MatrixFloat(m1);

        result.Add(m2);
        
        return result;
    }

    public static MatrixFloat operator +(MatrixFloat m1, MatrixFloat m2)
    {
        return MatrixFloat.Add(m1, m2);
    }

    public static MatrixFloat operator -(MatrixFloat m1,  MatrixFloat m2)
    {
        return MatrixFloat.Add(m1, -m2);
    }

    public MatrixFloat Multiply(MatrixFloat m2)
    {
        if (this.NbColumns != m2.NbLines)
            throw new MatrixMultiplyException("Can't multiply matrix. Columns of m1 don't match lines of m2 !");

        MatrixFloat result = new MatrixFloat(this.NbLines, m2.NbColumns);

        for (int i = 0; i < this.NbLines; i++)
        {
            for (int j = 0; j < m2.NbColumns; j++)
            {
                float tempValue = 0;
                
                for (int k = 0; k < m2.NbLines; k++)
                {
                    tempValue += this.matrix[i, k] * m2.matrix[k, j];
                }

                result.matrix[i, j] = tempValue;
            }
        }

        return result;
    }

    public static MatrixFloat Multiply(MatrixFloat m1, MatrixFloat m2)
    {
        MatrixFloat result = new MatrixFloat(m1);
        
        return result.Multiply(m2);
    }
    
    public static MatrixFloat operator *(MatrixFloat m1, MatrixFloat m2)
    {
        return MatrixFloat.Multiply(m1, m2);
    }

    public MatrixFloat Transpose()
    {
        MatrixFloat result = new MatrixFloat(this.NbColumns, this.NbLines);

        for (int i = 0; i < result.NbLines; i++)
        {
            for (int j = 0; j < result.NbColumns; j++)
            {
                result.matrix[i, j] = this.matrix[j, i];
            }
        }
        
        return result;
    }

    public static MatrixFloat Transpose(MatrixFloat m)
    {
        return m.Transpose();
    }


    public static MatrixFloat GenerateAugmentedMatrix(MatrixFloat m1, MatrixFloat m2)
    {
        MatrixFloat result = new MatrixFloat(m1.NbLines, m1.NbColumns + m2.NbColumns);

        for (int i = 0; i < m1.NbLines; i++)
        {
            for (int j = 0; j <= m1.NbColumns; j++)
            {
                if (j == m1.NbColumns)
                {
                    result[i, j] = m2[i, 0];
                }
                else
                {
                    result[i, j] = m1[i, j];
                }
            }
        }
        
        return result;
    }

    public (MatrixFloat, MatrixFloat) Split(int value)
    {
        MatrixFloat m1 =  new MatrixFloat(this.NbLines, value + 1);
        
        MatrixFloat m2 = new MatrixFloat(this.NbLines, this.NbColumns - (value + 1));

        for (int i = 0; i < m1.NbLines; i++)
        {
            for (int j = 0; j < m1.NbColumns; j++)
            {
                if (j > value)
                {
                    m2[i, j - value] = this.matrix[i, j];
                }
                else
                {
                    m1[i, j] = this.matrix[i, j];
                }
            }
        }
        
        return  (m1, m2);
    }
}