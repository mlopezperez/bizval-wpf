using System.Runtime.CompilerServices;

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

        /// <summary>
        /// Adds an opinion to the expertise.
        /// </summary>
        /// <param name="lowerBoundOpinion">The lower bound opinion.</param>
        /// <param name="upperBoundOpinion">The upper bound opinion.</param>
        public void AddOpinion(TwoTuple lowerBoundOpinion, TwoTuple upperBoundOpinion)
        {
            if (!this.Cardinalities.ContainsKey(lowerBoundOpinion))
            {
                this.Cardinalities.Add(lowerBoundOpinion, new Cardinality(0, 0));
            }
            if (!this.Cardinalities.ContainsKey(upperBoundOpinion))
            {
                this.Cardinalities.Add(upperBoundOpinion, new Cardinality(0, 0));
            }

            this.Cardinalities[lowerBoundOpinion].Lower++;
            this.Cardinalities[upperBoundOpinion].Upper++;
        }
    }
}