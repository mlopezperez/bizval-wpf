namespace BizVal.Model
{
    public class LinguisticExpertise : Expertise<TwoTuple>
    {
        public LinguisticExpertise(Interval interval)
            : base(interval)
        {
        }
    }
}