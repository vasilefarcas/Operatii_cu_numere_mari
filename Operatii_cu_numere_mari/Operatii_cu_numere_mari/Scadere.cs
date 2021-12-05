using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Scadere
    {
        public static void Scadere_Numere()
        {
            // Declaram doua variabile de tip string in care vom salva numerele
            string primul = string.Empty, al_doilea = string.Empty;
            // Introducem numerele de la tastatura, iar transmiterea citirii
            // in program se face prin referinta
            // Pentru a nu copia din nou metoda pentru citire o voi folosi pe cea din clasa pentru adunare
            // La fel si metoda pentru convertirea numerelor.
            Adunare.Citire_Numere(ref primul, ref al_doilea);
            // Declar vectorii in care voi stoca numerele pe rand
            int[] v = new int[primul.Length], a = new int[al_doilea.Length];
            // Convertesc sirurile de caractere in tip int
            Adunare.Convertire(ref v, primul);
            Adunare.Convertire(ref a, al_doilea);
            // Vom aborda diferit scaderea in cazul in care sirurile de numere au 
            // dimensiuni diferite
            if (primul.Length == al_doilea.Length)
                Afisare_Rezultat(Scadere_Egale(v, a));
            else
                Afisare_Rezultat(Scadere_Inegale(v, a));
        }

        private static int[] Scadere_Inegale(int[] a, int[] b)
        {
            // l1 respectiv l2 stocheaza lungimile vectorilor de numere.
            // max stocheaza lungimea maxima dintre cele doua siruri.

            int l1 = a.Length, l2 = b.Length, i, j, max = Math.Max(l1, l2)-1;
            // Declararea noului vector care reprezinta rezultatul final al adunarii, 
            // Acesta are lungimea maximului dintre cele doua plus doua pozitii in cazul
            // in care rezultatul o sa necesite asta
            int[] c = new int[Math.Max(l1, l2)];
            // Pornim cu fiecare vector de la final si adaugam in noul vector creat de la final.
            for (i = l1 - 1, j = l2 - 1; i >= 0 && j >= 0; i--, j--, max--)
            {
                c[max] = c[max] + (a[i] - b[j] + 10) % 10;
                // In cazul in care suma celor doua numere de pe pozitia i si j este mai mare decat 9
                // vom adauga 1 la pozitia urmatoare.
                if (a[i] - b[j] < 0)
                    c[max - 1]--;
            }
            // Aici completam din numarul de lungime mai mare partea care nu a fost adaugata in 
            // for-ul anterior
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

        private static int[] Scadere_Egale(int[] a, int[] b)
        {
            // l reprezinta lungimea numerelor.
            int l = a.Length, i;
            // Vectorul c in care vom stoca rezultatul.
            int[] c = new int[l];

            for (i = l - 1; i >= 0; i--)
            {
                c[i] = c[i] + (a[i] - b[i]) % 10;
                if (a[i] + b[i] < 0)
                    c[i - 1]--;
            }
            // Returnam rezultatul.
            return c;
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
            if (v[i] <0)
                Console.Write("-");
            // Afisam vectorul.
            for (; i < v.Length; i++)
                Console.Write(Math.Abs(v[i]));
        }
    }
}
