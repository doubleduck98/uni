using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace zadanie2._5._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainWindowModel _model;

        public MainWindow()
        {
            _model = new MainWindowModel();
            DataContext = _model;
            InitializeComponent();
        }

        public class MainWindowModel : INotifyPropertyChanged
        {
            private Student _selected;
            private ObservableCollection<Student> _studenci;
            public event PropertyChangedEventHandler PropertyChanged;
            private const string Cs = @"server=.\sqlexpress;database=example;integrated security=true";

            public ObservableCollection<Student> Studenci => _studenci;

            public Student Selected
            {
                get => _selected;
                set
                {
                    if (value != _selected)
                    {
                        _selected = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Selected"));
                    }
                }
            }

            public MainWindowModel()
            {
                _studenci = new ObservableCollection<Student>();
                _selected = new Student();
                InitCollection();
            }

            private void InitCollection()
            {
                using (var db = new StudenciDataContext(Cs))
                {
                    var query = from s in db.Student select s;
                    _studenci = new ObservableCollection<Student>(query.ToList());
                }
            }

            public void AddDummy()
            {
                using (var db = new StudenciDataContext(Cs))
                {
                    var nstud = new Student()
                    {
                        Imię = "Tester",
                        Nazwisko = "Testowy",
                        DataUrodzenia = DateTime.Now
                    };
                    db.Student.InsertOnSubmit(nstud);
                    db.SubmitChanges();
                    db.SubmitChanges();

                    _studenci.Add(nstud);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Studenci"));
                }
            }

            public void RemoveSelected()
            {
                if (_selected == null) return;
                using (var db = new StudenciDataContext(Cs))
                {
                    var id = _selected.id;
                    Studenci.Remove(_selected);
                    var query = db.Student.Where(s => id == s.id).ToList();
                    foreach (var student in query)
                    {
                        db.Student.DeleteOnSubmit(student);
                    }

                    db.SubmitChanges();
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Selected"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Studenci"));
            }
        }

        private void ButtonAdd(object sender, RoutedEventArgs e)
        {
            _model.AddDummy();
        }

        private void ButtonRemove(object sender, RoutedEventArgs e)
        {
            _model.RemoveSelected();
        }
    }
}