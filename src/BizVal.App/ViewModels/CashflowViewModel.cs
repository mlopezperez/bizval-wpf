using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class CashflowViewModel : PropertyChangedBase
    {
        private const string CashflowDataName = "Expected Cashflow:";
        private const string WaccDataName = "Expected Wacc:";

        public IntervalListViewModel CashflowData { get; set; }
        public IntervalListViewModel WaccData { get; set; }

        public CashflowViewModel(IntervalListViewModel cashflowData, IntervalListViewModel waccData)
        {
            this.CashflowData = cashflowData;
            this.WaccData = waccData;

            this.CashflowData.InputName = CashflowDataName;
            this.WaccData.InputName = WaccDataName;
        }
    }
}