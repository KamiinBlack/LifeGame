using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife_v2
{
    ///
    public class OneFieldInMapForLifeGame
    {
        /// <summary>
        /// NeighboursCounter() zlicza ilość sąsiadów wokół wybranego pola i zwraca wartośc int
        /// </summary>
        /// <param name="maptoCheckNeighbours"> tablica z wartościami 0,1</param>
        /// <param name="filedInMapX"> współrzędne X pojedynczego pola </param>
        /// <param name="filedInMapY"> współrzędne Y pojedynczego pola </param>
        /// <param name="mapRowsAndColumns"> wielkośc tablicy </param>
        /// <returns></returns>

        public int NeighboursCounter(int[,] maptoCheckNeighbours, int filedInMapX, int filedInMapY)
        {
            int counter = 0;
            for (short i = -1; i<2; i++)
            {
                for(short j = -1; j < 2; j++) {
                    counter += maptoCheckNeighbours[(filedInMapX + i + maptoCheckNeighbours.GetLength(0)) % maptoCheckNeighbours.GetLength(0), (filedInMapY + j + maptoCheckNeighbours.GetLength(0)) % maptoCheckNeighbours.GetLength(0)]; //dodaj kometarz
                }
            }

            return counter - maptoCheckNeighbours[filedInMapX, filedInMapY];
        }
        /// <summary>
        /// CheckIfFieldIsAlive() wybiera jedo pole i po sprawdzeniu ilości sąsiadów decyduje czy pole ma utrzymac obecną wartośc czy ją zmienić 
        /// </summary>
        /// <param name="maptoCheckLife">tablica z wartościami 0,1</param>
        /// <param name="mapRowsAndColumns">wielkośc tablicy</param>
        public void CheckIfFieldIsAlive(int[,] maptoCheckLife)
        {
            for (int i = 0; i < maptoCheckLife.GetLength(0); i++)
            {
                for (int j = 0; j < maptoCheckLife.GetLength(0); j++)
                {
                    int countertoDetermineDestiny = NeighboursCounter(maptoCheckLife, i,j);
                    if (countertoDetermineDestiny < 2) maptoCheckLife[i, j] = 0;
                    if (countertoDetermineDestiny == 3 && maptoCheckLife[i, j] == 0) maptoCheckLife[i, j] = 1;
                    if ((countertoDetermineDestiny == 3 || countertoDetermineDestiny == 2)&& maptoCheckLife[i, j]==1) maptoCheckLife[i, j] = 1;
                    if (countertoDetermineDestiny > 3) maptoCheckLife[i, j] = 0;
                   /* 
                    Jeśli komórka ma mniej niż 2 sąsiadów umiera 
                    Jeśli komórka obecnie żyje i ma 2 lub 3 sąsiadów przeżywa
                    Jeśli komórka ma więcej niż 3 sąsiadów umiera
                    Jeśli martwa komórka ma dokładnie 3 sąsiadów powaraca dożycia
                    */
                }

            }
        }
    }
}
