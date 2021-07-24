class Pair {
    public int start {
        get;
        set;
    }
    public int end {
        get;
        set;
    }
    public Pair(int _start, int _end){
        start = _start;
        end = _end;
    }
    
}
class MyComparer : IComparer <Pair> {
    public int Compare (Pair a, Pair b){
        if (a.end > b.end){ // b should appear first in sort order
            return 1;
        }
        else if (a.end == b.end){
            return 0;
        }
        return -1;
    }
}
class Solution
{
	public int maxMeetings(int[] start, int[] end, int n)
	{
		Pair[] pairs = new Pair[n];
		for (int i = 0; i < n; i++){
			pairs[i] = new Pair(start[i], end[i]);
		}
		// sort the pairs in increasing order based on end time.
		MyComparer sortByEnd = new MyComparer();
		int time_limit = int.MinValue;
		int count = 0;
		Array.Sort(pairs, sortByEnd);
		// for each meeting in the list:
		// if the start time is after (not equal) the end time of previous
		// meeting, then the current meeting can be held.
		// the end time of current meeting is now basis for comparison
		// when checking future meetings
		foreach (Pair p in pairs){
			if (p.start > time_limit){
				time_limit = p.end;
				count++;
			}
		}
		return count;
	}
}
    
