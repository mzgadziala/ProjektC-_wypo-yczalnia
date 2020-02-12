using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wypozyczalnia
{

    /// <summary>
    /// Publiczna klasa działająca na liście samochodów dostawczych, implementuje interfejs ICloneable
    /// </summary>
    [Serializable]
    public class Dostawcze:ICloneable
    {

        /// <summary>Liczba samochodów dostawczych</summary>
        public int liczbaDostawczych;

        /// <summary>Lista wszystkixg samochodów dostawczych</summary>
        public List<SamochodDostawczy> wszystkieDostawcze;

        /// <summary>Lista dostepnych samochodów dostawczych</summary>
        public List<SamochodDostawczy> dostepneDostawcze;


        /// <summary>Initializowanie podczas tworzenia nowego obiektu klasy<see cref="Dostawcze"/> class.</summary>
        public Dostawcze()
        {
            liczbaDostawczych = 0;
            wszystkieDostawcze = new List<SamochodDostawczy>();
        }

        /// <summary> Dodawanie obiektu Samochod Dostawczy do listy.</summary>
        /// <param name="s"> obiekt Samochód Dostawczy do dodania</param>
        public void dodajSamochod(SamochodDostawczy s)
        {
            liczbaDostawczych++;
            wszystkieDostawcze.Add(s);
        }


        /// <summary>Sprawdzenie czy Samochód Dostawczy jest na liście</summary>
        /// <param name="c">  obiekt Samochód Dostawczy</param>
        /// <returns>Wybrany Samochd Dostawczy nie jest dostępny</returns>
        public bool jestWInwentarzu(SamochodDostawczy c)
        {
            foreach (SamochodDostawczy s in wszystkieDostawcze)
            {
                if (s.Equals(c)) return true;
            }
            return false;
        }

        /// <summary>Usunięcie Samochodu Dostawczego z listy, jeśli jest on dostępny.</summary>
        /// <param name="p">  Obiekt Samochd Dostawczy do usunięcia</param>
        public void UsunSamochod(SamochodDostawczy p)
        {
            if (jestWInwentarzu(p))
            {
                wszystkieDostawcze.Remove(p);
            }
        }

        /// <summary>Generowanie listy dostępnych wypożyczeń w danym czasie</summary>
        /// <param name="lista">  Lista Wypożyczen</param>
        /// <param name="dataOdbioru">  Data odbioru samochodu</param>
        /// <param name="dataZwrotu">  Data zwrotu samochodu</param>
        /// <returns>Lista dostępnych Samochodów Dostawczych</returns>
        public List<SamochodDostawczy> pokazDostepne(ListaWypozyczen lista, string dataOdbioru, string dataZwrotu)
        {
            DateTime odbior = DateTime.Parse(dataOdbioru);
            DateTime zwrot = DateTime.Parse(dataZwrotu);
            dostepneDostawcze = new List<SamochodDostawczy>(wszystkieDostawcze);

            foreach (SamochodDostawczy s in wszystkieDostawcze)
            {
                foreach (Wypozyczenie w in lista.listaWypozyczen)
                {
                    if (s == w.Sd && ((zwrot > w.DataOdbioru && odbior < w.DataOdbioru) ||
                        (odbior < w.DataZwrotu && zwrot > w.DataZwrotu) || (odbior > w.DataOdbioru && zwrot < w.DataZwrotu)))
                    {
                        dostepneDostawcze.Remove(s);
                    }
                }
            }
            return dostepneDostawcze;
        }

        /// <summary>Konwersja do Stringa.</summary>
        /// <returns>Zwraca opis wszystkich Samochodów Dostawczych z listy <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (SamochodDostawczy s in wszystkieDostawcze)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }
        /// <summary>  Zapisywanie do pliku XML obiektu klasy Dostawcze</summary>
        /// <param name="nazwa">nazwa pliku.</param>
        /// <param name="d">samochod dostawczy</param>
        public static void ZapiszXML(string nazwa, Dostawcze d)
        {
            var serializer = new XmlSerializer(typeof(Dostawcze));
            var sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, d);
            sw.Close();
        }

        /// <summary> Odczytywanie z pliku XML obiektu klasy Dostawcze</summary>
        /// <param name="nazwa">nazwa pliku</param>
        /// <returns></returns>
        public static Dostawcze OdczytajXML(string nazwa)
        {
            Dostawcze listaOdczytana;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(Dostawcze));
            listaOdczytana = (Dostawcze)bf.Deserialize(fs);
            fs.Close();
            return listaOdczytana;
        }

        /// <summary>  Klonowanie obiektu</summary>
        /// <returns>  Nowy obiekt będący kopią istniejącego</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
