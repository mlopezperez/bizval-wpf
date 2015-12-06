using System;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests.Model
{
    [TestFixture]
    public class LabelSetTests
    {
        [Test]
        public void DeltaThrowsIfBetaLowerThanZero()
        {
            var set = this.GetTermSet();
            Assert.Throws<ArgumentException>(() => set.Delta(-1));
        }

        [Test]
        public void DeltaThrowsIfBetaGreaterThenG()
        {
            var set = this.GetTermSet();
            Assert.Throws<ArgumentException>(() => set.Delta(set.G + 1));
        }

        [Test]
        public void DeltaReturnsProper()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(1, result.Label.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperLowerLimit()
        {
            var set = this.GetTermSet();
            var result = set.Delta(0);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(0, result.Label.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperUpperLimit()
        {
            var set = this.GetTermSet();
            var result = set.Delta(2);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(2, result.Label.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.7m);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(2, result.Label.Index);

            Assert.AreEqual(-0.3f, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset2()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.5m);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(2, result.Label.Index);

            Assert.AreEqual(-0.5f, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset3()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.499m);

            Assert.NotNull(result);
            Assert.NotNull(result.Label);
            Assert.AreEqual(1, result.Label.Index);

            Assert.AreEqual(0.499f, result.Alpha);
        }

        [Test]
        public void DeltaInvGetsNumericValue()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple(set[1], -0.5m));

            Assert.AreEqual(0.5m, result);
        }

        [Test]
        public void DeltaInvGetsNumericValueLowerLimit()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple(set[0], 0m));

            Assert.AreEqual(0, result);
        }

        [Test]
        public void DeltaInvGetsNumericValueUpperLimit()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple(set[2], 0m));
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DeltaInvThrowsIfInvalidLowerTuple()
        {
            var set = this.GetTermSet();

            Assert.Throws<ArgumentException>(() =>
                set.DeltaInv(new TwoTuple(new Label(-1, "Invalid"), 0m)));
        }

        [Test]
        public void DeltaInvThrowsIfInvalidUpperTuple()
        {
            var set = this.GetTermSet();

            Assert.Throws<ArgumentException>(() =>
               set.DeltaInv(new TwoTuple(new Label(3, "Invalid"), 0m)));
        }


        private LabelSet GetTermSet()
        {
            var termSet = new LabelSet();
            termSet.Add(new Label(0, "Poco"));
            termSet.Add(new Label(1, "Medio"));
            termSet.Add(new Label(2, "Mucho"));

            return termSet;
        }
    }
}
