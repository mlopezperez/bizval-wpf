using System;
using BizVal.Model;
using NUnit.Framework;

namespace BizVal.Tests.Model
{
    [TestFixture]
    public class HierarchyTests
    {
        [Test]
        public void TranslateThrowsIfFinishLevelNotPresent()
        {
            var hierarchy = this.GetTestHierarchy();
            Assert.Throws<ArgumentException>(() => hierarchy.Translate(new TwoTuple(hierarchy[5][0], 0), 10));
        }

        [Test]
        public void TranslateThrowsIfFinishLevelLowerThanSource()
        {
            var hierarchy = this.GetTestHierarchy();
            Assert.Throws<ArgumentException>(() => hierarchy.Translate(new TwoTuple(hierarchy[7][0], 0), 5));
        }

        [Test]
        public void TranslateTuples()
        {
            var hierarchy = this.GetTestHierarchy();
            var label = hierarchy[7][4];
            var tuple = label.Theta();
            var newTuple = hierarchy.Translate(tuple, 9);

            Assert.NotNull(newTuple);
            Assert.NotNull(newTuple.Label);
            Assert.AreEqual(newTuple.Label, hierarchy[9][5]);
            Assert.AreEqual(5, newTuple.Label.Index);

            // 0.33 expressed as fraction to get periodic decimal.
            Assert.AreEqual(1m / 3m, newTuple.Alpha);
        }

        [Test]
        public void TranslateTupleToSameLevelReturnsSame()
        {
            var hierarchy = this.GetTestHierarchy();
            var label = hierarchy[7][4];
            var tuple = label.Theta();
            var newTuple = hierarchy.Translate(tuple, 7);

            Assert.NotNull(newTuple);
            Assert.NotNull(newTuple.Label);
            Assert.AreEqual(newTuple.Label, hierarchy[7][4]);

            Assert.AreEqual(0m, newTuple.Alpha);
        }


        private Hierarchy GetTestHierarchy()
        {
            var hierarchy = new Hierarchy();
            hierarchy.Add(this.GetTermSet(5));
            hierarchy.Add(this.GetTermSet(7));
            hierarchy.Add(this.GetTermSet(9));
            return hierarchy;
        }

        private LabelSet GetTermSet(int cardinality)
        {
            var termSet = new LabelSet();
            for (int i = 0; i < cardinality; i++)
            {
                termSet.Add(new Label(i, string.Format("Term_{0}", i)));
            }
            return termSet;
        }
    }
}
