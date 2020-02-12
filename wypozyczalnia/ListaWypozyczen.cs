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
    /// Klasa publiczna generująca listę wypożyczeń
    /// </summary>
    [Serializable]
    public class ListaWypozyczen
    {

        /// <summary>Liczba wypozyczen</summary>
        public int liczbaWypozyczen = 0;

        /// <summary>Lista wypozyczen</summary>
        public List<Wypozyczenie> listaWypozyczen = new List<Wypozyczenie>();

        /// <summary>  Inicjalizacja przy nowym obiekcie klasy <see cref="ListaWypozyczen"/> class.</summary>
        public ListaWypozyczen()
        { }
        
        

        /// <summary>Dodawanie do listy nowego obiektu Wypożyczenie</summary>
        /// <param name="w">
        ///   <para>Wypożyczenie</para>
        /// </param>
        public void dodaj(Wypozyczenie w)
        {
            listaWypozyczen.Add(w);
            liczbaWypozyczen++;
        }


        /// <summary>Konwersja do Stringa.</summary>
        /// <returns>Zwraca opis Samochodów z listy wypożyczonych <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Wypozyczenie w in listaWypozyczen)
            {
                sb.AppendLine(w.ToString());
            }
            return sb.ToString();
        }

        /// <summary>  Zapis obiektu klasy Lista Wypozyczen do XML.</summary>
        /// <param name="nazwa">nazwa pliku.</param>
        /// <param name="l">lista wypozyczen.</param>
        public static void ZapiszXML(string nazwa, ListaWypozyczen l)
        {
            var serializer = new XmlSerializer(typeof(ListaWypozyczen));
            var sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, l);
            sw.Close();
        }
        /// <summary>  Odczytanie obiektu z pliku XML.</summary>
        /// <param name="nazwa">nazwa pliku.</param>
        /// <returns></returns>
        public static ListaWypozyczen OdczytajXML(string nazwa)
        {
            ListaWypozyczen listaOdczytana;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(ListaWypozyczen));
            listaOdczytana = (ListaWypozyczen)bf.Deserialize(fs);
            fs.Close();
            return listaOdczytana;
        }

    }

}
