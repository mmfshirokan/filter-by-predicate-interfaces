using System;

namespace ArrayExtensions
{
    /// <summary>
    /// Class of the additional operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain expected digit from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="digit">Expected digit.</param>
        /// <returns>Array of elements that contain expected digit.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit value is out of range (0..9).</exception>
        /// <example>
        /// {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}  => { 7, 70, 17 } for digit = 7.
        /// </example>
        public static int[] FilterByDigit(this int[]? source, int digit)
        {
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), "digit value is out of range (0..9).");
            }

            if (source is null)
            {
                throw new ArgumentNullException(nameof(source), "array is null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty.");
            }

            var result = new List<int>();

            foreach (var item in source)
            {
                if (IsMatch(item, digit))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();

            static bool IsMatch(int value, int digit)
            {
                long val = value;

                if (val < 0)
                {
                    val = -val;
                }

                long rest = val % 10;
                do
                {
                    if (rest == digit)
                    {
                        return true;
                    }

                    val /= 10;
                    rest = val % 10;
                }
                while (val != 0);

                return false;
            }
        }

        /// <summary>
        /// Returns new array that contains only palindromic numbers from source array.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <returns>Array of elements that are palindromic numbers.</returns>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        /// <exception cref="ArgumentException">Throw when array is empty.</exception>
        /// <example>
        /// {12345, 1111111112, 987654, 56, 1111111, -1111, 1, 1233321, 70, 15, 123454321}  => { 1111111, 123321, 123454321 }
        /// {56, -1111111112, 987654, 56, 890, -1111, 543, 1233}  => {  }.
        /// </example>
        public static int[] FilterByPalindromic(this int[]? source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Array is null.");
            }

            if (source.Length == 0)
            {
                throw new ArgumentException("array is empty.");
            }

            List<int> result = new List<int>();

            foreach (var item in source)
            {
                if (IsMatch(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();

            static bool IsMatch(int value)
            {
                if (value < 0)
                {
                    return false;
                }

                (int digitnum, int zeronum) = GetNumberOfDigits(value);
                while (digitnum > 1)
                {
                    byte lustNum = (byte)(value % 10);
                    byte firstNum = (byte)(value / zeronum);
                    if (firstNum != lustNum)
                    {
                        return false;
                    }

                    value /= 10;
                    value = value % (zeronum / 10);
                    digitnum -= 2;
                    zeronum /= 100;
                }

                return true;

                static (int, int) GetNumberOfDigits(int a) => a switch
                {
                    < 10 => (1, 1),
                    < 100 => (2, 10),
                    < 1000 => (3, 100),
                    < 10000 => (4, 1000),
                    < 100000 => (5, 10000),
                    < 1000000 => (6, 100000),
                    < 10000000 => (7, 1000000),
                    < 100000000 => (8, 10000000),
                    < 1000000000 => (9, 100000000),
                    _ => (10, 1000000000),
                };
            }
        }
    }
}
