using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests
{
    [TestFixture]
    public class TermSetTests
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
            Assert.NotNull(result.Term);
            Assert.AreEqual(1, result.Term.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperLowerLimit()
        {
            var set = this.GetTermSet();
            var result = set.Delta(0);

            Assert.NotNull(result);
            Assert.NotNull(result.Term);
            Assert.AreEqual(0, result.Term.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperUpperLimit()
        {
            var set = this.GetTermSet();
            var result = set.Delta(2);

            Assert.NotNull(result);
            Assert.NotNull(result.Term);
            Assert.AreEqual(2, result.Term.Index);

            Assert.AreEqual(0, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.7m);

            Assert.NotNull(result);
            Assert.NotNull(result.Term);
            Assert.AreEqual(2, result.Term.Index);

            Assert.AreEqual(-0.3f, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset2()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.5m);

            Assert.NotNull(result);
            Assert.NotNull(result.Term);
            Assert.AreEqual(2, result.Term.Index);

            Assert.AreEqual(-0.5f, result.Alpha);
        }

        [Test]
        public void DeltaReturnsProperWithOffset3()
        {
            var set = this.GetTermSet();
            var result = set.Delta(1.499m);

            Assert.NotNull(result);
            Assert.NotNull(result.Term);
            Assert.AreEqual(1, result.Term.Index);

            Assert.AreEqual(0.499f, result.Alpha);
        }

        [Test]
        public void DeltaInvGetsNumericValue()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple()
            {
                Alpha = -0.5m,
                Term = new Term(1, "Medio")
            });

            Assert.AreEqual(0.5m, result);
        }

        [Test]
        public void DeltaInvGetsNumericValueLowerLimit()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple()
            {
                Alpha = 0m,
                Term = new Term(0, "Poco")
            });

            Assert.AreEqual(0, result);
        }

        [Test]
        public void DeltaInvGetsNumericValueUpperLimit()
        {
            var set = this.GetTermSet();
            var result = set.DeltaInv(new TwoTuple()
            {
                Alpha = 0m,
                Term = new Term(2, "Mucho")
            });

            Assert.AreEqual(2, result);
        }

        [Test]
        public void DeltaInvThrowsIfInvalidLowerTuple()
        {
            var set = this.GetTermSet();

            Assert.Throws<ArgumentException>(() =>
                set.DeltaInv(new TwoTuple()
                {
                    Alpha = 0m,
                    Term = new Term(-1, "Invalid")
                }));
        }

        [Test]
        public void DeltaInvThrowsIfInvalidUpperTuple()
        {
            var set = this.GetTermSet();

            Assert.Throws<ArgumentException>(() =>
                set.DeltaInv(new TwoTuple()
                {
                    Alpha = 0m,
                    Term = new Term(3, "Invalid")
                }));
        }


        private TermSet GetTermSet()
        {
            var termSet = new TermSet();
            termSet.Add(new Term(0, "Poco"));
            termSet.Add(new Term(1, "Medio"));
            termSet.Add(new Term(2, "Mucho"));

            return termSet;
        }
    }
}
