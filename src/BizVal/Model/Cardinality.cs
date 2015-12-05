namespace BizVal.Model
{
    public class Cardinality
    {
        public int Lower { get; set; }

        public int Upper { get; set; }

        public Cardinality(int lowerCardinality, int upperCardinality)
        {
            this.Lower = lowerCardinality;
            this.Upper = upperCardinality;
        }
    }
}