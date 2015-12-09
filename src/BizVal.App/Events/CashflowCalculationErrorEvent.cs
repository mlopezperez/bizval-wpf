namespace BizVal.App.Events
{
    public class CashflowCalculationErrorEvent
    {
        public string Error { get; private set; }

        public CashflowCalculationErrorEvent(string message)
        {
            this.Error = message;
        }
    }
}
