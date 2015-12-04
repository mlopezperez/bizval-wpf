using System;

namespace BizVal.Model
{
    public class Interval
    {
        public decimal LowerBound { get; set; }

        public decimal UpperBound { get; set; }

        public Interval()
        {
        }

        public Interval(decimal lowerBound, decimal upperBound)
        {
            if (lowerBound > upperBound)
            {
                throw new ArgumentException("Lower bound is greater then upper bound");
            }

            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        protected bool Equals(Interval other)
        {
            return this.LowerBound.Equals(other.LowerBound) && this.UpperBound.Equals(other.UpperBound);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.LowerBound.GetHashCode() * 397) ^ this.UpperBound.GetHashCode();
            }
        }

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
                    LowerBound = (decimal)Math.Pow((double) interval.LowerBound, (double) number),
                    UpperBound = (decimal)Math.Pow((double) interval.UpperBound, (double) number),
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
