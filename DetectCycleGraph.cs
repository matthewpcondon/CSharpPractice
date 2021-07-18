class Solution
{
	public uint DFS(List<List<int>> adj, int parent, int v, int u, bool[] visited){
	    //Console.WriteLine("A successful call of DFS");
	    if (visited[u] && u != parent){// cycle detected
	        return 1;
	    }
	    else if (!visited[u]){
    	    visited[u] = true;
    	    uint ans = 0;
    	    foreach (int i in adj[u]){
    	        ans += DFS(adj, v, u, i, visited); 
    	        // before moving on to next one, check if answer returned 1
    	        // anywhere. This will prevent unnecessary iterations.
    	        if (ans > 0){
    	            break;
    	        }
    	    }
    	    return ans;
	    } // we've done every check, no loops detected
	    return 0;
	}
	public bool isCycle(int V, List<List<int>> adj)
	{
	    bool[] visited = new bool[V];
	    visited[0]  = true;
	    /* very odd: on practice.geeksforgeeks.org,
		when I reference the second node using adj[0][0]
	    the 'custom input' accepts my code, but
	    the problem submission gives me an IOB error.
	    */
	    
	    uint ans = DFS(adj, -1, 0, adj[0][0], visited);
	    return (ans > 0) ? true : false;
	}
}
