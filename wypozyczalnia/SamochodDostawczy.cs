using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{

    /// <summary>publiczna klasa opisująca Samochód dostawczy, dziedziczy po klasie Pojazd</summary>
    /// <seealso cref="wypozyczalnia.Pojazd" />
    [Serializable]
    public class SamochodDostawczy : Pojazd
    {
        private int pojemnosc;
        private static double oplataDodatkowa;
        private static double kaucjaZwrotna;

        /// <summary>Gets or sets pojemnosc.</summary>
        /// <value>Pojemnosc.</value>
        public int Pojemnosc { get => pojemnosc; set => pojemnosc = value; }

        /// <summary>Gets or sets oplata dodatkowa.</summary>
        /// <value>Oplata dodatkowa.</value>
        public static double OplataDodatkowa { get => oplataDodatkowa; set => oplataDodatkowa = value; }

        /// <summary>Gets or sets kaucja zwrotna.</summary>
        /// <value>Kaucja zwrotna.</value>
        public static double KaucjaZwrotna { get => kaucjaZwrotna; set => kaucjaZwrotna = value; }

        static SamochodDostawczy()
        {
            OplataDodatkowa = 500.0;
            kaucjaZwrotna = 700.0;
        }

        /// <summary>  Inicjalizacja przy nowym obiekcie klasy <see cref="SamochodDostawczy"/> class.</summary>
        public SamochodDostawczy()
        {

        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy<see cref="SamochodDostawczy"/> class.</summary>
        /// <param name="marka">Marka.</param>
        /// <param name="model">Model.</param>
        /// <param name="rocznik">Rocznik.</param>
        /// <param name="silnik">Silnik.</param>
        /// <param name="skrzynia">Skrzynia.</param>
        /// <param name="spalanie">Spalanie.</param>
        /// <param name="cena">Cena.</param>
        /// <param name="pojemnosc">Pojemnosc.</param>
        public SamochodDostawczy(string marka, string model, string rocznik, Silniki silnik, Skrzynie skrzynia,
            double spalanie, double cena, int pojemnosc) : base(marka, model, rocznik, silnik, skrzynia, spalanie, cena)
        {
            this.pojemnosc = pojemnosc;
        }

        /// <summary>  Konwersja do Stringa</summary>
        /// <returns>Zwraca opis Samochodu Dostawczego uzupełniony o pojemność i kaucję zwrotną <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $" {base.ToString()}\t{kaucjaZwrotna}\t{pojemnosc} kg";
        }

    }
}
