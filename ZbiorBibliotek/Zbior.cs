using System;
using System.Linq;

namespace ZbiorBiblioteka
{
    public class Zbior
    {
        private static int M_ROZ = 2000;
        protected int[] zbior = new int[M_ROZ];
        protected int roz = 0;
        public void dodaj(int n)
        {
            zbior[roz++] = n;
        }
        public void usun(int n)
        {
            int indeks = Array.IndexOf(zbior, n);
            if (indeks == -1)
                throw new ArgumentException();
            else
                zbior = zbior.Where((source, index) => index != indeks).ToArray();
        }
        public int losuj()
        {
            Random r = new Random();
            int indeks = r.Next(0, roz);
            int liczba = zbior[indeks];
            zbior = zbior.Where((source, index) => index != indeks).ToArray();
            return liczba;
        }
        public int pobierzSume()
        {
            int suma = 0;
            if (roz == 0)
                return suma;
            else
                foreach (int i in zbior)
                    suma += i;
            return suma;
        }
        public void iloraz_elem(int n)
        {
            int suma = 0;
            if (n == 0)
                throw new ArgumentException();
            else
                for (int i = 0; i < roz; i++)
                    zbior[i] /= n;
        }
        public bool sprawdz(int n)
        {
            bool znaleziony;
            if (Array.IndexOf(zbior, n) == -1)
                znaleziony = false;
            else
                znaleziony = true;
            return znaleziony;
        }
        public int pobierz_rozmiar()
        {
            return roz;
        }
    }
}
