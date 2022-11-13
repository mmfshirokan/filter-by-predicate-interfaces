using System;
using FilterByPredicate;

namespace FilterByPalindromic
{
    /// <summary>
    /// Palindrome predicate.
    /// </summary>
    public class ByPalindromicPredicate : IPredicate
    {
        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            {
                if (number < 0)
                {
                    return false;
                }

                (int digitnum, int zeronum) = GetNumberOfDigits(number);
                while (digitnum > 1)
                {
                    byte lustNum = (byte)(number % 10);
                    byte firstNum = (byte)(number / zeronum);
                    if (firstNum != lustNum)
                    {
                        return false;
                    }

                    number /= 10;
                    number = number % (zeronum / 10);
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
