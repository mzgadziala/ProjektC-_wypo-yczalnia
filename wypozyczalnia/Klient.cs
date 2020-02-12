using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia;


namespace wypozyczalnia
{
    /// <summary>
    /// Klasa publiczna opisująca Klienta, dziedzicząca po klasie Osoba
    /// </summary>
    [Serializable]
    public class Klient:Osoba
    {
        //private string imie;
        //private string nazwisko;
        private string numerTelefonu;
        private string adresEmail;
        private string numerKarty;
        private string waznoscKarty;
        private string kodZabezpieczajacy;


        /// <summary>Gets or sets numer telefonu.</summary>
        /// <value>  Numer telefonu.</value>
        public string NumerTelefonu { get => numerTelefonu; set => numerTelefonu = value; }

        /// <summary>Gets or sets adres email.</summary>
        /// <value>  Adres email.</value>
        public string AdresEmail { get => adresEmail; set => adresEmail = value; }

        /// <summary>Gets or sets numer karty.</summary>
        /// <value> Numer karty.</value>
        public string NumerKarty { get => numerKarty; set => numerKarty = value; }

        /// <summary>Gets or sets waznosc karty.</summary>
        /// <value>  Waznosc karty.</value>
        public string WaznoscKarty { get => waznoscKarty; set => waznoscKarty = value; }

        /// <summary>Gets or sets kod zabazpieczajacy.</summary>
        /// <value>  Kod zabazpieczajacy.</value>
        public string KodZabezpieczajacy { get => kodZabezpieczajacy; set => kodZabezpieczajacy = value; }

        /// <summary>  Inicjalizacja przy nowym obiekcie klasy<see cref="Klient"/> class.</summary>
        public Klient()
        {

        }
        /// <summary>Inicjalizacja przy nowym obiekcie klasy <see cref="Klient"/> class.</summary>
        /// <param name="imie">  Imie.</param>
        /// <param name="nazwisko">Nazwisko.</param>
        /// <param name="numerTelefonu">Numer telefonu.</param>
        /// <param name="adresEmail">Adres email.</param>
        /// /// <param name="numerKarty">Numer karty.</param>
        /// /// <param name="waznoscKarty">Ważność karty.</param>
        /// /// <param name="kodZabezpieczajacy">Kod zabezpieczający.</param>

        public Klient(string imie, string nazwisko, string numerTelefonu, string adresEmail, string numerKarty, string waznoscKarty, string kodZabezpieczajacy):base(imie, nazwisko)
        {
            //this.imie = imie;
            //this.nazwisko = nazwisko;
            this.numerTelefonu = numerTelefonu;
            this.adresEmail = adresEmail;
            this.numerKarty = numerKarty;
            this.waznoscKarty = waznoscKarty;
            this.kodZabezpieczajacy = kodZabezpieczajacy;
        }

        /// <summary>Konwersja do Stringa</summary>
        /// <returns>Zwraca imię i nazwisko Klienta <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
