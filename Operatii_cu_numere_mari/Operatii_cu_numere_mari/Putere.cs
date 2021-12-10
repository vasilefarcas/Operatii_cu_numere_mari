using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Putere
    {
        /// <summary>
        /// Metoda in care punem laolalta toate metodele create pentru a aduna cele doua numere de dimensiuni mari.
        /// </summary>
        public static void Ridicare_La_Putere_Numere()
        {
            // Declaram doua variabile de tip string in care vom salva numerele
            string primul = string.Empty, al_doilea = string.Empty;
            // Introducem numerele de la tastatura, iar transmiterea citirii
            // in program se face prin referinta
            Citire_Numere(ref primul, ref al_doilea);
            // Declar vectorii in care voi stoca numerele pe rand
            int[] v = new int[primul.Length], a = new int[al_doilea.Length];
            // Convertesc sirurile de caractere in tip int
            Adunare.Convertire(ref v, primul);
            Adunare.Convertire(ref a, al_doilea);
            Afisare_Rezultat(Ridicare_La_Putere(v, v, a));
        }

        private static void Afisare_Rezultat(int[] v)
        {
            int i = 0;
            while (v[i] == 0)
                i++;
            Console.WriteLine("Rezultatul este:");
            for(;i<v.Length;i++)
                Console.Write(v[i]);
        }

        private static int[] Ridicare_La_Putere(int[] v, int[] init, int[] p)
        {
            bool ok = true;
            int nr,i;
            p[p.Length - 1]--;
            while (ok == true)
            {
                int[] d = { 1 };
                if (p.Length == 1)
                    p = Scadere.Scadere_Egale(p, d);
                else
                    p = Scadere.Scadere_Inegale(p, d);
                v=Inmultire.Inmultire_Numere(v, init);
                nr = 0;
                foreach (int item in p)
                {
                    if (item == 0)
                        nr++;
                }
                i = 0;
                while (v[i] == 0)
                    i++;
                if (nr == p.Length)
                    ok = false;
                Array.Reverse(v);
                Array.Resize(ref v, v.Length - i);
            }
            return v;
        }

        /// <summary>
        /// Metoda prin care citim cele doua numere in variabile de tip string.
        /// </summary>
        /// <param name="primul">Primul sir de caractere.</param>
        /// <param name="al_doilea">Al doilea sir de caractere.</param>
        private static void Citire_Numere(ref string primul, ref string al_doilea)
        {
            Console.Clear();
            Console.WriteLine("Introduceti numarul pe care doriti sa il ridicati la putere:");
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti puterea la care doriti sa il ridicati pe numarul introdus anterior:");
            al_doilea = Console.ReadLine();
        }

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
    }
}
