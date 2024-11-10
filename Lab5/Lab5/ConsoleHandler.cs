using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    public static class ConsoleHandler
    {
        public static string ReadLine(SortedSet<string> allStations)
        {
            const string startLine = "Введите название станции (или пустую строку для выхода): ";
            var input = string.Empty;

            while (true)
            {
                Console.Clear();
                Console.Write(startLine);
                Console.Write(input);

                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Tab)
                {
                    var suggestions = allStations.Where(station =>
                        station.StartsWith(input, StringComparison.InvariantCultureIgnoreCase)).ToList();

                    if (suggestions.Count == 1)
                    {
                        input = suggestions[0];
                    }
                    else if (suggestions.Count > 1)
                    {
                        Console.WriteLine();
                        foreach (var suggestion in suggestions)
                        {
                            Console.WriteLine(suggestion);
                        }

                        Console.SetCursorPosition(startLine.Length + input.Length, Console.CursorLeft);

                        var choice = Console.ReadKey(intercept: true);
                        if (choice.Key == ConsoleKey.Tab)
                        {
                            input = suggestions[0];
                        }
                        else if (choice.Key == ConsoleKey.Backspace)
                        {
                            if (input.Length > 0)
                            {
                                input = input.Substring(0, input.Length - 1);
                            }
                        }
                        else
                        {
                            input += choice.KeyChar;
                        }
                    }
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    input += key.KeyChar;
                }
            }

            return input;
        }

        public static void WriteLine(string station, List<(Transport, TimeSpan)> departures, DateTime currentDateTime)
        {
            if (departures.Count > 0)
            {
                Console.WriteLine($"Ближайшие отправления с {station}:");
                foreach (var (transport, time) in departures)
                {
                    var difference = time - currentDateTime.TimeOfDay;
                    Console.WriteLine(
                        $"{transport} - отправление в {time:hh\\:mm} (через {TimeFormat.GetTimeFormatted(difference.Minutes)})");
                }
            }
            else
            {
                Console.WriteLine($"Нет предстоящих отправлений со станции {station}.");
            }
            var wait = Console.ReadKey(intercept: true);
        }
    }
}