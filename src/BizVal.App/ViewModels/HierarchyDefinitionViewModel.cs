using System.Windows.Media.Animation;
using BizVal.App.Events;
using BizVal.App.Interfaces;
using BizVal.App.Model;
using BizVal.Framework;
using BizVal.Model;
using Caliburn.Micro;

namespace BizVal.App.ViewModels
{
    public class HierarchyDefinitionViewModel : Screen, IHierarchyDefinitionViewModel
    {
        private const string Title = "Linguistic hierarchy definition";
        private readonly IEventAggregator eventAggregator;
        private readonly IWindowManager windowManager;
        private readonly IHierarchyManager hierarchyManager;
        private const string AddText = "Add";
        private const string SaveText = "Save";

        private BindableLabelSet selectedSet;
        private BindableHierarchy bindableHierarchy;
        private string setName;
        private bool editingSet;
        private string addSetButtonText;
        private BindableLabel selectedLabel;
        private string addLabelButtonTest;
        private string labelName;
        private bool editingLabel;
        private string errorMessage;
        private bool changes;

        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set { this.errorMessage = value; this.NotifyOfPropertyChange(() => this.ErrorMessage); }
        }

        public string AddSetButtonText
        {
            get { return this.addSetButtonText; }
            set
            {
                this.addSetButtonText = value;
                this.NotifyOfPropertyChange(() => this.AddSetButtonText);
            }
        }

        public BindableHierarchy Hierarchy
        {
            get
            {
                return this.bindableHierarchy;
            }
            set
            {
                this.bindableHierarchy = value;
                this.NotifyOfPropertyChange(() => this.Hierarchy);
            }
        }

        public BindableLabelSet SelectedSet
        {
            get
            {
                return this.selectedSet;
            }
            set
            {
                this.selectedSet = value;
                if (this.editingSet) this.SetName = this.selectedSet.SetName;
                this.SelectedLabel = null;
                this.NotifyOfPropertyChange(() => this.SelectedSet);
                this.NotifyOfPropertyChange(() => this.CanEditSet);
                this.NotifyOfPropertyChange(() => this.CanDeleteSet);
                this.NotifyOfPropertyChange(() => this.CanUpSet);
                this.NotifyOfPropertyChange(() => this.CanDownSet);
            }
        }

        public BindableLabel SelectedLabel
        {
            get { return this.selectedLabel; }
            set
            {
                this.selectedLabel = value;
                if (this.editingLabel) this.LabelName = this.selectedLabel.Name;
                this.NotifyOfPropertyChange(() => this.SelectedLabel);
                this.NotifyOfPropertyChange(() => this.CanEditLabel);
                this.NotifyOfPropertyChange(() => this.CanDeleteLabel);
                this.NotifyOfPropertyChange(() => this.CanUpLabel);
                this.NotifyOfPropertyChange(() => this.CanDownLabel);
                this.NotifyOfPropertyChange(() => this.CanEditLabelValues);
            }
        }

        public string SetName
        {
            get
            {
                return this.setName;
            }
            set
            {
                this.setName = value;
                if (!this.editingSet) this.SelectedSet = null;
                this.NotifyOfPropertyChange(() => this.SetName);
                this.NotifyOfPropertyChange(() => this.CanAddSet);
            }
        }

        public string LabelName
        {
            get
            {
                return this.labelName;
            }
            set
            {
                this.labelName = value;
                if (!this.editingLabel) this.SelectedLabel = null;
                this.NotifyOfPropertyChange(() => this.LabelName);
                this.NotifyOfPropertyChange(() => this.CanAddLabel);
            }
        }

        public string AddLabelButtonText
        {
            get { return this.addLabelButtonTest; }
            set
            {
                this.addLabelButtonTest = value;
                this.NotifyOfPropertyChange(() => this.AddLabelButtonText);
            }
        }

        public bool CanAddLabel
        {
            get { return this.SelectedSet != null && !string.IsNullOrEmpty(this.LabelName); }
        }

        public bool CanEditLabel
        {
            get { return this.SelectedSet != null && this.SelectedLabel != null; }
        }

        public bool CanDeleteLabel
        {
            get { return this.SelectedSet != null && this.SelectedLabel != null && !this.editingLabel; }
        }

        public bool CanUpLabel
        {
            get
            {
                return
                    this.SelectedSet != null &&
                    this.SelectedLabel != null &&
                    (this.SelectedSet.Labels.IndexOf(this.SelectedLabel) > 0);
            }
        }

        public bool CanDownLabel
        {
            get
            {
                return
                    this.SelectedSet != null &&
                    this.SelectedLabel != null &&
                    (this.SelectedSet.Labels.IndexOf(this.SelectedLabel) < this.SelectedSet.Labels.Count - 1);
            }
        }

