using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing", "This activity will help you relax and focus by guiding you through a simple breathing exercise.", duration) { }

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

        for (int i = 0; i < Duration/5; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(5000);
        }

        spinnerThread.Join();
    }
}