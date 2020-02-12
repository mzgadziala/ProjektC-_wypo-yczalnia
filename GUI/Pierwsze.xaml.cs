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
using System.Windows.Forms;
using wypozyczalnia;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy Pierwsze.xaml
    /// </summary>
    public partial class Pierwsze : Page
    {
        //ListaWypozyczen wypozyczenia = new ListaWypozyczen();
        //Osobowe osobowe = new Osobowe();
        
        //List<SamochodOsobowy> osobowe1 = new List <SamochodOsobowy>();

        public Pierwsze()
        {
            InitializeComponent();
            //wypozyczenia = ListaWypozyczen.OdczytajXML("lista1.xml");
            //osobowe = Osobowe.OdczytajXML("osobowe1.xml");
        }

        public void Button_check_Click(object sender, RoutedEventArgs e)
        {
            Miasta miastoOdbioru = Miasta.Kraków;
            Miasta miastoZwrotu = Miasta.Kraków;
            bool typ;

            if (ComboBox_odbior.Text == "Warszawa")
                miastoOdbioru = Miasta.Warszawa;
            else if (ComboBox_odbior.Text == "Kraków")
                miastoOdbioru = Miasta.Kraków;
            else if (ComboBox_odbior.Text == "Wrocław")
                miastoOdbioru = Miasta.Wrocław;
            else if (ComboBox_odbior.Text == "Łódź")
                miastoOdbioru = Miasta.Łódź;
            else if (ComboBox_odbior.Text == "Gdańsk")
                miastoOdbioru = Miasta.Gdańsk;
            else if (ComboBox_odbior.Text == "Katowice")
                miastoOdbioru = Miasta.Katowice;
            else if (ComboBox_odbior.Text == "Szczecin")
                miastoOdbioru = Miasta.Szczecin;
            else if (ComboBox_odbior.Text == "Bydgoszcz")
                miastoOdbioru = Miasta.Bydgoszcz;
            else if (ComboBox_odbior.Text == "Toruń")
                miastoOdbioru = Miasta.Toruń;
            else if (ComboBox_odbior.Text == "Lublin")
                miastoOdbioru = Miasta.Lublin;
            else if (ComboBox_odbior.Text == "Poznań")
                miastoOdbioru = Miasta.Poznań;
            else if (ComboBox_odbior.Text == "Rzeszów")
                miastoOdbioru = Miasta.Rzeszów;

            if (ComboBox_zwrot.Text == "Warszawa")
                miastoZwrotu = Miasta.Warszawa;
            else if (ComboBox_zwrot.Text == "Kraków")
                miastoZwrotu = Miasta.Kraków;
            else if (ComboBox_zwrot.Text == "Wrocław")
                miastoZwrotu = Miasta.Wrocław;
            else if (ComboBox_zwrot.Text == "Łódź")
                miastoZwrotu = Miasta.Łódź;
            else if (ComboBox_zwrot.Text == "Gdańsk")
                miastoZwrotu = Miasta.Gdańsk;
            else if (ComboBox_zwrot.Text == "Katowice")
                miastoZwrotu = Miasta.Katowice;
            else if (ComboBox_zwrot.Text == "Szczecin")
                miastoZwrotu = Miasta.Szczecin;
            else if (ComboBox_zwrot.Text == "Bydgoszcz")
                miastoZwrotu = Miasta.Bydgoszcz;
            else if (ComboBox_zwrot.Text == "Toruń")
                miastoZwrotu = Miasta.Toruń;
            else if (ComboBox_zwrot.Text == "Lublin")
                miastoZwrotu = Miasta.Lublin;
            else if (ComboBox_zwrot.Text == "Poznań")
                miastoZwrotu = Miasta.Poznań;
            else if (ComboBox_zwrot.Text == "Rzeszów")
                miastoZwrotu = Miasta.Rzeszów;


            DateTime? odbior = DataGrid_odbior.SelectedDate;
            DateTime? zwrot = DataGrid_zwrot.SelectedDate;
            while (String.IsNullOrEmpty(odbior.ToString()) == true || String.IsNullOrEmpty(zwrot.ToString()) == true)
            {
                System.Windows.MessageBox.Show("Musisz wybrać datę obioru oraz datę zwrotu!");
                if (MessageBoxButton.OK == 0) { break; }
            }

            int result = DateTime.Compare(Convert.ToDateTime(zwrot), Convert.ToDateTime(odbior));
            int czyodbior = DateTime.Compare(Convert.ToDateTime(odbior), DateTime.Now);
            int czyzwrot = DateTime.Compare(Convert.ToDateTime(zwrot), DateTime.Now);
            while (czyodbior <= 0)
            {

                System.Windows.MessageBox.Show("Data odbioru nie może być wcześniejsza niż data dzisiejsza!");
                if (MessageBoxButton.OK == 0) { break; }
            }
            while (czyzwrot <= 0)
            {

                System.Windows.MessageBox.Show("Data zwrotu nie może być wcześniejsza niż data dzisiejsza!");
                if (MessageBoxButton.OK == 0) { break; }
            }
            while (result <= 0)
            {

                System.Windows.MessageBox.Show("Data zwrotu nie może być wcześniejsza niż data odbioru!");
                if (MessageBoxButton.OK == 0) { break; }

            }
            if (radiobutton_osobowe.IsChecked == true)
            {
                typ = true;
            }
            else typ = false;
            while (String.IsNullOrEmpty(ComboBox_odbior.Text) == true || String.IsNullOrEmpty(ComboBox_zwrot.Text) == true)
            {
                System.Windows.MessageBox.Show("Musisz wybrać miejsce obioru oraz miejsce zwrotu!");
                if (MessageBoxButton.OK == 0) { break; }
            }

            if (result > 0 && String.IsNullOrEmpty(ComboBox_odbior.Text) == false && String.IsNullOrEmpty(ComboBox_zwrot.Text) == false &&
                String.IsNullOrEmpty(odbior.ToString()) == false && String.IsNullOrEmpty(zwrot.ToString()) == false && czyodbior > 0 && czyzwrot > 0)
            {
                string odbior2 = odbior.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                string zwrot2 = zwrot.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Drugie drugie = new Drugie(typ, odbior2, zwrot2, miastoOdbioru, miastoZwrotu);
                //Drugie drugie = new Drugie();
                this.NavigationService.Navigate(drugie);
            }
        }


        private void radiobutton_osobowe_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void radiobutton_dostawcze_Loaded(object sender, RoutedEventArgs e)
        {

        }


        //List<SamochodOsobowy> listaDostepnych = new List<SamochodOsobowy>(osobowe.pokazDostepne(wypozyczenia, odbior2, zwrot2));
        ////var listaDostepnych = osobowe.pokazDostepne(wypozyczenia, odbior2, zwrot2);
        
    }
}
