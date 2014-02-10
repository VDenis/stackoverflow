using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowSample1
{
    class Program
    {
        static void Main(string[] args)
        {

            var parametrs = new List<KeyValuePair<int, int>>();
            parametrs.Add(new KeyValuePair<int, int>(5,2));
            parametrs.Add(new KeyValuePair<int, int>(5, 3));
            parametrs.Add(new KeyValuePair<int, int>(1, 2));
            parametrs.Add(new KeyValuePair<int, int>(1, 3));
            parametrs.Add(new KeyValuePair<int, int>(4, 3));
            parametrs.Add(new KeyValuePair<int, int>(1, 4));
            parametrs.Add(new KeyValuePair<int, int>(1, 5));
            parametrs.Add(new KeyValuePair<int, int>(2, 4));
            //parametrs.Add(new KeyValuePair<int, int>(3, 2));
            parametrs.Add(new KeyValuePair<int, int>(5, 4));

            var answer = Sorting(parametrs);

            foreach (var i in answer)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }


        public static List<int> Sorting(List<KeyValuePair<int, int>> input)
        {
            var outPairs = new List<int>();

            int[] ranking = new int[5]{-1, -1, -1, -1, -1}; // size == the number of input elements, we have 5
            List<int>[] usingNumbersList = new List<int>[5]; // similarly
            for (int i = 0; i < usingNumbersList.Count(); i++)
            {
                usingNumbersList[i] = new List<int>();
            }


            foreach (var pair in input)
            {
                if (CheckUp(pair, usingNumbersList))
                {
                    int index = pair.Key - 1;
                    ranking[index] += pair.Value -1; // -1 Tk input starts with 1
                    usingNumbersList[index].Add(pair.Value -1 );
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int maxRank= ranking.Max();
                int maxIndex = Array.IndexOf(ranking, maxRank);
                outPairs.Add(maxIndex + 1);
                ranking[maxIndex] = -2;
            }

            return outPairs;
        }

        private static bool CheckUp(KeyValuePair<int, int> pair, List<int>[] usingNumbersList)
        {


            int search = pair.Key -1;
            int index = pair.Value -1 ;
            var temp = usingNumbersList[index];

            bool result = Recursion(temp, usingNumbersList, search);

            return result;
        }

        private static bool Recursion(IEnumerable<int> temp, List<int>[] usingNumbersList, int search)
        {
            if (!usingNumbersList.Any() || temp == null)
                return true;

            foreach (var index in temp)
            {
                if (index == search)
                    return false;

                if (Recursion(usingNumbersList[index], usingNumbersList, search))
                    return true;
                else
                    return false;
            }

            return true;
        }
    }
}
