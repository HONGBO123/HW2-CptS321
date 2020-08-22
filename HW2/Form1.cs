using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /// Initialize the variables used for random class
            int minRange = 0, maxRange = 20000, maxInt = 10000, count1 = 0,
                count2 = 0, count3 = 0;
       
            Random rand = new Random();

            /// Initialize a list of integers
            List<int> randInt = new List<int>(maxInt);

            /// adding randonm integer to the list with the max size of 10000
            for (int i = 0; i < maxInt; i++)
            {
                randInt.Add(rand.Next(minRange, maxRange));
            }

            /// 1. Use hash set to determine the number of distinct ingtegers in the list.
            /// The result will be included in the output. Also, include in the output information
            /// about the time complexity of this method.

            /// creating a hashset of integers
            HashSet<int> hashList = new HashSet<int>();

            /// insert the random integers in the hashset
            foreach (int x in randInt)
            {
                if (!hashList.Contains(x))
                {
                    hashList.Add(x);
                }
            }

            /// count of all the numbers in the hashlist
            count1 = hashList.Count;

            ///  2. If the you have an algorithm that would require more storage if the list had
            ///  items then it is not O(1) storage complexity. 

            /// variable to count the duplicate ints
            int dupl = 0;

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
            count2  = maxInt - dupl;

            /// 3. Sort the list (use built-in sorting functionality) and then use a new algorithm
            /// to determine the number of distinct items with O(1) storage.

            /// built in sort for list
            randInt.Sort();

            for (int h = 0; h < maxInt; h++)
            {
                /// ends at the limit in the list
                if(h == (maxInt - 1))
                {
                    count3++;
                }

                /// compare to the next one in the sorted list
                else if(randInt[h] < randInt[h + 1])
                {
                    count3++;
                }
            }

            textBox1.Text = "1. Hashset Method: " + count1.ToString() + " unique numbers" + Environment.NewLine +
                            "We used a O(N) method, with one foreach loop iterating through and adding in the hash set." + Environment.NewLine +
                            "2. O(1) storage method: " + count2.ToString() + " unique numbers" + Environment.NewLine +
                            "3. Sorted method: " + count3.ToString() + " unique numbers" + Environment.NewLine;
        }

    }
}
