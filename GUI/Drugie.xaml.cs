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
    public partial class Drugie : Page
    {

        bool typ;
        Miasta miastoOdbioru;
        Miasta miastoZwrotu;
        string dataOdbioru;
        string dataZwrotu;

        List<SamochodOsobowy> dostepne;
        List<SamochodDostawczy> dostepneDost;
        //ObservableCollection<SamochodDostawczy> dostepneDostawcze;

        //ListaWypozyczen wypozyczenia = new ListaWypozyczen();
        //Osobowe osobowe;
        


        //public Drugie()
        //{
        //    InitializeComponent();
        //    DataContext = this;
        //    //wypozyczenia = ListaWypozyczen.OdczytajXML("lista1.xml");
        //    //osobowe = Osobowe.OdczytajXML("osobowe1.xml");
        //}
        public ObservableCollection<string> Names { get; set; }
        public Drugie()
        {

            InitializeComponent();

        }
        public Drugie(bool typ, string dataOdbioru, string dataZwrotu, Miasta miastoOdbioru, Miasta miastoZwrotu)
        {

            ListaWypozyczen wypozyczenia = ListaWypozyczen.OdczytajXML("lista1.xml");
            Osobowe osobowe = Osobowe.OdczytajXML("osobowe1.xml");
            Dostawcze dostawcze = Dostawcze.OdczytajXML("dostawcze1.xml");
            //dostepne = new List<SamochodOsobowy>(osobowe.wszystkieOsobowe);
            InitializeComponent();
            DataContext = this;
            this.typ = typ;
            this.miastoOdbioru = miastoOdbioru;
            this.miastoZwrotu = miastoZwrotu;
            this.dataOdbioru = dataOdbioru;
            this.dataZwrotu = dataZwrotu;

            if (typ == true)
            {
                dostepne = new List<SamochodOsobowy>(osobowe.pokazDostepne(wypozyczenia, dataOdbioru, dataZwrotu));
                listBox_auta.ItemsSource = dostepne;
            }
            else
            {
                dostepneDost = new List<SamochodDostawczy>(dostawcze.pokazDostepne(wypozyczenia, dataOdbioru, dataZwrotu));
                listBox_auta.ItemsSource = dostepneDost;
            }

        }

        private void Button_dalej_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DataContext = this;
            Pojazd wybrany = (Pojazd)listBox_auta.SelectedItem;
            Trzecie trzecie = new Trzecie(wybrany, dataOdbioru, dataZwrotu, miastoOdbioru, miastoZwrotu);
            this.NavigationService.Navigate(trzecie);
        }

        private void Label_liczba_Loaded(object sender, RoutedEventArgs e)
        {
            if (typ == true)
            {
                Label_liczba.Content = dostepne.Count();
            }
            else
            {
                Label_liczba.Content = dostepneDost.Count();
            }
            
            //trzeba dodac zmienną wyswietlajaca liczbe znalezionych aut - ile
        }

        //private void listBox_auta_Loaded(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
