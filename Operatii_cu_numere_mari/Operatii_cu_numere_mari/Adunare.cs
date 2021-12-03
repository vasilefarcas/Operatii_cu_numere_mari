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
        /// Aceasta functie aduna doua numere de dimensiuni mari introduse de la tastatura.
        /// </summary>
        public static void Adunare_Numere()
        {
            Console.Clear();
            Console.WriteLine("Introduceti primul numar:");
            string primul, al_doilea;
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti cel de al doilea numar:");
            al_doilea = Console.ReadLine();
            // lungimea celui mai mare dintre cele doua numere si lungimea celui mai mic dintre cele doua numere.
            int max = Math.Max(primul.Length, al_doilea.Length), min = Math.Min(primul.Length, al_doilea.Length);
            int[] rezultat = new int[max];
            int i = max - 1;
            // aici vom stoca pe rand valoarea celor doua numere din cele doua siruri.
            int unu, doi, ok = 0;
            for (; i >= 0 || i >= min; i--)
            {
                unu = Convert.ToInt32(primul[i]);
                doi = Convert.ToInt32(al_doilea[i]);
                rezultat[i] = (unu + doi) % 10 + ok;
                ok = 0;
                if (unu + doi > 9)
                    ok = 1;
                else
                    ok = 0;
            }
            int l1 = primul.Length, l2 = al_doilea.Length;
            if (l1 != l2)
            {
                if (l1 > l2)
                    for (i = 0; i < min; i++)
                        rezultat[i] = primul[i];
                if (l2 > l1)
                    for (i = 0; i < min; i++)
                        rezultat[i] = primul[i];
            }
            for (i = 0; i < max; i++)
                Console.Write(rezultat[i]);

        }

    }
}
