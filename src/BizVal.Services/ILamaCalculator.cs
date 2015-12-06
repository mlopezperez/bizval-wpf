using System.Collections.Generic;
using BizVal.Model;

namespace BizVal.Services
{
    internal interface ILamaCalculator
    {
        TwoTuple LinguisticLama(IDictionary<TwoTuple, int> cardinalities, LabelSet referenceLabelSet);
    }


}
