using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the book of the scripture:");
        var book = Console.ReadLine();

        Console.WriteLine("Enter the chapter of the scripture:");
        var chapter = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the verse of the scripture:");
        var verse = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the text of the scripture:");
        var text = Console.ReadLine();

        var _scripture = new Scripture(new Reference(book, chapter, verse), text);
        while (true)
        {
            Console.Clear();
            Console.WriteLine(_scripture);
            if (_scripture.AllWordsHidden)
            {
                Console.WriteLine("All words are hidden. Press enter to end the program.");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine("Press enter to hide 3 words or type 'quit' to quit.");
                if (Console.ReadLine().ToLower() == "quit")
                {
                    break;
                }
                _scripture.HideRandomWords(3);
            }
        }
    }
}

class Scripture
{
    public Reference _reference { get; }
    public List<Word> _words { get; }
    public bool AllWordsHidden => _words.All(w => w._isHidden);

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var _visibleWords = _words.Where(w => !w._isHidden).ToList();
        var _random = new Random();
        for (int i = 0; i < count; i++)
        {
            if (_visibleWords.Any())
            {
                var _randomWord = _visibleWords[_random.Next(_visibleWords.Count)];
                _randomWord.Hide();
                _visibleWords.Remove(_randomWord); // remove the word from the list so it won't be selected again
            }
        }
    }

    public override string ToString() => $"{_reference}: {string.Join(" ", _words)}";
}

class Reference
{
    public string _book { get; }
    public int _chapter { get; }
    public int _verseStart { get; }
    public int? _verseEnd { get; }

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString() => $"{_book} {_chapter}:{_verseStart}{(_verseEnd.HasValue ? "-" + _verseEnd.Value : "")}";
}

class Word
{
    private string _text { get; }
    public bool _isHidden { get; private set; }

    public Word(string text)
    {
        _text = text;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public override string ToString() => _isHidden ? "_____" : _text;
}