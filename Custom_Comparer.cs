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
