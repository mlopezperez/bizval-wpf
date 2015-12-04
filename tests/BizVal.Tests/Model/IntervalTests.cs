using System;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests.Model
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        public void CreateIntervalWithBadBoundaries()
        {
            Assert.Throws<ArgumentException>(() => new Interval(10m, 2m));
        }

        [Test]
        public void SumIntegerAndNullIntervalTest()
        {
            var result = 0 + (Interval)null;
            Assert.Null(result);
        }

        [Test]
        public void SumdecimalAndNullIntervalTest()
        {
            var result = 0m + (Interval)null;
            Assert.Null(result);
        }

        [Test]
        public void SumIntegerAndEmptyIntervalTest()
        {
            var result = 0 + new Interval();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.LowerBound);
            Assert.AreEqual(0, result.UpperBound);
        }

        [Test]
        public void SumZeroIntegerAndIntervalTest()
        {
            var result = 0 + new Interval(1m, 1m);
            Assert.NotNull(result);
            Assert.AreEqual(1f, result.LowerBound);
            Assert.AreEqual(1f, result.UpperBound);
        }

        [Test]
        public void SumNonZeroIntegerAndIntervalTest()
        {
            var result = 5 + new Interval(1m, 1m);
            Assert.NotNull(result);
            Assert.AreEqual(6f, result.LowerBound);
            Assert.AreEqual(6f, result.UpperBound);
        }

        [Test]
        public void SumdecimalAndEmptyIntervalTest()
        {
            var result = 0m + new Interval();
            Assert.NotNull(result);
            Assert.AreEqual(0f, result.LowerBound);
            Assert.AreEqual(0f, result.UpperBound);
        }

        [Test]
        public void SumZerodecimalAndIntervalTest()
        {
            var result = 0m + new Interval(1m, 1m);
            Assert.NotNull(result);
            Assert.AreEqual(1f, result.LowerBound);
            Assert.AreEqual(1f, result.UpperBound);
        }

        [Test]
        public void SumNonZerodecimalAndIntervalTest()
        {
            var result = 2.45m + new Interval(1m, 1m);
            Assert.NotNull(result);
            Assert.AreEqual(3.45f, result.LowerBound);
            Assert.AreEqual(3.45f, result.UpperBound);
        }

        [Test]
        public void ProductIntegerAndNullIntervalTest()
        {
            var result = 0 * (Interval)null;
            Assert.Null(result);
        }

        [Test]
        public void ProductdecimalAndNullIntervalTest()
        {
            var result = 0 * (Interval)null;
            Assert.Null(result);
        }

        [Test]
        public void ProductIntegerAndEmptyIntervalTest()
        {
            var result = 1 * new Interval();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.LowerBound);
            Assert.AreEqual(0, result.UpperBound);
        }

        [Test]
        public void ProductZeroIntegerAndIntervalTest()
        {
            var result = 1 * new Interval(3, 3);
            Assert.NotNull(result);
            Assert.AreEqual(3f, result.LowerBound);
            Assert.AreEqual(3f, result.UpperBound);
        }

        [Test]
        public void ProductNonZeroIntegerAndIntervalTest()
        {
            var result = 2 * new Interval(0.2m, 0.2m);
            Assert.NotNull(result);
            Assert.AreEqual(0.4f, result.LowerBound);
            Assert.AreEqual(0.4f, result.UpperBound);
        }

        [Test]
        public void SumTwoNullIntervals()
        {
            Interval i1 = null;
            Interval i2 = null;
            var result = i1 + i2;
            Assert.IsNull(result);
        }

        [Test]
        public void SumNullInterval()
        {
            Interval i1 = null;
            Interval i2 = new Interval();
            var result = i1 + i2;
            Assert.IsNull(result);
        }

        [Test]
        public void SumTwoIntervals()
        {
            Interval i1 = new Interval(1, 2.2m);
            Interval i2 = new Interval(0, 2.1m);
            var result = i1 + i2;
            Assert.NotNull(result);
            Assert.AreEqual(1f, result.LowerBound);
            Assert.AreEqual(4.3f, result.UpperBound);
        }

        [Test]
        public void DivideNullInterval()
        {
            Interval i1 = null;
            Interval i2 = null;
            Assert.IsNull(i1 / i2);
        }

        [Test]
        public void DivideNullInterval1()
        {
            Interval i1 = null;
            Interval i2 = new Interval();
            Assert.IsNull(i1 / i2);
        }

        [Test]
        public void DivideNullInterval2()
        {
            Interval i1 = new Interval();
            Interval i2 = null;
            Assert.IsNull(i1 / i2);
        }

        [Test]
        public void DivideIntervals()
        {
            Interval i1 = new Interval(2.2m, 5.5m);
            Interval i2 = new Interval(2, 10);
            var result = i1 / i2;
            Assert.NotNull(result);
            Assert.AreEqual(1.1f, result.UpperBound);
            Assert.AreEqual(.55f, result.LowerBound);
        }
    }
}
