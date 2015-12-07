using System;
using BizVal.Framework;

namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates the two-tuples model with its operations.
    /// </summary>
    /// <seealso cref="System.IComparable{BizVal.Model.TwoTuple}" />
    public class TwoTuple : IComparable<TwoTuple>
    {
        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public decimal Alpha { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Label, this.Alpha);
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public Label Label { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwoTuple"/> class.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="alpha">The alpha.</param>
        public TwoTuple(Label label, decimal alpha)
        {
            this.Alpha = alpha;
            this.Label = Contract.NotNull(label, "label");
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
        /// </returns>
        public int CompareTo(TwoTuple other)
        {
            if (this.Label != other.Label)
            {
                return this.Label.CompareTo(other.Label);
            }
            else
            {
                return this.Alpha.CompareTo(other.Alpha);
            }
        }
    }
}