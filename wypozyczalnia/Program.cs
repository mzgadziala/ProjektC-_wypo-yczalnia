using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{
    class Program
    {
        static void Main(string[] args)
        {
            //dodanie samochodów
            SamochodOsobowy so1 = new SamochodOsobowy("Renault", "Clio", "2010", Silniki.Benzyna, Skrzynie.Manualna, 5.4, 120.0, 5);
            SamochodOsobowy so2 = new SamochodOsobowy("Toyota", "yaris", "2014", Silniki.Diesel, Skrzynie.Manualna, 6.1, 100.0, 4);
            SamochodOsobowy so3 = new SamochodOsobowy("Skoda", "Octavia", "2016", Silniki.BenzynaTSI, Skrzynie.Automatyczna, 5.9, 140.5, 5);
            SamochodOsobowy so4 = new SamochodOsobowy("Ford", "Mondeo", "2013", Silniki.Diesel3, Skrzynie.Automatyczna, 6.0, 150.0, 5);
            SamochodOsobowy so5 = new SamochodOsobowy("Peugeot", "508", "2015", Silniki.Diesel, Skrzynie.Manualna, 5.4, 165.0, 5);

            SamochodDostawczy sd1 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);
            SamochodDostawczy sd2 = new SamochodDostawczy("Renault", "Trafic", "2017", Silniki.Benzyna, Skrzynie.Automatyczna, 8.2, 350.0, 2250);
            SamochodDostawczy sd3 = new SamochodDostawczy("Peugeot", "Partner", "2015", Silniki.Benzyna, Skrzynie.Automatyczna, 6.7, 400.0, 800);
            SamochodDostawczy sd4 = new SamochodDostawczy("Ford", "Transit", "2000", Silniki.Diesel, Skrzynie.Manualna, 7.0, 300.0, 420);
            SamochodDostawczy sd5 = new SamochodDostawczy("Citroen", "Berlingo", "2014", Silniki.Benzyna, Skrzynie.Automatyczna, 9.0, 370.0, 390);

            Osobowe osobowe = new Osobowe();
            osobowe.dodajSamochod(so1);
            osobowe.dodajSamochod(so2);
            osobowe.dodajSamochod(so3);
            osobowe.dodajSamochod(so4);
            osobowe.dodajSamochod(so5);

            Dostawcze dostawcze = new Dostawcze();
            dostawcze.dodajSamochod(sd1);
            dostawcze.dodajSamochod(sd2);
            dostawcze.dodajSamochod(sd3);
            dostawcze.dodajSamochod(sd4);
            dostawcze.dodajSamochod(sd5);

            //stworzenie przykładowych klientów
            Klient k1 = new Klient("Jan", "Kot", "567345234", "jankot@gmail.com", "45674567456745678", "10/23", "789");
            Klient k2 = new Klient("Anna", "Nowak", "142756243", "annowak@wp.pl", "75847362548924235", "07/24", "332");
            Klient k3 = new Klient("Tomasz", "Kowalski", "142876243", "kowk@wp.pl", "75847362548924123", "07/20", "331");

            //dodanie kilku wypożyczeń
            Wypozyczenie w1 = new Wypozyczenie(Miasta.Kraków, Miasta.Warszawa, "12-05-2020", "16-05-2020", k1, so1);
            Wypozyczenie w2 = new Wypozyczenie(Miasta.Łódź, Miasta.Szczecin, "10-05-2020", "15-05-2020", k2, so2);
            Wypozyczenie w3 = new Wypozyczenie(Miasta.Warszawa, Miasta.Łódź, "14-05-2020", "15-05-2020", k3, sd1);

            ListaWypozyczen wypozyczenia = new ListaWypozyczen();
            wypozyczenia.dodaj(w1);
            wypozyczenia.dodaj(w2);
            wypozyczenia.dodaj(w3);

            //żeby wypisać dostepne osobowe
            var listaDostepnych = osobowe.pokazDostepne(wypozyczenia, "13-05-2020", "14-05-2020");
            int ile = listaDostepnych.Count();

            StringBuilder sb = new StringBuilder();
            foreach (SamochodOsobowy samOs in listaDostepnych)
            {
                sb.AppendLine(samOs.ToString());
            }

            //żeby wypisać dostepne dostawcze
            var listaDostepnychDost = dostawcze.pokazDostepne(wypozyczenia, "13-05-2020", "14-05-2020");

            StringBuilder sb2 = new StringBuilder();

            foreach (SamochodDostawczy samDost in listaDostepnychDost)
            {
                sb2.AppendLine(samDost.ToString());
            }

            //wypisanie dostepnych os i dost
            //Console.WriteLine(sb);
            //Console.WriteLine(ile);
            //Console.WriteLine(sb2);

            ListaWypozyczen.ZapiszXML("lista1.xml", wypozyczenia);
            Osobowe.ZapiszXML("osobowe1.xml", osobowe);
            Dostawcze.ZapiszXML("dostawcze1.xml", dostawcze);
            //Osobowe ooo = Osobowe.OdczytajXML("osobowe1.xml");
            //Console.WriteLine(ooo);

            //ListaWypozyczen lista1 = ListaWypozyczen.OdczytajXML("lista1.xml");
            Console.WriteLine(w1.kosztWypozyczenia());


            Console.ReadKey();
        }
    }
}
