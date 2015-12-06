using System;
using System.Collections.Generic;
using BizVal.Model;
using BizVal.Services.Valuation;
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
            var k1 = new Interval(0.040m, 0.050m);
            var k2 = new Interval(0.045m, 0.060m);
            var k3 = new Interval(0.050m, 0.060m);

            var expectedWaccs = new List<Interval> { k1, k2, k3 };

            var cfl1 = new Interval(4000, 6000);
            var cfl2 = new Interval(3000, 6000);
            var cfl3 = new Interval(2000, 5000);

            var expectedCashflows = new List<Interval> { cfl1, cfl2, cfl3 };

            var result = valuator.Cashflow(expectedCashflows, expectedWaccs);

            var expectedResult = new Interval(8359m, 15343m);

            Assert.NotNull(result);
            Assert.AreEqual(expectedResult.LowerBound, Math.Round(result.LowerBound));
            Assert.AreEqual(expectedResult.UpperBound, Math.Round(result.UpperBound));
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
            decimal substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, null, null));
        }


        [Test]
        public void MixedAnalysisThrowsIfNullBenefits()
        {
            decimal substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, null, new List<Interval>()));
        }

        [Test]
        public void MixedAnalysisThrowsIfNullRates()
        {
            decimal substantialValue = 3000;
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ArgumentNullException>(() => valuator.MixedAnalysis(substantialValue, new List<Interval>(), null));
        }

        [Test]
        public void MixedAnalysisThrowsIfDifferentAmountOfIntervals()
        {
            decimal substantialValue = 3000;
            var expectedInterests = new List<Interval> { new Interval(), new Interval() };
            var expectedBenefits = new List<Interval> { new Interval(), new Interval(), new Interval() };
            ICompanyValuator valuator = new CompanyValuator();
            Assert.Throws<ValuationException>(() => valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests));
        }

        [Test]
        public void MixedAnalysisReturnsProperValueIfEmptyIntervals()
        {
            decimal substantialValue = 3000;
            var expectedInterests = new List<Interval>();
            var expectedBenefits = new List<Interval>();
            ICompanyValuator valuator = new CompanyValuator();
            var result = valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests);

            Assert.NotNull(result);
            Assert.AreEqual(3000, result.UpperBound);
            Assert.AreEqual(3000, result.LowerBound);
        }

        [Test]
        public void MixedAnalysisReturnsProperValue()
        {
            ICompanyValuator valuator = new CompanyValuator();

            var substantialValue = 3000m;
            var k1 = new Interval(0.04738m, 0.04872m);
            var k2 = new Interval(0.05425m, 0.05786m);
            var k3 = new Interval(0.05183m, 0.05436m);

            var expectedInterests = new List<Interval> { k1, k2, k3 };

            var cfl1 = new Interval(4898, 5361);
            var cfl2 = new Interval(4166, 5306);
            var cfl3 = new Interval(2499, 3680);

            var expectedBenefits = new List<Interval> { cfl1, cfl2, cfl3 };

            var result = valuator.MixedAnalysis(substantialValue, expectedBenefits, expectedInterests);

            var expectedResult = new Interval(11913m, 14046m);

            Assert.NotNull(result);
            Assert.AreEqual(expectedResult.LowerBound, Math.Round(result.LowerBound));
            Assert.AreEqual(expectedResult.UpperBound, Math.Round(result.UpperBound));
        }
    }
}
