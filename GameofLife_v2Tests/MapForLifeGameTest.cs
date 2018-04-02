using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameofLife_v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLife_v2.Tests
{
    [TestClass()]
    public class MapForLifeGameTest 
    {
       [TestMethod()]
        public void Fill2DArrayRandomTestFill()
        {
            MapForLifeGame a = new MapForLifeGame();
            int[,] d = a.CreateAndFill2DMapWithRandom(5, 10);
            int counter = 0;
            foreach (int element in d)
            {
                if (element == 1) counter++;
            }
            Assert.IsTrue(counter<=10);
        }

        [TestMethod()]
        public void Fill2DArrayRandomTestCreate()
        {
            MapForLifeGame a = new MapForLifeGame();
            int[,] c = a.CreateAndFill2DMapWithRandom(5, 10);
            int[,] b = new int[5, 5];
            Assert.AreEqual(c.Length, b.Length);
        }

    }

    [TestClass()]
    public class OneFieldInMapForLifeGameTest
    {
        [TestMethod()]
        public void checkIfFieldIsAliveTest()
        {
            OneFieldInMapForLifeGame a = new OneFieldInMapForLifeGame();
            int[,] tab = new int[,] { { 1, 1 }, { 0, 0 }};
           
            a.CheckIfFieldIsAlive(ref tab);
            int c = 0;
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    c += tab[i, j]; 
                }
            }
            Assert.AreEqual(2, c);
        }

        [TestMethod()]
        public void neighboursCounterTest()  //testujemy zwykły warunek - pole jest w środku tablicy
        {
            OneFieldInMapForLifeGame a = new OneFieldInMapForLifeGame();
            int[,] tab = new int[,] { { 0, 1, 0, 1 },{ 1, 0, 0, 1 },{ 1, 1, 0, 0 },{ 0, 1, 0, 0 } };
            int countN1 = a.NeighboursCounter(tab,1,2);
            Assert.AreEqual(countN1,4);
            
        }
        [TestMethod()]
        public void neighboursCounter2Test() //testujemy warunek brzegowy - pole jest na skraju tablicy
        {
            OneFieldInMapForLifeGame a = new OneFieldInMapForLifeGame();
            int[,] tab = new int[,] { { 0, 1, 0, 1 }, { 1, 0, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 0, 0 } };
            int countN1 = a.NeighboursCounter(tab, 0, 3);
            Assert.AreEqual(countN1, 2);

        }
        [TestMethod()]
        public void neighboursCounter3Test() //testujemy warunek brzegowy malej tablicy - pole jest na skraju tablicy
        {
            OneFieldInMapForLifeGame a = new OneFieldInMapForLifeGame();
            int[,] tab = new int[,] { { 1, 1 }, { 0, 0 } };
            int countN1 = a.NeighboursCounter(tab, 0, 1);
            Assert.AreEqual(countN1, 2);

        }

        
    }
}