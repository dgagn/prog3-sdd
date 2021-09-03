using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Debug;

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
            ConsoleExtra.WriteLine("SDD - Application de décodage\nPar Dany Gagnon\nBasée sur: Stack\n",
                ConsoleColor.DarkYellow);

            while (true)
            {
                ConsoleExtra.Write("Décoder> ", ConsoleColor.Blue);
                var input = Console.ReadLine();
                if (input == "exit") break;
                ConsoleExtra.WriteLine($"{"",9}{Décoder(input!)}\n", ConsoleColor.Green);
            }

            ConsoleExtra.WriteLine("Au revoir", ConsoleColor.DarkYellow);
        }
    }
}