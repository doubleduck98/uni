using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace zadanie2._2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindowModel model;

        public MainWindow()
        {
            model = new MainWindowModel();
            DataContext = model;
            InitializeComponent();
        }

        public class MainWindowModel : INotifyPropertyChanged
        {
            private int _sliderValue;
            private int _progressBarValue;
            private string _progressBarValuePercent;
            private readonly ObservableCollection<Element> _elements;

            public event PropertyChangedEventHandler PropertyChanged;

            public int SliderValue
            {
                get => _sliderValue;
                set
                {
                    _sliderValue = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SliderValue"));
                }
            }

            public int ProgressBarValue
            {
                get => _progressBarValue;
                set
                {
                    _progressBarValue = value;
                    ProgressBarValuePercent = value.ToString() + "%";
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProgressBarValue"));
                }
            }

            public string ProgressBarValuePercent
            {
                get => _progressBarValuePercent;
                set
                {
                    _progressBarValuePercent = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProgressBarValuePercent"));
                }
            }

            public ObservableCollection<Element> Elements => _elements;

            public void InvokeElementsChange()
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Elements"));
            }

            public MainWindowModel()
            {
                _sliderValue = 80;
                _progressBarValue = 80;
                _progressBarValuePercent = _progressBarValue.ToString() + "%";
                _elements = new ObservableCollection<Element>()
                {
                    new Element() {El = "Element"},
                    new Element() {El = "Element"}
                };
            }
        }

        public class Element
        {
            public string El { get; set; }

            public override string ToString()
            {
                return El;
            }
        }

        private void LvDodaj(object sender, RoutedEventArgs e)
        {
            model.Elements.Add(new Element() {El = "Nowy element"});
            model.InvokeElementsChange();
        }

        private void PbMinus(object sender, RoutedEventArgs e)
        {
            var next = model.ProgressBarValue - 4;
            if (ProgressBar.Minimum <= next)
            {
                model.ProgressBarValue = next;
            }
            else
            {
                model.ProgressBarValue = (int) ProgressBar.Minimum;
            }
        }

        private void PbPlus(object sender, RoutedEventArgs e)
        {
            var next = model.ProgressBarValue + 4;
            if (ProgressBar.Maximum >= next)
            {
                model.ProgressBarValue = next;
            }
            else
            {
                model.ProgressBarValue = (int) ProgressBar.Maximum;
            }
        }
    }
}