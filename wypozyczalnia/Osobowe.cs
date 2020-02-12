using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wypozyczalnia
{

    /// <summary>Publiczna klasa działająca na liście Samochodów Osobowych, implementuje interfejs ICloneable</summary>
    [Serializable]
    public class Osobowe:ICloneable
    {

        /// <summary>Liczba osobowych</summary>
        public int liczbaOsobowych;

        /// <summary>Lista wszystkich Samochodów Osobowych</summary>
        public List<SamochodOsobowy> wszystkieOsobowe;

        /// <summary>Inicjalizacja przy nowym obiekcie klasy <see cref="Osobowe"/> class.</summary>
        public Osobowe()
        {
            liczbaOsobowych = 0;
            wszystkieOsobowe = new List<SamochodOsobowy>();
            
        }


        /// <summary>Dodawanie Samochodu Osobowego do listy</summary>
        /// <param name="s">obiekt Samochód Osobowy do dodania.</param>
        public void dodajSamochod(SamochodOsobowy s)
        {
            liczbaOsobowych++;
            wszystkieOsobowe.Add(s);
        }


        /// <summary>  Sprawdzanie czy obiekt Samochod Osobowy jest na liście</summary>
        /// <param name="c">  obiekt Samochd Osobowy</param>
        /// <returns>Wybrany Samochd Osobowy nie jest dostępny</returns>
        public bool jestWInwentarzu(SamochodOsobowy c)
        {
            foreach (SamochodOsobowy s in wszystkieOsobowe)
            {
                if (s.Equals(c)) return true;
            }
            return false;
        }

        /// <summary>  Usuwanie Samochodu Osobowego z listy</summary>
        /// <param name="p">  Obiekt Samochd Osobowy do usunięcia</param>
        public void UsunSamochod(SamochodOsobowy p)
        {
            if (jestWInwentarzu(p))
            {
                wszystkieOsobowe.Remove(p);
            }
        }

        /// <summary>Generowanie listy dostępnych wypożyczeń w danym czasie</summary>
        /// <param name="lista"> Lista Wypożyczen</param>
        /// <param name="dataOdbioru">Data odbioru.</param>
        /// <param name="dataZwrotu">Data zwrotu.</param>
        /// <returns>Lista dostępnych Samochodów Osobowych</returns>
        public List<SamochodOsobowy> pokazDostepne(ListaWypozyczen lista, string dataOdbioru, string dataZwrotu)
        {
            DateTime odbior = DateTime.Parse(dataOdbioru);
            DateTime zwrot = DateTime.Parse(dataZwrotu);
            List<SamochodOsobowy> dostepneOsobowe;
            dostepneOsobowe = new List<SamochodOsobowy>(wszystkieOsobowe);

            foreach(SamochodOsobowy s in wszystkieOsobowe)
            {
                foreach(Wypozyczenie w in lista.listaWypozyczen)
                {
                    if(s == w.So && ((zwrot > w.DataOdbioru && odbior < w.DataOdbioru) || 
                        (odbior < w.DataZwrotu && zwrot > w.DataZwrotu) || (odbior > w.DataOdbioru && zwrot < w.DataZwrotu)))
                    {
                        dostepneOsobowe.Remove(s);
                    }
                }
            }
            return dostepneOsobowe;
        }

        /// <summary>Konwersja do Stringa.</summary>
        /// <returns>Zwraca opis wszystkich Samochodów Osobowych <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (SamochodOsobowy s in wszystkieOsobowe)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }

        /// <summary>Klonowanie instancji.</summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>Zapis obiektu klasy Osobowe do pliku XML.</summary>
        /// <param name="nazwa">nazwa pliku.</param>
        /// <param name="o">samochod osobowy</param>
        public static void ZapiszXML(string nazwa, Osobowe o)
        {
            var serializer = new XmlSerializer(typeof(Osobowe));
            var sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, o);
            sw.Close();
        }

        /// <summary>Odczyt obiekyu z pliku XML.</summary>
        /// <param name="nazwa">nazwa pliku.</param>
        /// <returns></returns>
        public static Osobowe OdczytajXML(string nazwa)
        {
            Osobowe listaOdczytana;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(Osobowe));
            listaOdczytana = (Osobowe)bf.Deserialize(fs);
            fs.Close();
            return listaOdczytana;
        }


    }
}
