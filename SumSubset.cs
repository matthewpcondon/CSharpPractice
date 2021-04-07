public void consoleStuff(){

//an exponential-time solution and a pseudo polynomial time solution to the problem are used.
            Console.WriteLine("Please enter a list of numbers, and enter key when you're done.");
            string[] numbers = Console.ReadLine().Trim().Split(null);
            int[] arr = new int[numbers.Length];
            int count = 0;
            foreach (string s in numbers)
            {
                arr[count++] = Int32.Parse(s);
            }
            Console.WriteLine("Now enter a sum value that you would like to check for.");
            int sum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Now enter a length value that you would like to check for.");
            int length = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Here is a recursive solution:");
            if (isSubsetSumRecursive(arr, length, sum))
            {
                Console.WriteLine("It's there!");
            }
            else
            {
                Console.WriteLine("No, it's not there.\nHere is a dynamic solution:");
            }
            if (isSubsetDynamic(arr, length, sum))
            {
                Console.WriteLine("It's there!");
            }
            else
            {
                Console.WriteLine("No, it's not there.");
            }
            Console.WriteLine("Press any key to end the program...");
            Console.ReadKey();
        }
        private bool isSubsetSumRecursive(int[] arr, int length, int sum)
        {
            // This problem is solved twice because isSubsetSumRecursive() is of exponential time complexity
            // in the worst case.
            if (sum == 0)
                return true;
            if (sum != 0 && length == 0)
                return false;
            return isSubsetSumRecursive(arr, length - 1, sum - arr[length - 1]) ||
                isSubsetSumRecursive(arr, length - 1, sum);
        }
        private bool isSubsetDynamic(int[] arr, int length, int sum)
        {
            /* Geeksforgeeks.org
             Uses a 2d bool array. Each row represents a possible sum. the number of them equals the sum
             that the user is looking for.
             Each col represents a sub-length. The number of them equals the length of the original
             array.
             The bool array is filled from beginning to end by way of checks from end to beginning.
             */
            Boolean[,] subset = new Boolean[sum+1,length+1];
            // If sum is 0, then answer is true. Because it subtracts a current value from the search sum
            for (int i = 0; i <= length; i++)
                subset[0,i] = true;
            // If sum is not 0 and set is empty, then answer is false
            for (int i = 1; i <= sum; i++)
                subset[i,0] = false;
            for (int row = 1; row <= sum; row++)
            {
                for (int col = 1; col <= length; col++)
                {
                    subset[row,col] = subset[row,col-1];
                    if (row >= arr[col - 1]) // prevent an index-out-of-range exception
                        subset[row,col] = subset[row,col] ||
                                              subset[row - arr[col- 1], col - 1];
                    // The result is OR'd with a check of a previous sum.
                    // For example, say the array is 3 6 5 8 4 3
                    // if you're looking for a sum of 9, and the iterator is at row=9,col=3,
                    // it needs to check a previous sum of length == 2 in order to check for a sum
                    // of length = 3.
                    // It subtracts the value at the third position of the array from 9, 
                    // so that it's checking row= 9-5 = 4, and col=2.
                    // Then, it subtacts 6 from 4, and checks a previous check of length==1.
                    // row == -2, col == 1. The if statement prevents such a check.
                    // Now we know there are no sums of 9 from any 3 elements.

                    // Another example: if you're checking for a sum of 13, then you're at
                    // row == 13. You would get a value of "true" thusly:
                    // iterator is a row=13,col=4. It subtracts arr[4-1] from 13, leaving 5.
                    // It checks row == 5, col == 3. It checks row == 0, col == 2.
                    // This is one of the base cases, and is true.
                    // So, answers[13,4] = answers[5,3] = answers[0,2] = true.
                    // Now we know there is a sum of 13 from an array of length 6.
                }
            }
            return subset[sum, length];
        }
