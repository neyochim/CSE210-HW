using System;
using System.Collections.Generic;
public class Prompt
{
    // List of prompts to be used in the program
    public List<string> _promptsList = new List<string>() {"Who was the most interesting person I interacted with today?", "What was the best part of my day?", 
    "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?"};

    // Random object to select a random prompt
    public Random _randomSelector = new Random();

    // Index of the prompt to be used
    public int _promptIndex = 0;

    // Method to select a random prompt
    public string SelectRandomPrompt()
    {
        _promptIndex = _randomSelector.Next(0, _promptsList.Count);
        return _promptsList[_promptIndex];
    }

}

public class JournalEntry
{
    // variable to store the date and time
    public string _entryDateTime = "";

    // variable to store the prompt
    public string _entryPrompt = "";

    // variable to store the entry
    public string _entry = "";


    // method to get the random prompt and set it to the entry
    public void SetPrompt()
    {
        Prompt prompt = new Prompt();
        _entryPrompt = prompt.SelectRandomPrompt();
    }

    // method to get the date and time
    public void SetDateTime()
    {
        Console.WriteLine("Enter the date and time of the entry: ");
        _entryDateTime = Console.ReadLine();
    }

    // method to get the entry from the user
    public void SetEntry()
    {
        Console.WriteLine("Today's Prompt:");
        Console.WriteLine(_entryPrompt);
        Console.WriteLine("Enter your entry:");
        Console.WriteLine("");
        _entry = Console.ReadLine();
    }

    // method to display the entry
    public void DisplayEntry()
    {
        Console.WriteLine("");
        Console.WriteLine("==================================================================================");
        Console.WriteLine(_entryDateTime);
        Console.WriteLine("");
        Console.WriteLine("Prompt: " + _entryPrompt);
        Console.WriteLine("");
        Console.WriteLine("Entry: " + _entry);
        Console.WriteLine("==================================================================================");
    }
}



public class Journal
{
    // list to hold the journal entries
    public List<JournalEntry> _journalEntries = new List<JournalEntry>();

    // method to store the journal entry
    public void StoreJournalEntry(JournalEntry entry)
    {
        _journalEntries.Add(entry);
    }

    // method to display journal entries
    public void DisplayJournalEntries()
    {
        Console.WriteLine("");
        Console.WriteLine("Journal Entries:");
        Console.WriteLine("");
        foreach (JournalEntry entry in _journalEntries)
        {
            entry.DisplayEntry();
        }
    }
    
}