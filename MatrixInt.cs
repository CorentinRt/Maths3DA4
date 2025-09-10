// Corentin Remot

namespace UnitTestMaths3D;

public class MatrixInt()
{
    public MatrixInt(int nbLines, int nbColumns) : this()
    {
        this.NbLines = nbLines;
        this.NbColumns = nbColumns;

        this.Matrix = new int[this.NbLines, this.NbColumns];
    }

    public MatrixInt(int[,] matrix) : this()
    {
        this.Matrix = matrix;
        
        this.NbLines = matrix.GetLength(0);
        this.NbColumns = matrix.GetLength(1);
    }

    public MatrixInt(MatrixInt m) : this()
    {
        int[,] copiedMatrix = new  int[m.NbLines, m.NbColumns];
        
        for (int i = 0; i < m.NbLines; i++)
        {
            for (int j = 0; j < m.NbColumns; j++)
            {
                copiedMatrix[i, j] = m[i, j];
            }
        }

        this.Matrix = copiedMatrix;
        
        this.NbLines = m.NbLines;
        this.NbColumns = m.NbColumns;
    }
    
    public int NbLines;
    public int NbColumns;

    public int[,] Matrix;
    
    public int[,] ToArray2D()
    {
        return Matrix;
    }
    
    public int this[int i, int j]
    {
        get => this.Matrix[i, j];
        set => this.Matrix[i, j] = value;
    }

    public static MatrixInt Identity(int size)
    {
        MatrixInt identity = new MatrixInt(size, size);
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (j == i)
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
        bool isIdentity = true;

        if (this.NbColumns != this.NbLines)
            return false;
        
        for (int i = 0; i < NbLines; i++)
        {
            for (int j = 0; j < NbColumns; j++)
            {
                if (j == i)
                {
                    if (Matrix[i, j] != 1)
                    {
                        isIdentity = false;
                        break;
                    }
                }
                else
                {
                    if (Matrix[i, j] != 0)
                    {
                        isIdentity = false;
                        break;
                    }
                }
            }
        }

        return isIdentity;
    }

    public void Multiply(int value)
    {
        for (int i = 0; i < this.NbLines; i++)
        {
            for (int j = 0; j < this.NbColumns; j++)
            {
                Matrix[i, j] = this.Matrix[i, j] * value;
            }
        }
    }
    
    public static MatrixInt Multiply(MatrixInt matrix, int value)
    {
        MatrixInt m = new MatrixInt(matrix.NbLines, matrix.NbColumns);

        for (int i = 0; i < matrix.NbLines; i++)
        {
            for (int j = 0; j < matrix.NbColumns; j++)
            {
                m[i, j] = matrix.Matrix[i, j] * value;
            }
        }

        return m;
    }

    public static MatrixInt operator * (MatrixInt matrix, int value)
    {
        return Multiply(matrix, value);
    }
    public static MatrixInt operator * (int value, MatrixInt matrix)
    {
        return Multiply(matrix, value);
    }
    public static MatrixInt operator - (MatrixInt matrix)
    {
        return Multiply(matrix, -1);
    }
    
}