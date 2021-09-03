using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Décoder
{
    public class Program
    {
        public static string Décoder(string message)
        {
            var stringBuilder = new StringBuilder();
            var pile = new Stack<char>();

            var data = message.Select((c, index) => new { isPopper = c == '*', index, character = c });

            foreach (var datum in data)
                if (datum.isPopper)
                    if (pile.TryPop(out var result))
                        stringBuilder.Append(result);
                    else
                        throw new FormatException(
                            $"stack underflow {message.Remove(datum.index, 1).Insert(datum.index, "[*]")}");
                else
                    pile.Push(datum.character);

            if (pile.Count != 0)
                throw new FormatException(
                    $"étoiles manquantes '{string.Join(string.Empty, Enumerable.Repeat('*', pile.Count))}'");

            return stringBuilder.ToString();
        }

        private static void Main()
        {
            var a = Décoder("123**4**5*");
            Console.WriteLine(a);
        }
    }
}