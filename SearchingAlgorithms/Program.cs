

using System;
using System.Diagnostics;
using System.Numerics;

namespace SearchingAlgorithms
{

	class SearchingAlgorithms_LinearSearch
    {
        static int LinearSearch1<T>(T[] List, T item) where T : System.IComparable<T>
        {
            int n = List.Length;
            for (int i = 0; i < n; i++)
            {
                if (item.CompareTo(List[i])==0) // item == list[i]
                {
                    return i;
                }
            }
            return -1;
        }
        // LinearSearch<T>() - Searches the entire List<T> for an element
        // (Basic Algorithm) using the default comparer & "Linear (i.e.,
        // Sequential) Search" algorithm.

        /////////////////////////////////////

        // LinearSearch<T>() - Searches the entire List<T> for an element
        // (Basic Algorithm) using the default comparer & "Linear (i.e.,
        // Sequential) Search" algorithm.

        static int LinearSearch2<T>(T[] List, T item) where T : IComparable<T>
        {
            int n = List.Length;
            int retValue = -1;
            for (int i = 0; i < n; i++)
            {
                if (item.CompareTo(List[i])==0)  //( item == list[i])?
                {
                    retValue = i; //Match found at index i
                    break;
                }
            }
            return retValue;
        }

        static void Main(string[] args)
		{

            var watch = new System.Diagnostics.Stopwatch();
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" Testing DSA.LinearSearch<T>( ) ");
            Console.WriteLine("---------------------------------");

            int n, match;
            double[] list;
            double key;
            string input;
            bool check;
            Console.Write("Enter the number of list elements: ");
            input = Console.ReadLine();
            check = int.TryParse(input, out n);
            if (!check) { return; }
            list= new double[n];  // Create a list[n]
            for (int i = 0; i < n; i++) //Enter the list elements
            {
                do
                {
                    Console.WriteLine("Enter element no.{0}:", i+1);
                    input= Console.ReadLine();
                    check= double.TryParse(input, out list[i]);
                } while (!check);
            }
            Console.WriteLine("Enter the Search key:");
            input = Console.ReadLine();
            check= double.TryParse(input, out key);
            if (!check) { return; }
            watch.Start();
            match = LinearSearch1(list, key); //Perform the search
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            if (match <0)
                Console.WriteLine("No match is found.");
            else
                Console.WriteLine("Match is found at element no.{0}", match+1);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

            #region watch the difference betweeen TimSort (in built-in Method of Array.Sort() ) with Objects-Integer and with Primitive datatype-int

            /**  TimSort (in built-in Method of Array.Sort() ) with Primitive datatype-int
             * This algorithm offers O(n log(n)) average time complexity
             * in the worst case, its time complexity is O(n2). 
             * /
             */

            /**
             * Arrays.sort(Object[]) is based on the TimSort algorithm, giving us a time complexity of O(n log(n)). 
             * In short, TimSort makes use of the Insertion sort and the MergeSort algorithms. 
             * However, it is still slower compared to other sorting algorithms like some of the QuickSort implementations.
             * **/

            //var watch = new System.Diagnostics.Stopwatch();
            //BigInteger[] numbers = {-769214442, -1283881723, 1504158300, -1260321086, -1800976432, 1278262737,
            //                      1863224321, 1895424914, 2062768552, -1051922993, 751605209, -1500919212, 2094856518,
            //                      -1014488489, -931226326, -1677121986, -2080561705, 562424208, -1233745158, 41308167 };
            //int[] primitives = {-769214442, -1283881723, 1504158300, -1260321086, -1800976432, 1278262737,
            //                      1863224321, 1895424914, 2062768552, -1051922993, 751605209, -1500919212, 2094856518,
            //                      -1014488489, -931226326, -1677121986, -2080561705, 562424208, -1233745158, 41308167};


            //watch.Start();
            //Array.Sort(primitives);
            //Array.ForEach(primitives, Console.WriteLine);
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //watch.Stop();

            //watch.Start();
            //Array.Sort(numbers);
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //watch.Stop();

            #endregion


        }
    }
}