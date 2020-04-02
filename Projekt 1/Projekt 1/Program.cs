using System;
using System.Diagnostics;

namespace Projekt_1
{   
    // komentarz dla testow
    class Program
    {
        static int licznik = 0;
        public static int WyszukiwanieBinarne(int[] tab, int szukanie)
        {
            int left = 0;
            int right = tab.Length - 1;

            while(left <= right)
            {
                int CurrentPosition = left + (right - left) / 2;

                if (tab[CurrentPosition] == szukanie)
                    return CurrentPosition;
                if (tab[CurrentPosition] < szukanie)
                    left = CurrentPosition + 1;
                if (tab[CurrentPosition] > szukanie)
                    right = CurrentPosition - 1;
            }
            return -1;
        }

        

        public static int WyszukiwanieBinarneZInstrumentacja(int[] tab, int szukanie)
        {
            int left = 0;
            int right = tab.Length - 1;

            while (left <= right)
            {
                int CurrentPosition = left + (right - left) / 2;

                licznik++;
                if (tab[CurrentPosition] == szukanie)
                    return CurrentPosition;  

                else
                {
                    licznik++;
                    if (tab[CurrentPosition] < szukanie)
                        left = CurrentPosition + 1;
                    else
                        right = CurrentPosition - 1;
                }             
            }
            return -1;
        }


        public static int WyszukiwanieLiniowe(int[] tab, int element)
        {
            for(int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == element)
                    return i;
            }
            return -1;
        }

        public static int WyszukiwanieLinioweInstrumentacja(int[] tab, int element)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                licznik++;
                if (tab[i] == element)
                    return i;
            }
            return -1;
        }


        static void Main(string[] args)
        {

            int rTablicy = Convert.ToInt32(Math.Pow(2, 28)); // rozmiar tablicy
            int[] tablica = Pomocna.Posortowane(rTablicy); // tablica posortowana

            Stopwatch stoperek = new Stopwatch();
            double wynik = 0;

            // wyszukiwanie binarne pesymistyczne

            /* for(int i = 2000000; i < rTablicy; i+=8000000)
             {
                 stoperek.Reset();
                 stoperek.Start();
                 tablica = Pomocna.Posortowane(i);
                 WyszukiwanieBinarne(tablica, -1);
                 stoperek.Stop();
                 wynik = stoperek.ElapsedMilliseconds;
                 Console.WriteLine($"{wynik};{i}");

             } */

            // wyszukiwanie binarne pesymistyczne instrumentacyjne

            /*for(int i = 2000000; i < rTablicy; i+=5000000) 
            {
                tablica = Pomocna.Posortowane(i);
                licznik = 0;
                WyszukiwanieBinarneZInstrumentacja(tablica, -1);
                Console.WriteLine($"{licznik};{i}");
            }*/

            // wyszukiwanie liniowe pesymistyczne

            /*for (int i = 2000000; i < rTablicy; i+=5000000 ) 
            {
                tablica = Pomocna.Posortowane(i);
                stoperek.Reset();
                stoperek.Start();
                WyszukiwanieLiniowe(tablica, -1);
                stoperek.Stop();
                wynik = stoperek.ElapsedMilliseconds;
                Console.WriteLine($"{wynik};{i}");
            }*/

            // wyszukiwanie liniowe pesymistyczne instrumentacyjne

            /* for(int i = 2000000; i <rTablicy; i+=2000000) 
             {
                 tablica = Pomocna.Posortowane(i);
                 licznik = 0;
                 WyszukiwanieLinioweInstrumentacja(tablica, -1);
                 Console.WriteLine($"{licznik};{i}");
             }*/


            // binarne srednie pesymistyczne

            /*int counter = 0;
            for (int i = 2000000; i < rTablicy; i+=2000000) 
            {
                tablica = Pomocna.Posortowane(i);

                stoperek.Reset();
                stoperek.Start();
                counter++;
                WyszukiwanieBinarne(tablica, -1);
                wynik += stoperek.ElapsedTicks;
                stoperek.Stop();
                Console.WriteLine($"{wynik};{i};{counter}");
            }
            double srednia = wynik / counter;
            Console.WriteLine($"{srednia:F02}"); */

            // Binarne srednie pesymistyczne

         /*   int roznica = 0;
            double wyniczek = 0;
            for(int i = 2000000; i < rTablicy; i+=4000000)
            {
                wyniczek = 0;
                tablica = Pomocna.Posortowane(i);            
                for (int j = i/4; j <i/2; j++)
                {
                    stoperek.Reset();
                    stoperek.Start();
                    WyszukiwanieBinarne(tablica, tablica[j]);
                    stoperek.Stop();
                    wyniczek += stoperek.ElapsedTicks;
                }
                roznica = (i / 2) - (i / 4);
                Console.WriteLine($"Srednia {(wyniczek/roznica):F02};Element  {i}");
            } */



            // binarne srednie pesymistyczne instrumentacja

            /*for(int i = 2000000; i <rTablicy; i+=2000000) 
            {
                tablica = Pomocna.Posortowane(i);
                licznik = 0;
                WyszukiwanieBinarneZInstrumentacja(tablica, -1);
                wynik += licznik;
                Console.WriteLine($"{wynik};{i}");
            }
            double srednia = wynik / licznik;
            Console.WriteLine($"srednia arytmetyczna;{srednia:F02}"); */

            // liniowe srednie (pierwszy element + ostatni element)/2

            /*double sumka = 0;
            for(int i = 2000000; i < rTablicy; i+=7000000) 
            {
                tablica = Pomocna.Posortowane(i);
                sumka = 0;
                stoperek.Reset();
                stoperek.Start();
                WyszukiwanieLiniowe(tablica, tablica[i/2]);
                stoperek.Stop();
                sumka += stoperek.ElapsedTicks;
                Console.WriteLine($"Srednia {sumka}; element {i}");
            } */
        }
    }
}
