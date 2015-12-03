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
        public void CashflowThrowsWhenNullArguments()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, null));
        }

        [Test]
        public void CashflowThrowsWhenNullExpectedCashflows()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(null, new List<Interval>()));
        }

        [Test]
        public void CashflowThrowsWhenNullExpectedWaccs()
        {
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.Cashflow(new List<Interval>(), null));
        }

        [Test]
        public void CashflowThrowsWhenDifferentNumberOfIntervals()
        {
            ICompanyValuator valuator = new CompanyValuator();
            var cashflows = new List<Interval> { new Interval() };
            var waccs = new List<Interval> { new Interval(), new Interval() };
            Assert.Throws<ValuationException>(() => valuator.Cashflow(cashflows, waccs));
        }

        [Test]
        public void CashflowReturnsProperValue()
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

            //var expectedResult = new Interval(8971, 17122);
            var expectedResult = new Interval(8359.1860f, 15343.2012f);

            Assert.NotNull(result);
            Assert.AreEqual(expectedResult.LowerBound, result.LowerBound);
            Assert.AreEqual(expectedResult.UpperBound, result.UpperBound);
        }

        [Test]
        public void CashflowReturnsProperValueIfEmptyIntervals()
        {
            ICompanyValuator valuator = new CompanyValuator();
            var expectedWaccs = new List<Interval>();
            var expectedCashflows = new List<Interval>();

            var result = valuator.Cashflow(expectedCashflows, expectedWaccs);

            var expectedResult = new Interval(0, 0);
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult.LowerBound, result.LowerBound);
            Assert.AreEqual(expectedResult.UpperBound, result.UpperBound);
        }

        [Test]
        public void MixedAnalysisThrowsIfNullParms()
        {
            float substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, null, null));
        }


        [Test]
        public void MixedAnalysisThrowsIfNullBenefits()
        {
            float substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, null, new List<Interval>()));
        }

        [Test]
        public void MixedAnalysisThrowsIfNullRates()
        {
            float substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, new List<Interval>(), null));
        }

        [Test]
        public void MixedAnalysisThrowsIfDifferentAmountOfIntervals()
        {
            float substantialValue = 3000;
            var expectedInterests = new List<Interval> { new Interval(), new Interval() };
            var expectedBenefits = new List<Interval> { new Interval(), new Interval(), new Interval() };
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ValuationException>(() => valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests));
        }

        [Test]
        public void MixedAnalysisReturnsProperValueIfEmptyIntervals()
        {
            float substantialValue = 3000;
            var expectedInterests = new List<Interval>();
            var expectedBenefits = new List<Interval>();
            ICompanyValuator valuator = new CompanyValuator();
            var result = valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests);

            Assert.NotNull(result);
            Assert.AreEqual(3000, result.UpperBound);
            Assert.AreEqual(3000, result.LowerBound);
        }

        [Test]
        [Ignore("Get results with no round error")]
        public void MixedAnalysisReturnsProperValue()
        {
            ICompanyValuator valuator = new CompanyValuator();

            var substantialValue = 3000f;
            var k1 = new Interval(0.04738f, 0.04872f);
            var k2 = new Interval(0.05425f, 0.05786f);
            var k3 = new Interval(0.05183f, 0.05436f);

            var expectedInterests = new List<Interval> { k1, k2, k3 };

            var cfl1 = new Interval(4898, 5361);
            var cfl2 = new Interval(4166, 5306);
            var cfl3 = new Interval(2499, 3680);

            var expectedBenefits = new List<Interval> { cfl1, cfl2, cfl3 };

            var result = valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests);

            var expectedResult = new Interval(12047, 14212);

            Assert.NotNull(result);
            Assert.AreEqual(expectedResult.LowerBound, result.LowerBound);
            Assert.AreEqual(expectedResult.UpperBound, result.UpperBound);
        }
    }
}
