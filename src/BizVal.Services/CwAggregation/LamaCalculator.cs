using System.Collections.Generic;
using System.Linq;
using BizVal.Framework;
using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal sealed class LamaCalculator : ILamaCalculator
    {
        public TwoTuple LinguisticLama(IDictionary<TwoTuple, int> cardinalities, LabelSet referenceLabelSet)
        {
            Contract.NotNull(cardinalities, "cardinalities");
            Contract.NotNull(referenceLabelSet, "referenceLabelSet");
            var sortedCardinalities = this.GetSortedCardinalities(cardinalities);
            TwoTuple result = referenceLabelSet.Delta(this.GetBeta(sortedCardinalities, referenceLabelSet));
            return result;
        }

        private SortedList<TwoTuple, int> GetSortedCardinalities(IDictionary<TwoTuple, int> cardinalities)
        {
            var result = new SortedList<TwoTuple, int>();
            foreach (var cardinality in cardinalities)
            {
                result.Add(cardinality.Key, cardinality.Value);
            }
            return result;
        }

        private decimal GetBeta(SortedList<TwoTuple, int> cardinalities, LabelSet referenceLabelSet)
        {
            decimal beta = 0;
            foreach (var tuple in cardinalities.Keys)
            {
                if (cardinalities[tuple] > 0)
                {
                    beta = beta +
                           referenceLabelSet.DeltaInv(tuple) *
                           this.GetWeight(cardinalities[tuple], cardinalities.Values.Where(i => i > 0).OrderByDescending(i => i).ToList());
                }
            }
            return beta;
        }

        private decimal GetWeight(int currentCardinality, IList<int> sortedCardinalities)
        {
            IList<int> thetas = this.GetThetas(sortedCardinalities);
            decimal weight = 0m;

            while (thetas.Count > 0)
            {
                int sigma = currentCardinality > 0 ? 1 : 0;
                weight = weight + decimal.Divide(sigma, this.MultiplyThetas(thetas));
                thetas.RemoveAt(thetas.Count - 1);
                currentCardinality--;
            }
            return weight;
        }

        private decimal MultiplyThetas(IList<int> thetas)
        {
            var result = 1;
            for (int i = 0; i < thetas.Count; i++)
            {
                result = result * thetas[i];
            }
            return result;
        }

        private IList<int> GetThetas(IList<int> sortedCardinalities)
        {
            var result = new List<int>();
            var maxCardinality = sortedCardinalities.First();
            var minCardinality = sortedCardinalities.Last();
            for (int j = maxCardinality; j >= minCardinality; j--)
            {
                int theta = this.GetTheta(j, sortedCardinalities);
                result.Add(theta);
            }
            return result;
        }

        private int GetTheta(int current, IList<int> sortedCardinalities)
        {

            var result = sortedCardinalities.Count(i => i >= current);
            if (current != sortedCardinalities.Min())
            {
                result = result + 1;
            }
            return result;
        }
    }
}