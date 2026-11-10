using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercitii
{
    public class Exersare
    {
        public static void PeNumereWhere()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, };

            List<int> rez = lista.Where(x => x > 5).ToList();


            rez.ForEach(t => Console.WriteLine(t));


        }

        public static void PeNumereSelect()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, };

            List<int> rez = lista.Where(x => x > 5).Select(x => 2 * x).ToList();


            rez.ForEach(t => Console.WriteLine(t));
        }

        public static void PeNumereOrderBy()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, };

            List<int> rez = lista.OrderByDescending(x => x).ToList();

            rez.ForEach(t => Console.WriteLine(t));
        }

        public static void PeNumereDistinct()
        {
            List<int> lista = new List<int> { 1, 2, 3, 1, 2, 3 };

            List<int> rez = lista.Distinct().ToList();

            rez.ForEach(x => Console.WriteLine(x));
        }

        public static void PeNumereCount()
        {
            List<int> lista = new List<int> { 1, 2, 3, 4, 2234, 3 };

            int rez = lista.Count(x => x > 2);

            Console.WriteLine(rez);
        }

        public static void PeNumereOperatii()
        {
            List<int> lista = new List<int> { 1, 2, 4, 4, 5, 3 };

            int rez = lista.Max(x => x * 2);
            Console.WriteLine(rez);
            rez = lista.Min(x => x / 3);
            Console.WriteLine(rez);
            rez = lista.Sum();
            Console.WriteLine(rez);
            double rez2 = lista.Average();
            Console.WriteLine(rez2);

            Console.WriteLine(lista.Any(x => x > 4) + " " + lista.All(x => x > 4));
            try
            {
                Console.WriteLine(lista.First(x => x > 5));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.GetType());
            }
            Console.WriteLine(lista.FirstOrDefault(x => x > 5));
        }

        public static void PeNumereMultimi()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            List<int> b = new List<int> { 1, 3, 5 };

            List<int> rez = a.Union(b).ToList();
            rez.ForEach(x => Console.WriteLine(x));
            rez = a.Intersect(b).ToList();
            rez.ForEach(x => Console.WriteLine(x));
            rez = a.Except(b).ToList();
            rez.ForEach(x => Console.WriteLine(x));
        }

        public static void PeObiecte()
        {
            List<Masina> m = new List<Masina> { new Masina("Honda", "CRV", 2001, 1500), new Masina("Dacia", "Logan", 2005, 1900),
                new Masina("Ford", "Focus",2010, 5000) };

            int rez = m.Sum(x => x.Marca.GetHashCode() / 1000);

            Console.WriteLine(m.Max().AnFabricare);
            Console.WriteLine(rez);
        }

        public static void PeObiecteLant() 
        {
            List<Masina> m = new List<Masina> { new Masina("Honda", "CRV", 2001, 1500), new Masina("Dacia", "Logan", 2005, 1900),
                new Masina("Ford", "Focus",2010, 5000) };
            List<string> rez = m.Where(x => x.AnFabricare > 2000)
                .OrderByDescending(x => x.Pret)
                .Select(x => x.Marca + " " + x.Pret)
                .ToList();

            rez.ForEach(x => Console.WriteLine(x));
        }

        public static void PeObiecteGrupuri()
        {
            List<Masina> m = new List<Masina> { new Masina("Honda", "HRV", 2005, 3400), new Masina("Honda", "CRV", 2020, 23000),
                new Masina("Honda","Civic",2014, 7500), new Masina("Dacia", "Logan", 2005, 1900), new Masina("Dacia", "Duster", 2010, 4900),
                new Masina("Ford", "Focus",2010, 5000)};

            Dictionary<string, List<Masina>> rez = m.GroupBy(x => x.Model).ToDictionary(g=>g.Key, g=>g.ToList());
           
            foreach(var v in m.GroupBy(x => x.Model))
            {
                Console.WriteLine(v.Key);
            }
            Console.WriteLine();

            foreach (var key in rez.Keys) 
            {
                Console.Write(key + ": ");
                foreach(var value in rez[key])
                {
                    Console.Write(value.Marca  + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
