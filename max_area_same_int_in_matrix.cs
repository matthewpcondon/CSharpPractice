public void consoleStuff(string path)
        { // This program finds the most common number in a 2-d matrix by area.
          // Assumes the input comes from a square textual integer matrix.
          // uses depth-first search in a classic implementation of it.
            List<int> ints = new List<int>();
            int rows = 0, cols = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    string[] strings = sr.ReadLine().Split(null);
                    cols = strings.Length;
                    rows++;
                    foreach (string s in strings)
                    {
                        ints.Add(Convert.ToInt32(s.Trim()));
                    }
                }
            }
            int[,] arr = new int[rows, cols];
            bool[,] markedPath = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = ints[i * cols + j];
                }
            }
            // Uses depth-first search.
            int maxArea = 1, temp = 1;
            for (int i = 0; i < rows; i ++)
            {
                for (int j = 0; j < cols; j ++)
                {
                    if ((temp = scanPerim(markedPath, arr, i, j, rows, cols)) > maxArea)
                    {
                        maxArea = temp;
                    }
                }
            }
            Console.WriteLine("Here are the rows: " + rows + "\nAnd here are the columns: " + cols);
            Console.WriteLine("And here is the max area: " + maxArea);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // returns the number of hits
        private int scanPerim(bool[,] markedPath, int[,] arr, int i, int j, int rows, int cols)
        {
            int result = 1;
            markedPath[i, j] = true;
            // scan to the right
            if (j < cols-1)
            {
                if (arr[i, j] == arr[i, j + 1] && !markedPath[i, j + 1])
                    result += scanPerim(markedPath, arr, i, j+1, rows, cols);
            }
            // scan below
            if (i < rows-1)
            {
                if (arr[i, j] == arr[i + 1, j] && !markedPath[i + 1, j])
                    result += scanPerim(markedPath, arr, i + 1, j, rows, cols);
            }
            // scan to the left
            if (j > 0)
            {
                if (arr[i, j] == arr[i, j - 1] && !markedPath[i, j - 1])
                    result += scanPerim(markedPath, arr, i, j - 1, rows, cols);
            }
            // scan above
            if (i > 0)
            {
                if (arr[i, j] == arr[i - 1, j] && !markedPath[i - 1, j])
                    result += scanPerim(markedPath, arr, i - 1, j, rows, cols);
            }
            return result;
        }