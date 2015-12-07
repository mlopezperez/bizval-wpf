using System.Collections.Generic;
using BizVal.Model;

namespace BizVal.Services
{
    /// <summary>
    /// Interface defining operations to implement LAMA operator.
    /// </summary>
    internal interface ILamaCalculator
    {
        /// <summary>
        /// Aggregates linguistic information using LAMA operator
        /// </summary>
        /// <param name="cardinalities">The cardinalities of the 2-tuples to aggregate.</param>
        /// <param name="referenceLabelSet">The reference label set.</param>
        /// <returns>A representative value of the information in 2-tuple representation.</returns>
        TwoTuple LinguisticLama(IDictionary<TwoTuple, int> cardinalities, LabelSet referenceLabelSet);
    }


}
