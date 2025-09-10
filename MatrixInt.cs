// Corentin Remot

namespace UnitTestMaths3D;

public class MatrixInt()
{
    public MatrixInt(int NbLines, int NbColumns) : this()
    {
        this.NbLines = NbLines;
        this.NbColumns = NbColumns;

        this.Matrix = new int[this.NbLines, this.NbColumns];
    }

    public MatrixInt(int[,] Matrix) : this()
    {
        this.Matrix = Matrix;
        
        this.NbLines = Matrix.GetLength(0);
        this.NbColumns = Matrix.GetLength(1);
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
}