using System;
using System.Collections.Generic;
using System.IO;


namespace Lab5
{
    public class Schedule
    {
        public List<Transport> Transports { get; set; } = new List<Transport>();

        public List<Transport> GetNextDepartures(string station)
        {
            DateTime now = DateTime.Now;
            return Transports.FindAll(t => t.Station.Equals(station, StringComparison.OrdinalIgnoreCase) && t.DepartureTime > now);
        }
        
        public void LoadSchedule(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 4 &&
                    DateTime.TryParse(parts[3], out DateTime departureTime))
                {
                    Transports.Add(new Transport(parts[0], parts[1], parts[2], departureTime));
                }
            }
        }
    }
}