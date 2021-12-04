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
            AdunareI(v, a);
        }

        private static void Convertire(ref int[] a, string b)
        {
            int i = 0;
            while(i<b.Length)
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

        private static void Afisare_Rezultat(char[] v, int ok)
        {
            Console.WriteLine("Rezultatul este:");
            if (ok == 1)
                Console.Write("1");
            for (int i = 0; i < v.Length; i++)
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

        private static void AdunareI(int[] a, int[] b)
        {
            int l1 = a.Length, l2 = b.Length, i, j, ok = 0, lun = Math.Min(l1, l2);
            // Adunarea
            char[] c = new char[Math.Max(l1, l2) + 1];
            for (i = 0; i < lun; i++)
            {
                c[i] = Convert.ToChar(((a[i] + b[i]) + ok) % 10);
                ok = 0;
                if (a[i] + b[i] > 9)
                    ok = 1;
            }
            if (lun == l1)
                while (i < Math.Max(l1, l2) - 1)
                {
                    c[i] = Convert.ToChar((b[i] + ok) % 10);
                    i++;
                }
            else
                if (lun == l2)
                while (i < Math.Max(l1, l2) - 1)
                {
                    c[i] = Convert.ToChar((a[i] + ok) % 10);
                    i++;
                }
            Array.Reverse(c);
            i = 0;
            if (l1 == l2)
                ok = 1;
            else
                ok = 0;
            while (Convert.ToInt32(c[i]) == 0)
                i++;
            for (; i < c.Length; i++)
                Console.Write(Convert.ToInt32(c[i]));
            Afisare_Rezultat(c, ok);
        }

    }
}
