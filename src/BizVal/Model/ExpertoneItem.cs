namespace BizVal.Model
{
    public class ExpertoneItem
    {
        public decimal LowerItem { get; set; }
        public decimal UpperItem { get; set; }

        public ExpertoneItem(decimal lowerBound, decimal upperBound)
        {
            this.LowerItem = lowerBound;
            this.UpperItem = upperBound;
        }

        public override string ToString()
        {
            return string.Format("LowerItem: {0}, UpperItem: {1}", this.LowerItem, this.UpperItem);
        }
    }
}
