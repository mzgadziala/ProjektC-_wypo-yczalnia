using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{
    /// <summary>Abstrakcyjna klasa opisująca imię i nazwisko Osoby</summary>
    public abstract class Osoba
    {
        private string imie;
        private string nazwisko;

        /// <summary>Gets or sets imie.</summary>
        /// <value>  Imię.</value>
        public string Imie { get => imie; set => imie = value; }
        /// <summary>Gets or sets nazwisko.</summary>
        /// <value>Nazwisko.</value>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }

        /// <summary>  Inicjalizacja przy nowym obiekcie klasy<see cref="Osoba"/> class.</summary>
        public Osoba()
        {

        }


        /// <summary>  Inicjalizacja przy nowym obiekcie klasy <see cref="Osoba"/> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        /// <summary>  Konwersja do Stringa.</summary>
        /// <returns>  Imię i nazwisko Osoby <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{imie} {nazwisko}";
        }
    }
}
