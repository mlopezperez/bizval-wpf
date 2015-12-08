using BizVal.App.Interfaces;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : IShell
    {
        public CashflowViewModel Cashflow { get; set; }

        public MixedAnalysisViewModel MixedAnalysis { get; set; }  

        private readonly Hierarchy hierarchy;

        public ShellViewModel(
            IHierarchyManager hierarchyManager, 
            CashflowViewModel casflowViewModel,
            MixedAnalysisViewModel mixedAnalysisViewModel)
        {
            Contract.NotNull(hierarchyManager, "hierarchyManager");
            this.hierarchy = hierarchyManager.GetDefaultHierarchy();

            this.Cashflow = Contract.NotNull(casflowViewModel, "casflowViewModel");
            this.MixedAnalysis = Contract.NotNull(mixedAnalysisViewModel, "mixedAnalysisViewModel");
        }
    }
}