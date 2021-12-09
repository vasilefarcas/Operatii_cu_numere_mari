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
        /// Metoda in care punem laolalta toate metodele create pentru a aduna cele doua numere de dimensiuni mari.
        /// </summary>
        public static void Adunare_Numere()
        {
            // Declaram doua variabile de tip string in care vom salva numerele
            string primul = string.Empty, al_doilea = string.Empty;
            // Introducem numerele de la tastatura, iar transmiterea citirii
            // in program se face prin referinta
            Citire_Numere(ref primul, ref al_doilea);
            // Declar vectorii in care voi stoca numerele pe rand
            int[] v = new int[primul.Length], a = new int[al_doilea.Length];
            // Convertesc sirurile de caractere in tip int
            Convertire(ref v, primul);
            Convertire(ref a, al_doilea);
            // Vom aborda diferit adunarea in cazul in care sirurile de numere au 
            // dimensiuni diferite
            int z = Math.Max(Inmultire.Numarare_Zerouri_Final(v), Inmultire.Numarare_Zerouri_Final(a));
            if (primul.Length == al_doilea.Length)
                Afisare_Rezultat_Egale(Adunare_Egale(v, a),z);
            else
                Afisare_Rezultat_Inegale(Adunare_Inegale(v, a));

        }

        /// <summary>
        /// Metoda prin care citim cele doua numere in variabile de tip string.
        /// </summary>
        /// <param name="primul">Primul sir de caractere.</param>
        /// <param name="al_doilea">Al doilea sir de caractere.</param>
        public static void Citire_Numere(ref string primul, ref string al_doilea)
        {
            Console.Clear();
            Console.WriteLine("Introduceti primul numar:");
            primul = Console.ReadLine();
            Console.WriteLine("Introduceti cel de al doilea numar:");
            al_doilea = Console.ReadLine();
        }
        
        /// <summary>
        /// Metoda care converteste un sir de caractere in vector de tipul int. 
        /// </summary>
        /// <param name="a">Vectorul in care dorim stocam numarul.</param>
        /// <param name="b">Variabila de tip string pe care o vom converti in vector de tip int.</param>
        public static void Convertire(ref int[] a, string b)
        {
            int i = 0;
            while (i < b.Length)
            {
                a[i] = int.Parse(Convert.ToString(b[i]));
                i++;
            }
        }
        
        /// <summary>
        /// Metoda care aduna doua numere de lungimi egale si returneaza printr-un vector rezultatul. 
        /// </summary>
        /// <param name="a">Primul numar sub forma de vector.</param>
        /// <param name="b">Al doilea numar sub forma de vector.</param>
        /// <returns></returns>
        private static int[] Adunare_Egale(int[] a, int[] b)
        {
            // l reprezinta lungimea numerelor.
            int l = a.Length, i;
            // Vectorul c in care vom stoca rezultatul.
            int[] c = new int[l + 2];

            for (i = 0; i < l; i++)
            {
                c[i] = c[i] + (a[i] + b[i]) % 10;
                if (a[i] + b[i] > 9)
                    c[i + 1]++;
            }
            // Inversam vectorul c pentru ca rezultatul sa fie corect afisat.
            Array.Reverse(c);
            // Returnam rezultatul.
            return c;
        }

        /// <summary>
        /// Metoda care afiseaza rezultatul.
        /// </summary>
        /// <param name="v">Vectorul pe care il vom afisa ca rezultat.</param>
        private static void Afisare_Rezultat_Egale(int[] v, int z)
        {
            Console.WriteLine("Rezultatul este:");
            int i = 0;
            // Sarim peste valorile de 0 de la inceputul sirului in cazul in care acestea exista.
            while (v[i] == 0)
                i++;
            // Afisam vectorul.
            for (; i < v.Length; i++)
                Console.Write(v[i]);
            while (z > 0)
            {
                Console.Write('0');
                z--;
            }
        }

        private static void Afisare_Rezultat_Inegale(int[] v)
        {
            Console.WriteLine("Rezultatul este:");
            int i = 0;
            // Sarim peste valorile de 0 de la inceputul sirului in cazul in care acestea exista.
            while (v[i] == 0)
                i++;
            // Afisam vectorul.
            for (; i < v.Length; i++)
                Console.Write(v[i]);
        }

        /// <summary>
        /// Metoda care aduna doua numere de lungimi diferite si returneaza printr-un vector rezultatul.
        /// </summary>
        /// <param name="a">Primul numar sub forma de vector</param>
        /// <param name="b">Al doilea numar sub forma de vector</param>
        /// <returns></returns>
        private static int[] Adunare_Inegale(int[] a, int[] b)
        {
            // l1 respectiv l2 stocheaza lungimile vectorilor de numere.
            // max stocheaza lungimea maxima dintre cele doua siruri.

            int l1 = a.Length, l2 = b.Length, i, j, max = Math.Max(l1, l2) + 1;
            // Declararea noului vector care reprezinta rezultatul final al adunarii, 
            // Acesta are lungimea maximului dintre cele doua plus doua pozitii in cazul
            // in care rezultatul o sa necesite asta
            int[] c = new int[Math.Max(l1, l2) + 2];
            // Pornim cu fiecare vector de la final si adaugam in noul vector creat de la final.
            for (i = l1 - 1, j = l2 - 1; i >= 0 && j >= 0; i--, j--, max--)
            {
                c[max] = c[max] + (a[i] + b[j]) % 10;
                // In cazul in care suma celor doua numere de pe pozitia i si j este mai mare decat 9
                // vom adauga 1 la pozitia urmatoare.
                if (a[i] + b[j] > 9)
                    c[max - 1]++;
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

        /// <summary>
        /// Metoda care afiseaza un vector de tip int.
        /// </summary>
        /// <param name="v">Vectorul pe care il vom afisa</param>
        private static void Afisare_Vector(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i]);
        }

    }
}
