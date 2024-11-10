using System;
using System.Collections.Generic;

namespace Assignment3
{
    /// <summary>
    /// Provides statistical functions such as sum, average, median, and standard deviation for a list of numerical values.
    /// </summary>
    public class StatisticalFunctions
    {
        /// <summary>
        /// Calculates the sum of the given list of numbers.
        /// </summary>
        /// <param name="values">The list of values to sum.</param>
        /// <param name="includeNegative">Indicates whether negative values should be included in the sum.</param>
        /// <returns>The sum of the values in the list.</returns>
        /// <exception cref="ArgumentException">Thrown if the list is empty.</exception>
        public static double Sum(List<double> values, bool includeNegative)
        {
            if (values == null || values.Count == 0)
            {
                throw new ArgumentException("The list cannot be empty.");
            }

            double sum = 0.0;
            foreach (double value in values)
            {
                if (includeNegative || value >= 0)
                {
                    sum += value;
                }
            }

            return sum;
        }

        /// <summary>
        /// Calculates the average of the values in the list.
        /// </summary>
        /// <param name="values">The list of values to calculate the average of.</param>
        /// <param name="includeNegative">Indicates whether to include negative values in the calculation.</param>
        /// <returns>The average value of the list.</returns>
        /// <exception cref="ArgumentException">Thrown if no valid values (>= 0) are found.</exception>
        public static double Average(List<double> values, bool includeNegative)
        {
            double sum = Sum(values, includeNegative);
            int validCount = 0;

            foreach (double value in values)
            {
                if (includeNegative || value >= 0)
                {
                    validCount++;
                }
            }

            if (validCount == 0)
            {
                throw new ArgumentException("No valid values greater than or equal to zero were found.");
            }

            return sum / validCount;
        }

        /// <summary>
        /// Calculates the median value of the given list of numbers.
        /// </summary>
        /// <param name="values">The list of values to calculate the median of.</param>
        /// <returns>The median value of the list.</returns>
        /// <exception cref="ArgumentException">Thrown if the list is empty.</exception>
        public static double Median(List<double> values)
        {
            if (values == null || values.Count == 0)
            {
                throw new ArgumentException("The list cannot be empty.");
            }

            values.Sort();
            int count = values.Count;

            if (count % 2 == 0)
            {
                // Even number of elements, average the middle two values.
                return (values[count / 2] + values[count / 2 - 1]) / 2;
            }
            else
            {
                // Odd number of elements, return the middle element.
                return values[count / 2];
            }
        }

        /// <summary>
        /// Calculates the sample standard deviation of the values in the list.
        /// </summary>
        /// <param name="values">The list of values to calculate the standard deviation of.</param>
        /// <returns>The sample standard deviation of the list.</returns>
        /// <exception cref="ArgumentException">Thrown if the list has fewer than two elements.</exception>
        public static double StandardDeviation(List<double> values)
        {
            if (values == null || values.Count <= 1)
            {
                throw new ArgumentException("The list must contain at least two values.");
            }

            double mean = Average(values, true);
            double sumOfSquares = 0.0;

            foreach (double value in values)
            {
                sumOfSquares += Math.Pow(value - mean, 2);
            }

            return Math.Sqrt(sumOfSquares / (values.Count - 1));
        }

        /// <summary>
        /// Main method to execute the statistical functions.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Sample Output for Statistical Functions Library");

            // Sample data for testing
            List<double> testData = new List<double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            // Display results for various statistical functions
            Console.WriteLine("The sum of the array = {0}", StatisticalFunctions.Sum(testData, true));
            Console.WriteLine("The average of the array = {0}", StatisticalFunctions.Average(testData, true));
            Console.WriteLine("The median value of the data set = {0}", StatisticalFunctions.Median(testData));
            Console.WriteLine("The sample standard deviation of the data set = {0}", StatisticalFunctions.StandardDeviation(testData));

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
