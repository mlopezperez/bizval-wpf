using BizVal.App.Interfaces;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class ShellViewModel : Screen, IShell
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IHierarchyManager hierarchyManager;
        private readonly IWindowManager windowManager;

        public CashflowViewModel Cashflow { get; set; }

        public MixedAnalysisViewModel MixedAnalysis { get; set; }

        public ResultsViewModel Results { get; set; }

        public ShellViewModel(
            IWindowManager windowManager,
            IHierarchyManager hierarchyManager,
            IEventAggregator eventAggregator,
            CashflowViewModel casflowViewModel,
            MixedAnalysisViewModel mixedAnalysisViewModel,
            ResultsViewModel resultsViewModel)
        {
            this.eventAggregator = Contract.NotNull(eventAggregator, "eventAggregator");
            this.hierarchyManager = Contract.NotNull(hierarchyManager, "hierarchyManager");
            this.windowManager = Contract.NotNull(windowManager, "windowManager");

            this.Cashflow = Contract.NotNull(casflowViewModel, "casflowViewModel");
            this.MixedAnalysis = Contract.NotNull(mixedAnalysisViewModel, "mixedAnalysisViewModel");
            this.Results = Contract.NotNull(resultsViewModel, "resultsViewModel");
        }

        public void DefineHierarchy()
        {
            var hierarchyDefinitionViewModel = new HierarchyDefinitionViewModel(this.hierarchyManager, this.windowManager, this.eventAggregator);
            this.windowManager.ShowDialog(hierarchyDefinitionViewModel);
        }
    }
}