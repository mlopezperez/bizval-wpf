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
            var lowerItemslist = expertone.LowerItems;

            Assert.NotNull(lowerItemslist);
            Assert.AreEqual(5, lowerItemslist.Count);
            Assert.AreEqual(0.5m, lowerItemslist[0]);
            Assert.AreEqual(0.5m, lowerItemslist[1]);
            Assert.AreEqual(0.2m, lowerItemslist[2]);
            Assert.AreEqual(0.2m, lowerItemslist[3]);
            Assert.AreEqual(0m, lowerItemslist[4]);

            var upperItemslist = expertone.UpperItems;

            Assert.NotNull(upperItemslist);
            Assert.AreEqual(5, upperItemslist.Count);
            Assert.AreEqual(1, upperItemslist[0]);
            Assert.AreEqual(0.8m, upperItemslist[1]);
            Assert.AreEqual(0.6m, upperItemslist[2]);
            Assert.AreEqual(0.6m, upperItemslist[3]);
            Assert.AreEqual(0m, upperItemslist[4]);
        }

        [Test]
        public void GetExpectedValueRetursProperInterval()
        {
            var expertone = new Expertone<string>(this.GetTestExpertise());
            var expectedValue = expertone.GetExpectedValue();

            Assert.NotNull(expectedValue);
            Assert.AreEqual(0.18m, expectedValue.LowerBound);
            Assert.AreEqual(0.4m, expectedValue.UpperBound);
        }

        private Expertise<string> GetTestExpertise()
        {
            var expertise = new Expertise<string>(new Interval());
            expertise.Cardinalities.Add("a", new Cardinality(5, 0));
            expertise.Cardinalities.Add("e", new Cardinality(0, 2));
            expertise.Cardinalities.Add("i", new Cardinality(3, 2));
            expertise.Cardinalities.Add("o", new Cardinality(0, 0));
            expertise.Cardinalities.Add("u", new Cardinality(2, 6));

            return expertise;
        }
    }
}
