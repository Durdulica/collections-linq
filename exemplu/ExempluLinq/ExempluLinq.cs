using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLinq
{
    class Zbor
    {
        public string Cod { get; set; }
        public string Destinatie { get; set; }
        public string Companie { get; set; }
        public int Pasageri { get; set; }
        public int Intarziere { get; set; }

        public Zbor(string cod, string destinatie, string companie, int pasageri, int intarziere)
        {
            Cod = cod;
            Destinatie = destinatie;
            Companie = companie;
            Pasageri = pasageri;
            Intarziere = intarziere;
        }
    }

    static class ExempluLinq
    {
        static List<Zbor> Zboruri()
        {
            return new List<Zbor>
            {
                new Zbor("RO101", "Londra", "Tarom", 150, 0),
                new Zbor("RO202", "Paris", "Tarom", 90, 25),
                new Zbor("W6303", "Londra", "Wizz", 180, 40),
                new Zbor("W6404", "Roma", "Wizz", 175, 5),
                new Zbor("LH505", "Munchen", "Lufthansa", 120, 15),
                new Zbor("RO606", "Roma", "Tarom", 60, 55)
            };
        }

        static void Incearca(string eticheta, Action actiune)
        {
            try
            {
                actiune();
                Console.WriteLine(eticheta + " -> ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(eticheta + " -> " + ex.GetType().Name);
            }
        }

        static string Lista<T>(IEnumerable<T> elemente)
        {
            return "[" + string.Join(", ", elemente) + "]";
        }

        static void LinqInterogari()
        {
            Console.WriteLine("--- 1. LINQ: Where, OrderBy, Select");
            List<Zbor> zboruri = Zboruri();
            List<string> pline = zboruri.Where(z => z.Pasageri > 100)
                                        .OrderByDescending(z => z.Pasageri)
                                        .Select(z => z.Cod + " " + z.Pasageri)
                                        .ToList();
            Console.WriteLine(Lista(pline));
            Console.WriteLine(Lista(zboruri.OrderBy(z => z.Companie).ThenByDescending(z => z.Intarziere).Select(z => z.Cod)));
            Console.WriteLine(zboruri.Count(z => z.Intarziere > 0) + " " + zboruri.Sum(z => z.Pasageri) +
                              " " + zboruri.Average(z => z.Intarziere).ToString("0.00") +
                              " " + zboruri.Min(z => z.Intarziere) + " " + zboruri.Max(z => z.Pasageri));
            Console.WriteLine(Lista(zboruri.Select(z => z.Destinatie).Distinct()));
        }

        static void LinqGrupate()
        {
            Console.WriteLine("--- 2. LINQ: GroupBy, Any, All, First");
            List<Zbor> zboruri = Zboruri();
            foreach (var g in zboruri.GroupBy(z => z.Companie).OrderBy(g => g.Key))
            {
                Console.WriteLine(g.Key + ": " + g.Count() + " zboruri, " + g.Sum(z => z.Pasageri) + " pasageri");
            }
            Console.WriteLine(zboruri.Any(z => z.Intarziere > 50) + " " + zboruri.All(z => z.Intarziere > 0));
            Console.WriteLine(zboruri.First(z => z.Destinatie == "Roma").Cod);
            Zbor lipsa = zboruri.FirstOrDefault(z => z.Destinatie == "Oslo");
            Console.WriteLine(lipsa == null ? "null" : lipsa.Cod);
            Incearca("First(Oslo)", () => zboruri.First(z => z.Destinatie == "Oslo"));
            Dictionary<string, int> intarzieri = zboruri.ToDictionary(z => z.Cod, z => z.Intarziere);
            Console.WriteLine(intarzieri["W6303"]);
        }

        static void LinqAmanat()
        {
            Console.WriteLine("--- 3. LINQ amanat");
            List<int> intarzieri = new List<int> { 5, 40, 12 };
            IEnumerable<int> mari = intarzieri.Where(m => m > 30);
            List<int> mariAcum = intarzieri.Where(m => m > 30).ToList();
            intarzieri.Add(90);
            Console.WriteLine(string.Join(" ", mari));
            Console.WriteLine(string.Join(" ", mariAcum));
        }

        public static void Ruleaza()
        {
            LinqInterogari();
            LinqGrupate();
            LinqAmanat();
        }
    }
}
