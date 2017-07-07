public void consoleStuff()
        { // Prints all variatinos of k numbers in the range 1 .. max inclusive.
            Console.WriteLine("Please give me a max value.");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please give me a k value.");
            int k = Int32.Parse(Console.ReadLine());
            int[] arr = new int[k];
            int max = (int) Math.Pow(n, k);
            for (int i = 0; i < max; i ++)
            {
                int tempI = i;
                // store digits in by moduloing i by moduloing i by k, dividing by k,
                // then moduloing and so forth until i is 0.
                for (int a = 0; a < k; a++)
                {
                    arr[a] = tempI % n;
                    tempI /= n;
                    /*if (arr[a] == 0)
                        arr[a] = 1; */
                    Console.Write(arr[a] + 1);// Mathematical operation, not string concatenation.
                    arr[a] = 0;
                }
                Console.WriteLine();
                }
            Console.WriteLine("Press any key to end the program...");
            Console.ReadKey();
        }