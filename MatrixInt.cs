// Corentin Remot //

namespace UnitTestMaths3D;

public struct MatrixInt
{
    public MatrixInt(int NbLines, int NbColumns)
    {
        this.NbLines = NbLines;
        this.NbColumns = NbColumns;

        this.Matrix = new int[this.NbLines, this.NbColumns];
    }

    public MatrixInt(int[,] Matrix)
    {
        this.Matrix = Matrix;
        
        this.NbLines = Matrix.GetLength(0);
        this.NbColumns = Matrix.GetLength(1);
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