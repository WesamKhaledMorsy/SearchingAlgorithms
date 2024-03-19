

namespace SearchingAlgorithms
{
  
    class SearchingAlgorithms_BinarySearch
    {
        static int BinarySearch<T>(T[]List,T item) where T : System.IComparable<T>
        {
            int low =0, high = List.Length -1 , mid;
            while (low<=high)
            {
                mid = (low+high)/2 ;
                 if (item.CompareTo(List[mid])<0) // (item < list[mid])?
                {
                    high =mid-1;
                }
                else if (item.CompareTo(List[mid])>0) // (item > list[mid])?
                {
                    low =mid+1;
                }else{
                    return mid;
                }          
            }
            return -1;
        }

        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            Console.WriteLine("---------------------------------");
            Console.WriteLine(" Testing DSA.BinarySearch<T>( ) ");
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
            match = BinarySearch(list, key); //Perform the search
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            if (match <0)
                Console.WriteLine("No match is found.");
            else
                Console.WriteLine("Match is found at element no.{0}", match+1);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}