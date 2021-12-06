using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatii_cu_numere_mari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Operatiile care se pot executa sunt: adunare, scadere, inmultire, impartire, ridicare la putere si radacina patrata.\n" +
                "Fiecare operatie are un numar. Pentru a efectua operatia respectiva introduceti numarul si apasati tasta \"ENTER\"\n" +
                "1 - adunare\n" +
                "2 - scadere\n" +
                "3 - inmultire\n" +
                "4 - impartire\n" +
                "5 - ridicare la putere\n" +
                "6 - radacina patrata\n" +
                "Introduceti varianta:");
            int varianta = 0;
            while (varianta > 6 || varianta < 1)
            {
                try
                {
                    varianta = int.Parse(Console.ReadLine());
                    Console.WriteLine(varianta);
                    Console.WriteLine("Introduceti o valoare dintre cele valide:");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Introduceti doar valori numerice din intervalul [1,6].");

                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("Introduceti doar valori numerice din intervalul [1,6].");
                }
            }
            switch (varianta)
            {
                case 1:
                    Adunare.Adunare_Numere();
                    break;
                case 2:
                    Scadere.Scadere_Numere();
                    break;
                case 3:
                    Inmultire.Inmultire_Numere();
                    break;
                default:
                    Console.WriteLine(" ");
                    break;
            }
            Console.ReadKey();
        }
    }
}
