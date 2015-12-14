using System;
using BizVal.Model;

namespace BizVal.Services.Cw
{
    internal class TwoTupleDecimalConverter : ITwoTupleDecimalConverter
    {
        public decimal ConvertToDecimal(TwoTuple tuple)
        {
            var set = tuple.Label.LabelSet;
            var beta = set.DeltaInv(tuple);
            decimal k = 1m;
            if (beta < set.G)
            {
                int h = (int)Math.Truncate(beta);
                var sigma = beta - h;
                var membershipTuple1 = new TwoTuple(set[h], 1 - sigma);
                var membershipTuple2 = new TwoTuple(set[h + 1], sigma);
                k = (membershipTuple1.Label.M * membershipTuple1.Alpha) +
                    (membershipTuple2.Label.M * membershipTuple2.Alpha);
            }
            return k;
        }
    }
}