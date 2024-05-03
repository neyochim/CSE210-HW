using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess the magic number!");
        Random randomGenerator = new Random();
        int magicInt = randomGenerator.Next(1, 11);
        int guessInt = 0;
        while (guessInt != magicInt)
        {
            Console.WriteLine("What is your guess? ");
            string guess = Console.ReadLine();
            guessInt = int.Parse(guess);
            if (guessInt == magicInt)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (guessInt < magicInt)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }
    }
}