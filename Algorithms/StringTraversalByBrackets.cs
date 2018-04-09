using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class StringTraversalByBrackets
    {
        private static readonly Dictionary<char, char> Brackets = new Dictionary<char, char>
        {
            {'{', '}'},
            {'[', ']'},
            {'(', ')'}
        };

        public static string Traverse(string expression, string successAnswer, string unSuccessAnswer)
        {
            var res = new Stack<char>();

            foreach (var symbol in expression)
            {
                // пришла открывающая скобка
                if (IsOpenBracket(symbol))
                    res.Push(symbol);

                if (!IsClosedBracket(symbol))
                    continue;

                if (IsStringBeginFromClosedSymbol(res))
                    return unSuccessAnswer;

                var top = res.Pop();
                var closedTopPair = Brackets[top];
                if (closedTopPair != symbol)
                    return unSuccessAnswer;
            }

            return IsOpenBracketsMoreThanClosed(res)
                ? unSuccessAnswer
                : successAnswer;
        }

        private static bool IsClosedBracket(char symbol)
        {
            return Brackets.Values.Contains(symbol);
        }

        private static bool IsOpenBracket(char symbol)
        {
            return Brackets.Keys.Contains(symbol);
        }

        private static bool IsOpenBracketsMoreThanClosed(IEnumerable<char> res)
        {
            return res.Any();
        }

        private static bool IsStringBeginFromClosedSymbol(IEnumerable<char> res)
        {
            return !res.Any();
        }
    }
}