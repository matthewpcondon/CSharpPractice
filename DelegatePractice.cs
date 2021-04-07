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
                return "Get girls?\nYou clean your face up, exercise and get a good job.";
            case 2: 
                return "Get a job? You find what you like doing, get good at it and then brag to employers.";
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
