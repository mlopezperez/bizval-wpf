using System;
using BizVal.Framework;

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

        public TwoTuple(Label label, decimal alpha)
        {
            this.Alpha = alpha;
            this.Label = Contract.NotNull(label, "label");
        }

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