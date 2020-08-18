using System;

namespace Green_vs_Red
{
    /// <summary>
    ///     Matrix: Is a class with one method that fills a two-dimensional array with data.
    /// </summary>
    class Matrix
    {
        /// <summary>
        ///     CreateMatrix: Is a void method for packing a two dimentional integer array with 0's and 1's which were obtained from the user input in the console.
        ///     It takes three integer parameters.
        /// </summary>
        /// <param name="rows">The amount of rows for the array.</param>
        /// <param name="cols">The amount of columns for the array.</param>
        /// <param name="matrix">Two-dimensional array.</param>
        public static void CreateMatrix(int rows, int cols, int[,] matrix)
        {
            Console.WriteLine("Please type a combination of 1's and 0's within the specified dimensions.");

            for (int row = 0; row < rows; row++)
            {
                string tempCurrentRow = Console.ReadLine();
                int[] currentRow = ConvertValues.ConvertRowToInt(tempCurrentRow);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
