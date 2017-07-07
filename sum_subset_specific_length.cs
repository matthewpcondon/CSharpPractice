public void consoleStuff()
        {// Checks if a subset of a specific length with a specific sum exists.
            Console.WriteLine("Please enter a list of numbers, and hit 'enter' when you're done.");
            string[] numbers = Console.ReadLine().Trim().Split(null);
            int[] arr = new int[numbers.Length];
            int count = 0;
            foreach (string s in numbers)
            {
                arr[count++] = Int32.Parse(s);
            }
            Console.WriteLine("Please enter a sum you'd like to search for.");
            int sum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a length.");
            int checkLength = Int32.Parse(Console.ReadLine());
            allSubsets(arr, checkLength, sum);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void allSubsets(int[] arr, int checkLength, int sum)
        {
            // use a binary number to represent which indices should be included in the sum.
            int max = (int) Math.Pow(2, arr.Length + 1) - 1;
            for (int i = 1; i < max; i++)
            {
                int combos = i;
                int hits = 0, checkSum = 0;
                for (int j = 1; j <= arr.Length && combos > 0; j++)
                {
                    
                    if (combos % 2 == 1) // if it's odd
                    {
                        hits++;
                        checkSum += arr[j-1];
                        if (hits == checkLength && checkSum == sum)
                        {
                            Console.WriteLine("I found it!!!!\nat i = "+Convert.ToString(i,2));
                            return;
                        }
                    }
                    combos >>= 1;
                }
                    
            }
        }