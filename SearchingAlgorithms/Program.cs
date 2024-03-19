

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
			if(!check) { return ; }
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
			input = Console.ReadLine() ;
			check= double.TryParse(input, out key);
			if(!check) { return ; }
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
        }
    }
}