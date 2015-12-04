using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BizVal.Model
{
    public class TermSet : ICollection<Term>
    {
        private readonly SortedList<int, Term> terms;

        public int G
        {
            get
            {
                var last = this.terms.Values.LastOrDefault();
                return last == null ? 0 : last.Index;
            }
        }

        public int Count
        {
            get { return this.terms.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public TermSet()
        {
            this.terms = new SortedList<int, Term>();
        }

        public TwoTuple Delta(decimal beta)
        {
            if ((beta < 0) || (beta > this.G))
            {
                throw new ArgumentException("Value not valid to get a 2-tuple from current set.");
            }

            var termIndex = (int)Math.Round(beta, MidpointRounding.ToEven);
            var result = new TwoTuple()
            {
                Term = this.terms[termIndex],
                Alpha = beta - termIndex
            };

            return result;
        }

        public decimal DeltaInv(TwoTuple tuple)
        {
            if ((tuple.Term == null) || tuple.Term.Index > this.G || tuple.Term.Index < 0)
            {
                throw new ArgumentException("2-Tuple not valid to get a numeric value from it with the current set.");
            }

            var result = tuple.Term.Index + tuple.Alpha;
            return result;
        }

        public IEnumerator<Term> GetEnumerator()
        {
            return this.terms.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.terms.Values.GetEnumerator();
        }

        public void Add(Term item)
        {
            this.terms.Add(item.Index, item);
        }

        public void Clear()
        {
            this.terms.Clear();
        }

        public bool Contains(Term item)
        {
            return this.terms.ContainsKey(item.Index);
        }

        public void CopyTo(Term[] array, int arrayIndex)
        {
            this.terms.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(Term item)
        {
            return this.terms.Remove(item.Index);
        }
    }
}
