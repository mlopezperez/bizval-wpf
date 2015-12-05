namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates a linguistic label and its related functions.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="name">The name.</param>
        public Label(int index, string name)
        {
            this.Index = index;
            this.Name = name;
        }

        /// <summary>
        /// Theta function for a Label.
        /// </summary>
        /// <returns>A 2-tuple for the label value.</returns>
        public TwoTuple Theta()
        {
            return new TwoTuple
            {
                Alpha = 0m,
                Label = this
            };
        }
    }
}