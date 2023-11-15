using System;
using System.IO;
using System.Linq;

public static class FileExplorer
{
    public static void Main()
    {
        bool quit = false;
        string currentPath = "";

        while (!quit)
        {
            Console.Clear();
            DisplayDrives();

            if (!string.IsNullOrEmpty(currentPath))
            {
                Console.WriteLine("[..] Go up");
                DisplayDirectoriesAndFiles(currentPath);
            }

            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                if (!string.IsNullOrEmpty(currentPath))
                {
                    currentPath = Directory.GetParent(currentPath).FullName;
                }
                else
                {
                    quit = true;
                }
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                if (string.IsNullOrEmpty(currentPath))
                {
                    currentPath = GetSelectedDrive();
                }
                else
                {
                    string selectedEntry = GetSelectedEntry(currentPath);
                    if (!string.IsNullOrEmpty(selectedEntry))
                    {
                        string newPath = Path.Combine(currentPath, selectedEntry);
                        if (Directory.Exists(newPath))
                        {
                            currentPath = newPath;
                        }
                        else if (File.Exists(newPath))
                        {
                            OpenFile(newPath);
                        }
                    }
                }
            }
        }
    }

    private static void DisplayDrives()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine(drive.Name);
            Console.WriteLine($"{drive.TotalSize - drive.TotalFreeSpace} bytes used out of {drive.TotalSize} bytes");
            Console.WriteLine();
        }
    }

    private static void DisplayDirectoriesAndFiles(string path)
    {
        string[] directories = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);

        foreach (string directory in directories)
        {
            Console.WriteLine($"[{Path.GetDirectoryName(directory)}] <DIR>");
        }

        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    private static string GetSelectedDrive()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        int selectedDriveIndex = 0;

        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            for (int i = 0; i < drives.Length; i++)
            {
                if (i == selectedDriveIndex)
                {
                    Console.Write("> ");
                }
                Console.WriteLine(drives[i].Name);
            }

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedDriveIndex = (selectedDriveIndex - 1 + drives.Length) % drives.Length;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedDriveIndex = (selectedDriveIndex + 1) % drives.Length;
            }
        } while (key.Key != ConsoleKey.Enter);

        return drives[selectedDriveIndex].RootDirectory.FullName;
    }

    private static string GetSelectedEntry(string path)
    {
        string[] directories = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);
        int selectedEntryIndex = 0;

        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            Console.WriteLine("[..] Go up");
            for (int i = 0; i < directories.Length; i++)
            {
                if (i == selectedEntryIndex)
                {
                    Console.Write("> ");
                }
                Console.WriteLine($"[{Path.GetDirectoryName(directories[i])}] <DIR>");
            }

            for (int i = 0; i < files.Length; i++)
            {
                if (i == selectedEntryIndex - directories.Length)
                {
                    Console.Write("> ");
                }
                Console.WriteLine(Path.GetFileName(files[i]));
            }

            key = Console.ReadKey(true);

            int totalEntries = directories.Length + files.Length;

            if (key.Key == ConsoleKey.UpArrow)
            {
                selectedEntryIndex = (selectedEntryIndex - 1 + totalEntries) % totalEntries;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                selectedEntryIndex = (selectedEntryIndex + 1) % totalEntries;
            }
        } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

        if (key.Key == ConsoleKey.Escape)
        {
            return "..";
        }

        if (selectedEntryIndex < directories.Length)
        {
            return Path.GetDirectoryName(directories[selectedEntryIndex]);
        }
        else
        {
            return Path.GetFileName(files[selectedEntryIndex - directories.Length]);
        }
    }

    private static void OpenFile(string filePath)
    {
        // Add your code here to open the file using the default program associated with its extension
    }
}
