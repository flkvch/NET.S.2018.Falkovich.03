using System;
using System.Diagnostics;

namespace MathOperations
{
    /// <summary>
    /// Algorithms of finding the greatest common divisor
    /// </summary>
    public static class GCD
    {
        #region Euclidian's method
        /// <summary>
        /// Finds GCD of 2 numbers <paramref name="a"/> and <paramref name="b"/> by Euclidian's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>
        /// </returns>
        public static int FindGCDEuclidian(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Finds GCD of 3 numbers <paramref name="a"/> and <paramref name="b"/> by Euclidian's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/>, <paramref name="b"/>  and <paramref name="c"/>
        /// </returns>
        public static int FindGCDEuclidian(int a, int b, int c)
        {
            return FindGCD(FindGCDEuclidian, a, b, c);
        }

        /// <summary>
        /// Finds GCD of 4 and more numbers by Euclidian's algorithm 
        /// </summary>
        /// <param name="array">
        /// Numbers 
        /// </param>
        /// <returns>
        /// GCD of 3 and more numbers
        /// </returns>
        public static int FindGCDEuclidian(params int[] array)
        {
            return FindGCD(FindGCDEuclidian, array);
        }
        #endregion

        #region Euclidian's method + time
        /// <summary>
        /// Finds GCD of 2 numbers <paramref name="a"/> and <paramref name="b"/> by Euclidian's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="time">
        /// Returns elapsed time for the algorithm 
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>
        /// </returns>
        public static int FindGCDEuclidian(int a, int b, out long time)
        {
            return FindGCD(FindGCDEuclidian, out time, a, b);
        }

        /// <summary>
        /// Finds GCD of 3 numbers <paramref name="a"/> and <paramref name="b"/> by Euclidian's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <param name="time">
        /// Returns elapsed time for the algorithm 
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/>, <paramref name="b"/>  and <paramref name="c"/>
        /// </returns>
        public static int FindGCDEuclidian(int a, int b, int c, out long time)
        {
            return FindGCD(FindGCDEuclidian, out time, a, b, c);
        }

        /// <summary>
        /// Finds GCD of 4 and more numbers by Euclidian's algorithm 
        /// </summary>
        /// <param name="time">
        /// Returns elapsed time for the algorithm 
        /// </param>
        /// <param name="array">
        /// Numbers
        /// </param>
        /// <returns>
        /// The greatest common divisor
        /// </returns>
        public static int FindGCDEuclidian(out long time, params int[] array)
        {
            return FindGCD(FindGCDEuclidian, out time, array);
        }
        #endregion

        #region Stein's method
        /// <summary>
        /// Finds GCD of 2 numbers <paramref name="a"/> and <paramref name="b"/> by Stein's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>
        /// </returns>
        public static int FindGCDBinary(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            if ((~a & 1) != 0)
            {
                if ((b & 1) != 0)
                {
                    return FindGCDBinary(a >> 1, b);
                }
                else
                {
                    return FindGCDBinary(a >> 1, b >> 1) << 1;
                }
            }

            if ((~b & 1) != 0)
            {
                return FindGCDBinary(a, b >> 1);
            }

            if (a > b)
            {
                return FindGCDBinary((a - b) >> 1, b);
            }

            return FindGCDBinary((b - a) >> 1, a);
        }

        /// <summary>
        /// Finds GCD of 3 numbers <paramref name="a"/> and <paramref name="b"/> by Stein's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/>, <paramref name="b"/>  and <paramref name="c"/>
        /// </returns>
        public static int FindGCDBinary(int a, int b, int c)
        {
            return FindGCD(FindGCDBinary, a, b, c);
        }

        /// <summary>
        /// Finds GCD of 4 and more numbers by Stein's algorithm
        /// </summary>
        /// <param name="array">
        /// Numbers 
        /// </param>
        /// <returns>
        /// GCD of 3 and more numbers
        /// </returns>
        public static int FindGCDBinary(params int[] array)
        {
            return FindGCD(FindGCDBinary, array);
        }
        #endregion

        #region Stein's method + time
        /// <summary>
        /// Finds GCD of 2 numbers <paramref name="a"/> and <paramref name="b"/> by Stein's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="time">
        /// Returns elapsed time for the algorithm 
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>
        /// </returns>
        public static int FindGCDBinary(int a, int b, out long time)
        {
            return FindGCD(FindGCDEuclidian, out time, a, b);
        }

        /// <summary>
        /// Finds GCD of 3 numbers <paramref name="a"/> and <paramref name="b"/> by Stein's algorithm 
        /// </summary>
        /// <param name="a">
        /// The first number
        /// </param>
        /// <param name="b">
        /// The second number
        /// </param>
        /// <param name="c">
        /// The third number
        /// </param>
        /// <param name="time">
        /// Returns elapsed time for the algorithm 
        /// </param>
        /// <returns>
        /// The greatest common divisor of <paramref name="a"/>, <paramref name="b"/>  and <paramref name="c"/>
        /// </returns>
        public static int FindGCDBinary(int a, int b, int c, out long time)
        {
            return FindGCD(FindGCDEuclidian, out time, a, b, c);
        }

        /// <summary>
        /// Finds GCD of 4 and more numbers by Stein's algorithm 
        /// </summary>
        /// <param name="time">
        /// Out parameter, returns elapsed time for the algorithm 
        /// </param>
        /// <param name="array">
        /// Numbers
        /// </param>
        /// <returns>
        /// GCD of 3 and more numbers
        /// </returns>
        public static int FindGCDBinary(out long time, params int[] array)
        {
            return FindGCD(FindGCDBinary, out time, array);
        }
        #endregion

        #region Private methods
        private static int FindGCD(Func<int, int, int> function, int a, int b, int c)
        {
            return function(function(a, b), c);
        }

        private static int FindGCD(Func<int, int, int> function, params int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1 || array.Length == 0)
            {
                throw new ArgumentException(nameof(array), "CGD counts only for 2 and more numbers");
            }

            int result = array[0];
            foreach (int number in array)
            {
                result = function(result, number);
            }

            return result;
        }

        private static int FindGCD(Func<int, int, int> function, out long time, int a, int b, int c)
        {
            Stopwatch stw = Stopwatch.StartNew();
            int gcd = FindGCD(function, a, b, c);
            time = stw.ElapsedTicks;
            stw.Stop();
            return gcd;
        }

        private static int FindGCD(Func<int, int, int> function, out long time, params int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1 || array.Length == 0)
            {
                throw new ArgumentException(nameof(array), "CGD counts only for 2 and more numbers");
            }

            Stopwatch stw = Stopwatch.StartNew();
            int gcd = FindGCD(function, array);
            time = stw.ElapsedTicks;
            stw.Stop();
            return gcd;
        }
        #endregion
    }
}
