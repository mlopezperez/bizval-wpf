using System.Collections.Generic;
using BizVal.Model;

namespace BizVal.Services
{
    internal interface ILamaCalculator
    {
        TwoTuple LinguisticLama(SortedList<TwoTuple, int> cardinalities, LabelSet referenceLabelSet);
    }


}
