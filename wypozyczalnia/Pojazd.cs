using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{
    /// <summary>Generowanie enumeracji Silniki</summary>
    [Serializable]
    public enum Silniki 
    {
        /// <summary> Silnik - Benzyna</summary>
        Benzyna = 0,
        /// <summary> Silnik - Diesel</summary>
        Diesel = 1,
        /// <summary>  Silnik - Diesel3</summary>
        Diesel3 = 2,
        /// <summary> Silnik - Benzyna TSI</summary>
        BenzynaTSI = 3 };

    /// <summary>Generowanie enumeracji Skrzynie</summary>
    public enum Skrzynie 
    {
        /// <summary>Skrzynie - Manualna</summary>
        Manualna = 0,
        /// <summary>  Skrzynie - Automatyczna</summary>
        Automatyczna = 1 };

    /// <summary>Publiczna, abstrakcyjna klasa opisująca Pojazd</summary>
    public class Pojazd
    {
        private string marka;
        private string model;
        private string rocznik;
        private Silniki silnik;
        private Skrzynie skrzynia;
        private double spalanie;
        private double cena;

        /// <summary>Gets or sets marka.</summary>
        /// <value>Marka.</value>
        public string Marka { get => marka; set => marka = value; }

        /// <summary>Gets or sets model.</summary>
        /// <value>  Model.</value>
        public string Model { get => model; set => model = value; }

        /// <summary>Gets or sets rocznik.</summary>
        /// <value>  Rocznik.</value>
        public string Rocznik { get => rocznik; set => rocznik = value; }

        /// <summary>Gets or sets silnik.</summary>
        /// <value>Silnik.</value>
        public Silniki Silnik { get => silnik; set => silnik = value; }

        /// <summary>Gets or sets Skrzynia.</summary>
        /// <value>Skrzynia.</value>
        public Skrzynie Skrzynia { get => skrzynia; set => skrzynia = value; }

        /// <summary>Gets or sets spalanie.</summary>
        /// <value>Spalanie.</value>
        public double Spalanie { get => spalanie; set => spalanie = value; }

        /// <summary>Gets or sets cena.</summary>
        /// <value>  Cena.</value>
        public double Cena { get => cena; set => cena = value; }


        /// <summary>Inicjalizacja przy nowym obiekcie klasy <see cref="Pojazd"/> class.</summary>
        public Pojazd()
        {
            marka = null;
            model = null;
            rocznik = null;
            silnik = Silniki.Benzyna;
            skrzynia = Skrzynie.Manualna;
            spalanie = 0.0;
            cena = 0;
        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy <see cref="Pojazd"/> class.</summary>
        /// <param name="marka">Marka.</param>
        /// <param name="model">Model.</param>
        public Pojazd(string marka, string model)
        {
            this.marka = marka;
            this.model = model;
        }

        /// <summary>Inicjalizacja przy nowym obiekcie klasy <see cref="Pojazd"/> class.</summary>
        /// <param name="marka">Marka.</param>
        /// <param name="model">Model.</param>
        /// <param name="rocznik">Rocznik.</param>
        /// <param name="silnik">Silnik.</param>
        /// <param name="skrzynia">Skrzynia.</param>
        /// <param name="spalanie">Spalanie.</param>
        /// <param name="cena">Cena.</param>
        public Pojazd(string marka, string model, string rocznik, Silniki silnik, Skrzynie skrzynia,
            double spalanie, double cena)
        {
            this.marka = marka;
            this.model = model;
            this.rocznik = rocznik;
            this.silnik = silnik;
            this.skrzynia = skrzynia;
            this.spalanie = spalanie;
            this.cena = cena;
        }

        /// <summary>  Konwersja do Stringa</summary>
        /// <returns> Zwraca opis Samochodu <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{Marka}\t\t{Model}\t\t{Rocznik}\t{Silnik}\t\t{Skrzynia}\t{Spalanie} l/100 km\t{Cena}/dzień";
        }
    }
}