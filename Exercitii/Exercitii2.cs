using System;
using System.Collections.Generic;
using System.Linq;

class Elev
{
    public string Nume { get; set; }
    public string Clasa { get; set; }
    public double Medie { get; set; }

    public Elev(string nume, string clasa, double medie)
    {
        Nume = nume;
        Clasa = clasa;
        Medie = medie;
    }
}

static class Exercitii2
{
    static List<Elev> Catalog()
    {
        return new List<Elev>
        {
            new Elev("Ana", "12A", 9.50), new Elev("Ion", "11B", 8.20),
            new Elev("Maria", "12A", 9.80), new Elev("Dan", "11B", 9.10),
            new Elev("Ioana", "10C", 7.40), new Elev("Vlad", "10C", 9.50),
            new Elev("Elena", "12A", 4.90)
        };
    }

    static string CelMaiFrecventCuvant(string text)
    {
        Dictionary<string, int> frecvente = new Dictionary<string, int>();
        foreach (string bucata in text.ToLower().Split(' '))
        {
            string cuvant = bucata.Trim('.', ',', '!', '?');
            if (cuvant.Length == 0)
            {
                continue;
            }
            int n;
            frecvente.TryGetValue(cuvant, out n);
            frecvente[cuvant] = n + 1;
        }
        string cel = null;
        int max = 0;
        foreach (KeyValuePair<string, int> p in frecvente)
        {
            if (p.Value > max || (p.Value == max && string.CompareOrdinal(p.Key, cel) < 0))
            {
                cel = p.Key;
                max = p.Value;
            }
        }
        return cel;
    }

    static List<string> Premianti(List<Elev> elevi)
    {
        List<string> list = new List<string>();
        elevi.Sort((a, b) => string.Compare(a.Nume, b.Nume));

        while (elevi.Count > 0)
        {
            Elev e = elevi.MaxBy(x => x.Medie);
            elevi.Remove(elevi.MaxBy(x => x.Medie));

            if(e.Medie < 9) break;

            list.Add(e.Nume + " " + e.Medie);
        }

        return list;
    }

    public static void Ex1()
    {
        List<Elev> elevi = Catalog();
        elevi.Reverse();
        foreach (string linie in Premianti(elevi))
        {
            Console.WriteLine(linie);
        }
    }

    static List<string> RaportClase(List<Elev> elevi)
    {
        List<string> list = new List<string>();
        elevi.Sort((a,b) => string.Compare(a.Clasa, b.Clasa));
        Dictionary<string, List<Elev>> d = elevi.GroupBy(x => x.Clasa).ToDictionary(x => x.Key, x => x.ToList());
        
        foreach (var key in d.Keys) 
        {
            list.Add(key + ": " + d[key].Count + " elevi, media " + (decimal)d[key].Average(x => x.Medie) + ", primul " + d[key].Max(x => x.Medie));
        }//????
        return list;
    }

    public static void Ex2()
    {
        foreach (string linie in RaportClase(Catalog()))
        {
            Console.WriteLine(linie);
        }
    }

    static void SituatiaVizitatoriLinq()
    {
        ISet<string> c = new HashSet<string>() { "Ana", "Ion", "Ana", "Maria", "Ion" };
        Console.WriteLine(c.Count);
    }

    static void ReuniuneCuIonSiEvaLinq()
    {
        ISet<string> s = new HashSet<string>() { "Ana", "Ion", "Maria", };
        ISet<string> s2 = new HashSet<string> { "Ion", "Eva" };
        s.UnionWith(s2);
        Console.WriteLine(string.Join(", ", s));
    }

    static void IntersectieCuIonMariaZoeLinq()
    {
        ISet<string> s = new HashSet<string> { "Ana", "Ion", "Maria" };
        ISet<string> s2 = new HashSet<string> { "Ion", "Maria", "Zoe" };
        s.IntersectWith(s2);
        Console.WriteLine(string.Join(", ", s));
    }

    static void SituatiaClasamentLinq()
    {
        SortedList<string, int> d = new SortedList<string, int>();
        d.Add("Zoe", 5);
        d.Add("Ana", 9);
        d.Add("Ion", 7);
        foreach (KeyValuePair<string, int> kv in d)
        {
            Console.Write(kv.Key + "=" + kv.Value + ", ");
        }
        Console.WriteLine();
    }

    public static void Ex3()
    {
        SituatiaVizitatoriLinq();
        ReuniuneCuIonSiEvaLinq();
        IntersectieCuIonMariaZoeLinq();
        SituatiaClasamentLinq();
    }

    public static void Ex4()
    {
        List<Elev> cat = Catalog();
        Console.WriteLine(cat.Any(x => x.Medie < 5));
        Console.WriteLine(cat.All(x => x.Medie >= 5));
        Console.WriteLine(cat.First(x => x.Clasa == "11B").Nume);
        //Elev lipsa = cat.First(x => x.Clasa == "9A");  ?????
        //Console.WriteLine(lipsa == null ? "null" : lipsa.Nume);
        Console.WriteLine(cat.Max(x => x.Medie));
        try
        {
            Console.WriteLine(cat.First(x => x.Clasa == "9A"));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.GetType().Name);
        }
    }

    public static void Ex5()
    {
        List<int> valori = new List<int> { 5, 20, 8, 30 };
        IEnumerable<int> mari = valori.Where(v => v > 10);
        List<int> mariAcum = valori.Where(v => v > 10).ToList();
        valori.Add(50);
        Console.WriteLine(string.Join(" ", mari));  // 20 30
        Console.WriteLine(string.Join(" ", mariAcum));  // 20 30 50
    }

    static string CelMaiFrecventCuvantLinq(string text)
    {
        //Dictionary<string, int> frecvente = new Dictionary<string, int>();
        //List<string> l = text.Split(" ").ToList();
        //l = l.Select(x => x.ToLower().Trim('.', ',', '!', '?')).ToList();
        return text
            .ToLower()
            .Split(' ')
            .Select(x => x.Trim('.', ',', '!', '?'))
            .Where(c => c.Length > 0)
            .GroupBy(c => c)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key, StringComparer.Ordinal)
            .First()
            .Key;
    }
    public static void Ex6()
    {
        string text = "Ana are mere. Ion are pere, ana are si prune!";
        Console.WriteLine(CelMaiFrecventCuvantLinq(text));
        Console.WriteLine(CelMaiFrecventCuvantLinq("mar par mar par"));
        Console.WriteLine(CelMaiFrecventCuvantLinq("par mar par mar"));
    }
}
