using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace zadanie2._2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();
            InitializeComponent();
        }

        public class MainWindowModel
        {
            public List<Studia> Items =>
                new List<Studia>
                {
                    new Studia() {Rodzaj = "3-letnie licencjackie"},
                    new Studia() {Rodzaj = "3.5-letnie inżynierskie"},
                    new Studia() {Rodzaj = "1.5-letnie magisterskie"},
                    new Studia() {Rodzaj = "2-letnie magisterskie"},
                    new Studia() {Rodzaj = "5-letnie magisterskie"}
                };
        }

        public class Studia
        {
            public string Rodzaj { get; set; }
            public override string ToString()
            {
                return Rodzaj;
            }
        }

        private void Akceptuj(object sender, RoutedEventArgs e)
        {
            var message = new StringBuilder();
            const string caption = "Uczelnia";
            message.Append($"{Nazwa.Text}\n");
            message.Append($"{Adres.Text}\n");
            message.Append($"{Cykl.SelectionBoxItem}\n");
            if (Dzienne.IsChecked == true)
            {
                message.Append($"{Dzienne.Content} ");
            }
            if (Uzu.IsChecked == true)
            {
                message.Append($"{Uzu.Content}");
            }

            MessageBox.Show(message.ToString(), caption, MessageBoxButton.OK);
        }

        private void Wyjdz(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}