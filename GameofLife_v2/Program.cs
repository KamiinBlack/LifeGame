using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameofLife_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj rozmiar tablicy do gry :");
            int mapRowsAndColumns = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Podaj maksymalną ilość żywych jednostek na planszy :");
            Console.WriteLine("Tablica będzie wypełniona nie wększa ilością niż podana!");
            int maxStartingLifeOnArray = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Podaj ile razy chesz przeprowadzić ewolucje : ");
            int amountOfIteration = Int32.Parse(Console.ReadLine());
            Console.Clear();

            MapForLifeGame newMap = new MapForLifeGame();
            int[,] newMapArray = newMap.CreateAndFill2DMapWithRandom(mapRowsAndColumns, maxStartingLifeOnArray);
            OneFieldInMapForLifeGame oneField = new OneFieldInMapForLifeGame();

            Console.WriteLine("Wygenerowana losowo tablica startowa to : ");
            Console.WriteLine("Nacisniej dowolny przycisk, aby uruchomić symulację życia");
            Console.WriteLine("  ");
            newMap.PrintArrayonConsole(newMapArray);
            Console.ReadKey();
            Console.Clear();

            for (int i = 0; i < amountOfIteration; i++)
            {
                Console.SetCursorPosition(0, 0);
                oneField.CheckIfFieldIsAlive(ref newMapArray);
                newMap.PrintArrayonConsole(newMapArray);
                Thread.Sleep(300);
                //Console.ReadKey(); przejście kontrolowane przez użytkownika
            }

            Console.ReadKey();
        }
    }
}
