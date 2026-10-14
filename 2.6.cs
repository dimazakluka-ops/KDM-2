using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.InputEncoding = Encoding.GetEncoding(1251);
        Console.OutputEncoding = Encoding.GetEncoding(1251);
      
        HashSet<int> N = new HashSet<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };

     
        HashSet<(int, int)> R = new HashSet<(int, int)>();

        foreach (int x in N)
        {
            foreach (int y in N)
            {
                if ((x + y) % 2 == 0)
                {
                    R.Add((x, y));
                }
            }
        }

      
        Console.WriteLine("Відношення R:");
        foreach (var pair in R)
        {
            Console.Write($"({pair.Item1},{pair.Item2}) ");
        }

        Console.WriteLine();
        Console.WriteLine();

  
        bool reflexive = true;

        foreach (int x in N)
        {
            if (!R.Contains((x, x)))
            {
                reflexive = false;
                break;
            }
        }

     
        bool symmetric = true;

        foreach (var pair in R)
        {
            if (!R.Contains((pair.Item2, pair.Item1)))
            {
                symmetric = false;
                break;
            }
        }

        
        bool transitive = true;

        foreach (var pair1 in R)
        {
            foreach (var pair2 in R)
            {
                if (pair1.Item2 == pair2.Item1)
                {
                    if (!R.Contains((pair1.Item1, pair2.Item2)))
                    {
                        transitive = false;
                        break;
                    }
                }
            }

            if (!transitive)
                break;
        }

        Console.WriteLine("Рефлексивність: " +
            (reflexive ));

        Console.WriteLine("Симетричність: " +
            (symmetric ));

        Console.WriteLine("Транзитивність: " +
            (transitive     ));

        // Перевірка, чи є еквівалентністю
        bool equivalence = reflexive && symmetric && transitive;

        Console.WriteLine();

        Console.WriteLine("Чи є відношення еквівалентністю: " +
            (equivalence));
    }
}