using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wypozyczalnia;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Trzecie.xaml
    /// </summary>
    public partial class Trzecie : Page
    {
        
        Miasta miastoOdbioru;
        Miasta miastoZwrotu;
        string dataOdbioru;
        string dataZwrotu;
        Pojazd wybrany;
        public double dodatki;
        public double cenaCalkowita=0.0;
        public Trzecie()
        {
            InitializeComponent();

        }

        public ObservableCollection<string> Names { get; set; }

        public Trzecie(Pojazd wybrany, string dataOdbioru, string dataZwrotu, Miasta miastoOdbioru, Miasta miastoZwrotu)
        {
            
            this.wybrany = wybrany;
            this.miastoOdbioru = miastoOdbioru;
            this.miastoZwrotu = miastoZwrotu;
            this.dataOdbioru = dataOdbioru;
            this.dataZwrotu = dataZwrotu;
            InitializeComponent();
            DataContext = this;
            List<Pojazd> wybrany1;
            wybrany1 = new List<Pojazd>();
            wybrany1.Add(wybrany);
            listBox_konkretneauto.ItemsSource = wybrany1;

            //if (CheckBox_gps.IsChecked == true)
            //{

            //    this.dodatki = this.dodatki + Wypozyczenie.gps;
            //}
            //if (CheckBox_lancuch.IsChecked == true)
            //{
            //    this.dodatki = this.dodatki + Wypozyczenie.lancuchy;
            //}
            //if (CheckBox_fotelik.IsChecked == true)
            //{
            //    this.dodatki = this.dodatki + Wypozyczenie.fotelik;
            //}
            //if (CheckBox_wyjazd.IsChecked == true)
            //{
            //    this.dodatki = this.dodatki + Wypozyczenie.wyjazdZaGranice;
            //}


            DateTime data1 = DateTime.Parse(dataOdbioru);
            DateTime data2 = DateTime.Parse(dataZwrotu);


            if (wybrany.GetType() == typeof(SamochodOsobowy))
            {
                cenaCalkowita = wybrany.Cena * Convert.ToDouble((data2 - data1).TotalDays) + SamochodOsobowy.KaucjaZwrotna + dodatki;
            }
            else
                cenaCalkowita = wybrany.Cena * Convert.ToDouble((data2 - data1).TotalDays) + SamochodDostawczy.KaucjaZwrotna + SamochodDostawczy.OplataDodatkowa + dodatki;

        }

        private void Button_dalej_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox_gps.IsChecked == true)
            {

                dodatki = dodatki + Wypozyczenie.gps;
            }
            if (CheckBox_lancuch.IsChecked == true)
            {
                dodatki = dodatki + Wypozyczenie.lancuchy;
            }
            if (CheckBox_fotelik.IsChecked == true)
            {
                dodatki = dodatki + Wypozyczenie.fotelik;
            }
            if (CheckBox_wyjazd.IsChecked == true)
            {
                dodatki = dodatki + Wypozyczenie.wyjazdZaGranice;
            }

            Czwarte czwarte = new Czwarte(wybrany, dataOdbioru, dataZwrotu, miastoOdbioru, miastoZwrotu, dodatki, cenaCalkowita);
            this.NavigationService.Navigate(czwarte);

        }

        private void Label_wynajem_Loaded(object sender, RoutedEventArgs e)
        {
            Label_wynajem.Content = wybrany.Cena;
        }

        private void Label_kaucja_Loaded(object sender, RoutedEventArgs e)
        {
            if(wybrany.GetType() == typeof(SamochodOsobowy))
            {
                Label_kaucja.Content = SamochodOsobowy.KaucjaZwrotna;
            }
            else
            Label_kaucja.Content = SamochodDostawczy.KaucjaZwrotna;
        }

        private void Label_oplata_Loaded(object sender, RoutedEventArgs e)
        {
            if (wybrany.GetType() == typeof(SamochodOsobowy))
            {
                Label_oplata.Content = 0;
            }
            else
                Label_oplata.Content = SamochodDostawczy.OplataDodatkowa;

        }

    private void Label_suma_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime data1 = DateTime.Parse(dataOdbioru);
            DateTime data2 = DateTime.Parse(dataZwrotu);
            
            
            if (wybrany.GetType() == typeof(SamochodOsobowy))
            {
                Label_suma.Content = wybrany.Cena * Convert.ToDouble((data2 - data1).TotalDays) + SamochodOsobowy.KaucjaZwrotna+ dodatki;
            }
            else
                Label_suma.Content = wybrany.Cena * Convert.ToDouble((data2 - data1).TotalDays) + SamochodDostawczy.KaucjaZwrotna+ SamochodDostawczy.OplataDodatkowa+ dodatki;
            
        }
        private void Label_suma_refresh(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
