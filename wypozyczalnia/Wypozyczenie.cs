using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wypozyczalnia
{
    /// <summary>Generowanie enumeracji Miasta</summary>
    [Serializable]

    public enum Miasta

    {
        /// <summary> Miasto - Warszawa</summary>
        Warszawa = 0,
        /// <summary>Miasto - Kraków</summary>
        Kraków = 1,
        /// <summary> Miasto - Wrocław</summary>
        Wrocław = 2,
        /// <summary>  Miasto - Lodź</summary>
        Łódź = 3,
        /// <summary>Miasto - Poznań</summary>
        Poznań = 4,
        /// <summary>Miasto - Gdańsk</summary>
        Gdańsk = 5,
        /// <summary>Miasto - Szczecin</summary>
        Szczecin = 6,
        /// <summary> Miasto - Bydgoszcz</summary>
        Bydgoszcz = 7,
        /// <summary> Miasto - Lublin</summary>
        Lublin = 8,
        /// <summary>Miasto - Katowice</summary>
        Katowice = 9,
        /// <summary> Miasto - Rzeszów</summary>
        Rzeszów = 10,
        /// <summary>Miasto - Toruń</summary>
        Toruń = 11
    }

    /// <summary>Publiczna klasa opisująca Wypożyczenie</summary>
    /// <seealso cref="wypozyczalnia.IZapisywalna" />
    public class Wypozyczenie
    {
        private Pojazd p;
        private Miasta miejsceOdbioru;
        private Miasta miejsceZwrotu;
        private DateTime dataOdbioru;
        private DateTime dataZwrotu;
        private Klient k;
        private SamochodOsobowy so;
        private SamochodDostawczy sd;
        private double cena;

        /// <summary>Gets or sets miejsce odbioru.</summary>
        /// <value>Miejsce odbioru.</value>
        public Miasta MiejsceOdbioru { get => miejsceOdbioru; set => miejsceOdbioru = value; }

        /// <summary>Gets or sets miejsce zwrotu.</summary>
        /// <value>Miejsce zwrotu.</value>
        public Miasta MiejsceZwrotu { get => miejsceZwrotu; set => miejsceZwrotu = value; }

        /// <summary>Gets or sets data odbioru.</summary>
        /// <value>Data odbioru.</value>
        public DateTime DataOdbioru { get => dataOdbioru; set => dataOdbioru = value; }

        /// <summary>Gets or sets data zwrotu.</summary>
        /// <value>Data zwrotu.</value>
        public DateTime DataZwrotu { get => dataZwrotu; set => dataZwrotu = value; }

        /// <summary>Gets or sets  klient.</summary>
        /// <value>  Klient</value>
        public Klient K { get => k; set => k = value; }

        /// <summary>Gets or sets samochod osobowy.</summary>
        /// <value>  samochod osobowy</value>
        public SamochodOsobowy So { get => so; set => so = value; }

        /// <summary>Gets or sets samochod dostawczy.</summary>
        /// <value>
        ///   <para>samochod dostawczy.
        /// </para>
        /// </value>
        public SamochodDostawczy Sd { get => sd; set => sd = value; }

        /// <summary>Gets or sets cena.</summary>
        /// <value>Cena.</value>
        public double Cena { get => cena; set => cena = value; }

        /// <summary>Gets or sets pojazd.</summary>
        /// <value>Pojazd</value>
        public Pojazd P { get => p; set => p = value; }

        /// <summary> GPS </summary>
        public static double gps;

        /// <summary>Lancuchy </summary>
        public static double lancuchy;

        /// <summary>Fotelik</summary>
        public static double fotelik;

        /// <summary>Wyjazd za granice</summary>
        public static double wyjazdZaGranice;

        /// <summary>
        ///   <para>
        ///  Konstruktor statyczny<see cref="Wypozyczenie"/> class.
        /// </para>
        /// </summary>
        static Wypozyczenie()
        {
            gps = 20.0;
            lancuchy = 25.0;
            fotelik = 20.0;
            wyjazdZaGranice = 200.0;
        }

        /// <summary>  Inicjalizacja przy nowym obiekcie klasy <see cref="Wypozyczenie"/> class.</summary>
        public Wypozyczenie()
        { }
        /// <summary>Inicjalizacja przy nowym obiekcie klasy, gdy wypozyczamy samochód osobowy <see cref="Wypozyczenie"/> class.</summary>
        /// <param name="miejsceOdbioru">Miejsce odbioru.</param>
        /// <param name="miejsceZwrotu">Miejsce zwrotu.</param>
        /// <param name="dataOdbioru">Data odbioru.</param>
        /// <param name="dataZwrotu">Data zwrotu.</param>
        /// <param name="k">  Klient</param>
        /// <param name="so"> samochod osobowy</param>
        public Wypozyczenie(Miasta miejsceOdbioru, Miasta miejsceZwrotu, string dataOdbioru, string dataZwrotu, Klient k, SamochodOsobowy so)
        {
            DateTime data1 = DateTime.Parse(dataOdbioru);
            //DateTime.TryParseExact(dataOdbioru, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mm-yy" }, null, DateTimeStyles.None, out data1);
            DateTime data2 = DateTime.Parse(dataZwrotu);
            //DateTime.TryParseExact(dataZwrotu, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mm-yy" }, null, DateTimeStyles.None, out data2);

            this.miejsceOdbioru = miejsceOdbioru;
            this.miejsceZwrotu = miejsceZwrotu;
            this.dataOdbioru = data1;
            this.dataZwrotu = data2;
            this.k = k;
            this.so = so;
        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy, gdy wypozyczamy samochód dostawczy <see cref="Wypozyczenie"/> class.</summary>
        /// <param name="miejsceOdbioru">  Miejsce odbioru.</param>
        /// <param name="miejsceZwrotu">Miejsce zwrotu.</param>
        /// <param name="dataOdbioru">  Data odbioru.</param>
        /// <param name="dataZwrotu">Data zwrotu.</param>
        /// <param name="k">  Klient</param>
        /// <param name="sd">samochod dostawczy</param>
        public Wypozyczenie(Miasta miejsceOdbioru, Miasta miejsceZwrotu, string dataOdbioru, string dataZwrotu, Klient k, SamochodDostawczy sd)
        {
            DateTime data1 = DateTime.Parse(dataOdbioru);
            //DateTime.TryParseExact(dataOdbioru, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mmm-yy" }, null, DateTimeStyles.None, out data1);
            DateTime data2 = DateTime.Parse(dataZwrotu);
            //DateTime.TryParseExact(dataZwrotu, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mmm-yy" }, null, DateTimeStyles.None, out data2);

            this.miejsceOdbioru = miejsceOdbioru;
            this.miejsceZwrotu = miejsceZwrotu;
            this.dataOdbioru = data1;
            this.dataZwrotu = data2;
            this.k = k;
            this.sd = sd;
        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy<see cref="Wypozyczenie"/> class.</summary>
        /// <param name="miejsceOdbioru">Miejsce odbioru.</param>
        /// <param name="miejsceZwrotu">Miejsce zwrotu.</param>
        /// <param name="dataOdbioru">Data odbioru.</param>
        /// <param name="dataZwrotu">Data zwrotu.</param>
        /// <param name="k">klient.</param>
        /// <param name="p">pojazd.</param>
        public Wypozyczenie(Miasta miejsceOdbioru, Miasta miejsceZwrotu, string dataOdbioru, string dataZwrotu, Klient k, Pojazd p)
        {
            DateTime data1 = DateTime.Parse(dataOdbioru);
            //DateTime.TryParseExact(dataOdbioru, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mm-yy" }, null, DateTimeStyles.None, out data1);
            DateTime data2 = DateTime.Parse(dataZwrotu);
            //DateTime.TryParseExact(dataZwrotu, new[] { "yyyy-mm-dd", "yyyy/mm/dd", "mm/dd/yyyy", "dd-mm-yy" }, null, DateTimeStyles.None, out data2);

            this.miejsceOdbioru = miejsceOdbioru;
            this.miejsceZwrotu = miejsceZwrotu;
            this.dataOdbioru = data1;
            this.dataZwrotu = data2;
            this.k = k;
            this.p = p;
        }

        /// <summary> Obliczanie kosztu wypozyczenia.</summary>
        /// <returns>Cena za wypozyczenie</returns>
        public double kosztWypozyczenia() // metoda do policzenia kosztu wypożyczenia wewnątrz gui która podliczy też opłaty dodatkowe
        {
            if (so == null)
            {
                cena = sd.Cena * Convert.ToDouble((dataZwrotu - dataOdbioru).TotalDays) + SamochodDostawczy.KaucjaZwrotna + SamochodDostawczy.OplataDodatkowa;
            }
            else
            {
                cena = so.Cena * Convert.ToDouble((dataZwrotu - dataOdbioru).TotalDays) + SamochodOsobowy.KaucjaZwrotna;
            }
            return cena;
        }

        /// <summary>Konowersja do Stringa</summary>
        /// <returns>Zwraca opis wypożyczenia <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $"Miejsce odbioru: {MiejsceOdbioru}, Miejsce zwrotu: {MiejsceZwrotu}, Kiedy: {DataOdbioru.ToShortDateString()}-{DataZwrotu.ToShortDateString()}, Klient: {k.ToString()}";
        }


        /// <summary>Zapisywanie do XML obiektu klasy Wypozyczenie.</summary>
        /// <param name="nazwa">Nazwa pliku.</param>
        /// <param name="w">Obiekt Wypozyczenie.</param>
        public void ZapiszXML(string nazwa, Wypozyczenie w)
        {
            var serializer = new XmlSerializer(typeof(Wypozyczenie));
            var sw = new StreamWriter(nazwa);
            serializer.Serialize(sw, w);
            sw.Close();
        }

        /// <summary>Odczytywanie z XML obiektu klasy Wypozyczenie.</summary>
        /// <param name="nazwa">Nazwa pliku.</param>
        /// <returns></returns>
        public object OdczytajXML(string nazwa)
        {
            Wypozyczenie wypozyczenieOdczytane;
            var fs = new FileStream(nazwa, FileMode.Open);
            var bf = new XmlSerializer(typeof(Wypozyczenie));
            wypozyczenieOdczytane = (Wypozyczenie)bf.Deserialize(fs);
            fs.Close();
            return wypozyczenieOdczytane;
        }
    }
}
