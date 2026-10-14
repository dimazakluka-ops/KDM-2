using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    

    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.InputEncoding = Encoding.GetEncoding(1251);
        Console.OutputEncoding = Encoding.GetEncoding(1251);
       
        HashSet<int> A = new HashSet<int>();

        for (int x = -3; x <= 3; x++)
        {
            A.Add(x);
        }

      
        HashSet<int> B = new HashSet<int>();

        for (int y = 1; y <= 6; y++)
        {
            B.Add(y);
        }

       
        List<(int x, int y)> P1 = new List<(int x, int y)>();

        foreach (int x in A)
        {
            foreach (int y in B)
            {
                
                if (x * y <= 0)
                {
                    P1.Add((x, y));
                }
            }
        }


        Console.WriteLine("A = {" + string.Join(", ", A) + "}");
        Console.WriteLine("B = {" + string.Join(", ", B) + "}");

        Console.WriteLine("\nВідношення P1:");

        foreach (var pair in P1)
        {
            Console.WriteLine($"({pair.x}, {pair.y})");
        }

        Console.WriteLine($"\nКількість елементів P1 = {P1.Count}");
    }
}