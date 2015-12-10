using System;

namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates a linguistic label and its related functions.
    /// </summary>
    public class Label : IComparable<Label>
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

        public decimal A { get; set; }

        public decimal B { get; set; }

        public decimal M { get; set; }

        /// <summary>
        /// Gets or sets the label set in which the label is contained.
        /// </summary>
        /// <value>
        /// The label set.
        /// </value>
        public LabelSet LabelSet { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Label" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="name">The name.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="medium">The medium.</param>
        /// <param name="max">The maximum.</param>
        public Label(int index, string name, decimal lower, decimal medium, decimal max)
        {
            this.Index = index;
            this.Name = name;
            this.A = lower;
            this.M = medium;
            this.B = max;
        }

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
            return new TwoTuple(this, 0m);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{1}-{0}", this.Index, this.Name);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(Label other)
        {
            return this.Index.CompareTo(other.Index);
        }
    }
}