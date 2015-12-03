using System;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests
{
    [TestFixture]
    public class IntervalTests
    {
        [Test]
        public void CreateIntervalWithBadBoundaries()
        {
            Assert.Throws<ArgumentException>(() => new Interval(10f, 2f));
        }

        [Test]
        public void SumIntegerAndNullIntervalTest()
        {
            var result = 0 + (Interval)null;
            Assert.Null(result);
        }

        [Test]
        public void SumFloatAndNullIntervalTest()
        {
            var result = 0f + (Interval)null;
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
            var result = 0 + new Interval(1f, 1f);
            Assert.NotNull(result);
            Assert.AreEqual(1f, result.LowerBound);
            Assert.AreEqual(1f, result.UpperBound);
        }

        [Test]
        public void SumNonZeroIntegerAndIntervalTest()
        {
            var result = 5 + new Interval(1f, 1f);
            Assert.NotNull(result);
            Assert.AreEqual(6f, result.LowerBound);
            Assert.AreEqual(6f, result.UpperBound);
        }

        [Test]
        public void SumFloatAndEmptyIntervalTest()
        {
            var result = 0f + new Interval();
            Assert.NotNull(result);
            Assert.AreEqual(0f, result.LowerBound);
            Assert.AreEqual(0f, result.UpperBound);
        }

        [Test]
        public void SumZeroFloatAndIntervalTest()
        {
            var result = 0f + new Interval(1f, 1f);
            Assert.NotNull(result);
            Assert.AreEqual(1f, result.LowerBound);
            Assert.AreEqual(1f, result.UpperBound);
        }

        [Test]
        public void SumNonZeroFloatAndIntervalTest()
        {
            var result = 2.45f + new Interval(1f, 1f);
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
        public void ProductFloatAndNullIntervalTest()
        {
            var result = 0f * (Interval)null;
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
            var result = 1 * new Interval(3f, 3f);
            Assert.NotNull(result);
            Assert.AreEqual(3f, result.LowerBound);
            Assert.AreEqual(3f, result.UpperBound);
        }

        [Test]
        public void ProductNonZeroIntegerAndIntervalTest()
        {
            var result = 2 * new Interval(0.2f, 0.2f);
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
            Interval i1 = new Interval(1f, 2.2f);
            Interval i2 = new Interval(0f, 2.1f);
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
            Assert.IsNull(i1/i2);
        }

        [Test]
        public void DivideIntervals()
        {
            Interval i1 = new Interval(2.2f, 5.5f);
            Interval i2 = new Interval(2f, 10f);
            var result = i1/i2;
            Assert.NotNull(result);
            Assert.AreEqual(1.1f, result.LowerBound);
            Assert.AreEqual(.55f, result.UpperBound);
        }
    }
}
