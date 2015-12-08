//using System.Collections.Generic;
//using BizVal.App.Model;
//using Caliburn.Micro;

//namespace BizVal.App.ViewModels
//{

//    public class SliderViewModel : PropertyChangedBase
//    {
//        private readonly Hierarchy modelScales;

//        private TermSet selectedScale;

//        private int selectedValue;

//        private int selectedScaleIndex;

//        public int MinValue
//        {
//            get
//            {
//                return 0;
//            }
//        }

//        public int MaxValue
//        {
//            get
//            {
//                return this.selectedScale.Terms.Count - 1;
//            }
//        }

//        public int SelectedValue
//        {
//            get
//            {
//                return this.selectedValue;
//            }

//            set
//            {
//                this.selectedValue = value;
//                this.NotifyOfPropertyChange(() => this.SelectedValueText);
//            }
//        }

//        public string SelectedValueText
//        {
//            get
//            {
//                return this.selectedScale.Terms[this.selectedValue];
//            }
//        }

//        public IEnumerable<TermSet> Scales
//        {
//            get
//            {
//                return this.modelScales.TermSets;
//            }
//        }

//        public int SelectedScale
//        {
//            get
//            {
//                return this.selectedScaleIndex;
//            }

//            set
//            {
//                this.selectedScaleIndex = value;
//                this.selectedScale = this.modelScales.TermSets[this.selectedScaleIndex];
//                this.NotifyOfPropertyChange(() => this.SelectedScale);
//                this.NotifyOfPropertyChange(() => this.SelectedValueText);
//                this.NotifyOfPropertyChange(() => this.MaxValue);
//            }
//        }

//        public string SelectedScaleName
//        {
//            get
//            {
//                return this.selectedScale.Name;
//            }
//        }

//        //public SliderViewModel()
//        //{
//        //    var scale1 = new TermSet();
//        //    scale1.Name = "s1";
//        //    scale1.Terms = new List<string>();
//        //    scale1.Terms.Add("termino11");
//        //    scale1.Terms.Add("termino12");
//        //    scale1.Terms.Add("termino13");

//        //    var scale2 = new TermSet();
//        //    scale2.Name = "S2";
//        //    scale2.Terms = new List<string>();
//        //    scale2.Terms.Add("termino21");
//        //    scale2.Terms.Add("termino22");
//        //    scale2.Terms.Add("termino23");
//        //    scale2.Terms.Add("termino24");
//        //    scale2.Terms.Add("termino25");

//        //    this.modelScales = new Hierarchy();
//        //    this.modelScales.TermSets = new List<TermSet>();
//        //    this.modelScales.TermSets.Add(scale1);
//        //    this.modelScales.TermSets.Add(scale2);

//        //    this.SelectedScale = 0;
//        //}
//    }
//}
