using System;
using System.Collections;
using System.Collections.Generic;

namespace BizVal.Model
{
    /// <summary>
    /// Encapsulates a linguistic hierarchy with several levels.
    /// </summary>
    /// <seealso cref="System.Collections.Generic.ICollection{BizVal.Model.LabelSet}" />
    public class Hierarchy : ICollection<LabelSet>
    {
        private readonly SortedList<int, LabelSet> levels;

        /// <summary>
        /// Gets the <see cref="LabelSet"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="LabelSet"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns>The label set.</returns>
        public LabelSet this[int key]
        {
            get { return this.levels[key]; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Hierarchy"/> class.
        /// </summary>
        public Hierarchy()
        {
            this.levels = new SortedList<int, LabelSet>();
        }

        /// <summary>
        /// Translates the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="gFinish">The g goal.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Source level or destination level does not exist in current hierarchy</exception>
        public TwoTuple Translate(TwoTuple source, int gFinish)
        {
            var gSource = source.Label.LabelSet.Count;
            if (!this.ContainsLevel(gSource) || !this.ContainsLevel(gFinish) || gSource > gFinish)
            {
                throw new ArgumentException("Source level or destination level does not exist in current hierarchy");
            }

            var sourceLevel = this.levels[gSource];
            var destinationLevel = this.levels[gFinish];
            decimal beta = (sourceLevel.DeltaInv(source) * (destinationLevel.Count - 1)) / (sourceLevel.Count - 1);

            TwoTuple result = destinationLevel.Delta(beta);
            return result;
        }

        /// <summary>
        /// Determines whether current hierarchy contains a level with the given cardinality.
        /// </summary>
        /// <param name="cardinality">The cardinality.</param>
        /// <returns>True if the hierarchy contains a level with the given cardinality.</returns>
        public bool ContainsLevel(int cardinality)
        {
            return this.levels.ContainsKey(cardinality);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<LabelSet> GetEnumerator()
        {
            return this.levels.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.levels.Values.GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        public void Add(LabelSet item)
        {
            try
            {
                this.levels.Add(item.Count, item);
            }
            catch (ArgumentException ex)
            {
                var message =
                    string.Format(
                        "A level with cardinality {0} already exists in hierarchy. Check hierarchy level \"{1}\" for missing items.",
                        item.Count,
                        item.Name);
                throw new HierarchyException(message, ex);
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            this.levels.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </returns>
        public bool Contains(LabelSet item)
        {
            return this.levels.ContainsKey(item.Count);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(LabelSet[] array, int arrayIndex)
        {
            this.levels.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
        /// <returns>
        /// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </returns>
        public bool Remove(LabelSet item)
        {
            return this.levels.Remove(item.Count);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public int Count
        {
            get { return this.levels.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }
    }
}
