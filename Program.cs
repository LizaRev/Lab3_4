using System;

class Program
{
    delegate StringStatistics StringAnalyzer(string text);

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть рядок: ");
        string text = Console.ReadLine() ?? "";

        StringAnalyzer analyzeLambda = text =>
        {
            StringStatistics result = new StringStatistics();

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                    result.Letters++;
                else if (char.IsDigit(symbol))
                    result.Digits++;
                else
                    result.Other++;
            }

            return result;
        };

        StringStatistics lambdaResult = analyzeLambda(text);

        Console.WriteLine("\n Результат Lambda ");
        Console.WriteLine($"Літер: {lambdaResult.Letters}");
        Console.WriteLine($"Цифр: {lambdaResult.Digits}");
        Console.WriteLine($"Інших символів: {lambdaResult.Other}");


        StringAnalyzer analyzeAnonymous = delegate (string text)
        {
            StringStatistics result = new StringStatistics();

            foreach (char symbol in text)
            {
                if (char.IsLetter(symbol))
                    result.Letters++;
                else if (char.IsDigit(symbol))
                    result.Digits++;
                else
                    result.Other++;
            }

            return result;
        };

        StringStatistics anonymousResult = analyzeAnonymous(text);

        Console.WriteLine("\n  Результат Anonymous метода ");
        Console.WriteLine($"Літер: {anonymousResult.Letters}");
        Console.WriteLine($"Цифр: {anonymousResult.Digits}");
        Console.WriteLine($"Інших символів: {anonymousResult.Other}");


        Console.WriteLine("\n Створення басейну");

        Console.Write("Введіть довжину басейну (м): ");
        double length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть ширину басейну (м): ");
        double width = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть глибину басейну (м): ");
        double depth = Convert.ToDouble(Console.ReadLine());

        Pool pool = new Pool(length, width, depth);

        Console.WriteLine($"\nОб'єм басейну: {pool.Volume:F2} л");


        pool.PoolOverflow += PoolOverflowHandler;


        Console.Write("\nСкільки літрів води варто долити: ");
        double addWater = Convert.ToDouble(Console.ReadLine());

        pool.AddWater(addWater);

        Console.WriteLine($"Зараз у басейні: {pool.CurrentWater:F2} л");


        Console.Write("\nСкільки літрів води варто злити: ");
        double removeWater = Convert.ToDouble(Console.ReadLine());

        pool.RemoveWater(removeWater);

        Console.WriteLine($"Після зливу у басейні: {pool.CurrentWater:F2} л");

        Console.WriteLine("\nПрограма завершена.");
    }

    private static void PoolOverflowHandler(
        object? sender,
        PoolOverflowEventArgs e)
    {
        Console.WriteLine("\n Басейн переповнено");
        Console.WriteLine($"Максимальний об'єм: {e.Volume:F2} л");
        Console.WriteLine($"Кількість води: {e.CurrentWater:F2} л");
        Console.WriteLine($"Перелилося води: {e.OverflowAmount:F2} л");
    }
}