using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMModEvaluator
{
    /// <summary>
    /// A Static class, which evaluates Modulus Statements and outputs a number or a string based on the result
    /// </summary>
    public static class ModEvaluator
    {
        /// <summary>
        /// Evaluates a list Modulus Statements and outputs a number or a statement based on the result when compared to a range of numbers
        /// </summary>
        /// <param name="start">The number to start with.</param>
        /// <param name="end">The number to start on.</param>
        /// <param name="parameterList">The list of Modulus Operators example {{3,"fizz"},{5,"buzz"}}</param>
        /// <returns></returns>
        static public List<string> ModEval(int start, int end, List<KeyValuePair<int, string>> parameterList)
        {
            var output = new List<string>();
            for (var number = start; number <= end; number++)
            {
                var value = new StringBuilder();
                foreach (var parameter in parameterList.Where(parameter => number % parameter.Key == 0))
                {
                    value.Append(parameter.Value);
                }
                if (value.Length < 1)
                {
                    value.Append(number);
                }

                output.Add(value.ToString());
            }
            return output;
        }
    }
}
