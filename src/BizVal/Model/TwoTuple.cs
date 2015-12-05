using System;

namespace BizVal.Model
{
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
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public Label Label { get; set; }

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