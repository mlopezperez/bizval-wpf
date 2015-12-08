using System.Collections.Generic;
using System.Linq;
using BizVal.App.Interfaces;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class IntervalListViewModel : IIntervalListViewModel
    {
        private readonly IWindowManager windowManager;

        public string InputName { get; set; }

        public IntervalListViewModel(IWindowManager windowManager)
        {
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.Expertises = new List<LinguisticExpertise>();
            var expertise = new LinguisticExpertise(new Interval(0.1m, 0.2m));
            expertise.AddOpinion(new TwoTuple(new Label(1, "cosa"), 0m), new TwoTuple(new Label(2, "cosa2"), -0.33m));

            var expertise2 = new LinguisticExpertise(new Interval(0.15m, 0.30m));
            expertise2.AddOpinion(new TwoTuple(new Label(1, "cosa"), 0m), new TwoTuple(new Label(2, "cosa2"), -0.33m));
            expertise2.AddOpinion(new TwoTuple(new Label(1, "cosa"), 0m), new TwoTuple(new Label(1, "cosa1"), -0.33m));

            this.Expertises.Add(expertise);
            this.Expertises.Add(expertise2);
        }

        public IList<LinguisticExpertise> Expertises { get; set; }

        public void Add()
        {
            //var vm = new IntervalViewModel(this.Expertises.First());
            //this.windowManager.ShowDialog(vm);

        }

    }
}
