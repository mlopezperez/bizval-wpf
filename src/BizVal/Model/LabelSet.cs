using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates a set of linguistic labels and its related functions.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{BizVal.Model.Label}" />
    public class LabelSet : ICollection<Label>
    {
        private readonly SortedList<int, Label> labels;

        /// <summary>
        /// Gets the <see cref="Label"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="Label"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns>The label.</returns>
        public Label this[int key]
        {
            get { return this.labels[key]; }
        }

        /// <summary>
        /// Gets the index of the greater term in the set.
        /// </summary>
        /// <value>
        /// The index of the greater term.
        /// </value>
        public int G
        {
            get
            {
                var last = this.labels.Values.LastOrDefault();
                return last == null ? 0 : last.Index;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count
        {
            get { return this.labels.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelSet"/> class.
        /// </summary>
        public LabelSet()
        {
            this.labels = new SortedList<int, Label>();
        }

        /// <summary>
        /// Deltas function for the current term set to get a 2-tuple from a real number.
        /// </summary>
        /// <param name="beta">The beta.</param>
        /// <returns>A 2-tuple for a term in the current set corresponding to the entered real value.</returns>
        /// <exception cref="System.ArgumentException">Value not valid to get a 2-tuple from current set.</exception>
        public TwoTuple Delta(decimal beta)
        {
            if ((beta < 0) || (beta > this.G))
            {
                throw new ArgumentException("Value not valid to get a 2-tuple from current set.");
            }

            var termIndex = (int)Math.Round(beta, MidpointRounding.ToEven);
            var result = new TwoTuple()
            {
                Label = this.labels[termIndex],
                Alpha = beta - termIndex
            };

            return result;
        }

        /// <summary>
        /// Delta^-1 function.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        /// <returns>A real number corresponding to the 2-tuple given.</returns>
        /// <exception cref="System.ArgumentException">2-Tuple not valid to get a numeric value from it with the current set.</exception>
        public decimal DeltaInv(TwoTuple tuple)
        {
            if ((tuple.Label == null) || tuple.Label.Index > this.G || tuple.Label.Index < 0)
            {
                throw new ArgumentException("2-Tuple not valid to get a numeric value from it with the current set.");
            }

            var result = tuple.Label.Index + tuple.Alpha;
            return result;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Label> GetEnumerator()
        {
            return this.labels.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.labels.Values.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(Label item)
        {
            this.labels.Add(item.Index, item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            this.labels.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        public bool Contains(Label item)
        {
            return this.labels.ContainsKey(item.Index);
        }

        /// <summary>
        /// Copies to a given array starting from the given index.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(Label[] array, int arrayIndex)
        {
            this.labels.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(Label item)
        {
            return this.labels.Remove(item.Index);
        }
    }
}
