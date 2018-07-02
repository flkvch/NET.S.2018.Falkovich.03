using System;
using System.Diagnostics;
using SortingAlgorithms;

namespace MathOperations
{
    public static class Operations
    {
        #region API

        /// <summary>
        /// Finds root of n-th power of the number with the accuracy
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="n">
        /// The power
        /// </param>
        /// <param name="accuracy">
        /// The accuracy
        /// </param>
        /// <returns>
        /// The root
        /// </returns>
        public static double FindNthRoot(double number, int n, double accuracy)
        {
            Validation(number, n, accuracy);
            if (n == 1)
            {
                return number;
            }

            double current = 0.1, next = 1.0 / n * ((n - 1) * current + number / Math.Pow(current, n - 1));
            while (Math.Abs(next - current) > accuracy)
            {
                current = next;
                next = 1.0 / n * ((n - 1) * current + number / Math.Pow(current, n - 1));
            }

            return Round(next, accuracy);
        }

        /// <summary>
        /// Finds the next bigger number of <paramref name="number"/>
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <returns>
        /// The next bigger number of <paramref name="number"/>
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 10)
            {
                throw new ArgumentException("Argument shouldn't be a single-digit");
            }
            
            if (number < 0)
            {
                throw new ArgumentException("Argument should be positive");
            }

            int[] digits = ExtractDigits(number);
            Reverse(digits);
            int position = FindPosition(digits);
            Swap(ref digits[position], ref digits[position - 1]);            
            Algorithms.QuickSort(digits, position, digits.Length - 1);
            if (ArrayToInt(digits) <= number)
            {
                return -1;
            }

            return ArrayToInt(digits);
        }

        /// <summary>
        /// Finds the next bigger number of <paramref name="number"/>
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="time">
        /// Time for counting
        /// </param>
        /// <returns>
        /// The next bigger number of <paramref name="number"/>
        /// </returns>
        public static int FindNextBiggerNumber(int number, out string time)
        {
            Stopwatch stw = new Stopwatch();
            int a = FindNextBiggerNumber(number);
            stw.Stop();
            time = stw.ElapsedMilliseconds.ToString();
            return a;
        }
       
        #endregion

        #region private for FindNthRoot

        /// <summary>
        /// Rounds double variable with the accuracy
        /// </summary>
        /// <param name="number">
        /// variable
        /// </param>
        /// <param name="accuracy">
        /// accuracy
        /// </param>
        /// <returns>
        /// Rounded variable
        /// </returns>
        private static double Round(double number, double accuracy)
        {
            int count = -1;
            while (accuracy < 10)
            {
                int digit = (int)accuracy;
                count++;
                accuracy *= 10;
            }

            return Math.Round(number, count);
        }


        /// <summary>
        /// Checks parametres to be valid
        /// </summary>
        /// <param name="number">
        /// The number
        /// </param>
        /// <param name="n">
        /// The power
        /// </param>
        /// <param name="accuracy">
        /// The accuracy
        /// </param>
        private static void Validation(double number, int n, double accuracy)
        {
            if (n % 2 == 0 && number < 0)
            {
                throw new ArgumentException(nameof(number));
            }

            if (n < 2)
            {
                throw new ArgumentException(nameof(n));
            }

            if (accuracy > 1 || accuracy < 0)
            {
                throw new ArgumentException(nameof(accuracy));
            }

        }
        #endregion

        #region private for FindNextBiggerNumber

        /// <summary>
        /// Reverse the array
        /// </summary>
        /// <param name="array">
        /// Array for reversing
        /// </param>
        private static void Reverse(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                Swap(ref array[i], ref array[array.Length - i - 1]);
            }
        }

        /// <summary>
        /// Converts array of numbers to integer
        /// </summary>
        /// <param name="array">
        /// The array to convert
        /// </param>
        /// <returns>
        /// Integer form of the array
        /// </returns>
        private static int ArrayToInt(int[] array)
        {
            int number = 0;
            foreach (int i in array)
            {
                number += i;
                number *= 10;
            }

            return number /= 10;
        }

        /// <summary>
        /// Finds the position of start for sorting
        /// </summary>
        /// <param name="array">
        /// The array 
        /// </param>
        /// <returns>
        /// The start position of sorting
        /// </returns>
        private static int FindPosition(int[] array)
        {
            int position = array.Length - 1;
            for (int i = position; i > 0; i--) 
            {
                if (array[i] > array[i - 1])
                {
                    position = i;
                    break;
                }

            }

            return position;
        }

        /// <summary>
        /// Extract digits from the number to array
        /// </summary>
        /// <param name="number">
        /// Number for Extraction
        /// </param>
        /// <returns>
        /// The array of digits
        /// </returns>
        private static int[] ExtractDigits(int number)
        {
            int[] digits = new int[] { };
            if (number < 0)
            {
                number *= -1;
            }
            while (number > 0)
            {
                Array.Resize(ref digits, digits.Length + 1);
                digits[digits.Length - 1] = number % 10;
                number /= 10;
            }

            return digits;
        }

        /// <summary>
        /// Swap two elements of the array
        /// </summary>
        /// <param name="el1">
        /// The first element 
        /// </param>
        /// <param name="el2">
        /// The second element 
        /// </param>
        private static void Swap(ref int el1, ref int el2)
        {
            int temp = el1;
            el1 = el2;
            el2 = temp;
        }
        #endregion
    }
}