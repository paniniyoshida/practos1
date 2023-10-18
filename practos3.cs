using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    private static int currentOctave = 1;
    private static int[][] octaves = new int[][] {
        new int[] { 196, 293, 329, 349, 392, 440, 493 },
        new int[] { 523, 587, 659, 698, 784, 880, 987 },
        new int[] { 1046, 1174, 1318, 1396, 1568, 1760, 1975 }
     
    };

    static void Main(string[] args)
    {
        Console.WriteLine("Для смены октавы нажмите клавиши: F1, F2, F3");
        Console.WriteLine("Для выхода нажмите клавишу ESC");

        SetOctave(currentOctave);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                    break;

                if (key.Key == ConsoleKey.F1)
                    SetOctave(1);
                else if (key.Key == ConsoleKey.F2)
                    SetOctave(2);
                else if (key.Key == ConsoleKey.F3)
                    SetOctave(3);
                else
                    PlayNoteByKey(key.Key);
            }
        }
    }

    static void SetOctave(int octave)
    {
        if (octave < 1 || octave > octaves.Length)
        {
            Console.WriteLine("Неверный номер октавы");
            return;
        }
        currentOctave = octave;
        Console.WriteLine($"Текущая октава: {currentOctave}");
    }

    static void PlayNoteByKey(ConsoleKey key)
    {
        int noteIndex = -1;

        switch (key)
        {
            case ConsoleKey.Q:
                noteIndex = 0; break;
            case ConsoleKey.W:
                noteIndex = 1; break;
            case ConsoleKey.E:
                noteIndex = 2; break;
            case ConsoleKey.R:
                noteIndex = 3; break;
            case ConsoleKey.T:
                noteIndex = 4; break;
            case ConsoleKey.Y:
                noteIndex = 5; break;
            case ConsoleKey.U:
                noteIndex = 6; break;
            default:
                return;
        }

        int frequency = octaves[currentOctave - 1][noteIndex];
        Console.WriteLine($"Играю ноту {key}, частота: {frequency} Гц");
        PlaySound(frequency);
    }

    static void PlaySound(int frequency)
    {
        Console.Beep(frequency, 200);
    }
}
