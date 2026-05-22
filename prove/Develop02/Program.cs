using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    private const string DateFormat = "MMMM dd, yyyy hh:mm tt";

    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string prompt, string response, string? date = null)
    {
        Date = date ?? DateTime.Now.ToString(DateFormat);
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date:     {Date}\nPrompt:   {Prompt}\nResponse: {Response}";
    }
}

class PromptLibrary
{
    private static readonly Random Rng = new();

    private static readonly string[] Prompts =
    [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "If I had one thing I could do differently today, what would it be?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "What is something I learned about myself today?",
        "What am I most grateful for today?"
    ];

    public string GetRandom() => Prompts[Rng.Next(Prompts.Length)];
}

class Journal
{
    private const string Separator = "----------------------------------------";

    private readonly List<Entry> _entries = [];
    private readonly PromptLibrary _prompts = new();

    public void WriteEntry()
    {
        string prompt = _prompts.GetRandom();
        Console.WriteLine($"\n{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("No response given. Entry discarded.");
            return;
        }

        _entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry recorded.");
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\n{Separator}");
            Console.WriteLine($"Entry {i + 1}");
            Console.WriteLine(Separator);
            Console.WriteLine(_entries[i]);
        }

        Console.WriteLine($"\n{Separator}");
    }

    public void Save(string filename)
    {
        try
        {
            using StreamWriter writer = new(filename, append: false);
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
            Console.WriteLine($"Journal saved to '{filename}'.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Save failed: {ex.Message}");
        }
    }

    public void Load(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<Entry> loaded = [];

            foreach (string line in lines)
            {
                string[] parts = line.Split('|', 3);
                if (parts.Length == 3)
                    loaded.Add(new Entry(parts[1], parts[2], parts[0]));
            }

            _entries.Clear();
            _entries.AddRange(loaded);
            Console.WriteLine($"Loaded {_entries.Count} entry(s) from '{filename}'.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Load failed: {ex.Message}");
        }
    }
}

class Program
{
    private const string Menu =
        "\n--- Journal Menu ---\n" +
        "1. Write\n"             +
        "2. Display\n"           +
        "3. Save\n"              +
        "4. Load\n"              +
        "5. Quit\n";

    private readonly Journal _journal = new();
    private readonly Dictionary<string, Action> _handlers;
    private bool _running = true;

    public Program()
    {
        _handlers = new Dictionary<string, Action>
        {
            { "1", Write   },
            { "2", Display },
            { "3", Save    },
            { "4", Load    },
            { "5", Quit    }
        };
    }

    public void Run()
    {
        Console.WriteLine("Welcome to your Journal.");

        while (_running)
        {
            Console.WriteLine(Menu);
            Console.Write("Select an option: ");
            string choice = Console.ReadLine()?.Trim() ?? string.Empty;

            if (_handlers.TryGetValue(choice, out Action? handler))
                handler();
            else
                Console.WriteLine("Invalid option. Enter a number 1-5.");
        }
    }

    private void Write() => _journal.WriteEntry();

    private void Display() => _journal.Display();

    private void Save()
    {
        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(filename))
            Console.WriteLine("No filename provided.");
        else
            _journal.Save(filename);
    }

    private void Load()
    {
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(filename))
            Console.WriteLine("No filename provided.");
        else
            _journal.Load(filename);
    }

    private void Quit()
    {
        Console.WriteLine("Goodbye.");
        _running = false;
    }

    static void Main(string[] args) => new Program().Run();
}