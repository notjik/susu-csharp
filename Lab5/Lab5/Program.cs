using System;
using System.IO;

namespace Lab5
{
    public abstract class Program
    {
        public static void Main()
        {
            var schedule = new Schedule();
            string filePath = "../../schedule.txt";

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден.");
            }

            schedule.LoadSchedule(filePath);
            while (true)
            {
                var station = ConsoleHandler.ReadLine(schedule.Stations);
                if (string.IsNullOrWhiteSpace(station))
                    break;

                var currentDateTime = DateTime.Now;
                var departures = schedule.GetNextDepartures(station, currentDateTime, 10);

                ConsoleHandler.WriteLine(station, departures, currentDateTime);
            }
        }
    }
}