using System.Collections.Generic;

namespace Green_vs_Red
{
    /// <summary>
    ///     GenerationsEngine Class: Is a class that creates the next generations of cells.
    ///     It also inherits the CellManipulation class.
    /// </summary>
    class GenerationsEngine : CellManipulation
    {
        /// <summary>
        ///     CreateGenerations: Is a method comprised of several additional methods and it creates a new generation of cells.
        /// </summary>
        /// <param name="matrix">Two-dimensional array.</param>
        /// <param name="y">Height of the matrix.</param>
        /// <param name="x">Width of the matrix.</param>
        /// <param name="generations">How many generations do we want to check.</param>
        /// <param name="greenCell">Constant indicating the value for green cells.</param>
        /// <param name="redCell">Constant indicating the value for red cells.</param>
        /// <param name="cellStateChangeCount">How many times has the cell we want changed to green.</param>
        /// <returns>How many times has a certain cell changed its state throughout the generations.</returns>
        public static int CreateGenerations(int[,] matrix, int y, int x, int generations, byte greenCell, byte redCell, int cellStateChangeCount)
        {
            for (int i = 0; i < generations; i++)
            {
                List<int> newGenerationCellsList = new List<int>();

                // Going through the 2-dimensional array, cell by cell.
                for (int row = matrix.GetLowerBound(0); row <= matrix.GetUpperBound(0); row++)
                {
                    for (int col = matrix.GetLowerBound(1); col <= matrix.GetUpperBound(1); col++)
                    {
                        int redCellCount = 0;
                        int greenCellCount = 0;
                        int currentCellValue = matrix[row, col];
                        int upperLeft, upperCenter, upperRight, centerRight, lowerRight, lowerCenter, lowerLeft, centerLeft;

                        GetSurroundingCells(matrix, row, col, out upperLeft, out upperCenter, out upperRight, out centerRight, out lowerRight, out lowerCenter, out lowerLeft, out centerLeft);

                        int[] listOfSurroundingCells = new int[8] { upperLeft, upperCenter, upperRight, centerRight, lowerRight, lowerCenter, lowerLeft, centerLeft };

                        CheckCellColourCount(greenCell, redCell, ref redCellCount, ref greenCellCount, listOfSurroundingCells);

                        currentCellValue = ChangeCellColour(greenCell, redCell, greenCellCount, currentCellValue);
                        cellStateChangeCount = CountingCellStateChange(y, x, greenCell, cellStateChangeCount, row, col, currentCellValue);

                        newGenerationCellsList.Add(currentCellValue);
                    }
                }

                SpawnNextGeneration(matrix, newGenerationCellsList);
            }

            return cellStateChangeCount;
        }

        /// <summary>
        ///     SpawnNextGeneration: Is a method that overrides the current generation with the next one.
        ///     It takes two integer parameters.
        /// </summary>
        /// <param name="matrix">Two-dimensional array.</param>
        /// <param name="newGenerationCellsList">A list with the cell values for the new generation.</param>
        private static void SpawnNextGeneration(int[,] matrix, List<int> newGenerationCellsList)
        {
            int j = 0;
            for (int row = matrix.GetLowerBound(0); row <= matrix.GetUpperBound(0); row++)
            {
                for (int col = matrix.GetLowerBound(1); col <= matrix.GetUpperBound(1); col++)
                {
                    matrix[row, col] = newGenerationCellsList[j];
                    j++;
                }
            }
        }
    }
}
