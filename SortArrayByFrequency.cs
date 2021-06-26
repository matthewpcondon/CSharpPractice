using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
/* Generates a dictionary of (value, frequency) pairs.
Then generates a list of those pairs, then sorts them with a custom comparer.
Outputs the values of that sorted list.
*/
public class CustomComparer : IComparer <KeyValuePair<int, int>> {
    // sort first by frequency, then by key ascending if the freq's are
    // the same.
        public int Compare
        (KeyValuePair<int, int> kvp1, KeyValuePair<int, int> kvp2){
            
        /*KeyValuePair<int, int> kvp1 = (KeyValuePair<int, int>) obj1;
        KeyValuePair<int, int> kvp2 = (KeyValuePair<int, int>) obj2; */
        if (kvp1.Value != kvp2.Value){
            return (kvp1.Value > kvp2.Value) ? -1 : 1;
        }
        // if their values are the same, sort by key.
        return (kvp1.Key < kvp2.Key) ? -1 : 1;
    }
}

public class GFG {
    static private List<KeyValuePair<int, int>>
        SortByValues(Dictionary<int, int> dInput){
        // uses a custom comparer to sort the dictionary according to
        // the question's specifications
        List<KeyValuePair<int, int>> l = dInput.ToList();
        CustomComparer customComparer = new CustomComparer();
        l.Sort(customComparer);
        return l;
    }
    static private void PrintDicValues(List<KeyValuePair<int, int>> sd){
        int count;
        foreach (KeyValuePair<int, int> kvp in sd){
            count = kvp.Value;
            while (count-- > 0){
    		    Console.Write(kvp.Key + " ");
            }
		}
    }
	static public void Main () {
		int queries = Int32.Parse(Console.ReadLine());
		while (queries-- > 0){
		    int n = Int32.Parse(Console.ReadLine());
		    string[] tmpInput = Console.ReadLine().Trim().Split(" ");
		    int[] temp = new int[n];
		    int a = 0;
		    try{
    		    foreach(string s in tmpInput){
    		        temp[a++] = int.Parse(s);
    		    }
		    }
		    catch(FormatException f){
		        Console.WriteLine("The string: "
		        + tmpInput[a] + " was not formatted "+
		        "properly");
		    }
		    Dictionary<int, int> dUnsorted = new Dictionary<int, int>();
		    // fill the dictionary with (value, frequency) pairs
	        foreach(int i in temp){
	            if (!dUnsorted.ContainsKey(i)){
	                dUnsorted.Add(i, 1);
	            }
	            else {
	                dUnsorted[i] += 1;
	            }
	        }
	        List<KeyValuePair<int, int>> sd = SortByValues(dUnsorted);
		    PrintDicValues(sd);
		    if (queries > 0){
		        Console.WriteLine();
		    }
		}
	}
}
