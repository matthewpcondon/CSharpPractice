using System;
using System.Collections.Generic;
using System.IO;
class QuickSortDemo
{
    static void QuickSort(int[] arr, int low, int high)
    {// 5 8 1 3 7 9 2
        // 5 8 1 3 7 2 9 
        // 5 8 1 3 2 7 9 
        // 5 2 1 3 8 7 9
        // 3 2 1 5 8 7 9
        if (high > low)
        {
            int pivot = Partition(arr, low, high);
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }
    }
    static int Partition(int[] arr, int low, int high)
    {
        // uses left-most element as pivot.
        // keeps a 'wall' on the right side that shifts left every time there's a swap.
        // 'current' decrements until it finds a value >= the pivot
        // it swaps its value with that at the wall. Wall decrements.
        // 4 8 1 3 0 4 2
        // 4 8 1 3 0 2 4
        // 0 2 1 3 4 8 4
        // return wall
        
        int pivot = arr[low];
        int wall = high + 1;
        for (int current = high; current >= low; current--)
        {
            if (arr[current] >= pivot)
            {
                wall--;
                swap(ref arr[current], ref arr[wall]);
            }
        }
        return wall;
    }
    static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    /* Tail starts here */
    static void Main(String[] args)
    {

        int size = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[size];
        String elements = Console.ReadLine();
        String[] splitElements = elements.Split(' ');
        for (int i = 0; i < size; i++)
        {
            arr[i] = Convert.ToInt32(splitElements[i]);
        }

        QuickSort(arr, 0, size - 1);
        for (int i = 0; i < size; i++)
        {
            Console.Write(arr[i] + " ");
        }
        //Console.WriteLine();
        //Console.WriteLine("Press any key...");
        //Console.ReadKey();
    }
}
