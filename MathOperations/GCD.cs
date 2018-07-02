using System;
using System.Diagnostics;

namespace MathOperations
{
    /// <summary>
    /// Algorithms of finding the greatest common divisor
    /// </summary>
    public static class GCD
    {
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
        public static int FindGCD(int a, int b)
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
        /// Finds GCD of 3 and more numbers by Euclidian's algorithm 
        /// </summary>
        /// <param name="array">
        /// Numbers 
        /// </param>
        /// <returns>
        /// GCD of 3 and more numbers
        /// </returns>
        public static int FindGCD(params int[] array)
        {
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = FindGCD(gcd, array[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Finds GCD of 3 and more numbers by Euclidian's algorithm 
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
        public static int FindGCD(out string time, params int[] array)
        {
            Stopwatch stw = new Stopwatch();
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = FindGCD(gcd, array[i]);
            }

            stw.Stop();
            time = stw.ElapsedMilliseconds.ToString();
            return gcd;
        }

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
        /// Finds GCD of 3 and more numbers by Stein's algorithm
        /// </summary>
        /// <param name="array">
        /// Numbers 
        /// </param>
        /// <returns>
        /// GCD of 3 and more numbers
        /// </returns>
        public static int FindGCDBinary(params int[] array)
        {
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = FindGCDBinary(gcd, array[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Finds GCD of 3 and more numbers by Stein's algorithm 
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
        public static int FindGCDBinary(out string time, params int[] array)
        {
            Stopwatch stw = new Stopwatch();
            int gcd = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                gcd = FindGCDBinary(gcd, array[i]);
            }
            
            stw.Stop();
            time = stw.ElapsedMilliseconds.ToString();
            return gcd;
        }
    }
}
