using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using wypozyczalnia;
using System.Collections.Generic;

namespace TestyJednostkowe
{
    [TestClass]
    public class KlientTesty
    {
        [TestMethod]
        public void Klient_konstruktor_imie()
        {
            var klient1 = new Klient("Adam", null,null,null,null,null,null);
            Assert.AreEqual("Adam", klient1.Imie);
        }

        [TestMethod]
        public void Klient_konstruktor_nazwisko()
        {
            var klient1 = new Klient(null, "Nowak", null,null,null,null,null);
            Assert.AreEqual("Nowak", klient1.Nazwisko);
        }

        [TestMethod]
        public void Klient_konstruktor_telefon()
        {
            var klient1 = new Klient(null,null, "123456789", null,null,null,null);
            Assert.AreEqual("123456789", klient1.NumerTelefonu);
        }

        [TestMethod]
        public void Klient_konstruktor_mail()
        {
            var klient1 = new Klient(null,null,null, "anowak@gmail.com",null,null,null);
            Assert.AreEqual("anowak@gmail.com", klient1.AdresEmail);
        }

    }

    [TestClass]

    public class SamochodOsobowyTesty
    {

        [TestMethod]
        public void SO_liczebnosc_min()
        {
            var so1 = new SamochodOsobowy();
            so1.LiczbaOsob = 3;
            var rezultat = so1.LiczbaOsob;
            bool oczekiwany = rezultat >= 1;
            Assert.IsTrue(oczekiwany);
        }

        [TestMethod]
        public void SO_liczebnosc_max()
        {
            var so2 = new SamochodOsobowy();
            so2.LiczbaOsob = 3;
            var rezultat = so2.LiczbaOsob;
            bool oczekiwany = rezultat <= 5;
            Assert.IsTrue(oczekiwany);
        }
    }

    [TestClass]
    public class SamochodDostawczyTesty
    {
        [TestMethod]
        public void SD_silniki_benzyna()
        {
            var sd1 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);

