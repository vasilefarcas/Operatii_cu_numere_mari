using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Radical
    {

        public static void Este_PP()
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
            // Afisare_Rezultat(Radicalul(v));
        }

        private static void Citire_Numar(ref string numar)
        {
            Console.Clear();
            Console.WriteLine("Introduceti numarul pe care doriti sa il verificati daca este patrat perfect:");
            numar = Console.ReadLine();
        }

        private static int[] Radicalul(int[] v)
        {
            int[] rez = new int[10], rezv = new int[10];
            bool ok = true;
            return rez;
        }

        private static void Eliminare_Zerouri(ref int[] v)
        {
            int i = 0;
            while (v[i] == 0)
                i++;
            Array.Reverse(v);
            Array.Resize(ref v, v.Length - i);
            Array.Reverse(v);
        }
        /*
        private static int[] Comparare(int[] a, int[] b)
        {
            int i = a.Length-1, j = b.Length-1;
            while ()
                return true;
        }
        */
        private static void Afisare_Rezultat(bool rez)
        {
            if (rez == true)
                Console.WriteLine();
        }
    }
}
