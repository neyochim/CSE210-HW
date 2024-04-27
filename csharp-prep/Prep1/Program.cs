using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your FIRST name? "); string NameF = Console.ReadLine();
        Console.WriteLine("What is your LAST name? "); string NameL = Console.ReadLine();
        Console.WriteLine($"Your name is {NameL}, {NameF} {NameL}.");
    }
}