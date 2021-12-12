using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Impartire
    {
        public static void Impartire_Numere()
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
            Afisare_Rezultat(Impartirea(v, a));
        }

        public static void Citire_Numere(ref string primul, ref string al_doilea)
        {
            Console.Clear();
            Console.WriteLine("Introduceti deimpartitul:");
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti impartitorul:");
            al_doilea = Console.ReadLine();
        }

        public static void Afisare_Rezultat(int rez)
        {
            Console.WriteLine($"Rezultatul este:\n{rez}");
        }

        public static int Impartirea(int[] deimpartit, int[] impartitor)
        {

            if (deimpartit.Length < impartitor.Length)
                return 0;

            if (deimpartit == impartitor)
                return 1;
            int nr = 0, d = 1;
            while (d == 1)
            {
                if (deimpartit.Length == impartitor.Length)
                    deimpartit = Scadere.Scadere_Egale(deimpartit, impartitor);
                else
                    deimpartit = Scadere.Scadere_Inegale(deimpartit, impartitor);
                d = Verificare_Deimpartit(deimpartit);
                nr++;
            }
            if (d == -1)
                nr--;
            return nr;
        }

        public static int Verificare_Deimpartit(int[] d)
        {
            foreach (int item in d)
            {
                if (item > 0)
                    return 1;
                if (item < 0)
                    return -1;
            }
            return 0;
        }
    }
}
