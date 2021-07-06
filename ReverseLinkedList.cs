using System;
public class Node {
    public int data;
    public Node next {get; set;}
    public Node(int _data){
        data = _data;
        next = null;
    }
}
public class GFG{
    static public void PrintList(Node head){
        Node curr = head;
		do {
		    Console.Write(curr.data + " ");
		    curr = curr.next;
		} while (curr != null);
		Console.WriteLine();
    }
    static public void ReverseLinkedList(Node prev, Node curr, ref Node head) {
        if (curr == null){
            head = prev;
            return;
        }
        ReverseLinkedList(curr, curr.next, ref head);
        curr.next = prev;
    }
	static public void Main (){
	    string[] input = Console.ReadLine().Split(" ");
		int[] arr = Array.ConvertAll(input, (strI) => int.Parse(strI));
		Node head = new Node(arr[0]);
		Node curr = head;
		for (int i = 1; i < arr.Length; i++){
		    curr.next = new Node(arr[i]);
		    curr = curr.next;
		}
		// test traversal of list, assumes head is not null.
		PrintList(head);
		/* first arg initializes the pointer to the previous Node
		second arg is for the node that the recursive method is currently working with 
		third arg is a reference so that the head can be reset when we reach the end of
		the list. */
		ReverseLinkedList(null, head, ref head);
		PrintList(head);
	}
}
