
namespace Green_vs_Red
{
    /// <summary>
    ///     CellManipulation: A class that contains four methods, for obtaining the neighbouring values of a certain cell, checking their colour (red or green), 
    ///     changing their color and counting the times a certain cell has changed its colour.
    /// </summary>
    class CellManipulation
    {
        /// <summary>
        ///     GetSurroundingCells: Is a void method that obtains the values of all the surrounding cells from a certain coordinate in the matrix.
        ///     It takes eleven integer parameters.
        /// </summary>
        /// <param name="matrix">Two-dimensional array.</param>
        /// <param name="row">Current row.</param>
        /// <param name="col">Current column.</param>
        /// <param name="upperLeft">Upper left cell.</param>
        /// <param name="upperCenter">Upper center cell.</param>
        /// <param name="upperRight">Upper right cell.</param>
        /// <param name="centerRight">Right center cell.</param>
        /// <param name="lowerRight">Lower right cell.</param>
        /// <param name="lowerCenter">Lower center cell.</param>
        /// <param name="lowerLeft">Lower left cell.</param>
        /// <param name="centerLeft">Left center cell.</param>
        public static void GetSurroundingCells(int[,] matrix, int row, int col, out int upperLeft, out int upperCenter, out int upperRight, out int centerRight, out int lowerRight, out int lowerCenter, out int lowerLeft, out int centerLeft)
        {
            upperLeft = (row - 1 < matrix.GetLowerBound(0) || col - 1 < matrix.GetLowerBound(1)) ? 2 : matrix[row - 1, col - 1];
            upperCenter = (row - 1 < matrix.GetLowerBound(0)) ? 2 : matrix[row - 1, col];
            upperRight = (row - 1 < matrix.GetLowerBound(0) || col + 1 > matrix.GetUpperBound(1)) ? 2 : matrix[row - 1, col + 1];
            centerRight = (col + 1 > matrix.GetUpperBound(1)) ? 2 : matrix[row, col + 1];
            lowerRight = (row + 1 > matrix.GetUpperBound(0) || col + 1 > matrix.GetUpperBound(1)) ? 2 : matrix[row + 1, col + 1];
            lowerCenter = (row + 1 > matrix.GetUpperBound(0)) ? 2 : matrix[row + 1, col];
            lowerLeft = (row + 1 > matrix.GetUpperBound(0) || col - 1 < matrix.GetLowerBound(1)) ? 2 : matrix[row + 1, col - 1];
            centerLeft = (col - 1 < matrix.GetLowerBound(1)) ? 2 : matrix[row, col - 1];
        }
        /// <summary>
        ///     CheckCellColourCount: Is a void method that calculates how many red and green cells are there surrounding a certain coordinate in the matrix.
        ///     It takes five parameters.
        /// </summary>
        /// <param name="greenCell">Constant indicating the value for green cells.</param>
        /// <param name="redCell">Constant indicating the value for red cells.</param>
        /// <param name="redCellCount">The amount of red cells.</param>
        /// <param name="greenCellCount">The amount of green cells.</param>
        /// <param name="listOfSurroundingCells">Array of all the surrounding cell's values.</param>
        public static void CheckCellColourCount(byte greenCell, byte redCell, ref int redCellCount, ref int greenCellCount, int[] listOfSurroundingCells)
        {
            foreach (var cell in listOfSurroundingCells)
            {
                if (cell == greenCell)
                {
                    greenCellCount++;
                }
                else if (cell == redCell)
                {
                    redCellCount++;
                }
            }
        }
        /// <summary>
        ///     ChangeCellColour: Is a method that changes the state/colour of a certain cell.
        ///     It takes four parameters.
        /// </summary>
        /// <param name="greenCell">Constant indicating the value for green cells.</param>
        /// <param name="redCell">Constant indicating the value for red cells.</param>
        /// <param name="greenCellCount">The amount of green cells.</param>
        /// <param name="currentCellValue">The value of the cell we are currently looking at.</param>
        /// <returns>The new value of the cell.</returns>
        public static int ChangeCellColour(byte greenCell, byte redCell, int greenCellCount, int currentCellValue)
        {
            if (currentCellValue == greenCell)
            {
                if (greenCellCount != 2 && greenCellCount != 3 && greenCellCount != 6)
                {
                    currentCellValue = 0;
                }
            }
            else if (currentCellValue == redCell)
            {
                if (greenCellCount == 3 || greenCellCount == 6)
                {
                    currentCellValue = 1;
                }
            }

            return currentCellValue;
        }
        /// <summary>
        ///     CountingCellStateChange: Is a method that counts how many times a certain cell has changed its colour/state.
        ///     It takes seven parameters.
        /// </summary>
        /// <param name="y">Height of the matrix.</param>
        /// <param name="x">Width of the matrix.</param>
        /// <param name="greenCell">Constant indicating the value for green cells.</param>
        /// <param name="cellStateChangeCount">How many times has the cell we want changed to green.</param>
        /// <param name="row">Current row.</param>
        /// <param name="col">Current column.</param>
        /// <param name="currentCellValue">The value of the cell we are currently looking at.</param>
        /// <returns>The amount of state changes.</returns>
        public static int CountingCellStateChange(int y, int x, byte greenCell, int cellStateChangeCount, int row, int col, int currentCellValue)
        {
            if (row == x && col == y && currentCellValue == greenCell)
            {
                cellStateChangeCount++;
            }

            return cellStateChangeCount;
        }
    }
}
