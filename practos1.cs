using System;

class Calculator
{
    static void Main()
    {
        int choice;
        double num1, num2;

        do
        {
            Console.WriteLine("\nВыберите операцию:");
            Console.WriteLine("1) Сложить 2 числа");
            Console.WriteLine("2) Вычесть первое из второго");
            Console.WriteLine("3) Перемножить 2 числа");
            Console.WriteLine("4) Разделить первое на второе");
            Console.WriteLine("5) Возвести в степень N первое число");
            Console.WriteLine("6) Найти квадратный корень из числа");
            Console.WriteLine("7) Найти 1 процент от числа");
            Console.WriteLine("8) Найти факториал из числа");
            Console.WriteLine("9) Выйти из программы");
            Console.Write("Ваш выбор: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 + num2));
                    break;
                case 2:
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 - num2));
                    break;
                case 3:
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 * num2));
                    break;
                case 4:
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 / num2));
                    break;
                case 5:
                    Console.Write("Введите число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите степень: ");
                    int power = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Результат: " + Math.Pow(num1, power));
                    break;
                case 6:
                    Console.Write("Введите число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + Math.Sqrt(num1));
                    break;
                case 7:
                    Console.Write("Введите число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 / 100));
                    break;
                case 8:
                    Console.Write("Введите число: ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Результат: " + Factorial(num1));
                    break;
                case 9:
                    Console.WriteLine("Выход из программы...");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор операции");
                    break;
            }
        } while (choice != 9);
    }

    // Функция для вычисления факториала числа
    static double Factorial(double n)
    {
        if (n == 0)
            return 1;
        else
            return n * Factorial(n - 1);
    }
}
