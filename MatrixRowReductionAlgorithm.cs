// Corentin Remot

namespace UnitTestMaths3D;

public class MatrixRowReductionAlgorithm
{
    public static (MatrixFloat, MatrixFloat) Apply(MatrixFloat m1, MatrixFloat m2)
    {
        MatrixFloat augmentedMatrix = MatrixFloat.GenerateAugmentedMatrix(m1, m2);
        
        int i = 0;
        int j = 0;

        while (j < m1.NbColumns)
        {
            /*
            Console.WriteLine($"Turn {i} !!");
            Console.WriteLine($"i = {i} / j = {j} : matrix i j = {augmentedMatrix[i, j]}");
            */
            
            float highestValue = augmentedMatrix[i, j];
            int highestLine = i;
            
            for (int k = i; k < augmentedMatrix.NbLines; k++)
            {
                if (MathF.Abs(augmentedMatrix[k, j]) > highestValue)
                {
                    highestValue = MathF.Abs(augmentedMatrix[k, j]);
                    highestLine = k;
                }
            }

            if (highestValue == 0)
            {
                j++;
                //i++;
                continue;
            }
            
            if (highestLine != i)
            {
                //Console.WriteLine($"Swap line {i} to highest {highestLine}");
                MatrixElementaryOperations.SwapLines(augmentedMatrix, highestLine, i);
            }
            
            
            //Console.WriteLine($"Multiply line {i} by {1f/augmentedMatrix[i, j]}");
            MatrixElementaryOperations.MultiplyLine(augmentedMatrix, i, (1f/augmentedMatrix[i, j]));

            for (int r = 0; r < augmentedMatrix.NbLines; r++)
            {
                if (r == i)
                    continue;
                
                float factor = augmentedMatrix[r, j];
                
                for (int c = j; c < augmentedMatrix.NbColumns; c++)
                {
                    //Console.WriteLine($"At position {r}:{c} , Add {-factor} * {augmentedMatrix[i, c]} + {augmentedMatrix[r, c]} to result in {-augmentedMatrix[r, j] * augmentedMatrix[i, c] + augmentedMatrix[r, c]}");
                    
                    augmentedMatrix[r, c] += -factor * augmentedMatrix[i, c];
                }
            }
            
            i++;
            j++;
        }

        /*
        Console.WriteLine("-------------------------------------");
        
        for (int y = 0; y < augmentedMatrix.NbLines; y++)
        {
            string toPrint = $"{y} : ";
            for (int u = 0; u < augmentedMatrix.NbColumns; u++)
            {
                toPrint += $"{augmentedMatrix[y, u]} | ";
            }
            
            Console.WriteLine(toPrint);
        }
        */
        
        (MatrixFloat, MatrixFloat) result = augmentedMatrix.Split(m1.NbColumns - 1);

        Console.WriteLine($"-------------- result item 2 -----------------------");
        
        for (int y = 0; y < result.Item2.NbLines; y++)
        {
            string toPrint = $"{y} : ";
            for (int u = 0; u < result.Item2.NbColumns; u++)
            {
                toPrint += $"{result.Item2[y, u]} | ";
            }
            
            Console.WriteLine(toPrint);
        }
        
        return  result;
    }
    
    
}