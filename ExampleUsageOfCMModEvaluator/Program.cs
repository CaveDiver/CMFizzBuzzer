using System;
using System.Collections.Generic;
using CMModEvaluator;

namespace ExampleUsageOfCMModEvaluator
{
    class Program
    {
        static void Main()
        {
            var parameters = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(3, "fizz"),
                new KeyValuePair<int, string>(5,"buzz"),
                new KeyValuePair<int, string>(10,"sudz")
            };
            const int start = 1;
            const int end = 100;
            var unit = ModEvaluator.ModEval(start, end, parameters);
            unit.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
