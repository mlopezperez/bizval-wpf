using System;

namespace BizVal.Model
{
    public class Interval
    {
        public float LowerBound { get; set; }

        public float UpperBound { get; set; }

        public Interval()
        {
        }

        public Interval(float lowerBound, float upperBound)
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

        public static Interval operator +(Interval interval, float number)
        {
            return number + interval;
        }


        public static Interval operator +(float number, Interval interval)
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

        public static Interval operator *(Interval interval, float number)
        {
            return number * interval;
        }


        public static Interval operator *(float number, Interval interval)
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



        public static Interval operator /(Interval interval, float number)
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

        public static Interval operator /(float number, Interval interval)
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

        public static Interval operator ^(Interval interval, float number)
        {
            Interval result = null;
            if (interval != null)
            {
                result = new Interval()
                {
                    LowerBound = (float)Math.Pow(interval.LowerBound, number),
                    UpperBound = (float)Math.Pow(interval.UpperBound, number),
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
