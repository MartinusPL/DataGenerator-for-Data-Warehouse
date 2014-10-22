using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    public class Pracownik : IComparable
    {
        public string PESEL { get; set;}
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int ID_funkcji { get; set;}
        public string Specjalnosc { get; set; }
        public Pracownik() { }
        public Pracownik(string pPESEL, string pImie, string pNazwisko, int pID_funkcji, string pSpecjalnosc) 
        {
            this.PESEL = pPESEL;
            this.Imie = pImie;
            this.Nazwisko = pNazwisko;
            this.ID_funkcji = pID_funkcji; 
            this.Specjalnosc = pSpecjalnosc;
        }

        public override string ToString()
        {
            return PESEL + " " + Imie + " " + Nazwisko + " " + ID_funkcji + " " + Specjalnosc;
        }

        public int CompareTo(object obj)
        {
            var p = (Pracownik) obj;
            return String.Compare(p.PESEL, this.PESEL, System.StringComparison.Ordinal);
        }
    }
    public class Rozmowa
    {
        public int ID_rozmowa { get; set; }
        public int PESEL { get; set; }
        public DateTime Data  { get; set; }
        public int Czas_trwania { get; set; }
        public int Nr_telefonu { get; set; }
        public Rozmowa() { }
        public Rozmowa(int pID_rozmowa, int pPESEL, DateTime pData, int pCzas_trwania, int pNr_telefonu)
        {
            this.ID_rozmowa = pID_rozmowa;
            this.PESEL = pPESEL;
            this.Data = pData;
            this.Czas_trwania = pCzas_trwania;
            this.Nr_telefonu = pNr_telefonu;
        }

    }
    public class Pojazd : IComparable
    {
        public string Nr_rejestracyjny { get; set; }
        public string Model { get; set; }
        public string Marka { get; set; }
        public bool Aktywny { get; set; }
        public Pojazd(){}
        public Pojazd(string pNr_rejestracyjny, string pModel, string pMarka, bool pAktywny) 
        {
            this.Nr_rejestracyjny = pNr_rejestracyjny;
            this.Model = pModel;
            this.Marka = pMarka;
            this.Aktywny = pAktywny;
        }

        public int CompareTo(object obj)
        {
            var p = (Pojazd) obj;
            return System.String.Compare(Nr_rejestracyjny, p.Nr_rejestracyjny, System.StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Nr_rejestracyjny + " " + Marka + " " + Model + " " + Aktywny;
        }
    }
    public class Zespol 
    {
        public int ID_zespolu { get; set; }
        public int ID_rodzaj { get; set; }
        public string ID_pojazd { get; set; }
        public DateTime Rozpoczecie_dyzuru { get; set; }
        public DateTime Zakonczenie_dyzuru { get; set; }
        public string Zajety { get; set; } 
        public Zespol() { }
        public Zespol(int pID_zespolu, int pID_rodzaj, string pID_pojazd, DateTime pRozpoczecie_dyzuru, DateTime pZakonczenie_dyzuru, string pZajety) 
        {
            this.ID_zespolu = pID_zespolu;
            this.ID_rodzaj = pID_rodzaj;
            this.ID_pojazd = pID_pojazd;
            this.Rozpoczecie_dyzuru = pRozpoczecie_dyzuru;
            this.Zakonczenie_dyzuru = pZakonczenie_dyzuru;
            this.Zajety = pZajety;
        }
    }
    public class Wyjazd 
    {
        public int ID_wyjazdu { get; set; }
        public int ID_zespolu { get; set; }
        public int ID_rozmowy { get; set; }
        public DateTime Data { get; set; }
        public int ID_kategorii { get; set; }
        public int Kod_wyjazdu { get; set; }
        public string Adres_miasto { get; set; }
        public string Adres_ulica { get; set; }
        public string Adres_nr_domu { get; set; }
        public string Adres_nr_lokalu { get; set; }
        public string Dodatkowe_informacje { get; set; }
        public Wyjazd() { }
        public Wyjazd( int pID_wyjazdu, int pID_zespolu, int pID_rozmowy, DateTime pData, int pID_kategorii, int pKod_wyjazdu, string pAdres_miasto, string pAdres_ulica,string pAdres_nr_domu, string pAdres_nr_lokalu, string pDodatkowe_informacje) 
        {
            this.ID_wyjazdu = pID_wyjazdu;
            this.ID_zespolu = pID_zespolu;
            this.ID_rozmowy = pID_rozmowy;
            this.Data = pData;
            this.ID_kategorii = pID_kategorii;
            this.Adres_miasto = pAdres_miasto;
            this.Adres_ulica = pAdres_ulica;
            this.Adres_nr_domu = pAdres_nr_domu;
            this.Adres_nr_lokalu = pAdres_nr_lokalu;
            this.Dodatkowe_informacje = pDodatkowe_informacje;
        
        }
    }
    public class Przynaleznosc 
    {
        public int PESEL { get; set; }
        public int ID_zespol { get; set; }
        public Przynaleznosc() { }
        public Przynaleznosc(int pPESEL, int pID_zespol) 
        {
            this.PESEL = pPESEL;
            this.ID_zespol = pID_zespol;
        }
        
    }

    public class RodzajZespolu
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public RodzajZespolu() {}

        public RodzajZespolu(int id, string nazwa)
        {
            this.Id = id;
            this.Nazwa = nazwa;
        }
    }

    public class KategoriaWyjazdu
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public KategoriaWyjazdu() {}
        public KategoriaWyjazdu(int id, string nazwa)
        {
            this.Id = id;
            this.Nazwa = nazwa;
        }
    }

    public class FunkcjaPracownika
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public FunkcjaPracownika() { }
        public FunkcjaPracownika(int id, string nazwa)
        {
            this.Id = id;
            this.Nazwa = nazwa;
        }
    }
}
