using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy Czwarte.xaml
    /// </summary>
    public partial class Czwarte : Page
    {
        Miasta miastoOdbioru;
        Miasta miastoZwrotu;
        string dataOdbioru;
        string dataZwrotu;
        Pojazd wybrany;
        double dodatki = 0.0;
        double cenaCalkowita = 0.0;
        public string imie;
        public string nazwisko;
        public string numerTelefonu;
        public string adresEmail;
        public string numerKarty;
        public string waznoscKarty;
        public string kodZabazpieczajacy;
        public Czwarte()
        {
            InitializeComponent();
        }
        public Czwarte(Pojazd wybrany, string dataOdbioru, string dataZwrotu, Miasta miastoOdbioru, Miasta miastoZwrotu, double dodatki, double cenaCalkowita)
        {
            this.wybrany = wybrany;
            this.miastoOdbioru = miastoOdbioru;
            this.miastoZwrotu = miastoZwrotu;
            this.dataOdbioru = dataOdbioru;
            this.dataZwrotu = dataZwrotu;
            this.dodatki = dodatki;
            this.cenaCalkowita = cenaCalkowita;
            InitializeComponent();
        }

        private void Button_zarezerwuj_Click(object sender, RoutedEventArgs e)
        {
            this.imie = textBox_imie.Text;
            this.nazwisko = textBox_nazwisko.Text;
            this.adresEmail = textBox_meil.Text;
            this.numerTelefonu = textBox_telefon.Text;
            this.numerKarty = textBox_karta.Text;
            this.waznoscKarty = textBox_waznosc.Text;
            this.kodZabazpieczajacy = textBox_kod.Text;
            int result1 = numerKarty.Length;
            while (String.IsNullOrEmpty(imie) == true || String.IsNullOrEmpty(nazwisko) == true || String.IsNullOrEmpty(adresEmail) == true
                || String.IsNullOrEmpty(numerTelefonu) == true || String.IsNullOrEmpty(numerKarty) == true
                || String.IsNullOrEmpty(waznoscKarty) == true || String.IsNullOrEmpty(kodZabazpieczajacy) == true)
            {
                MessageBox.Show("Proszę o wypełnienie wszystkich pól!");
                if (MessageBoxButton.OK == 0) { break; }
            }
            while (checkbox_lata.IsChecked == false || checkbox_prawojazdy.IsChecked == false || checkbox_regulamin.IsChecked == false)
            {
                
                MessageBox.Show("Proszę o zaznaczenie wymaganych zgód!");
                if(MessageBoxButton.OK == 0) { break; }
                
               
            }
            while (result1 != 16)
            {

                System.Windows.MessageBox.Show("Numer karty musi zawierać 16 cyfr!");
                if (MessageBoxButton.OK == 0) { break; }

            }
            if (checkbox_lata.IsChecked == true && checkbox_prawojazdy.IsChecked == true && checkbox_regulamin.IsChecked == true && result1 == 16 &&
                String.IsNullOrEmpty(imie) == false && String.IsNullOrEmpty(nazwisko) == false && String.IsNullOrEmpty(adresEmail) == false
                && String.IsNullOrEmpty(numerTelefonu) == false && String.IsNullOrEmpty(numerKarty) == false
                && String.IsNullOrEmpty(waznoscKarty) == false && String.IsNullOrEmpty(kodZabazpieczajacy) == false)
            {
                ListaWypozyczen wypozyczeniaOdczytane = ListaWypozyczen.OdczytajXML("lista1.xml");
                Klient klient = new Klient(imie, nazwisko, numerTelefonu, adresEmail, numerKarty, waznoscKarty, kodZabazpieczajacy);
                Wypozyczenie noweWypozyczenie = new Wypozyczenie(miastoOdbioru, miastoZwrotu, dataOdbioru, dataZwrotu, klient, wybrany);
                wypozyczeniaOdczytane.dodaj(noweWypozyczenie);
                ListaWypozyczen.ZapiszXML("lista1.xml", wypozyczeniaOdczytane);
                Piąte piąte = new Piąte();
                this.NavigationService.Navigate(piąte);
            }
        }

        private void Label_calkowity_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime data1 = DateTime.Parse(dataOdbioru);
            DateTime data2 = DateTime.Parse(dataZwrotu);


            if (wybrany.GetType() == typeof(SamochodOsobowy))
            {
                Label_calkowity.Content = cenaCalkowita+ dodatki;
            }
            else
                Label_calkowity.Content = cenaCalkowita+ dodatki;
        }
    }
}
