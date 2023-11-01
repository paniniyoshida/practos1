using System;
using System.Collections.Generic;
using System.IO;

// Класс для подпункта меню
public class MenuItem
{
    public string Description { get; set; }
    public decimal Price { get; set; }

    public MenuItem(string description, decimal price)
    {
        Description = description;
        Price = price;
    }
}

// Класс для стрелочного меню
public static class ArrowMenu
{
    // Метод для отображения меню
    public static int ShowMenu(string title, List<MenuItem> menuItems)
    {
        Console.Clear();
        Console.WriteLine(title);

        for (int i = 0; i < menuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuItems[i].Description}");
        }

        ConsoleKeyInfo key;
        int selectedItemIndex = 0;

        do
        {
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow && selectedItemIndex > 0)
                selectedItemIndex--;
            else if (key.Key == ConsoleKey.DownArrow && selectedItemIndex < menuItems.Count - 1)
                selectedItemIndex++;

            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{selectedItemIndex + 1}. {menuItems[selectedItemIndex].Description}");
            Console.ResetColor();
        } while (key.Key != ConsoleKey.Enter);

        return selectedItemIndex;
    }
}

// Класс для заказа
public class Order
{
    private MenuItem[] forms = new[]
    {
        new MenuItem("Круглая", 100),
        new MenuItem("Прямоугольная", 120),
        new MenuItem("Сердце", 150)
    };

    private MenuItem[] sizes = new[]
    {
        new MenuItem("Маленький", 50),
        new MenuItem("Средний", 80),
        new MenuItem("Большой", 100)
    };

    private MenuItem[] flavors = new[]
    {
        new MenuItem("Шоколадный", 60),
        new MenuItem("Ванильный", 40),
        new MenuItem("Карамельный", 50)
    };

    private MenuItem[] glazes = new[]
    {
        new MenuItem("Шоколадная", 30),
        new MenuItem("Сливочная", 20),
        new MenuItem("Фруктовая", 25)
    };

    private MenuItem[] decorations = new[]
    {
        new MenuItem("Фрукты", 15),
        new MenuItem("Шоколадные кусочки", 10),
        new MenuItem("Цветы", 12)
    };

    private List<MenuItem[]> menuItems = new List<MenuItem[]>();

    public void StartOrder()
    {
        menuItems.Add(forms);
        menuItems.Add(sizes);
        menuItems.Add(flavors);
        menuItems.Add(glazes);
        menuItems.Add(decorations);

        List<MenuItem> selectedItems = new List<MenuItem>();

        foreach (var menu in menuItems)
        {
            int selectedIndex = ArrowMenu.ShowMenu("Выберите пункт", menu);
            selectedItems.Add(menu[selectedIndex]);
        }

        decimal totalPrice = 0;

        foreach (var item in selectedItems)
        {
            totalPrice += item.Price;
        }

        Console.WriteLine($"Суммарная цена: {totalPrice}");

        SaveOrder(selectedItems, totalPrice);

        Console.WriteLine("Заказ оформлен. Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
        Console.Clear();

        StartOrder();
    }

    private void SaveOrder(List<MenuItem> items, decimal totalPrice)
    {
        string filePath = "История заказов.txt";

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine("Заказ:");
            foreach (var item in items)
            {
                sw.WriteLine($"{item.Description}: {item.Price} руб.");
            }
            sw.WriteLine($"Итого: {totalPrice} руб.");
            sw.WriteLine(new string('-', 30));
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();
        order.StartOrder();
    }
}
