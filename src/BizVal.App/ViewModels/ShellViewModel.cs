using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : Conductor<object>, IShell
    {
        private readonly IHierarchyManager hierarchyManager;
        private readonly ResultsViewModel resultsViewModel;
        private readonly IWindowManager windowManager;

        public CashflowViewModel Cashflow { get; set; }

        public MixedAnalysisViewModel MixedAnalysis { get; set; }

        public ResultsViewModel Results { get; set; }

        public ShellViewModel(
            IWindowManager windowManager,
            IHierarchyManager hierarchyManager,
            CashflowViewModel casflowViewModel,
            MixedAnalysisViewModel mixedAnalysisViewModel,
            ResultsViewModel resultsViewModel)
        {
            this.hierarchyManager = Contract.NotNull(hierarchyManager, "hierarchyManager");
            this.resultsViewModel = Contract.NotNull(resultsViewModel, "resultsViewModel");
            this.windowManager = Contract.NotNull(windowManager, "windowManager");

            this.Cashflow = Contract.NotNull(casflowViewModel, "casflowViewModel");
            this.MixedAnalysis = Contract.NotNull(mixedAnalysisViewModel, "mixedAnalysisViewModel");
            this.Results = Contract.NotNull(resultsViewModel, "resultsViewModel");

            this.ActivateItem(this.Cashflow);
        }

        public void DefineHierarchy()
        {
            var hierarchyDefinitionViewModel = new HierarchyDefinitionViewModel(this.hierarchyManager);
            this.windowManager.ShowDialog(hierarchyDefinitionViewModel);
        }

        public void ShowCashflow()
        {
            this.ActivateItem(this.Cashflow);
        }

        public void ShowMixedAnalysis()
        {
            this.ActivateItem(this.MixedAnalysis);
        }

        public void ShowResults()
        {
            this.ActivateItem(this.Results);
        }
    }
}