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

        public override string ToString()
        {
            return string.Format("Lower: {0}, Upper: {1}", this.Lower, this.Upper);
        }
    }
}