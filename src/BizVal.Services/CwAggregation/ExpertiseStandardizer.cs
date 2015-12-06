using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal class ExpertiseStandardizer : IExpertiseStandardizer
    {
        public LinguisticExpertise Standardize(LinguisticExpertise expertise, Hierarchy hierarchy, int referenceLevel)
        {
            var result = new LinguisticExpertise(expertise.Interval);
            foreach (var item in expertise.Cardinalities)
            {
                var standarTuple = hierarchy.Translate(item.Key, referenceLevel);
                result.Cardinalities.Add(standarTuple, item.Value);
            }
            return result;
        }
    }
}