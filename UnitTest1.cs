using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitTest()
        {

            int minRange = 0, maxRange = 20000, maxInt = 10000, count1 = 0;

            Random rand = new Random();

            List<int> randInt = new List<int>(maxInt);

            for (int i = 0; i < maxInt; i++)
            {
                randInt.Add(rand.Next(minRange, maxRange));
            }

            HashSet<int> hashList = new HashSet<int>();

            foreach (int x in randInt)
            {
                if (!hashList.Contains(x))
                {
                    hashList.Add(x);
                }
            }

            count1 = hashList.Count;

            int dupl = 0, count2 = 0;

            for (int y = 0; y < maxInt; y++)
            {
                /// needed to check if there are more than 2 duplicates
                bool distinct = true;

                for (int z = y + 1; z < maxInt && distinct; z++)
                {
                    /// checks if the int is distinct
                    if (randInt[y] == randInt[z])
                    {
                        distinct = false;
                        dupl++;
                    }
                }
            }

            /// subtracting all the dupl in the list fromm the max
            count2 = maxInt - dupl;

            int count3 = 0;
            randInt.Sort();

            for (int h = 0; h < maxInt; h++)
            {
                /// ends at the limit in the list
                if (h == (maxInt - 1))
                {
                    count3++;
                }

                /// compare to the next one in the sorted list
                else if (randInt[h] < randInt[h + 1])
                {
                    count3++;
                }
            }

            Assert.AreEqual(count1, count2);
            Assert.AreEqual(count1, count3);
        }
    }
}