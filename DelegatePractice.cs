using System;
public delegate string StrDelegate(int n);
class delPractice{
    static void Main(String[] args)
    {
        StrDelegate doStuff = new StrDelegate(delPractice.howToDoIt);
        StrDelegate addStuff = new StrDelegate(delPractice.concatenate);
        // Two implemented functions that use the same delegate.
        Console.WriteLine(doStuff(1));
        Console.WriteLine(addStuff(4));
    }
    public static string howToDoIt(int n)
    {
        switch (n)
        {
            case 1:
                return "Fix a car? Don't bother, you suck at it.";
            case 2: 
                return "Socialize a rabbit? I don't know, can you spare an hour a day?";
            default:
                Console.WriteLine("You have to enter a one or a two.");
                return null;
        }
    }
    public static string concatenate(int n)
    {
        if (n < 0)
        {
            return null;
        }
        string additive = "";
        while (n > 0)
        {
            additive += "1";
            n--;
        }
        return additive;
    }
}
