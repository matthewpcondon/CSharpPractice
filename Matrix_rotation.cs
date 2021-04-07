 /*
            using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    private static void rotate(int dir, int[] a, int k)
    {
        int n = a.Length;
        if (dir == 1) // rotate left
        {
            for (int j = 0; j < k; j++)
            { // perform rotations
                int temp = a[0];
                for (int i = 0; i < n-1; i++)
                {
                    a[i] = a[i+1];
                }
                a[n-1] = temp;
            }
        }
        else // rotate right
        {
            for (int d = 0; d < k; d++)
            { // perform rightward rotations
                int temp = a[n-1];
                for (int i = n-1; i > 0; i--)
                {
                    a[i] = a[i-1];
                }
                a[0] = temp;
            }
        }
    }
    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]); // length of the array
        int k = Convert.ToInt32(tokens_n[1]); // number of john's rotations
        int q = Convert.ToInt32(tokens_n[2]); // number of sherlock's queries
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        // since n*(any integer) rotations would result in the same array, only
        // rotate by a non-zero modulo of n. So, k = k % n.
        // if k > n/2, rotate to the left instead of right by n - k units.
        k = k % n;
        if (k > n/2)
        { // rotate left
            k = n - k;
            rotate(1, a, k);
        }
        else if (k != 0)
        { // rotate right
            rotate(0, a, k);
        }
        else
        {// k is 0
        }
        for (int a0 = 0; a0 < q; a0++)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            // simply read the value at a[m-1]
            Console.WriteLine(a[m]);
        }
    }
}
