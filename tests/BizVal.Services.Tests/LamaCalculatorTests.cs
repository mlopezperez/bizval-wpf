using System;
using System.Collections.Generic;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Services.Tests
{
    [TestFixture]
    public class LamaCalculatorTests
    {
        [Test]
        public void LamaThrowsIfEmptyArguments()
        {
            ILamaCalculator lamaCalculator = new LamaCalculator();
            Assert.Throws<ArgumentNullException>(() => lamaCalculator.LinguisticLama(null, null));
        }

        [Test]
        public void LamaThrowsIfEmptyReferenceSet()
        {
            ILamaCalculator lamaCalculator = new LamaCalculator();
            Assert.Throws<ArgumentNullException>(() => lamaCalculator.LinguisticLama(new SortedList<TwoTuple, int>(), null));
        }

        [Test]
        public void LamaThrowsIfEmtpyCardinalities()
        {
            ILamaCalculator lamaCalculator = new LamaCalculator();
            Assert.Throws<ArgumentNullException>(() => lamaCalculator.LinguisticLama(null, new LabelSet()));
        }

        [Test]
        public void LamaCalculatesProperly()
        {
            var set = this.GetReferenceSet();
            var cardinalities = new SortedList<TwoTuple, int>();
            cardinalities.Add(new TwoTuple(set[5], 0), 2);
            cardinalities.Add(new TwoTuple(set[4], 0), 1);
            cardinalities.Add(new TwoTuple(set[2], 0), 1);
            cardinalities.Add(new TwoTuple(set[1], 0.33m), 1);

            ILamaCalculator lamaCalculator = new LamaCalculator();
            TwoTuple result = lamaCalculator.LinguisticLama(cardinalities, set);

            Assert.NotNull(result);
            Assert.AreEqual(set[4], result.Label);
            Assert.AreEqual(0.04125m, result.Alpha);
        }

        [Test]
        public void LamaCalculatesProperlySingleElement()
        {
            var set = this.GetReferenceSet();
            var cardinalities = new SortedList<TwoTuple, int>();
            cardinalities.Add(new TwoTuple(set[2], 0.33m), 5);
            
            ILamaCalculator lamaCalculator = new LamaCalculator();
            TwoTuple result = lamaCalculator.LinguisticLama(cardinalities, set);

            Assert.NotNull(result);
            Assert.AreEqual(set[2], result.Label);
            Assert.AreEqual(0.33m, result.Alpha);
        }

        private LabelSet GetReferenceSet()
        {
            var labelSet = new LabelSet();

            var label0 = new Label(0, "nada");
            var label1 = new Label(1, "casi nada");
            var label2 = new Label(2, "muy poco");
            var label3 = new Label(3, "poco");
            var label4 = new Label(4, "medio");
            var label5 = new Label(5, "algo");
            var label6 = new Label(6, "mucho");
            var label7 = new Label(7, "casi todo");
            var label8 = new Label(8, "todo");
            labelSet.Add(label0);
            labelSet.Add(label1);
            labelSet.Add(label2);
            labelSet.Add(label3);
            labelSet.Add(label4);
            labelSet.Add(label5);
            labelSet.Add(label6);
            labelSet.Add(label7);
            labelSet.Add(label8);

            return labelSet;
        }
    }
}
