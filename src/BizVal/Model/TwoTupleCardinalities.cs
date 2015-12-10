
namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates an expertise of linguistic information with TwoTuples.
    /// </summary>
    /// <seealso cref="BizVal.Model.Expertise{BizVal.Model.TwoTuple}" />
    public class TwoTupleCardinalities : CardinalityList<TwoTuple>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoTupleCardinalities"/> class.
        /// </summary>
        /// <param name="expertise">The expertise.</param>
        public TwoTupleCardinalities(Expertise expertise)
            : base(expertise.Interval)
        {
            foreach (var item in expertise.Opinions)
            {
                this.AddOpinion(item.LowerOpinion, item.UpperOpinion);
            }
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