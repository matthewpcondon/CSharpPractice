using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    
    // all eight of the searches done one at a time.
    // cease when a '1' is encountered in the array
    private static int dfs(int[,] arr, int n, int rQueen, int cQueen)
    {
        //Console.WriteLine("Queen's array position is: {0},{1}", rQueen, cQueen);
        int count = 0;
        // depth-first search:
        // col-- (left)
        if (cQueen > 0)
        {
            //Console.WriteLine("Moving left...");
            for (int col = cQueen - 1; col >= 0 && arr[rQueen,col] != 1; col--)
            {
                //Console.WriteLine("Checking index: {0},{1}", rQueen, col);
                count++;
            }
        }
        // col++ (right)
        if (cQueen < n - 1)
        {
            //Console.WriteLine("Moving right...");
            for (int col = cQueen + 1; col < n && arr[rQueen,col] != 1; col++)
            {
                //Console.WriteLine("Checking index: {0},{1}", rQueen, col);
                count++;
            }
        }
        // row++ (down)
        if (rQueen < n - 1)
        {
            //Console.WriteLine("Moving down...");
            for (int row = rQueen + 1; row < n && arr[row,cQueen] != 1; row++)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, cQueen);
                count++;
            }
        }
        // row-- (up)
        if (rQueen > 0)
        {
            //Console.WriteLine("Moving up...");
            for (int row = rQueen - 1; row >= 0 && arr[row,cQueen] != 1; row--)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, cQueen);
                count++;
            }
        }
        // col-- and row-- (up left)
        if (rQueen > 0 && cQueen > 0)
        {
            //Console.WriteLine("Moving up-left...");
            for (int row = rQueen - 1, col = cQueen - 1;
                 row >= 0 && col >= 0 && arr[row,col] != 1;
                 row--, col--)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, col);
                count++;
            }
        }
        // col++ and row-- (up right)
        if (rQueen > 0 && cQueen < n - 1)
        {
            //Console.WriteLine("Moving up-right...");
            for (int row = rQueen - 1, col = cQueen + 1;
                 row >= 0 && col < n && arr[row,col] != 1;
                 row--, col++)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, col);
                count++;
            }
        }
        // col-- and row++ (down left)
        if (rQueen < n-1 && cQueen > 0)
        {
            //Console.WriteLine("Moving down-left...");
            for (int row = rQueen + 1, col = cQueen - 1;
                 row < n && col >= 0 && arr[row,col] != 1;
                 row++, col--)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, col);
                count++;
            }
        }
        // col++ and row++ (down right)
        if (rQueen < n-1 && cQueen < n - 1)
        {
            //Console.WriteLine("Moving down-right...");
            for (int row = rQueen + 1, col = cQueen + 1;
                 row < n && col < n && arr[row,col] != 1;
                 row++, col++)
            {
                //Console.WriteLine("Checking index: {0},{1}", row, col);
                count++;
            }
        }
        return count;
    }
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] tokens_rQueen = Console.ReadLine().Split(' ');
        int rQueen = Convert.ToInt32(tokens_rQueen[0]) - 1;
        int cQueen = Convert.ToInt32(tokens_rQueen[1]) - 1;
        // keep the whole chessboard in memory as an array
        // the board is flipped upside down, but otherwise it's the same board.
        // the original board is numbered weirdly: rows are n to 1 inclusive
        // and columns are 1 to n inclusive.
        // a 0 means passable, a 1 means obstacle.
        int[,] arr = new int[n,n];
        for(int a0 = 0; a0 < k; a0++)
        {
            string[] tokens_rObstacle = Console.ReadLine().Split(' ');
            int rObstacle = Convert.ToInt32(tokens_rObstacle[0]);
            int cObstacle = Convert.ToInt32(tokens_rObstacle[1]);
            arr[rObstacle - 1, cObstacle - 1] = 1;
        }
        if (n > 1)
        {
            Console.WriteLine(dfs(arr, n, rQueen, cQueen));
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}
