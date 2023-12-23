using System;
using System.IO;

class CircularArray
{
    static void Main()
    {
        Console.Write("Введите размер массива (n): ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите длину обхода (m): ");
        int m = int.Parse(Console.ReadLine());

        if (n <= 0 || m <= 0)
        {
            Console.WriteLine("Размер массива и длина обхода должны быть положительными числами.");
            return;
        }

        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = i + 1;
        }

        Console.Write($"Полученный путь: ");

        int currentIndex = 0;
        do
        {
            Console.Write(array[currentIndex]);
            currentIndex = (currentIndex + m - 1) % array.Length;
        } while (currentIndex != 0);


        Console.ReadLine();
    }

}
