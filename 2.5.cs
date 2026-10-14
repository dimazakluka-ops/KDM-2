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

        HashSet<int> A = new HashSet<int> { 1, 2, 3, 4 };

        HashSet<(int, int)> R = new HashSet<(int, int)>
        {
            (1, 1), (2, 2), (3, 3), (4, 4),
            (1, 2), (1, 3), (1, 4)
        };

        bool reflexive = A.All(x => R.Contains((x, x)));

   
        bool symmetric = R.All(pair =>  R.Contains((pair.Item2, pair.Item1)));

        
        bool antisymmetric = R.All(pair => pair.Item1 == pair.Item2 || !R.Contains((pair.Item2, pair.Item1)));

     
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
                    }
                }
            }
        }

        Console.WriteLine("Відношення R:");
        Console.WriteLine("R = {(1,1), (2,2), (3,3), (4,4), (1,2), (1,3), (1,4)}");
        Console.WriteLine();

        Console.WriteLine("Рефлексивність: " +  (reflexive ));

        Console.WriteLine("Симетричність: " +  (symmetric ));

        Console.WriteLine("Антисиметричність: " +  (antisymmetric));

        Console.WriteLine("Транзитивність: " + (transitive));
    }
}