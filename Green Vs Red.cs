using System;

namespace Green_vs_Red
{
    class RedvsGreen
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ______________________________________________________________________\n" +
                              "|This game will check how many times will a specific cell from the grid|\n" +
                              "|change its state to green over the course of predifined turns.        |\n" +
                              "|______________________________________________________________________|");

            Console.WriteLine("Please type the dimensions of the grid. For example: 3, 3");
            int[] gridDimensions = ConvertValues.ParseValues();

            int rows = gridDimensions[0];
            int cols = gridDimensions[1];
            
            int[,] matrix = new int[rows, cols];

            Matrix.CreateMatrix(rows, cols, matrix);

            Console.WriteLine($"Please specify the coordinates of the cell you would like to check the changes for and the amount of turns.\n" +
                              $"Use the following format: x, y, z\n" +
                              $"The (x) represents the width, (y) represents the height and (z) represents the amount of turns.");

            int[] coordinates = ConvertValues.ParseValues();

            int y = coordinates[0];
            int x = coordinates[1];
            int generations = coordinates[2];

            /*
             *  END OF INPUT PART!
             */
            
            const byte greenCell = 1;
            const byte redCell = 0;
            int cellStateChangeCount = 0;

            cellStateChangeCount = GenerationsEngine.CreateGenerations(matrix, y, x, generations, greenCell, redCell, cellStateChangeCount);

            Console.WriteLine($"Times that cell [{y}, {x}] changed its state in {generations} generations: {cellStateChangeCount}");
        } 
    }
}
