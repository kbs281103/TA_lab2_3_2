using System;

class Program
{
    static void Main()
    {
        // Встановлення кодування консолі на UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть розмірність масиву (n):");
        int n = GetPositiveIntegerFromUser();

        int[] array = GenerateRandomArray(n);

        // Виведення масиву
        Console.WriteLine("Згенерований масив:");
        PrintArray(array);

        // Знаходження максимального елементу
        int maxElement = FindMaxElement(array);
        Console.WriteLine($"Максимальний елемент масиву: {maxElement}");

        // Знаходження суми елементів між першим і другим додатними
        int sumBetweenPositive = FindSumBetweenPositiveElements(array);
        Console.WriteLine($"Сума елементів масиву, розташованих між першим і другим додатними: {sumBetweenPositive}");

        // Закриття програми після натискання на символ 'q'
        CloseProgramOnKeyPress('q');
    }

    // Метод для отримання цілого числа від користувача
    static int GetIntegerFromUser(string prompt)
    {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Некоректне введення. Будь ласка, введіть ціле число.");
            Console.Write(prompt);
        }
        return number;
    }

    // Метод для отримання позитивного цілого числа від користувача
    static int GetPositiveIntegerFromUser()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Некоректне введення. Будь ласка, введіть додатне ціле число.");
            Console.Write("n = ");
        }
        return number;
    }

    // Метод для виведення масиву на консоль
    static void PrintArray(int[] array)
    {
        Console.WriteLine("Масив:");
        foreach (var element in array)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    // Метод для генерації масиву випадкових чисел
    static int[] GenerateRandomArray(int n)
    {
        Random rand = new Random();
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = rand.Next(-100, 101);
        }
        return array;
    }

    // Метод для знаходження максимального елементу масиву
    static int FindMaxElement(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    // Метод для знаходження суми елементів масиву, розташованих між першим і другим додатними
    static int FindSumBetweenPositiveElements(int[] array)
    {
        int sum = 0;
        int firstPositiveIndex = -1;

        // Знаходимо індекс першого додатнього елемента
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                firstPositiveIndex = i;
                break;
            }
        }

        // Якщо немає додатніх елементів, повертаємо 0
        if (firstPositiveIndex == -1)
        {
            return 0;
        }

        // Знаходимо індекс другого додатнього елемента
        int secondPositiveIndex = -1;
        for (int i = firstPositiveIndex + 1; i < array.Length; i++)
        {
            if (array[i] > 0)
            {
                secondPositiveIndex = i;
                break;
            }
        }

        // Якщо немає другого додатнього елемента, повертаємо 0
        if (secondPositiveIndex == -1)
        {
            return 0;
        }

        // Обчислюємо суму елементів між першим і другим додатними
        for (int i = firstPositiveIndex + 1; i < secondPositiveIndex; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    // Метод для закриття програми при натисканні на певний символ
    static void CloseProgramOnKeyPress(char key)
    {
        Console.WriteLine($"Натисніть клавішу '{key}' для закриття програми...");
        while (Console.ReadKey().KeyChar != key) { }
    }
}
