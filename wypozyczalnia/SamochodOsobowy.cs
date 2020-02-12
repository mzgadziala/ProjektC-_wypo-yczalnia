using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{

    /// <summary>publiczna klasa opisująca samochód osobowy, dziedzy po klasie Pojazd</summary>
    /// <seealso cref="wypozyczalnia.Pojazd" />
    [Serializable]
    public class SamochodOsobowy : Pojazd
    {

        private static double kaucjaZwrotna;
        private int liczbaOsob;

        /// <summary>
        ///  <para>
        ///  Gets or sets liczba osob.
        /// </para>
        /// </summary>
        /// <value> Liiczba osob.</value>
        public int LiczbaOsob { get => liczbaOsob; set => liczbaOsob = value; }

        /// <summary>Gets or sets kaucja zwrotna.</summary>
        /// <value>Kaucja zwrotna.</value>
        public static double KaucjaZwrotna { get => kaucjaZwrotna; set => kaucjaZwrotna = value; }

        static SamochodOsobowy()
        {
            KaucjaZwrotna = 400.0;
        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy<see cref="SamochodOsobowy"/> class.</summary>
        public SamochodOsobowy() : base()
        {

        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy<see cref="SamochodOsobowy"/> class.</summary>
        /// <param name="marka">Marka.</param>
        /// <param name="model">Model.</param>
        /// <param name="rocznik">Rocznik.</param>
        /// <param name="silnik">Silnik.</param>
        /// <param name="skrzynia">Skrzynia.</param>
        /// <param name="spalanie">Spalanie.</param>
        /// <param name="cena">Cena.</param>
        /// <param name="liczbaOsob">Liczba osob.</param>
        public SamochodOsobowy(string marka, string model, string rocznik, Silniki silnik, Skrzynie skrzynia,
            double spalanie, double cena, int liczbaOsob) : base(marka, model, rocznik, silnik, skrzynia, spalanie, cena)
        {
            this.liczbaOsob = liczbaOsob;
        }

        /// <summary>Konwersja do Stringa.</summary>
        /// <returns>Zwraca opis Samochodu Osobowego uzupełniony o liczbę osób <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $" {base.ToString()}\t {kaucjaZwrotna}\t\t{liczbaOsob}";
        }

    }
}