            Silniki rezultat = sd1.Silnik;
            Silniki oczekiwany = Silniki.Benzyna;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void SD_silniki_benzynaTSI()
        {
            var sd2 = new SamochodDostawczy("Renault", "Trafic Furgon", "2017", Silniki.BenzynaTSI, Skrzynie.Automatyczna, 8.2, 350.0, 2250);

            Silniki rezultat = sd2.Silnik;
            Silniki oczekiwany = Silniki.BenzynaTSI;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void SD_silniki_diesel()
        {
            var sd3 = new SamochodDostawczy("Renault", "Trafic Furgon", "2017", Silniki.Diesel, Skrzynie.Automatyczna, 8.2, 350.0, 2250);

            Silniki rezultat = sd3.Silnik;
            Silniki oczekiwany = Silniki.Diesel;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void SD_silniki_diesel3()
        {
            var sd4 = new SamochodDostawczy("Renault", "Trafic Furgon", "2017", Silniki.Diesel3, Skrzynie.Automatyczna, 8.2, 350.0, 2250);

            Silniki rezultat = sd4.Silnik;
            Silniki oczekiwany = Silniki.Diesel3;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void SD_skrzynie_manualna()
        {
            var sd1 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);

            Skrzynie rezultat = sd1.Skrzynia;
            Skrzynie oczekiwany = Skrzynie.Manualna;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void SD_skrzynie_automatyczna()
        {
            var sd2 = new SamochodDostawczy("Renault", "Trafic Furgon", "2017", Silniki.Diesel3, Skrzynie.Automatyczna, 8.2, 350.0, 2250);

            Skrzynie rezultat = sd2.Skrzynia;
            Skrzynie oczekiwany = Skrzynie.Automatyczna;

            Assert.AreEqual(oczekiwany, rezultat);
        }
    }

    [TestClass]
    public class OsoboweTesty
    {
        [TestMethod]
        public void Dodawanie()
        {
            Osobowe os1 = new Osobowe();
            SamochodOsobowy s1 = new SamochodOsobowy();
            int liczbaPoczatkowa = os1.liczbaOsobowych;
            os1.dodajSamochod(s1);
            int rezultat = os1.liczbaOsobowych;
            int oczekiwany = liczbaPoczatkowa+1;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void jestwInwentarzu()
        {
            Osobowe os2 = new Osobowe();
            SamochodOsobowy s2 = new SamochodOsobowy();
            SamochodOsobowy s3 = new SamochodOsobowy();

            bool oczekiwany = s2.Equals(s3);
            bool rezultat = os2.jestWInwentarzu(s2);

            Assert.AreEqual(oczekiwany,rezultat);
        }

        
        [TestMethod]
        public void Usuwanie()
        {
            Osobowe os3 = new Osobowe();
            SamochodOsobowy s3 = new SamochodOsobowy();
            int liczbaPoczatkowa = os3.liczbaOsobowych;
            os3.UsunSamochod(s3);
            int rezultat = os3.liczbaOsobowych;
            int oczekiwany = liczbaPoczatkowa--;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void Klonowanie()
        {
            var os1 = new Osobowe();
            var os2 = new Osobowe();
            os1.liczbaOsobowych = 5;
            os2 = (Osobowe)os1.Clone();

            bool rezultat = os1.liczbaOsobowych > os2.liczbaOsobowych;

            Assert.IsFalse(rezultat);
        }

    }

    [TestClass]

    public class DostawczeTesty
    {
        [TestMethod]
        public void Dodawanie()
        {
            Dostawcze dost1 = new Dostawcze();
            SamochodDostawczy s1 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);
            int liczbaPoczatkowa = dost1.liczbaDostawczych;
            dost1.dodajSamochod(s1);
            int rezultat = dost1.liczbaDostawczych;
            int oczekiwany = liczbaPoczatkowa+1;

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]

        public void jestwInwentarzu_true()
        {
            Osobowe os2 = new Osobowe();
            SamochodOsobowy s2 = new SamochodOsobowy();
            SamochodOsobowy s4 = new SamochodOsobowy();

            bool oczekiwany = s2.Equals(s4);
            bool rezultat = os2.jestWInwentarzu(s2);

            Assert.AreEqual(oczekiwany, rezultat);
        }

        [TestMethod]
        public void Usuwanie()
        {
            Dostawcze dost3 = new Dostawcze();
            SamochodDostawczy s3 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);
            int liczbaPoczatkowa = dost3.liczbaDostawczych;
            dost3.UsunSamochod(s3);
            int rezultat = dost3.liczbaDostawczych;
            int oczekiwany = liczbaPoczatkowa--;

            Assert.AreEqual(oczekiwany, rezultat);
        }

    }
    [TestClass]

    public class WypozyczenieTesty
    {
        [TestMethod]
        public void kosztWypozyczenia_so_null()
        {
            var k1 = new Klient("Jan", "Kot", "567345234", "jankot@gmail.com", "45674567456745678", "10/23", "789");
            var sd1 = new SamochodDostawczy("Fiat", "Ducato", "2017", Silniki.Benzyna, Skrzynie.Manualna, 9.4, 250.0, 550);
            var wypozyczenie1 = new Wypozyczenie(Miasta.Kraków, Miasta.Warszawa, "12-05-2020", "16-05-2020", k1, sd1);

            double cena_rezultat = wypozyczenie1.kosztWypozyczenia();
            double cena_oczekiwana = sd1.Cena* Convert.ToDouble((wypozyczenie1.DataZwrotu - wypozyczenie1.DataOdbioru).TotalDays) + SamochodDostawczy.KaucjaZwrotna + SamochodDostawczy.OplataDodatkowa;

            Assert.AreEqual(cena_oczekiwana,cena_rezultat);
        }

        [TestMethod]
        public void kosztWypozyczenia_so_notNull()
        {
            var k2 = new Klient("Tomasz", "Kowalski", "142876243", "kowk@wp.pl", "75847362548924123", "07/20", "331");
            var so1 = new SamochodOsobowy("Ford", "Mondeo", "2013", Silniki.Diesel3, Skrzynie.Automatyczna, 6.0, 150.0, 5);
            var wypozyczenie2 = new Wypozyczenie(Miasta.Łódź, Miasta.Szczecin, "10-05-2020", "15-05-2020", k2, so1);

            double cena_rezultat = wypozyczenie2.kosztWypozyczenia();
            double cena_oczekiwana = so1.Cena * Convert.ToDouble((wypozyczenie2.DataZwrotu - wypozyczenie2.DataOdbioru).TotalDays) + SamochodOsobowy.KaucjaZwrotna;

            Assert.AreEqual(cena_oczekiwana,cena_rezultat);
        }
    }

}
