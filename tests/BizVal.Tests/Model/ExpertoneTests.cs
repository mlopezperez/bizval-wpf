using System;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests.Model
{
    [TestFixture]
    public class ExpertoneTests
    {
        [Test]
        public void ConstructorThrowsIfNullExpertise()
        {
            Assert.Throws<ArgumentNullException>(() => new Expertone<string>(null));
        }

        [Test]
        public void ConstructorGeneratesExpertone()
        {
            var expertone = new Expertone<string>(this.GetTestExpertise());
            var lowerItemslist = expertone.LowerValues;

            Assert.NotNull(lowerItemslist);
            Assert.AreEqual(11, lowerItemslist.Count);
            Assert.AreEqual(0.9m, lowerItemslist[0]);
            Assert.AreEqual(0.9m, lowerItemslist[1]);
            Assert.AreEqual(0.9m, lowerItemslist[2]);
            Assert.AreEqual(0.9m, lowerItemslist[3]);
            Assert.AreEqual(0.9m, lowerItemslist[4]);
            Assert.AreEqual(0.7m, lowerItemslist[5]);
            Assert.AreEqual(0.6m, lowerItemslist[6]);
            Assert.AreEqual(0.3m, lowerItemslist[7]);
            Assert.AreEqual(0.3m, lowerItemslist[8]);
            Assert.AreEqual(0.3m, lowerItemslist[9]);
            Assert.AreEqual(0m, lowerItemslist[10]);

            var upperItemslist = expertone.UpperValues;

            Assert.NotNull(upperItemslist);
            Assert.AreEqual(11, upperItemslist.Count);
            Assert.AreEqual(1, upperItemslist[0]);
            Assert.AreEqual(0.9m, upperItemslist[1]);
            Assert.AreEqual(0.9m, upperItemslist[2]);
            Assert.AreEqual(0.9m, upperItemslist[3]);
            Assert.AreEqual(0.9m, upperItemslist[4]);
            Assert.AreEqual(0.8m, upperItemslist[5]);
            Assert.AreEqual(0.8m, upperItemslist[6]);
            Assert.AreEqual(0.7m, upperItemslist[7]);
            Assert.AreEqual(0.6m, upperItemslist[8]);
            Assert.AreEqual(0.5m, upperItemslist[9]);
            Assert.AreEqual(0m, upperItemslist[10]);
        }

        [Test]
        [Ignore("Check results and methodology")]
        public void GetExpectedValueRetursProperInterval()
        {
            var expertone = new Expertone<string>(this.GetTestExpertise());
            var expectedValue = expertone.GetExpectedValue();

            Assert.NotNull(expectedValue);
            Assert.AreEqual(0.04610m, expectedValue.LowerBound);
            Assert.AreEqual(0.04720m, expectedValue.UpperBound);
        }

        private Expertise<string> GetTestExpertise()
        {
            var expertise = new Expertise<string>(new Interval(0.04m, 0.05m));
            expertise.Cardinalities.Add("k", new Cardinality(3, 5));
            expertise.Cardinalities.Add("j", new Cardinality(0, 1));
            expertise.Cardinalities.Add("i", new Cardinality(0, 1));
            expertise.Cardinalities.Add("h", new Cardinality(3, 1));
            expertise.Cardinalities.Add("g", new Cardinality(1, 0));
            expertise.Cardinalities.Add("f", new Cardinality(2, 1));
            expertise.Cardinalities.Add("e", new Cardinality(0, 0));
            expertise.Cardinalities.Add("d", new Cardinality(0, 0));
            expertise.Cardinalities.Add("c", new Cardinality(0, 0));
            expertise.Cardinalities.Add("b", new Cardinality(0, 1));
            expertise.Cardinalities.Add("a", new Cardinality(1, 0));

            return expertise;
        }
    }
}
