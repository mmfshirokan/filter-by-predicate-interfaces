using System;
using FilterByPredicate;

namespace FilterByDigit
{
    /// <summary>
    /// Predicate that determines the presence of some digit in integer.
    /// </summary>
    public class ByDigitPredicate : IPredicate
    {
        private int digit;

        /// <summary>
        /// Gets or sets a digit.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when Digit more than 9 or less than 0.</exception>
        public int Digit
        {
            get
            {
                return this.digit;
            }

            set
            {
                if (value > 9 || value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.digit = value;
            }
        }

        /// <inheritdoc/>
        public bool IsMatch(int number)
        {
            long val = number;

            if (val < 0)
            {
                val = -val;
            }

            long rest = val % 10;
            do
            {
                if (rest == this.Digit)
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
}
