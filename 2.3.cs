using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string Pair((int x, int y) p)
    {
        return $"({p.x}, {p.y})";
    }

 
    static void PrintRelation(string name,HashSet<(int x, int y)> relation)
    {
        Console.WriteLine($"\n{name}:");

        if (relation.Count == 0)
        {
            Console.WriteLine("z");
            return;
        }

        Console.WriteLine("{");

        foreach (var p in relation.OrderBy(p => p.x).ThenBy(p => p.y))
        {
            Console.Write($"{Pair(p)} ");
        }

        Console.WriteLine("}");
        Console.WriteLine($"Кількість елементів: {relation.Count}");
    }

    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.InputEncoding = Encoding.GetEncoding(1251);
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        

        HashSet<(int x, int y)> P1 = new HashSet<(int x, int y)>();

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

       

        HashSet<(int x, int y)> P2 = new HashSet<(int x, int y)>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = 0; y <= 3; y++)
            {
                P2.Add((x, y));
            }
        }

        
      
        HashSet<(int x, int y)> union = new HashSet<(int x, int y)>(P1);

        union.UnionWith(P2);

        HashSet<(int x, int y)> intersection = new HashSet<(int x, int y)>(P1);

        intersection.IntersectWith(P2);

        
        HashSet<(int x, int y)> difference12 = new HashSet<(int x, int y)>(P1);

        difference12.ExceptWith(P2);

        HashSet<(int x, int y)> difference21 = new HashSet<(int x, int y)>(P2);

        difference21.ExceptWith(P1);

        HashSet<(int x, int y)> symmetricDifference = new HashSet<(int x, int y)>(P1);

        symmetricDifference.SymmetricExceptWith(P2);

       

        PrintRelation("P1", P1);
        PrintRelation("P2", P2);

        PrintRelation("P1 U P2", union);
        PrintRelation("P1 n P2", intersection);
        PrintRelation("P1 \\ P2", difference12);
        PrintRelation("P2 \\ P1", difference21);
        PrintRelation("P1 A P2", symmetricDifference);

        Console.ReadKey();
    }
}