//For creativity the program loads scriptures from a file (scriptures.txt) to allow for easy updates and management.
//For creativity the program Selects a random scripture for each session to provide a varied practice experience.
//For creativity the program Tracks and displays the number of hidden words vs total words to help users gauge their progress.
//Ensures encapsulation by separating functionality into distinct classes.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a single word in the scripture text
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    // Represents the reference part of the scripture (e.g., "John 3:16")
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int StartVerse { get; private set; }
        public int? EndVerse { get; private set; }

        public Reference(string book, int chapter, int startVerse, int? endVerse = null)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        public override string ToString()
        {
            return EndVerse.HasValue ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" : $"{Book} {Chapter}:{StartVerse}";
        }
    }

    // Represents the entire scripture including the reference and text
    public class Scripture
    {
        public Reference Ref { get; private set; }
        public List<Word> Words { get; private set; }

        public Scripture(Reference reference, string text)
        {
            Ref = reference;
            Words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        public void HideRandomWords(int count)
        {
            var random = new Random();
            var wordsToHide = Words.Where(w => !w.IsHidden).OrderBy(w => random.Next()).Take(count).ToList();

            foreach (var word in wordsToHide)
            {
                word.Hide();
            }
        }

        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }

        public override string ToString()
        {
            return $"{Ref}\n{string.Join(' ', Words)}";
        }

        public int HiddenWordsCount()
        {
            return Words.Count(w => w.IsHidden);
        }

        public int TotalWordsCount()
        {
            return Words.Count;
        }
    }

    // The main program class to control the flow
    class Program
    {
        static void Main(string[] args)
        {
            var scriptures = LoadScripturesFromFile("scriptures.txt");
            var random = new Random();
            var scripture = scriptures[random.Next(scriptures.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine($"\nHidden words: {scripture.HiddenWordsCount()} / {scripture.TotalWordsCount()}");
                Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
                var input = Console.ReadLine();

                if (input?.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);

                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture);
                    Console.WriteLine("\nAll words are hidden. Program will exit.");
                    break;
                }
            }
        }

        public static List<Scripture> LoadScripturesFromFile(string filePath)
        {
            var scriptures = new List<Scripture>();
            var lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i += 3)
            {
                var referenceParts = lines[i].Split(':');
                var bookChapter = referenceParts[0].Split(' ');
                var book = bookChapter[0];
                var chapter = int.Parse(bookChapter[1]);
                var startVerse = int.Parse(referenceParts[1].Split('-')[0]);
                var endVerse = referenceParts[1].Contains('-') ? int.Parse(referenceParts[1].Split('-')[1]) : (int?)null;
                var reference = new Reference(book, chapter, startVerse, endVerse);
                var text = lines[i + 1];
                var scripture = new Scripture(reference, text);
                scriptures.Add(scripture);
            }

            return scriptures;
        }
    }
}
