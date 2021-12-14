using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Radical
    {

        public static void RadacinaPatrata()
        {
            // Declaram o variabila de tip string.
            string numar = string.Empty;

            // Introducem numerele de la tastatura, iar transmiterea citirii
            // in program se face prin referinta
            Citire_Numar(ref numar);
            
            // Declar vectorul in care vom stoca numarul
            int[] v = new int[numar.Length];
            
            // Convertesc sirul de caractere in tip int
            Adunare.Convertire(ref v, numar);
            
            Afisare_Rezultat(Radicalul(v));
        }

        private static void Citire_Numar(ref string numar)
        {
            Console.Clear();
            Console.WriteLine("Introduceti numarul pentru care doriti sa ii aflati radicalul:");
            numar = Console.ReadLine();
        }


        /// <summary>
        /// Metoda in care prin intermediu metodei Babiloniana vom ajunge la radacina patrata a volorii introduse.
        /// </summary>
        /// <param name="v">Valoarea careia vom afla radacina patrata.</param>
        /// <returns>Returneaza radacina patrata a valorii introduse.</returns>
        private static int[] Radicalul(int[] v)
        {
            int[] rez = new int[1], rezv = new int[1], rezvv=new int[1];
            rez[0] = 1;
            rezv[0] = 0;
            rezvv[0] = 0;
            int ok = 0;
            int[] d = new int[1];
            d[0] = 2;
            while (ok==0)
            {
                rezvv = rezv;
                rezv = rez;
                rez = Impartirea(Adunare.Adunarea_Numerelor(rez, Impartirea(v,rez)),d);
                ok = Comparare(rezvv, rez);
            }
            return rez;
        }

        /// <summary>
        /// Metoda care verifica daca doi vectori de tip int sunt egali.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> In cazul in care sunt egali se returneaza 1, in caz contrar 0.</returns>
        private static int Comparare(int[] a, int[] b)
        {
            int i = a.Length - 1, j = b.Length - 1;
            while (i >= 0 || j >= 0)
            {
                if (a[i] > b[j])
                    return 0;
                if (a[i] < b[j])
                    return 0;
                i--;
                j--;
            }
            return 1;
        }

        private static void Afisare_Rezultat(int[] rez)
        {
            Console.WriteLine("Rezultatul este:");
            foreach  (int item in rez)
            {
                Console.Write($"{item}");
            }
        }

        /// <summary>
        /// Aceasta este metoda de la impartire, insa spre deosebire de aceea, aceasta returneaza o valoare int ci nu un vector.
        /// </summary>
        /// <param name="deimpartit"></param>
        /// <param name="impartitor"></param>
        /// <returns></returns>
        public static int[] Impartirea(int[] deimpartit, int[] impartitor)
        {
            int[] q = new int[1];
            if (deimpartit.Length < impartitor.Length)
            {
                q[0] = 0;
                return q;
            }
            if (deimpartit == impartitor)
            {
                q[0] = 1;
                return q;
            }
                int nr = 0, d = 1;
            while (d == 1)
            {
                if (deimpartit.Length == impartitor.Length)
                    deimpartit = Scadere.Scadere_Egale(deimpartit, impartitor);
                else
                    deimpartit = Scadere.Scadere_Inegale(deimpartit, impartitor);
                d = Impartire.Verificare_Deimpartit(deimpartit);
                nr++;
            }
            if (d == -1)
                nr--;
            int i = 0, aux = nr;
            while (aux != 0)
            {
                aux /= 10;
                i++;

            }
            int[] rez = new int[i];
            i--;
            while (nr != 0)
            {
                rez[i] = nr % 10;
                nr /= 10;
                i--;
            }
            return rez;
        }
    }
}
