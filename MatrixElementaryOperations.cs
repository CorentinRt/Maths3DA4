// Corentin Remot

namespace UnitTestMaths3D;

public static class MatrixElementaryOperations
{
    #region  MatrixInt
    public static void SwapLines(MatrixInt m, int l1, int l2)
    {
        for (int i = 0; i < m.NbColumns; i++)
        {
            (m[l1, i], m[l2, i]) = (m[l2, i], m[l1, i]);

            /*
            int tempValue = m[l1, i];
            
            m[l1, i] = m[l2, i];
            m[l2, i] = tempValue;
            */
        }
    }
    
    public static void SwapColumns(MatrixInt m, int c1, int c2)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            (m[i, c1], m[i, c2]) = (m[i, c2], m[i, c1]);

            /*
            int tempValue = m[i, c1];
            
            m[i, c1] = m[i, c2];
            m[i, c2] = tempValue;
            */
        }
    }

    public static void MultiplyLine(MatrixInt m, int l, int value)
    {
        if (value == 0)
        {
            throw new MatrixScalarZeroException("Cannot multiply line by zero.");
        }

        for (int i = 0; i < m.NbColumns; i++)
        {
            m[l, i] *= value;
        }
    }
    
    public static void MultiplyColumn(MatrixInt m, int c, int value)
    {
        if (value == 0)
        {
            throw new MatrixScalarZeroException("Cannot multiply columns by zero.");
        }

        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, c] *= value;
        }
    }

    public static void AddLineToAnother(MatrixInt m, int lignToAdd, int lignWhereToAdd, int factor)
    {
        for (int i = 0; i < m.NbColumns; i++)
        {
            m[lignWhereToAdd, i] = m[lignToAdd, i] * factor + m[lignWhereToAdd, i];
        }
    }
    
    public static void AddColumnToAnother(MatrixInt m, int columnToAdd, int columnWhereToAdd, int factor)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, columnWhereToAdd] = m[i, columnToAdd] * factor + m[i, columnWhereToAdd];
        }
    }
    
    #endregion

    #region  MatrixFloat

    public static void SwapLines(MatrixFloat m, int l1, int l2)
    {
        for (int i = 0; i < m.NbColumns; i++)
        {
            (m[l1, i], m[l2, i]) = (m[l2, i], m[l1, i]);

            /*
            float tempValue = m[l1, i];

            m[l1, i] = m[l2, i];
            m[l2, i] = tempValue;
            */
        }
    }
    
    public static void SwapColumns(MatrixFloat m, int c1, int c2)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            (m[i, c1], m[i, c2]) = (m[i, c2], m[i, c1]);

            /*
            float tempValue = m[i, c1];

            m[i, c1] = m[i, c2];
            m[i, c2] = tempValue;
            */
        }
    }

    public static void MultiplyLine(MatrixFloat m, int l, float value)
    {
        if (value == 0)
        {
            throw new MatrixScalarZeroException("Cannot multiply line by zero.");
        }

        for (int i = 0; i < m.NbColumns; i++)
        {
            m[l, i] *= value;
        }
    }
    
    public static void MultiplyColumn(MatrixFloat m, int c, float value)
    {
        if (value == 0)
        {
            throw new MatrixScalarZeroException("Cannot multiply columns by zero.");
        }

        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, c] *= value;
        }
    }

    public static void AddLineToAnother(MatrixFloat m, int lignToAdd, int lignWhereToAdd, int factor)
    {
        for (int i = 0; i < m.NbColumns; i++)
        {
            m[lignWhereToAdd, i] = m[lignToAdd, i] * factor + m[lignWhereToAdd, i];
        }
    }
    
    public static void AddColumnToAnother(MatrixFloat m, int columnToAdd, int columnWhereToAdd, int factor)
    {
        for (int i = 0; i < m.NbLines; i++)
        {
            m[i, columnWhereToAdd] = m[i, columnToAdd] * factor + m[i, columnWhereToAdd];
        }
    }

    #endregion
}
public class MatrixScalarZeroException : Exception
{
    public MatrixScalarZeroException() : base() { }
    public MatrixScalarZeroException(string message) : base(message) { }
    public MatrixScalarZeroException(string message, Exception inner) : base(message, inner) { }
}
