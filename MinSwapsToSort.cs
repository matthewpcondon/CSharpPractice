class Solution
{
    private int Skip(int[] arr, bool[] visited, int itr, ref int numVisited,
                        Dictionary<int, int> valueToIndex){
        // this method detects the size of each cycle
        int cyclesFound = 0;
        visited[itr] = true;
        numVisited++;
        int val = arr[itr];
        int currIndex = valueToIndex[val]; // the index where val is supposed to be
        visited[currIndex] = true;
        while (currIndex != itr) {
            cyclesFound++;
            visited[currIndex] = true;
            currIndex = valueToIndex[arr[currIndex]]; // where the next element is
            // supposed to be
            numVisited++;
        } // currIndex has gone back to itr, so we're done discovering the cycle
        return cyclesFound;
    }
    //Function to find the minimum number of swaps required to sort the array. 
    public int minSwaps(int[] arr)
    {
        /* keep track of number visited
        iterate through array, skipping over to ideal places of each element
        that you find. Increment numVisited each time.
        When you start skipping to ideal positions, remember where the iterator was.
        when your skipping finds a value that was already visited,
        continue where your itr left off. */
        int n = arr.Length;
        int[] sortedArr = new int[n];
        arr.CopyTo(sortedArr, 0);
        Array.Sort(sortedArr);
        int val;
        Dictionary<int, int> valueToIndex = new Dictionary<int, int>(n);
        // this dictionary stores which indices each value needs to go to
        for (int i = 0; i < n; i++){
            val = sortedArr[i];
            valueToIndex.Add(val, i);
        }
        int numVisited = 0;
        bool[] visited = new bool[n];
        int numCycles = 0;
        for (int itr = 0; numVisited < n && itr < n; itr++){
            val = arr[itr];
            if (!visited[itr] && (itr != valueToIndex[val])){ // check if the
            // current value is in the wrong place.
                numCycles += Skip(arr, visited, itr, ref numVisited,
                    valueToIndex);
            }
            else if (!visited[itr]) { // not visited, but value is in right place
                numVisited++;
                visited[itr] = true;
            }
            // else, we've already looked at that element
        }
        return numCycles;
    }
