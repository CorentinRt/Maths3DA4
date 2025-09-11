// Corentin Remot

namespace UnitTestMaths3D;

public class MatrixRowReductionAlgorithm
{
    public static (MatrixFloat, MatrixFloat) Apply(MatrixFloat m1, MatrixFloat m2)
    {
        MatrixFloat augmentedMatrix = MatrixFloat.GenerateAugmentedMatrix(m1, m2);
        
        
        // Apply algorithm

        int i = 0;
        int j = 0;

        while (i < augmentedMatrix.NbLines - 1)
        {
            float highestValue = augmentedMatrix[i, j];
            int highestLine = i;
            
            for (int k = i; k < augmentedMatrix.NbColumns; k++)
            {
                if (augmentedMatrix[i, k] > highestValue)
                {
                    highestValue = augmentedMatrix[i, k];
                    highestLine = k;
                }
            }
            
            if (highestLine != i)
            {
                Console.WriteLine($"Try to swap line {i} to highest {highestLine}");
                // ERROR INDEX OUT OF RANGE
                MatrixElementaryOperations.SwapLines(augmentedMatrix, highestLine, i);
            }
            
            MatrixElementaryOperations.MultiplyLine(augmentedMatrix, i, (1f/augmentedMatrix[i, j]));

            for (int r = 0; r < augmentedMatrix.NbLines; r++)
            {
                if (r != i)
                {
                    augmentedMatrix[r, j] += -augmentedMatrix[r, j] * augmentedMatrix[i, j];
                }
            }
            
            i++;
            j++;
        }
        
        
        (MatrixFloat, MatrixFloat) result = augmentedMatrix.Split(augmentedMatrix.NbLines - 2);
        
        return  result;
    }
    
    
}