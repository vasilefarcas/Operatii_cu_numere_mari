using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Adunare
    {

        /// <summary>
        /// In aceasta metoda o sa 
        /// </summary>
        public static void Adunare_Numere()
        {
            string primul = string.Empty, al_doilea = string.Empty;
            Citire_Numere(ref primul, ref al_doilea);
            int[] v = new int[primul.Length], a = new int[al_doilea.Length];
            Convertire(ref v, primul);
            Convertire(ref a, al_doilea);
            if (primul.Length == al_doilea.Length)
                Afisare_Rezultat(Adunare_Egale(v, a));
            else
                Afisare_Rezultat(Adunare_Inegale3(v, a));

        }

        private static void Convertire(ref int[] a, string b)
        {
            int i = 0;
            while (i < b.Length)
            {
                a[i] = int.Parse(Convert.ToString(b[i]));
                i++;
            }
        }

        private static void Citire_Numere(ref string primul, ref string al_doilea)
        {
            Console.Clear();
            Console.WriteLine("Introduceti primul numar:");
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti cel de al doilea numar:");
            al_doilea = Console.ReadLine();
        }

        private static int[] Adunare_Egale(int[] a, int[] b)
        {
            int l = a.Length, i, j;
            // Adunarea
            int[] c = new int[l + 2];

            for (i = 0; i < l; i++)
            {
                c[i] = c[i] + (a[i] + b[i]) % 10;
                if (a[i] + b[i] > 9)
                    c[i + 1]++;
            }
            Array.Reverse(c);
            return c;
        }

        private static void Adunarea(string primul, string al_doilea)
        {
            int max = Math.Max(primul.Length, al_doilea.Length), min = Math.Min(primul.Length, al_doilea.Length);
            if (max == min)
            {
                int[] rezultat = new int[max];
                int i = max - 1;
                int unu, doi, ok = 0;
                for (; i >= 0; i--)
                {
                    // aici vom stoca pe rand valoarea celor doua numere din cele doua siruri.
                    unu = int.Parse(Convert.ToString(primul[i]));
                    doi = int.Parse(Convert.ToString(primul[i]));
                    rezultat[i] = (unu + doi) % 10 + ok;
                    ok = 0;
                    // in variabila ok stocam valoarea 1 in cazul in care suma celor doua numere este mai mare decat 9
                    if (unu + doi > 9)
                        ok = 1;
                    else
                        ok = 0;
                }
                if (int.Parse(Convert.ToString(primul[0])) + int.Parse(Convert.ToString(primul[0])) > 9)
                    ok = 1;
                else
                    ok = 0;
                // Afisare_Rezultat(rezultat, ok);
            }
        }

        private static void Afisare_Vector(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i]);
        }

        private static void Afisare_Rezultat(int[] v)
        {
            Console.WriteLine("Rezultatul este:");
            int i = 0;
            while (v[i] == 0)
                i++;
            for (; i < v.Length; i++)
                Console.Write(v[i]);
        }
        /// <summary>
        /// Aceasta functie aduna doua numere de dimensiuni mari introduse de la tastatura.
        /// </summary>
        public static void Adunare_Numere1()
        {
            Console.Clear();
            Console.WriteLine("Introduceti primul numar:");
            string primul, al_doilea;
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti cel de al doilea numar:");
            al_doilea = Console.ReadLine();
            // lungimea celui mai mare dintre cele doua numere si lungimea celui mai mic dintre cele doua numere.
            int max = Math.Max(primul.Length, al_doilea.Length), min = Math.Min(primul.Length, al_doilea.Length);
            if (min == max)
            {
                int[] rezultat = new int[max];
                int i = max - 1;
                int unu, doi, ok = 0;
                for (; i >= 0 || i > min; i--)
                {
                    // aici vom stoca pe rand valoarea celor doua numere din cele doua siruri.
                    unu = int.Parse(Convert.ToString(primul[i]));
                    doi = int.Parse(Convert.ToString(al_doilea[i]));
                    rezultat[i] = (unu + doi) % 10 + ok;
                    ok = 0;
                    // in variabila ok stocam valoarea 1 in cazul in care suma celor doua numere este mai mare decat 9
                    if (unu + doi > 9)
                        ok = 1;
                    else
                        ok = 0;
                }

                // afisarea rezultatului 
                for (i = 0; i < max; i++)
                    Console.Write(rezultat[i]);

            }

        }


        private static int[] Adunare_Inegale(int[] a, int[] b)
        {
            int l1 = a.Length, l2 = b.Length, i, j, ok = 0, lun = Math.Min(l1, l2);
            // Adunarea
            int[] c = new int[Math.Max(l1, l2) + 2];

            for (i = 0; i < lun; i++)
            {
                c[i] = c[i] + (a[i] + b[i]) % 10;
                if (a[i] + b[i] > 9)
                    c[i + 1]++;
            }

            if (lun == l1)
                while (i < Math.Max(l1, l2))
                {
                    c[i] = (b[i] + ok) % 10;
                    i++;
                }
            else
                if (lun == l2)
                while (i < Math.Max(l1, l2))
                {
                    c[i] = (a[i] + ok) % 10;
                    i++;
                }
            return c;
        }

        private static int[] Adunare_Inegale2(int[] a, int[] b)
        {
            int l1 = a.Length, l2 = b.Length, i, j;
            int[] c = new int[Math.Max(l1, l2) + 2];
            i = 0;
            if (l1 < l2)
            {
                while (l1 + i < l2)
                {
                    c[i] = b[i];
                    i++;
                }
                int q;
                j = Math.Max(l1, l2);
                for (q = 0; i < j || q < l1; i++, q++)
                {
                    c[i] = c[i] + (a[q] + b[i]) % 10;
                    if (a[q] + b[i] > 9)
                        c[i + 1]++;
                }

            }
            if (l2 < l1)
            {
                while (l2 + i < l1)
                {
                    c[i] = a[i];
                    i++;
                }
                int q;
                j = Math.Max(l1, l2);
                for (q = 0; i < j || q < l2; i++, q++)
                {
                    c[i] = c[i] + (a[i] + b[q]) % 10;
                    if (a[i] + b[q] > 9)
                        c[i + 1]++;
                }
            }
            return c;
        }

        private static int[] Adunare_Inegale3(int[] a, int[] b)
        {
            int l1 = a.Length, l2 = b.Length, i, j, max = Math.Max(l1, l2) + 1;
            int[] c = new int[Math.Max(l1, l2) + 2];
            for (i = l1 - 1, j = l2 - 1; i >= 0 && j >= 0; i--, j--, max--)
            {
                c[max] = c[max] + (a[i] + b[j]) % 10;
                if (a[i] + b[j] > 9)
                    c[max - 1]++;
            }
            while (i >= 0)
            {
                c[max] = c[max] + a[i];
                max--;
                i--;
            }
            while (j >= 0)
            {
                c[max] = c[max] + b[j];
                max--;
                j--;
            }
            return c;
        }


    }
}
