using System;
using System.Linq;

namespace Green_vs_Red
{
    /// <summary>
    ///     ConvertValues: A class with two methods that are converting input from the console to an integer data type.
    /// </summary>
    class ConvertValues
    {
        /// <summary>
        ///     ParseValues: Is a method which takes no parameters, parses and converts input from the console to integer data type.
        /// </summary>
        /// <returns>Input as integer</returns>
        public static int[] ParseValues()
        {
            return Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
        }

        /// <summary>
        ///     ConvertRowToInt: Is a method which takes one string parameter and converts it to an array of integers.
        /// </summary>
        /// <param name="tempCurrentRow">Just a mediator for the conversion process.</param>
        /// <returns>An array of integers</returns>
        public static int[] ConvertRowToInt(string tempCurrentRow)
        {
            return tempCurrentRow.Select(n => n - '0').ToArray();
        }
    }
}
