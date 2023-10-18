using System;
using System.Collections.Generic;

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsCompleted { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
        IsCompleted = true;
    }
}

class Program
{
    static List<Note> notes = new List<Note>();

    static void Main(string[] args)
    {
        InitializeNotes();

        int selectedIndex = 0;
        while (true)
        {
            Console.Clear();
            DisplayNotes(selectedIndex);

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                DisplayNoteDetails(notes[selectedIndex]);
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                selectedIndex = MoveSelectionLeft(selectedIndex);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                selectedIndex = MoveSelectionRight(selectedIndex);
            }
        }
    }

    static void InitializeNotes()
    {
        notes.Add(new Note("Заметка 1", "Сходить на пары", new DateTime(2023, 10, 14)));
        notes.Add(new Note("Заметка 2", "Прогулять пары", new DateTime(2023, 10, 15)));
        notes.Add(new Note("Заметка 3", "Выполнить практос", new DateTime(2023, 10, 16)));
        notes.Add(new Note("Заметка 4", "Извиниться за пропуск срока сдачи практоса", new DateTime(2023, 10, 17)));
        notes.Add(new Note("Заметка 5", "Можно и поспать", new DateTime(2023, 10, 18)));
    }
    
    static void DisplayNotes(int selectedIndex)
    {
        for (int i = 0; i < notes.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ResetColor();
            }

            Console.WriteLine(notes[i].Title);
        }
    }
static void DisplayNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine("Название: " + note.Title);
        Console.WriteLine("Описание: " + note.Description);
        Console.WriteLine("Дата: " + note.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Выполнено: " + (note.IsCompleted ? "Да" : "Нет"));

        Console.ReadKey();
    }

    static int MoveSelectionLeft(int currentIndex)
    {
        return currentIndex == 0 ? notes.Count - 1 : currentIndex - 1;
    }

    static int MoveSelectionRight(int currentIndex)
    {
        return currentIndex == notes.Count - 1 ? 0 : currentIndex + 1;
    }
}
