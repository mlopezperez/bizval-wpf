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
    }
}
