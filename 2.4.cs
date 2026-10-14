using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       

        HashSet<(int x, int y)> P1 =
            new HashSet<(int x, int y)>();

        for (int x = -3; x <= 3; x++)
        {
            for (int y = 1; y <= 6; y++)
            {
                if (x * y <= 0)
                {
                    P1.Add((x, y));
                }
            }
        }

       

        HashSet<(int x, int y)> P2 =
            new HashSet<(int x, int y)>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = 0; y <= 3; y++)
            {
                P2.Add((x, y));
            }
        }

      

        int[] C = { 1, 2, 3, 4, 5 };
        int[] D = { 10, 20, 30, 40 };

       
        HashSet<(int x, int y)> Q =
            new HashSet<(int x, int y)>();

        foreach (int x in C)
        {
            foreach (int y in D)
            {
                Q.Add((x, y));
            }
        }

   

        HashSet<(int x, int z)> R1 =
            new HashSet<(int x, int z)>();

        foreach (var q in Q)
        {
            foreach (var p in P1)
            {
               
                if (q.y == p.x)
                {
                    R1.Add((q.x, p.y));
                }
            }
        }


        HashSet<(int x, int z)> R2 =
            new HashSet<(int x, int z)>();

        foreach (var q in Q)
        {
            foreach (var p in P2)
            {
             
                if (q.y == p.x)
                {
                    R2.Add((q.x, p.y));
                }
            }
        }

    

        Console.WriteLine("Q = C x D");

        Console.WriteLine("\nR1 = P1 o Q:");

        if (R1.Count == 0)
            Console.WriteLine("z");
        else
            foreach (var p in R1)
                Console.WriteLine($"({p.x}, {p.z})");

        Console.WriteLine("\nR2 = P2 o Q:");

        if (R2.Count == 0)
            Console.WriteLine("z");
        else
            foreach (var p in R2)
                Console.WriteLine($"({p.x}, {p.z})");

        Console.ReadKey();
    }
}