using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Inmultire
    {
        public static void Inmultire_Numere()
        {
            // Declaram doua variabile de tip string in care vom salva numerele
            string primul = string.Empty, al_doilea = string.Empty;
            // Introducem numerele de la tastatura, iar transmiterea citirii
            // in program se face prin referinta
            Adunare.Citire_Numere(ref primul, ref al_doilea);
            // Declar vectorii in care voi stoca numerele pe rand
            int[] v = new int[primul.Length], a = new int[al_doilea.Length];
            // Convertesc sirurile de caractere in tip int
            Adunare.Convertire(ref v, primul);
            Adunare.Convertire(ref a, al_doilea);
            // Vom aborda diferit adunarea in cazul in care sirurile de numere au 
            // dimensiuni diferite
            if (primul.Length == al_doilea.Length)
                Afisare_Rezultat(Inmultire_Egale2(v, a));
            else
                Afisare_Rezultat(Inmultire_Inegale(v, a));
        }

        /// <summary>
        /// Metoda care afiseaza rezultatul.
        /// </summary>
        /// <param name="v">Vectorul pe care il vom afisa ca rezultat.</param>
        private static void Afisare_Rezultat(int[] v)
        {
            Console.WriteLine("Rezultatul este:");
            int i = 0;
            // Sarim peste valorile de 0 de la inceputul sirului in cazul in care acestea exista.
            while (v[i] == 0)
                i++;
            if (v[i] < 0)
                Console.Write("-");
            // Afisam vectorul.
            for (; i < v.Length; i++)
                Console.Write(Math.Abs(v[i]));
        }

        private static int[] Inmultire_Egale(int[] a, int[] b)
        {
            // l reprezinta lungimea numerelor.
            int l = a.Length, i;
            // Vectorul c in care vom stoca rezultatul.
            int[] c = new int[2 * l];

            for (i = 0; i < l; i++)
            {

                c[i] = c[i] + (a[i] * b[i]) % 10;
                if (a[i] + b[i] > 9)
                    c[i + 1] += (a[i] * b[i]) / 10;
            }
            // Inversam vectorul c pentru ca rezultatul sa fie corect afisat.
            Array.Reverse(c);
            // Returnam rezultatul.
            return c;
        }

        private static int[] Inmultire_Egale2(int[] a, int[] b)
        {
            // l reprezinta lungimea numerelor.
            int l = a.Length, i, j;
            // Vectorul c in care vom stoca rezultatul.
            int[] c = new int[2 * l];
            int k = 0;
            for (i = 0; i < l; i++)
            {
                for (j = 0; j < l; j++)
                {
                    c[i + k] = c[i + k] + (a[i] * b[j]) % 10;
                    if (a[i] + b[j] > 9)
                        c[i + 1 + k] = c[i + 1 + k] + (a[i] * b[j]) / 10;
                }
                k++;
            }
            // Inversam vectorul c pentru ca rezultatul sa fie corect afisat.
            Array.Reverse(c);
            // Returnam rezultatul.
            return c;
        }

        private static int[] Inmultire_Inegale(int[] v, int[] a)
        {
            int lun = 1;
            int[] c = new int[lun];
            return c;
        }
    }
}