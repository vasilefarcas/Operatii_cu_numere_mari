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
            int z = Numarare_Zerouri_Final(v)+Numarare_Zerouri_Final(a);
            Afisare_Rezultat(Inmultire_Numere(v, a), z);
        }

        /// <summary>
        /// Metoda care afiseaza rezultatul.
        /// </summary>
        /// <param name="v">Vectorul pe care il vom afisa ca rezultat.</param>
        private static void Afisare_Rezultat(int[] v, int z)
        {
            Console.WriteLine("Rezultatul este:");
            int i = 0;
            Array.Reverse(v);
            // Sarim peste valorile de 0 de la inceputul sirului in cazul in care acestea exista.
            while (v[i] == 0)
                i++;
            if (v[i] < 0)
                Console.Write("-");
            // Afisam vectorul.
            for (; i < v.Length; i++)
                Console.Write(Math.Abs(v[i]));
            // In cazul in care vreunul din numere are valoarea 0 la final vom afisa cate valori de 0 e nevoie.
            while (z != 0)
            {
                Console.Write("0");
                z--;
            }
        }

        /// <summary>
        /// Metoda care calculeaza intr-un al treilea vector produsul celor doua numere transmise ca vector.
        /// </summary>
        /// <param name="v">Primul vector care reprezintaa primul numar.</param>
        /// <param name="a">Al doilea vector care reprezintaa al doilea numar.</param>
        /// <returns></returns>
        private static int[] Inmultire_Numere(int[] v, int[] a)
        {
            int i, j, k = 0, l1 = v.Length, l2 = a.Length;
            int[] c = new int[Math.Max(l1, l2) * 2];
            for (i = 0; i < l1; i++)
            {
                for (j = 0; j < l2; j++)
                {
                    c[j + k] = c[j + k] + (v[i] * a[j]);
                }
                k++;
            }
            // Parcurgem din nou vectorul rezultat, iar in cazul in care valoarea este mai mare decat 9 vom adauga
            // pe pozitia urmatoare valoarea pe care "o tinem in minte".
            for (i = 0; i < c.Length; i++)
                if (c[i] > 9)
                {
                    c[i + 1] = c[i + 1] + c[i] / 10;
                    c[i] %= 10;
                }
            return c;
        }

        /// <summary>
        /// Metoda care numara cate valori 0 avem la finalul unui vector.
        /// </summary>
        /// <param name="v">Vectorul in care vom numara valorile de 0 de la final.</param>
        /// <returns></returns>
        private static int Numarare_Zerouri_Final(int[] v)
        {
            int i = v.Length - 1, nr = 0;
            for (; i > 0; i--)
                if (v[i] == 0)
                    nr++;
                else
                    return nr;
            return nr;

        }
    }
}