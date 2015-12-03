using System;
using System.Collections.Generic;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Services.Tests
{
    [TestFixture]
    public class CompanyValuatorTests
    {
        [Test]
        public void CompanyValuatorThrowsWhenNullArguments()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, null));
        }

        [Test]
        public void CompanyValuatorThrowsWhenNullExpectedCashflows()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, new List<Interval>()));
        }

        [Test]
        public void CompanyValuatorThrowsWhenNullExpectedWaccs()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(new List<Interval>(), null));
        }

        [Test]
        public void CompanyValuatorThrowsWhenDifferentNumberOfIntervals()
        {
            ICompanyValuator valuator = new CompanyValuator();
            var cashflows = new List<Interval> { new Interval() };
            var waccs = new List<Interval> { new Interval(), new Interval() };
            Assert.Throws<ValuationException>(() => valuator.Cashflow(cashflows, waccs));
        }

        [Test]
        public void CompanyValuatorReturnsProperValueWithCashflow()
        {
            ICompanyValuator valuator = new CompanyValuator();
            var k1 = new Interval(0.040f, 0.050f);
            var k2 = new Interval(0.045f, 0.060f);
            var k3 = new Interval(0.050f, 0.060f);

            var expectedWaccs = new List<Interval> { k1, k2, k3 };

            var cfl1 = new Interval(4000, 6000);
            var cfl2 = new Interval(3000, 6000);
            var cfl3 = new Interval(2000, 5000);

            var expectedCashflows = new List<Interval> { cfl1, cfl2, cfl3 };

            var result = valuator.Cashflow(expectedCashflows, expectedWaccs);

            var expectedResult = new Interval(8971, 17122);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result);
        }

    }
}
