using System;

namespace BizVal.Model
{
    public class Interval
    {
        /// <summary>
        /// Gets or sets the lower bound.
        /// </summary>
        /// <value>
        /// The lower bound.
        /// </value>
        public decimal LowerBound { get; set; }

        /// <summary>
        /// Gets or sets the upper bound.
        /// </summary>
        /// <value>
        /// The upper bound.
        /// </value>
        public decimal UpperBound { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        public Interval()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        /// <exception cref="System.ArgumentException">Lower bound is greater then upper bound</exception>
        public Interval(decimal lowerBound, decimal upperBound)
        {
            if (lowerBound > upperBound)
            {
                throw new ArgumentException("Lower bound is greater then upper bound");
            }

            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        protected bool Equals(Interval other)
        {
            return this.LowerBound.Equals(other.LowerBound) && this.UpperBound.Equals(other.UpperBound);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.LowerBound.GetHashCode() * 397) ^ this.UpperBound.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("LowerBound: {0}, UpperBound: {1}", this.LowerBound, this.UpperBound);
        }

        public static Interval operator +(Interval interval, decimal number)
        {
            return number + interval;
        }


        public static Interval operator +(decimal number, Interval interval)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = interval.LowerBound + number,
                    UpperBound = interval.UpperBound + number,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator +(Interval interval1, Interval interval2)
        {
            Interval result = null;
            if (interval1 != null && interval2 != null)
            {
                result = new Interval()
                {
                    LowerBound = interval1.LowerBound + interval2.LowerBound,
                    UpperBound = interval1.UpperBound + interval2.UpperBound,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator *(Interval interval, decimal number)
        {
            return number * interval;
        }


        public static Interval operator *(decimal number, Interval interval)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = interval.LowerBound * number,
                    UpperBound = interval.UpperBound * number,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator *(Interval interval1, Interval interval2)
        {
            Interval result = null;
            if (interval1 != null && interval2 != null)
            {
                result = new Interval()
                {
                    LowerBound = interval1.LowerBound * interval2.LowerBound,
                    UpperBound = interval1.UpperBound * interval2.UpperBound,
                };
                CheckReorderInterval(result);
            }
            return result;
        }



        public static Interval operator /(Interval interval, decimal number)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = interval.LowerBound / number,
                    UpperBound = interval.UpperBound / number,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator /(decimal number, Interval interval)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = number / interval.LowerBound,
                    UpperBound = number / interval.UpperBound,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator /(Interval interval1, Interval interval2)
        {
            Interval result = null;
            if (interval1 != null && interval2 != null)
            {
                result = new Interval()
                {
                    LowerBound = interval1.LowerBound / interval2.LowerBound,
                    UpperBound = interval1.UpperBound / interval2.UpperBound,
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        public static Interval operator ^(Interval interval, decimal number)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = (decimal)Math.Pow((double)interval.LowerBound, (double)number),
                    UpperBound = (decimal)Math.Pow((double)interval.UpperBound, (double)number),
                };
                CheckReorderInterval(result);
            }
            return result;
        }

        private static void CheckReorderInterval(Interval result)
        {
            if (result.LowerBound > result.UpperBound)
            {
                var lowerBound = result.LowerBound;
                result.LowerBound = result.UpperBound;
                result.UpperBound = lowerBound;
            }
        }


    }
}
