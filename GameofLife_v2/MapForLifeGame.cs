using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife_v2
{
    public class MapForLifeGame
    {
        /// <summary>
        /// PrintArrayonConsole() drukuje tablice na console kolorując wartości żywe(1) na kolor czerwony, a martwe(0) na kolor biały
        /// </summary>
        /// <param name="MapToPrint">tablica dwuwymiarowa do wydrukowania</param>
        /// <param name="MapRowsAndColumns">wielkośc tablicy</param>
        public void PrintArrayonConsole(int[,] MapToPrint)
        {
            Console.WriteLine("Tablica Gry Game of Life");
            for (int i = 0; i < MapToPrint.GetLength(0); i++)
            {

                Console.WriteLine("  ");
                Console.WriteLine("  ");
                for (int j = 0; j < MapToPrint.GetLength(0); j++)
                {
                    if (MapToPrint[i, j] == 1)
                    {
                        Console.ForegroundColor = System.ConsoleColor.Red;
                        Console.Write(MapToPrint[i, j]);
                        Console.ResetColor();
                        Console.Write('|');
                    }
                    if (MapToPrint[i, j] == 0)
                    {
                        Console.ForegroundColor = System.ConsoleColor.White;
                        Console.Write(MapToPrint[i, j]);
                        Console.Write('|');
                    }
                }
            }
            Console.ResetColor();
        }

        /// <summary>
        /// CreateAndFill2DMapWithRandom() wypełnia tablice randomowo wartościami 1(żywe)
        /// </summary>
        /// <param name="mapRowsAndColumns"></param>
        /// <param name="maxStartingLifeOnArray">maksymalna liczba żyjących komórek - może być mniejsza, ale nie będzie wieksza niż podana liczna int</param>
        /// <returns></returns>
        public int[,] CreateAndFill2DMapWithRandom(int mapRowsAndColumns, int maxStartingLifeOnArray)
        {
            int[,] mapArray2D = new int[mapRowsAndColumns, mapRowsAndColumns];

            Random rdm = new Random();
            int counter = 0;
            for (int i = 0; i < mapRowsAndColumns; i++)
            {
                for (int j = 0; j < mapRowsAndColumns; j++)
                {

                    int RandomNumberToCheck = rdm.Next(0, 2);  //wyznacza nowy Random w przedziale 0 , 1
                    if (counter < maxStartingLifeOnArray)
                    {
                        mapArray2D[i, j] = RandomNumberToCheck;
                        if (RandomNumberToCheck == 1) counter++;
                    }
                    else
                    {
                        return mapArray2D;
                    }
                }
            }
            return mapArray2D; //zwróć "zasiedloną" tablicę
        }

    }
}
