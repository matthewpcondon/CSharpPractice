public void consoleStuff()
        { // find all prime numbers in range 1 .. 10e7
            Console.WriteLine("Please give me a value. I will give you every prime number between 1 and that value.\n" +
                "But before we do that, let's play with some string formatting.");
            Console.WriteLine(String.Format("{0:N0}\n{0:E1}", 10000000));
            listPrimes(Int32.Parse(Console.ReadLine()));
            Console.WriteLine("Press any key to end program...");
            Console.ReadKey();
        }
        private void listPrimes(int max)
        {
            // limited to a max value of 10e7
            // Uses of the Sieve of Eratosthenes algorithm
            // It marks all values that are a multiple of two or greater.
            // Then, it reads the array and prints all unmarked indices, which by now are prime numbers.
            if (max > 10000000)
            {
                throw new RaymondSaidSoException("This algorithm is considered inefficient for values greater" +
                    " than 10,000,000.");
            }
            int[] arr = new int[max];
            arr[0] = 1;
            arr[1] = 1;
            int count = 1, increment = 1;
            while (increment < max)
            {
                count = ++increment;
                while ((count += increment) < max)
                {
                    arr[count] = 1;
                }
            }
            for (int i = 2; i < max; i++)
            {
                if (arr[i] == 0)
                    Console.WriteLine("I found a prime! " + i);
            }
        }