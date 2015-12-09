using BizVal.App.Events;
using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class IntervalListViewModel : PropertyChangedBase, IIntervalListViewModel
    {
        private readonly IHierarchyManager hierarchyManager;
        private readonly IEventAggregator eventAggregator;
        private readonly IWindowManager windowManager;
        private BindableExpertise selectedItem;

        public string InputName { get; set; }

        public IObservableCollection<BindableExpertise> Values { get; set; }

        public BindableExpertise SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                this.NotifyOfPropertyChange(() => this.SelectedItem);
                this.NotifyOfPropertyChange(() => this.CanEdit);
                this.NotifyOfPropertyChange(() => this.CanDelete);
            }
        }

        public bool CanEdit
        {
            get { return this.SelectedItem != null; }
        }

        public bool CanDelete
        {
            get { return this.SelectedItem != null; }
        }

        public IntervalListViewModel(IWindowManager windowManager, IHierarchyManager hierarchyManager, IEventAggregator eventAggregator)
        {
            this.hierarchyManager = hierarchyManager;
            this.eventAggregator = eventAggregator;
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.Values = new BindableCollection<BindableExpertise>();
        }

        public void Add()
        {
            var data = new BindableExpertise(new BindableInterval());
            var vm = new IntervalViewModel(this.windowManager, data, this.hierarchyManager);
            var result = this.windowManager.ShowDialog(vm);
            if (result.HasValue && result.Value)
            {
                this.Values.Add(data);
            }
            this.eventAggregator.PublishOnUIThread(new DataChangedEvent());
            this.NotifyOfPropertyChange(() => this.Values);
        }

        public void Edit()
        {
            var vm = new IntervalViewModel(this.windowManager, this.SelectedItem, this.hierarchyManager);
            this.windowManager.ShowDialog(vm);
            this.eventAggregator.PublishOnUIThread(new DataChangedEvent());
            this.NotifyOfPropertyChange(() => this.Values);
        }

        public void Delete()
        {
            this.Values.Remove(this.SelectedItem);
            this.NotifyOfPropertyChange(() => this.Values);
        }
    }
}
