﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HD;
using ExtensionMethods;

namespace DataGenerator
{
    class Program
    {
        public const string Path = @"C:\tmp\auto_erase\";

        static void Main(string[] args)
        {
            #region slowniki
            List < RodzajZespolu >  rodzajeZespolu;
            rodzajeZespolu = new List<RodzajZespolu>
            {
                new RodzajZespolu(1,"Podstawowy"),
                new RodzajZespolu(2,"Specjalistyczny"),
                new RodzajZespolu(3,"Transportowy"),
                new RodzajZespolu(4,"Neonatalogiczny")
            };

            List<FunkcjaPracownika> funkcjePracownika;
            funkcjePracownika = new List<FunkcjaPracownika>
            {
                new FunkcjaPracownika(1, "Dyspozytor"),
                new FunkcjaPracownika(2, "Ratownik kierowca"),
                new FunkcjaPracownika(3, "Ratownik medyczny"),
                new FunkcjaPracownika(4, "Ratownik medyczny kierowca"),
                new FunkcjaPracownika(5, "Pielegniarka"),
                new FunkcjaPracownika(6, "Lekarz")
            };

            List<KategoriaWyjazdu> kategorieWyjazdow;
            kategorieWyjazdow = new List<KategoriaWyjazdu>
            {
                new KategoriaWyjazdu(1,"Wypadek komunikacyjny"),
                new KategoriaWyjazdu(2,"Nagle zatrzymanie krazenia"),
                new KategoriaWyjazdu(3,"Porod"),
                new KategoriaWyjazdu(4,"Transport medyczny"),
                new KategoriaWyjazdu(5,"Bole w klatce piersiowej"),
                new KategoriaWyjazdu(6,"Zlamania konczyn"),
                new KategoriaWyjazdu(7,"Utrata przytomnosci"),
                new KategoriaWyjazdu(8,"Krwotoki"),
                new KategoriaWyjazdu(9,"Urazy"),
                new KategoriaWyjazdu(10,"Inne")
            };

#endregion

            #region parametry wejsciowe
            int liczbaRekordow = 1000;
            //System.Console.Write("Wpisz liczbe rekordow: ");
            //liczbaRekordow = System.Convert.ToInt32(System.Console.ReadLine());

            DateTime datestart = Convert.ToDateTime("2014-01-01");
            DateTime dateend = Convert.ToDateTime("2014-10-10");;
            //System.Console.Write("Wpisz date poczatkowa (RRRR-MM-DD): ");
            //datestart = System.Convert.ToDateTime(System.Console.ReadLine());
            //System.Console.Write("Wpisz date koncowa (RRRR-MM-DD): ");
            //dateend = System.Convert.ToDateTime(System.Console.ReadLine());
            #endregion

            var rand = new Random(Environment.TickCount);

            #region pracownicy
            var iloscPracownikow = rand.Next(50, 100);
            var imiona = new List<string>(){"Adam","Ewa","Marek","Danuta","Kazimierz","Dawid","Marcin","Patrycja","Adrian","Pawel",
                                            "Jakub","Igor","Maksymilian","Edyta","Barbara","Julia","Natalia","Blanka","Laura","lukasz",
                                            "Michal","Andrzej","Kamil","Jan","Julian","Magdalena","Paulina","Jedrzej","Mateusz","Grzegorz"};
            var nazwiska = new List<string>(){"Kubale","Goczyla","Jastrzebski","Ocetkiewicz","Turowski","Buclaw","Grzesiak","Nowak","Wesolowski","Ziemski",
                                              "Witt","Lietz","Patz","Kortas","Kiedrowicz","Mazur","Kobus","Gruchala","Galik","Debski",
                                              "Daniels","Frymark","Klepin","Meller","Rozek","Glock","Krzoska","Wyrwicki","Klawikowski","Lubicz"};
            var pracownicy = new HashSet<Pracownik>();
            var dyspozytorzy = new HashSet<Pracownik>();
            while (pracownicy.Count < iloscPracownikow)
            {
                var imie = imiona.ElementAt(rand.Next(imiona.Count));
                var nazwisko = nazwiska.ElementAt(rand.Next(nazwiska.Count));
                var funkcja = funkcjePracownika.ElementAt(rand.Next(funkcjePracownika.Count));
                var pesel1 = rand.Next(10000, 99999);
                var pesel2 = rand.Next(10000, 99999);
                var pesel_str = pesel1.ToString() + pesel2.ToString() + rand.Next(0, 9).ToString();

                var pracownik = new Pracownik() { ID_funkcji = funkcja.Id, Imie = imie, Nazwisko = nazwisko, PESEL = pesel_str };
                pracownicy.Add(pracownik);

                if (funkcja.Nazwa == "Dyspozytor")
                    dyspozytorzy.Add(pracownik);
            }
            #endregion
            #region pojazdy
            var iloscPojazdow = rand.Next(20, 30);
            var marki = new List<string>() { "Opel", "Mercedes", "Ford", "Renault", "Audi", "Peugeot","Saab" ,"Suzuki","Mitsubushi","Ferrari",
                                             "Honda","Hyundai","Alfa Romeo","Porsche","Seat","Subaru","Mazda","Dodge","Daewoo","Dacia"};
            var modele = new List<string>() { "A3", "C7", "Kaktus", "Sprinter", "4", "5", "Astra", "Benz", "Transit", "A4",
                                              "Boxer","Curier","Passat","Clio","Partner","Combo","Ducato","Jumper","Movano","Berlingo" };
            var pojazdy = new HashSet<Pojazd>();
            while (pojazdy.Count < iloscPojazdow)
            {
                var marka = marki.ElementAt(rand.Next(marki.Count));
                var model = modele.ElementAt(rand.Next(modele.Count));
                var aktywny = rand.Next(0, 10);
                var aktywny_bool = (aktywny <= 8);
                var nr_rej1 = "GD";
                var nr_rej2 = rand.Next(10000, 99999);
                var nr_rej = nr_rej1.ToString() + nr_rej2.ToString();

                var pojazd = new Pojazd() {Nr_rejestracyjny = nr_rej, Marka = marka, Model = model, Aktywny = aktywny_bool};
                pojazdy.Add(pojazd);
                System.Console.WriteLine(pojazd);

            }
            #endregion
            #region zespoly
            var timeDelta = dateend - datestart;
            var liczbaDni = timeDelta.Days;
            var liczbaZespolow = 15*2*liczbaDni;

            var zespoly = new HashSet<Zespol>();

            DateTime start = datestart;
            while (zespoly.Count < liczbaZespolow)
            {
                for (int i = 0; i < 15; i++)
                {
                    var idZespol = zespoly.Count + 1;
                    var idPojazdu = pojazdy.ElementAt(rand.Next(pojazdy.Count));
                    var rodzajZespolu = rodzajeZespolu.ElementAt(rand.Next(rodzajeZespolu.Count));

                    var zajety = rand.Next(0, 10);
                    var zajety_bool = (zajety <= 7);

                    var koniec = start + TimeSpan.FromHours(12);
                    var zespol = new Zespol()
                    {
                        ID_pojazdu = idPojazdu.Nr_rejestracyjny,
                        ID_rodzaj = rodzajZespolu.Id,
                        ID_zespolu = idZespol,
                        Rozpoczecie_dyzuru = start,
                        Zakonczenie_dyzuru = koniec,
                        Zajety = zajety_bool
                    };
                    zespoly.Add(zespol);                    
                }
                start += TimeSpan.FromHours(12);
            }
            #endregion
            #region przynaleznosc
            var przynaleznosci = new HashSet<Przynaleznosc>();
            foreach (var zespol in zespoly)
            {
                var liczbaCzlonkow = rand.Next(2, 4);

                for (int i = 0; i < liczbaCzlonkow; i++)
                {
                    var ID_pracownika = pracownicy.ElementAt(rand.Next(pracownicy.Count));
                    var ID_zespolu = zespol;
                    var przynaleznosc = new Przynaleznosc()
                    {
                        PESEL = ID_pracownika.PESEL,
                        ID_zespol = ID_zespolu.ID_zespolu
                    };
                    if (!przynaleznosci.Contains(przynaleznosc))
                        przynaleznosci.Add(przynaleznosc);
                }
            }
            #endregion
            #region rozmowy
            var rozmowy = new HashSet<Rozmowa>();
            var wyjazdy = new HashSet<Wyjazd>();
            var miasta = new List<string>() { "Gdansk", "Sopot", "Gdynia", "Chwaszczyno", "Pruszcz Gdanski", "zukowo", "Kartuzy", "Tczew", "Puck","Sztum",
                    "Wejherowo","Pepowo","Przejazdowo","Banino","Miszewo","Borkowo","Glincz","Niestepowo","Kolbudy","Straszyn",
                    "Suchy Dab", "Tuchom","Czeczewo","Lezno","Cedry Male","Rozyny","Warcz","Piaski","Nowy Dwor Gdanski", "Pszczolki"};
            var ulice = new List<string>() { "Pomorska", "Wejhera", "Grunwaldzka", "Chlopska", "Gdynska","Jelitkowska","Traugutta","Glowna","Kopernika","Lesna",
                    "Niemcewicza","Zielona","Kwiatowa","Koscielna", "Szkola","Lipowa","Agrestowa", "Obroncow Wybrzeza","Kolobrzeska","Cystersow",
                    "Oliwska", "Morska","Jagielonska","Poniatowskiego","Curie-Sklodowskiej","Jana Pawla II","Franciszkanska","Wesola","Brzozowa","Targowa",
                    "Bema","Sloneczna","Kasztanowa","Rozana" };
            var info = new List<string>() { "Wysoka goraczka", "Nie dawno przebyta operacja", "Naduzycie alkoholu", "Zaczal sie porod", "Ostatni dom po prawej", "Przyjmuje leki na serce", "Cukrzyca", "Kawalek drogi trzeba isc pieszo" };
            var leki = new List<string>() { "Acetylsalicylic acid","Amiodarone","Atropinum sulfuricum","Clemastine","Diazepam","Epinephrine bitartrate","Flumazenil",
                                            "Furosemide","Glucagon hydrochloride","Glucosum 20%","Glucosum 5%","Glyceryl trinitrate","Hydrocortisone","Methylprednisolone",
                                            "Magnesii sulfuricum","Ketoprofen","Lignocainum hydrochloricum","Midazolam","Metoclopramidum","Morphine sulphate",
                                            "Naloxonum hydrochloricum","Natrium chloratum 0,9%","Salbutamol","Solutio Ringeri"};
            var jednostki = new List<string>() { "1 mg", "1 amp", "250 mg", "0,5 mg", "0,25 mg", "1,5 mg", "2,5 mg", "10 mg", "30 mg", "3 mg", "60 mg" };

            var arkusze1 = new HashSet<Arkusz1>();
            var arkusze2 = new HashSet<Arkusz2>();
            

            while( rozmowy.Count< liczbaRekordow){
                var ID_rozmowy = rozmowy.Count +1;
                var ID_pracownika = dyspozytorzy.ElementAt(rand.Next(dyspozytorzy.Count));
                //Data jest totalnie losowa nie ma kolejnosci
                int range = (dateend-datestart).Days;
                DateTime data= datestart.AddDays(rand.Next(range)).AddHours(rand.Next(0, 24)).AddMinutes(rand.Next(0, 60)).AddSeconds(rand.Next(0, 60));
               //
                var czasTrwania = rand.Next(0, 20);
                var telefon = rand.Next(100000000, 999999999);
                var rozmowa = new Rozmowa() { 
                    ID_rozmowa = ID_rozmowy,
                    PESEL = ID_pracownika.PESEL,
                    Data = data,
                    Czas_trwania = czasTrwania,
                    Nr_telefonu = telefon, 
                };
                rozmowy.Add(rozmowa);

                var losowanieWyjazdu = rand.Next(0, 10);
                if (losowanieWyjazdu > 6) continue; // przerwanie petli

                
                   
                 var ID_wyjazdu = wyjazdy.Count + 1;
                 var ID_zespolu = zespoly.ElementAt(rand.Next(zespoly.Count));
                 var ID_kategorii = kategorieWyjazdow.ElementAt(rand.Next(kategorieWyjazdow.Count));
                        var KodWyjazdu = rand.Next(1, 3);
                        var adresMiasto = miasta.ElementAt(rand.Next(miasta.Count));
                        var adresUlica = ulice.ElementAt(rand.Next(ulice.Count));
                        var adresNrBudynku = rand.Next(1, 500).ToString();
                        var adresLokalu = rand.Next(1, 40).ToString();
                        var informacje = info.ElementAt(rand.Next(info.Count));
                        var wyjazd = new Wyjazd()
                        {
                            ID_wyjazdu = ID_wyjazdu,
                            ID_zespolu = ID_zespolu.ID_zespolu,
                            ID_rozmowy = ID_rozmowy,
                            Data = data,
                            ID_kategorii = ID_kategorii.Id,
                            Kod_wyjazdu = KodWyjazdu,
                            Adres_miasto = adresMiasto,
                            Adres_ulica = adresUlica,
                            Adres_nr_domu = adresNrBudynku,
                            Adres_nr_lokalu = adresLokalu,
                            Dodatkowe_informacje = informacje

                        };
                        wyjazdy.Add(wyjazd);

                        #region EXCEL
                        //ARKUSZ1
                        if (rand.Next(0, 10) < 5)
                        {
                            for (int j = 0; j < rand.Next(1, 3); j++)
                            {
                                var nazwaLeku = leki.ElementAt(rand.Next(leki.Count));
                                var iloscZuzytychLekow = rand.Next(1, 5);
                                var jednostkiMiary = jednostki.ElementAt(rand.Next(jednostki.Count));
                                var arkusz1 = new Arkusz1()
                                {
                                    IdWyjazdu = ID_wyjazdu,
                                    NazwaLeku = nazwaLeku,
                                    IloscZuzytychLekow = iloscZuzytychLekow,
                                    JednostkaMiary = jednostkiMiary
                                };
                                arkusze1.Add(arkusz1);
                                System.Console.WriteLine(arkusz1);
                            }
                        }
                        //ARKUSZ2
                        var czasDojazdu = rand.Next(10, 40);
                        DateTime dataPrzyjazdu = data + TimeSpan.FromMinutes(czasDojazdu * 2) + TimeSpan.FromMinutes(rand.Next(5, 15));
                        var czyOdnalezionoPacjenta = (rand.Next(0, 10) <= 8);
                        var czyUdzielonoPomocy = (rand.Next(0, 10) < 7);
                        var liczbaKilometrow = rand.Next(1, 50);
                        //jezeli jedzie karetka to moze byc jeden poszkodowany czy po prostu na miejscu wypadku liczba poszkodowanych 
                        var liczbaCzerwonych = rand.Next(0, 2);
                        var liczbaZoltych = rand.Next(0, 4);
                        var liczbaZielonych = rand.Next(0, 6);
                        var arkusz2 = new Arkusz2()
                        {
                            IdWyjazdu = ID_wyjazdu,
                            DataWyjazdu = data,
                            DataPrzyjazdu = dataPrzyjazdu,
                            CzasDojazdu = czasDojazdu,
                            CzyOdnalezionoPacjenta = czyOdnalezionoPacjenta,
                            CzyUdzielonoPomocy = czyUdzielonoPomocy,
                            LiczbaKilometrow = liczbaKilometrow,
                            LiczbaCzerwonych = liczbaCzerwonych,
                            LiczbaZoltych = liczbaZoltych,
                            LiczbaZielonych = liczbaZielonych
                        };
                        arkusze2.Add(arkusz2);
                        #endregion EXCEL
            }
            #endregion rozmowy

            #region serializacja
            string txt;
            txt = ExtensionMethods.CSV.ToCsv(rodzajeZespolu);
            using (var outfile = new StreamWriter(Path + "rodzajeZespolu.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(funkcjePracownika);
            using (var outfile = new StreamWriter(Path + "funkcjePracownika.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(kategorieWyjazdow);
            using (var outfile = new StreamWriter(Path + "kategorieWyjazdow.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(pracownicy);
            using (var outfile = new StreamWriter(Path + "pracownicy.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(pojazdy);
            using (var outfile = new StreamWriter(Path + "pojazdy.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(zespoly);
            using (var outfile = new StreamWriter(Path + "zespoly.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(przynaleznosci);
            using (var outfile = new StreamWriter(Path + "przynaleznosci.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(rozmowy);
            using (var outfile = new StreamWriter(Path + "rozmowy.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(wyjazdy);
            using (var outfile = new StreamWriter(Path + "wyjazdy.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(arkusze1);
            using (var outfile = new StreamWriter(Path + "arkusze1.csv"))
            {
                outfile.Write(txt.ToString());
            }

            txt = ExtensionMethods.CSV.ToCsv(arkusze2);
            using (var outfile = new StreamWriter(Path + "arkusze2.csv"))
            {
                outfile.Write(txt.ToString());
            }

            #endregion serializacja
        }

       
    }
}
