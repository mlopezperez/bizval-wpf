namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates a level of an Expertone.
    /// </summary>
    public class ExpertoneItem
    {
        /// <summary>
        /// Gets or sets the lower value.
        /// </summary>
        /// <value>
        /// The lower value.
        /// </value>
        public decimal LowerBoundValue { get; set; }

        /// <summary>
        /// Gets or sets the upper value.
        /// </summary>
        /// <value>
        /// The upper value.
        /// </value>
        public decimal UpperBoundValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpertoneItem"/> class.
        /// </summary>
        /// <param name="lowerBound">The lower bound.</param>
        /// <param name="upperBound">The upper bound.</param>
        public ExpertoneItem(decimal lowerBound, decimal upperBound)
        {
            this.LowerBoundValue = lowerBound;
            this.UpperBoundValue = upperBound;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.LowerBoundValue, this.UpperBoundValue);
        }
    }
}
