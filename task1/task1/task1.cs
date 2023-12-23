using System;
using System.IO;

class CircularArray
{
    static void Main()
    {

        int[] arg = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int n = arg[0];
        int m = arg[1];

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

        int currentIndex = 0;
        do
        {
            Console.Write(array[currentIndex]);
            currentIndex = (currentIndex + m - 1) % array.Length;
        } while (currentIndex != 0);


        Console.ReadLine();
    }

}