        public bool CanAddSet
        {
            get { return !string.IsNullOrEmpty(this.SetName); }
        }

        public bool CanEditSet
        {
            get { return this.SelectedSet != null; }
        }

        public bool CanDeleteSet
        {
            get { return this.SelectedSet != null && !this.editingSet; }
        }

        public bool CanUpSet
        {
            get
            {
                return this.SelectedSet != null &&
                    (this.Hierarchy.Levels.IndexOf(this.SelectedSet) > 0);
            }
        }

        public bool CanDownSet
        {
            get
            {

                return this.SelectedSet != null &&
                      (this.Hierarchy.Levels.IndexOf(this.SelectedSet) < this.Hierarchy.Levels.Count - 1);
            }
        }



        public void UpSet()
        {
            this.Hierarchy.UpLevel(this.SelectedSet);
            this.changes = true;
        }

        public void DownSet()
        {
            this.Hierarchy.DownLevel(this.SelectedSet);
            this.changes = true;
        }

        public void UpLabel()
        {
            this.SelectedSet.UpLabel(this.SelectedLabel);
            this.changes = true;
        }

        public void DownLabel()
        {
            this.SelectedSet.DownLabel(this.SelectedLabel);
            this.changes = true;
        }

        public bool CanEditLabelValues
        {
            get { return this.SelectedSet != null && this.SelectedLabel != null; }
        }

        public void EditLabelValues()
        {
            var vm = new LabelDefinitionViewModel(this.SelectedLabel);
            var result = this.windowManager.ShowDialog(vm);
            if (result.HasValue && result.Value)
            {
                this.changes = true;
            }
        }


        public HierarchyDefinitionViewModel(IHierarchyManager hierarchyManager, IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            this.DisplayName = Title;
            this.eventAggregator = Contract.NotNull(eventAggregator, "eventAggregator");
            this.windowManager = Contract.NotNull(windowManager, "windowManager");
            this.hierarchyManager = Contract.NotNull(hierarchyManager, "hierarchyManager");

            var hierarchy = hierarchyManager.GetCurrentHierarchy();
            this.Hierarchy = new BindableHierarchy(hierarchy);

            this.AddSetButtonText = AddText;
            this.AddLabelButtonText = AddText;
        }

        public void AddSet()
        {
            if (this.SelectedSet != null)
            {
                this.editingSet = false;
                this.SelectedSet.SetName = this.SetName;
                this.SelectedSet = null;
            }
            else
            {
                var newLevel = new BindableLabelSet(new LabelSet(this.SetName));
                this.Hierarchy.Levels.Add(newLevel);
                this.SelectedSet = null;
            }
            this.SetName = string.Empty;
            this.AddSetButtonText = AddText;
            this.changes = true;
        }

        public void EditSet()
        {
            this.editingSet = true;
            this.SetName = this.SelectedSet.SetName;
            this.AddSetButtonText = SaveText;
            this.NotifyOfPropertyChange(() => this.CanDeleteSet);
        }

        public void DeleteSet()
        {
            this.Hierarchy.Levels.Remove(this.SelectedSet);
        }

        public void AddLabel()
        {
            if (this.SelectedLabel != null)
            {
                this.editingLabel = false;
                this.SelectedLabel.Name = this.LabelName;
                this.SelectedLabel = null;
            }
            else
            {
                var label = new Label(this.SelectedSet.Labels.Count, this.LabelName, 0, 0, 0);
                this.SelectedSet.Labels.Add(new BindableLabel(label));
                this.SelectedLabel = null;
            }
            this.LabelName = string.Empty;
            this.AddLabelButtonText = AddText;
            this.changes = true;

        }

        public void EditLabel()
        {
            this.editingLabel = true;
            this.LabelName = this.SelectedLabel.Name;
            this.AddLabelButtonText = SaveText;
            this.NotifyOfPropertyChange(() => this.CanDeleteLabel);
        }

        public void DeleteLabel()
        {
            this.SelectedSet.Labels.Remove(this.SelectedLabel);
        }

        public void Accept()
        {
            try
            {
                if (this.changes)
                {
                    var changeHierarchy = new HierarchyChangedViewModel();
                    var result = this.windowManager.ShowDialog(changeHierarchy);
                    if (result.HasValue && result.Value)
                    {
                        Hierarchy modifiedHierarchy = this.Hierarchy.ToHierarchy();
                        this.hierarchyManager.SaveHierarchy(modifiedHierarchy);
                        this.TryClose(true);
                        this.changes = false;
                        this.eventAggregator.PublishOnUIThread(new HierarchyChangedEvent());
                    }
                }
                else
                {
                    this.TryClose(true);
                }
            }
            catch (HierarchyException ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        public void Cancel()
        {
            this.TryClose(false);
            this.changes = false;
        }
    }
}
