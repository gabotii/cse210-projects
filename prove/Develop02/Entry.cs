using System;

namespace JournalApp
{
    public class Entry
    {
        public DateTime Date { get; set; }
        public string Prompt { get; set; }
        public string Content { get; set; }

        public Entry(string prompt, string content)
        {
            Date = DateTime.Now;
            Prompt = prompt;
            Content = content;
        }

        public override string ToString()
        {
            return $"{Date.ToString("g")}\nPrompt: {Prompt}\nEntry: {Content}\n";
        }
    }
}
