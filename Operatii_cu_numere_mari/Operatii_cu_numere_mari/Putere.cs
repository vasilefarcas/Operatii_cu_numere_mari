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
            for (; i < v.Length; i++)
                Console.Write(v[i]);
        }

        /// <summary>
        /// Metoda in care prin inmultiri repetate vom ridica la putere vetorul v.
        /// </summary>
        /// <param name="v">Vectorul pe care il ridicam la putere.</param>
        /// <param name="init">Valoarea initiala a vectorului pentru a nu ii pierde valoarea initiala.</param>
        /// <param name="p">Puterea la care vom ridica.</param>
        /// <returns></returns>
        private static int[] Ridicare_La_Putere(int[] v, int[] init, int[] p)
        {
            bool ok = true;
            int nr, i;
            // In cazul in care puterea este 0 vom returna 1.
            if (p.Length == 1 && p[0] == 0)
            {
                int[] r = new int[1];
                r[0] = 1;
                return r;
            }
            p[p.Length - 1]--;
            int[] d = { 1 };
            while (ok == true)
            {
                // Pentru a scadea din p cate 1 de fiecare data cand realizam o inmultire vom utiliza Clasa Scadere.
                if (p.Length == 1)
                    p = Scadere.Scadere_Egale(p, d);
                else
                    p = Scadere.Scadere_Inegale(p, d);

                // Prin intermediul inmultirilor repetate vom ridica la putere. Pentru aceasta vom folosi Clasa Adunare.
                v = Inmultire.Inmultire_Numere(v, init);

                // aici se verifica daca puterea a ajuns la 0, iar in acest caz programul se va opri.
                nr = 0;
                foreach (int item in p)
                {
                    if (item == 0)
                        nr++;
                }
                i = 0;
                // Se numara, iar apoi se elimina valorile de 0 de la inceputul rezultatelor obtinute.
                while (v[i] == 0 && i < v.Length - 1)
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
        /// <param name="al_doilea">Al doilea sir de caractere care reprezinta puterea la care il vom ridica pe cel introdus anterior.</param>
        private static void Citire_Numere(ref string primul, ref string al_doilea)
        {
            Console.Clear();
            Console.WriteLine("Introduceti numarul pe care doriti sa il ridicati la putere:");
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti puterea la care doriti sa il ridicati pe numarul introdus anterior:");
            al_doilea = Console.ReadLine();
        }

    }
}
