namespace BizVal.Model
{
    public class Term
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public Term(int index, string name)
        {
            this.Index = index;
            this.Name = name;
        }

        public TwoTuple Theta()
        {
            return new TwoTuple
            {
                Alpha = 0m,
                Term = this
            };
        }
    }
}