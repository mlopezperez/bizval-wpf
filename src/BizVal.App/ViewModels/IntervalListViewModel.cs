using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class IntervalListViewModel : PropertyChangedBase, IIntervalListViewModel
    {
        private readonly IWindowManager windowManager;
        private IntervalWithOpinions selectedItem;

        public string InputName { get; set; }

        public IObservableCollection<IntervalWithOpinions> Values { get; set; }

        public IntervalWithOpinions SelectedItem
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

        public IntervalListViewModel(IWindowManager windowManager)
        {
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.Values = new BindableCollection<IntervalWithOpinions>();
        }

        public void Add()
        {
            var data = new IntervalWithOpinions(new Interval());
            var vm = new IntervalViewModel(this.windowManager, data);
            var result = this.windowManager.ShowDialog(vm);
            if (result.HasValue && result.Value)
            {
                this.Values.Add(data);
            }
            this.NotifyOfPropertyChange(() => this.Values);
        }

        public void Edit()
        {
            var vm = new IntervalViewModel(this.windowManager, this.SelectedItem);
            this.windowManager.ShowDialog(vm);
            this.NotifyOfPropertyChange(() => this.Values);
        }

        public void Delete()
        {
            this.Values.Remove(this.SelectedItem);
            this.NotifyOfPropertyChange(() => this.Values);
        }
    }
}
