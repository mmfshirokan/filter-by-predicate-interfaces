using System;
using System.Collections.Generic;

namespace FilterByPredicate
{
    /// <summary>
    /// Class of the additional operations with array.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Returns new array of elements that contain elements that correspond given predicate only.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="predicate">Predicate.</param>
        /// <returns>Array of elements that correspond given predicate only.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        /// <exception cref="ArgumentNullException">Thrown when predicate is null.</exception>
        public static int[] Select(this int[]? source, IPredicate? predicate)
        {
                if (source is null)
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
                    if (predicate.IsMatch(item))
                    {
                        result.Add(item);
                    }
                }

                return result.ToArray();
            }
    }
}
