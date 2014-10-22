using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HD;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region slowniki
            List < RodzajZespolu >  rodzajeZespolu;
            rodzajeZespolu = new List<RodzajZespolu>()
            {
                new RodzajZespolu(1,"Podstawowy"),
                new RodzajZespolu(2,"Specjalistyczny"),
                new RodzajZespolu(3,"Transportowy"),
                new RodzajZespolu(4,"Neonatalogiczny")
            };

            List<FunkcjaPracownika> funkcjePracownika;
            funkcjePracownika = new List<FunkcjaPracownika>()
            {
                new FunkcjaPracownika(1, "Dyspozytor"),
                new FunkcjaPracownika(2, "Ratownik kierowca"),
                new FunkcjaPracownika(3, "Ratownik medyczny"),
                new FunkcjaPracownika(4, "Ratownik medyczny kierowca"),
                new FunkcjaPracownika(5, "Pielęgniarka"),
                new FunkcjaPracownika(6, "Lekarz")
            };

            List<KategoriaWyjazdu> kategorieWyjazdow;
            kategorieWyjazdow = new List<KategoriaWyjazdu>()
            {
                new KategoriaWyjazdu(1,"Wypadek komunikacyjny"),
                new KategoriaWyjazdu(2,"Nagłe zatrzymanie krążenia"),
                new KategoriaWyjazdu(3,"Poród"),
                new KategoriaWyjazdu(4,"Transport medyczny"),
                new KategoriaWyjazdu(5,"Bóle w klatce piersiowej"),
                new KategoriaWyjazdu(6,"Złamania kończyn"),
                new KategoriaWyjazdu(7,"Utrata przytomności"),
                new KategoriaWyjazdu(8,"Krwotoki"),
                new KategoriaWyjazdu(9,"Urazy"),
                new KategoriaWyjazdu(10,"Inne")
            };

#endregion

            #region parametry wejsciowe
            int liczbaRekordow = 100;
            //System.Console.Write("Wpisz liczbe rekordow: ");
            //liczbaRekordow = System.Convert.ToInt32(System.Console.ReadLine());

            DateTime datestart = System.Convert.ToDateTime("2014-01-01");
            DateTime dateend = System.Convert.ToDateTime("2014-10-10");;
            //System.Console.Write("Wpisz date poczatkowa (RRRR-MM-DD): ");
            //datestart = System.Convert.ToDateTime(System.Console.ReadLine());
            //System.Console.Write("Wpisz date koncowa (RRRR-MM-DD): ");
            //dateend = System.Convert.ToDateTime(System.Console.ReadLine());
            #endregion

            var rand = new Random(Environment.TickCount);
            var iloscPracownikow = rand.Next(50, 100);
            var imiona = new List<string>(){"Adam","Ewa","Marek","Danuta","Kazimierz"};
            var nazwiska = new List<string>(){"Kubale","Zawadzka","Jastrzębski","Ocetkiewicz","Turowski"};
            var pracownicy = new HashSet<Pracownik>();
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
            }

            var iloscPojazdow = rand.Next(20, 30);
            var marki = new List<string>() { "Opel", "Mercedes", "Ford", "Renault", "Audi", "Peugot" };
            var modele = new List<string>() { "A3", "C7", "Kaktus", "Sprinter", "4", "5", "232", "512", "1024" };
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

                    var koniec = start + TimeSpan.FromHours(12);
                    var zespol = new Zespol()
                    {
                        ID_pojazd = idPojazdu.Nr_rejestracyjny,
                        ID_rodzaj = rodzajZespolu.Id,
                        ID_zespolu = idZespol,
                        Rozpoczecie_dyzuru = start,
                        Zakonczenie_dyzuru = koniec
                    };

                    zespoly.Add(zespol);
                }
                start += TimeSpan.FromHours(12);
            }
        }
    }
}
