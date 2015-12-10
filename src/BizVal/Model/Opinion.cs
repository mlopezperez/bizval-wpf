
namespace BizVal.Model
{
    public class Opinion
    {
        public TwoTuple LowerOpinion { get; set; }
        public TwoTuple UpperOpinion { get; set; }

        public Opinion(TwoTuple lowerOpinion, TwoTuple upperOpinion)
        {
            this.LowerOpinion = lowerOpinion;
            this.UpperOpinion = upperOpinion;
        }
    }
}
