using MeasuresConverter.Managers;
using MeasuresConverter.Models;
using MeasuresConverter.MVVMEngine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MeasuresConverter
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<MeasureGroup> MeasuresGroups { get; set; }

        private MeasureGroup _SelectedMeasuresGroup;
        public MeasureGroup SelectedMeasuresGroup
        {
            get { return _SelectedMeasuresGroup; }
            set
            {
                if (_SelectedMeasuresGroup != value)
                {
                    _SelectedMeasuresGroup = value;
                    RaisePropertyChanged("SelectedMeasuresGroup");
                    ResetSourceMeasureValue();
                    ResetTargetMeasureValue();
                }
            }
        }

        private Measure _SelectedSourceMeasure;
        public Measure SelectedSourceMeasure
        {
            get { return _SelectedSourceMeasure; }
            set
            {
                if (_SelectedSourceMeasure != value)
                {
                    _SelectedSourceMeasure = value;
                    RaisePropertyChanged("SelectedSourceMeasure");
                    ResetSourceMeasureValue();
                }
            }
        }

        private Measure _SelectedTargetMeasure;
        public Measure SelectedTargetMeasure
        {
            get { return _SelectedTargetMeasure; }
            set
            {
                if (_SelectedTargetMeasure != value)
                {
                    _SelectedTargetMeasure = value;
                    RaisePropertyChanged("SelectedTargetMeasure");
                    ResetTargetMeasureValue();
                }
            }
        }

        private string _SourceMeasureValue;
        public string SourceMeasureValue
        {
            get { return _SourceMeasureValue; }
            set 
            {
                if (_SourceMeasureValue != value)
                {
                    _SourceMeasureValue = value;
                    RaisePropertyChanged("SourceMeasureValue");
                    ConvertMeasure(value);
                }
            }
        }

        private string _TargetMeasureValue;
        public string TargetMeasureValue
        {
            get { return _TargetMeasureValue; }
            set
            {
                if (_TargetMeasureValue != value)
                {
                    _TargetMeasureValue = value;
                    RaisePropertyChanged("TargetMeasureValue");
                }
            }
        }

        private void ConvertMeasure(string stringValue)
        {
            double doubleValue;
            if (!double.TryParse(stringValue, out doubleValue))
                return;

            var convension = SelectedMeasuresGroup.Conversions.FirstOrDefault(c => c.SourceId == SelectedSourceMeasure.Id && c.TargerId == SelectedTargetMeasure.Id);
            if (convension != null)
            {
                var lc = new LinearConverter(convension.Factor, convension.Deltha);
                TargetMeasureValue = lc.Convert(doubleValue).ToString();
            }
            else
            {
                convension = SelectedMeasuresGroup.Conversions.FirstOrDefault(c => c.SourceId == SelectedTargetMeasure.Id && c.TargerId == SelectedSourceMeasure.Id);
                if (convension != null)
                {
                    var lc = new LinearConverter(convension.Factor, convension.Deltha).Inverse;
                    TargetMeasureValue = lc.Convert(doubleValue).ToString();
                }
                else if (SelectedTargetMeasure.Id == SelectedSourceMeasure.Id)
                {
                    TargetMeasureValue = SourceMeasureValue;
                }
            }
        }

        private void ResetSourceMeasureValue()
        {
            this.SourceMeasureValue = "";
        }

        private void ResetTargetMeasureValue()
        {
            this.TargetMeasureValue = "";
        }

        private ICommand _SelectMeasureGroupCommand;
        public ICommand SelectMeasureGroupCommand
        {
            get
            {
                if (_SelectMeasureGroupCommand == null)
                    _SelectMeasureGroupCommand = new RelayCommand(arg =>
                    {
                        var measuresGroup = arg as MeasureGroup;
                        if (measuresGroup == null)
                            return;

                        SelectedMeasuresGroup = measuresGroup;
                        ResetSourceMeasureValue();
                        ResetTargetMeasureValue();
                        SelectedSourceMeasure = null;
                        SelectedTargetMeasure = null;
                    });
                return _SelectMeasureGroupCommand;
            }
        }

        private ICommand _SelectSourceMeasureCommand;
        public ICommand SelectSourceMeasureCommand
        {
            get
            {
                if (_SelectSourceMeasureCommand == null)
                    _SelectSourceMeasureCommand = new RelayCommand(arg =>
                    {
                        var measure = arg as Measure;
                        if (measure == null)
                            return;

                        SelectedSourceMeasure = measure;
                        ConvertMeasure(SourceMeasureValue);
                    });
                return _SelectSourceMeasureCommand;
            }
        }

        private ICommand _SelectTargetMeasureCommand;
        public ICommand SelectTargetMeasureCommand
        {
            get
            {
                if (_SelectTargetMeasureCommand == null)
                    _SelectTargetMeasureCommand = new RelayCommand(arg =>
                    {
                        var measure = arg as Measure;
                        if (measure == null)
                            return;

                        SelectedTargetMeasure = measure;
                        ConvertMeasure(SourceMeasureValue);
                    });
                return _SelectTargetMeasureCommand;
            }
        }

        public MainWindowViewModel()
        {
            this.MeasuresGroups = new ObservableCollection<MeasureGroup>();

            try
            {
                var measuresTable = XMLManager.GetXMLFromFile<XMLEntities.MeasuresTable>("MeasuresTable.xml");
                foreach (var measureGroup in measuresTable.MeasureGroups)
                    this.MeasuresGroups.Add(new MeasureGroup(measureGroup));
            }
            catch
            {
                MessageBox.Show("XML Corrupted");
            }
        }
    }
}
