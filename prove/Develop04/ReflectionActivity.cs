using System;
using System.Threading;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private static readonly Random Random = new Random();
    private static readonly string[] Prompts = new[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = new[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration) { }

    public override void StartActivity()
    {
        base.StartActivity();

        var spinner = new Spinner();
        var startTime = DateTime.Now;

        var spinnerThread = new Thread(() =>
        {
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                spinner.Turn();
                Thread.Sleep(100); 
            }
        });
        spinnerThread.Start();

        Console.WriteLine(Prompts[Random.Next(Prompts.Length)]);

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.WriteLine(Questions[Random.Next(Questions.Length)]);
            Thread.Sleep(5000);
        }

        spinnerThread.Join(); 
    }
}