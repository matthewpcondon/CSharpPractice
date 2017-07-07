public void consoleStuff(){		
//An implementation of the famous Quicksort algorithm.
            // partition() chooses a random element and then sorts everything to the left of that element.
            // quicksort() calls partition and then calls quicksort() for everything to the left
            // and then everything to the right.
            Console.WriteLine("Please input some integers. Press the 'enter' key when you're done.");
            string[] strings = Console.ReadLine().Trim().Split(null);
            List<int> ints = new List<int>();
            foreach (string s in strings)
            {
                ints.Add(Int32.Parse(s));
            }
            int[] arr = ints.ToArray();
            quickSortHoare(arr, 0, arr.Length-1);
            Console.WriteLine("Here is a geeksforgeeks.org solution...");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            arr = ints.ToArray();
            quickSortMiddle(arr, 0, arr.Length - 1);
            Console.WriteLine("\nHere is my solution");
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void quickSortHoare(int[] arr, int low, int high)
        {
            // call partition, which uses Hoare's partition scheme.
            // call quicksort for sub array to the left of the index.
            // call quicksort for sub array to the right of index.
            if (high > low)
            {
                int pivot = partitionHoare(arr, low, high);
                quickSortHoare(arr, low, pivot);
                quickSortHoare(arr, pivot+1, high);
            }
        }
        private int partitionHoare(int[] arr, int low, int high)
        {
            // uses left-most element as pivot.
            // Taken from geeksforgeeks.org
            int i = low - 1;
            int j = high + 1;
            int pivot = arr[low];
            while (true)
            {
                do
                {
                    i += 1;
                } while (arr[i] < pivot);
                do
                {
                    j -= 1;
                } while (arr[j] > pivot);
                if (i >= j)
                    return j;
                swap(ref arr[i], ref arr[j]);
            }
        }
        private void quickSortMiddle(int[] arr, int low, int high)
        {
            // call partition, which uses middle-pivot partition scheme
            // It is Hoare's partition scheme except it uses the middle index as a pivot.
            // call quicksort for sub array to the left of the index.
            // call quicksort for sub array to the right of index.
            if (high > low)
            {
                int pivot = partitionMiddle(arr, low, high);
                quickSortMiddle(arr, low, pivot);
                quickSortMiddle(arr, pivot+1, high);
            }
        }
        private int partitionMiddle(int[] arr, int low, int high)
        {
            // uses middle element as pivot.
            // keeps two counters. A low and a high.
            // The low keeps moving up until it encounters a value higher than the pivot.
            // The high keeps moving down until it encounters a value lower than pivot.
            // when they've both stopped, they swap values.
            int pivot = arr[low + (high - low) / 2];
            while (low < high)
            {
                while (arr[low] < pivot && low < high)
                    low++;
                while (arr[high] > pivot && high > low)
                    high--;
                swap(ref arr[low], ref arr[high]);
                high--;
            }
            return low + (high - low) / 2;
        }
        private void swap(ref int a,ref int b)
        {
            // I would have used XOR swapping, but XOR'ing with itself leads to 0.
            int temp = b;
            b = a;
            a = temp;
        }