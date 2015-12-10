namespace BizVal.App.Events
{
    public class MixedCalculationErrorEvent
    {
        public string Error { get; set; }

        public MixedCalculationErrorEvent(string error)
        {
            this.Error = error;
        }
    }
}