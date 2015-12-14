using BizVal.Model;

namespace BizVal.Services
{
    internal interface ITwoTupleDecimalConverter
    {
        decimal ConvertToDecimal(TwoTuple tuple);
    }
}
