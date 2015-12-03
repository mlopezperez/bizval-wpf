namespace BizVal.App.ViewModels
{
    using Caliburn.Micro;
    using System.Collections.Generic;

    public class ListViewModel : PropertyChangedBase
    {
        private int selectedItemIndex;

        private IObservableCollection<string> items;

        private string newItem;

        public IObservableCollection<string> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
                this.NotifyOfPropertyChange(() => this.Items);
            }
        }

        public int SelectedItemIndex
        {
            get
            {
                return this.selectedItemIndex;
            }

            set
            {
                this.selectedItemIndex = value;
                this.NotifyOfPropertyChange(() => this.SelectedItemIndex);
            }
        }

        public string NewItem
        {
            get
            {
                return this.newItem;
            }
            set
            {
                this.newItem = value;
                this.NotifyOfPropertyChange(() => this.NewItem);
                this.NotifyOfPropertyChange(() => this.CanAdd);
            }
        }

        public string InputName { get; private set; }
        

        public ListViewModel(string inputName, IEnumerable<string> items)
        {
            this.Items = new BindableCollection<string>(items);
            this.InputName = inputName;
        }

        public bool CanAdd
        {
            get
            {
                return !string.IsNullOrEmpty(this.NewItem);
            }
        }

        public void Add()
        {
            if (!string.IsNullOrEmpty(this.NewItem))
            {
                this.Items.Add(this.NewItem);
                this.NewItem = string.Empty;

                this.NotifyOfPropertyChange(() => this.NewItem);
            }
        }

        public void Delete()
        {
            if (this.SelectedItemIndex >= 0)
            {
                this.Items.RemoveAt(this.SelectedItemIndex);
            }
        }

        public void Up()
        {
            if ((this.Items.Count > 1) && (this.SelectedItemIndex > 0))
            {
                int currentIndex = this.SelectedItemIndex;
                int previousIndex = this.SelectedItemIndex - 1;
                var upper = this.Items[previousIndex];
                var current = this.Items[currentIndex];

                this.Items[previousIndex] = current;
                this.Items[currentIndex] = upper;
                this.SelectedItemIndex = previousIndex;
            }
        }

        public void Down()
        {
            if ((this.Items.Count > 1) && (this.SelectedItemIndex < this.Items.Count - 1))
            {
                int currentIndex = this.SelectedItemIndex;
                int nextIndex = this.SelectedItemIndex + 1;
                var next = this.Items[nextIndex];
                var current = this.Items[currentIndex];

                this.Items[nextIndex] = current;
                this.Items[currentIndex] = next;

                this.SelectedItemIndex = nextIndex;
            }
        }
    }
}
