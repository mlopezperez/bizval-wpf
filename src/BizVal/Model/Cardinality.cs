namespace BizVal.Model
{
    public class Cardinality
    {
        /// <summary>
        /// Gets or sets the cardinality for the lower bound of the interval.
        /// </summary>
        /// <value>
        /// The cardinality for the lower bound of the interval
        /// </value>
        public int Lower { get; set; }

        /// <summary>
        /// Gets or sets the cardinality for the upper bound of the interval.
        /// </summary>
        /// <value>
        /// The cardinality for the upper bound of the interval
        /// </value>
        public int Upper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cardinality"/> class.
        /// </summary>
        /// <param name="lowerCardinality">The lower cardinality.</param>
        /// <param name="upperCardinality">The upper cardinality.</param>
        public Cardinality(int lowerCardinality, int upperCardinality)
        {
            this.Lower = lowerCardinality;
            this.Upper = upperCardinality;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Lower: {0}, Upper: {1}", this.Lower, this.Upper);
        }
    }
}