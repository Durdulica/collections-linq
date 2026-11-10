using System;

namespace Exercitii
{
    public class Masina :IComparable<Masina>
    {
        public string Model { get; set; }
        public string Marca {  get; set; }
        public int AnFabricare { get; set; }
        public int Pret {  get; set; }
        public Masina(string model, string marca, int an, int pret) 
        {
            Model = model;
            Marca = marca;
            AnFabricare = an;
            Pret = pret;
        }

        public int CompareTo(Masina other)
        {
            if (AnFabricare > other.AnFabricare)
            {
                return AnFabricare;
            }
            else
            {
                return other.AnFabricare;
            }
        }
    }
}
