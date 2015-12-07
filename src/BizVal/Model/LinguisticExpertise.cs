namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates an expertise of linguistic information with TwoTuples.
    /// </summary>
    /// <seealso cref="BizVal.Model.Expertise{BizVal.Model.TwoTuple}" />
    public class LinguisticExpertise : Expertise<TwoTuple>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinguisticExpertise"/> class.
        /// </summary>
        /// <param name="interval">The interval.</param>
        public LinguisticExpertise(Interval interval)
            : base(interval)
        {
        }
    }
}