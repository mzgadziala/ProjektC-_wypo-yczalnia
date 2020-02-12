using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalnia;

namespace wypozyczalnia
{

    /// <summary>Interfejs zawierający metody publiczne wykorzystywane w klasie Wypożyczenie</summary>
    interface IZapisywalna
    {
        void ZapiszXML(string nazwa, ListaWypozyczen lista1);
        Object OdczytajXML(string nazwa);
    }
}
