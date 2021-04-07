public void consoleStuff()
        { 
int val = 5;
            Console.WriteLine(~val + " " + Int32.MaxValue);
            int n = Int32.Parse(Console.ReadLine());
            IntComparer ic = new IntComparer();
            ArrayList al = new ArrayList();
            SortedSet<int> s = new SortedSet<int>(ic);
            string[] scores_string = Console.ReadLine().Split(' ');
            int[] scores = Array.ConvertAll(scores_string, Int32.Parse);
            for (int i = 0; i < n; i++)
            {
                if (!s.Contains(scores[i]))
                {
                    s.Add(scores[i]);
                    al.Add(scores[i]);
                }
            }
            n = al.Count;
            int[] arr = new int[n];
            al.CopyTo(arr);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
            int m = Int32.Parse(Console.ReadLine());
            string[] scores_alica = Console.ReadLine().Split(' ');
            int[] alicaScores = Array.ConvertAll(scores_alica, Int32.Parse);
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine( (1 + binarySearch(arr, 0, n-1, alicaScores[i])) );
            }
            // Don't get rid of this! It makes program output readable.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private int binarySearch(int[] arr, int left, int right, int key)
        {
            int m;
            // m, left and right are indices
            // this is not the classic search algorithm, because it's designed to work with
            // reversed arrays.
            if (key > arr[0])
                return 0;
            else if (key < arr[arr.Length-1])
            {
                return arr.Length;
            }
            while (right - left > 1)
            {
                m = left + (right - left) / 2;
                if (arr[m] > key)
                    left = m;
                else if (arr[m] == key)
                {
                    return m;
                }
                else
                    right = m;
            }
            return right;
        }
