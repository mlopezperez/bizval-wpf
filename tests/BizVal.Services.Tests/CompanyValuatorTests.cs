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
            var valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, null));
        }

        [Test]
        public void CompanyValuatorThrowsWhenNullExpectedCashflows()
        {
            var valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, new List<Interval>()));
        }

        [Test]
        public void CompanyValuatorThrowsWhenNullExpectedWaccs()
        {
            var valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(new List<Interval>(), null));
        }

        [Test]
        public void CompanyValuatorThrowsWhenDifferentNumberOfIntervals()
        {
            var valuator = new CompanyValuator();
            var cashflows = new List<Interval> { new Interval() };
            var waccs = new List<Interval> { new Interval(), new Interval() };
            Assert.Throws<ValuationException>(() => valuator.Cashflow(cashflows, waccs));
        }
    }
}
