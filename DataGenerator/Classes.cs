using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;


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
            return PESEL + CSV.separator + Imie + CSV.separator + Nazwisko + CSV.separator + ID_funkcji + CSV.separator + Specjalnosc;
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
        public string PESEL { get; set; }
        public DateTime Data  { get; set; }
        public int Czas_trwania { get; set; }
        public int Nr_telefonu { get; set; }
        public Rozmowa() { }
        public Rozmowa(int pID_rozmowa, string pPESEL, DateTime pData, int pCzas_trwania, int pNr_telefonu)
        {
            this.ID_rozmowa = pID_rozmowa;
            this.PESEL = pPESEL;
            this.Data = pData;
            this.Czas_trwania = pCzas_trwania;
            this.Nr_telefonu = pNr_telefonu;
        }
        public override string ToString()
        {
            return ID_rozmowa + CSV.separator + PESEL + CSV.separator + Data + CSV.separator + Czas_trwania + CSV.separator + Nr_telefonu;
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
            return Nr_rejestracyjny + CSV.separator + Marka + CSV.separator + Model + CSV.separator + Aktywny;
        }
    }
    public class Zespol : IComparable
    {
        public int ID_zespolu { get; set; }
        public int ID_rodzaj { get; set; }
        public string ID_pojazdu { get; set; }
        public DateTime Rozpoczecie_dyzuru { get; set; }
        public DateTime Zakonczenie_dyzuru { get; set; }
        public bool Zajety { get; set; } 
        public Zespol() { }
        public Zespol(int pID_zespolu, int pID_rodzaj, string pID_pojazd, DateTime pRozpoczecie_dyzuru, DateTime pZakonczenie_dyzuru, bool pZajety) 
        {
            this.ID_zespolu = pID_zespolu;
            this.ID_rodzaj = pID_rodzaj;
            this.ID_pojazdu = pID_pojazd;
            this.Rozpoczecie_dyzuru = pRozpoczecie_dyzuru;
            this.Zakonczenie_dyzuru = pZakonczenie_dyzuru;
            this.Zajety = pZajety;
        }
     
        public int CompareTo(object obj)
        {
            var z = (Zespol) obj;
            return System.String.Compare(ID_pojazdu, z.ID_pojazdu, System.StringComparison.Ordinal);
        }
        
        public override string ToString()
        {
            return ID_zespolu + CSV.separator + ID_rodzaj + CSV.separator + ID_pojazdu + CSV.separator + Rozpoczecie_dyzuru + CSV.separator + Zakonczenie_dyzuru + CSV.separator + Zajety; 
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
        public override string ToString()
        {
            return ID_wyjazdu + CSV.separator + ID_zespolu + CSV.separator + ID_rozmowy + CSV.separator + Data + CSV.separator + ID_kategorii + CSV.separator + Adres_miasto + CSV.separator + Adres_ulica + CSV.separator + Adres_nr_domu + CSV.separator + Adres_nr_lokalu + CSV.separator + Dodatkowe_informacje; 
        } 
    }
    public class Przynaleznosc : IComparable 
    {
        public string PESEL { get; set; }
        public int ID_zespol { get; set; }
        public Przynaleznosc() { }
        public Przynaleznosc(string pPESEL, int pID_zespol) 
        {
            this.PESEL = pPESEL;
            this.ID_zespol = pID_zespol;
        }
        public override string ToString()
        {
            return PESEL + CSV.separator + ID_zespol;
        }


        public int CompareTo(object obj)
        {
            var p = (Przynaleznosc) obj;
            if ((this.PESEL == p.PESEL) && (this.ID_zespol == p.ID_zespol))
                return 0;
            else 
                return 1;
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

    public class Arkusz1
    {
        public int IdWyjazdu { get; set; }
        public string NazwaLeku { get; set; }
        public int IloscZuzytychLekow { get; set; }
        public string JednostkaMiary { get; set; }
        public Arkusz1() { }
        public Arkusz1(int id_wyjazdu, string nazwaLeku, int iloscZuzytychLekow, string jednostkaMiary) 
        {
            this.IdWyjazdu = id_wyjazdu;
            this.NazwaLeku = nazwaLeku;
            this.IloscZuzytychLekow = iloscZuzytychLekow;
            this.JednostkaMiary = jednostkaMiary;
        }
        public override string ToString()
        {
            return IdWyjazdu + "|" + NazwaLeku + "|" + IloscZuzytychLekow + "|" + JednostkaMiary;
        }
    }
    public class Arkusz2
    {
        public int IdWyjazdu { get; set; }
        public DateTime DataWyjazdu { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public int CzasDojazdu { get; set; }
        public bool CzyOdnalezionoPacjenta { get; set; }
        public bool CzyUdzielonoPomocy { get; set; }
        public int LiczbaKilometrow { get; set; }
        public int LiczbaCzerwonych { get; set; }
        public int LiczbaZoltych { get; set; }
        public int LiczbaZielonych { get; set; }
        public Arkusz2() { }
        public Arkusz2(int id_wyjazdu, DateTime dataWyjazdu, DateTime dataPrzyjazdu, int czasDojazdu, bool czyOdnalezionoPacjenta, bool czyUdzielonoPomocy, int liczbaKilometrow, int liczbaCzerwonych, int liczbaZoltych, int liczbaZielonych)
        {
            this.IdWyjazdu = id_wyjazdu;
            this.DataWyjazdu = dataWyjazdu;
            this.DataPrzyjazdu = dataPrzyjazdu;
            this.CzasDojazdu = czasDojazdu;
            this.CzyOdnalezionoPacjenta = czyOdnalezionoPacjenta;
            this.CzyUdzielonoPomocy = czyUdzielonoPomocy;
            this.LiczbaKilometrow = liczbaKilometrow;
            this.LiczbaCzerwonych = liczbaCzerwonych;
            this.LiczbaZoltych = liczbaZoltych;
            this.LiczbaZielonych = liczbaZielonych;
        }
        public override string ToString()
        {
            return IdWyjazdu + "|" + DataWyjazdu + "|" + DataPrzyjazdu  + "|" + CzasDojazdu + "|" + CzyOdnalezionoPacjenta + "|" + CzyUdzielonoPomocy + "|" + LiczbaKilometrow +"|" + LiczbaCzerwonych + "|" + LiczbaZoltych + "|" + LiczbaZielonych;
        }
    }
}
