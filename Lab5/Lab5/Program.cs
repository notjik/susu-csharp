using System;



namespace Lab5
{
    public abstract class Program
    {
        public static void Main(string[] args)
        {
            Schedule schedule = new Schedule();
            schedule.LoadSchedule("../../schedule.txt");

            while (true)
            {
                Console.WriteLine("Введите название станции (или пустую строку для выхода):");
                string station = Console.ReadLine();
                if (string.IsNullOrEmpty(station))
                    break;

                var nextDepartures = schedule.GetNextDepartures(station);
                if (nextDepartures.Count > 0)
                {
                    Console.WriteLine("Ближайшие отправления:");
                    foreach (var transport in nextDepartures)
                    {
                        Console.WriteLine(transport);
                    }
                }
                else
                {
                    Console.WriteLine("Нет ближайших отправлений с этой станции.");
                }
            }
        }
    }

}