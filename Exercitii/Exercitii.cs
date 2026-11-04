using System;
using System.Collections.Generic;

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

static class Exercitii
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

    public static void Ex1()
    {
    }

    public static void Ex2()
    {
    }

    public static void Ex3()
    {
    }

    public static void Ex4()
    {
    }

    public static void Ex5()
    {
    }

    public static void Ex6()
    {
    }
}
