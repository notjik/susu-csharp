using System;
using System.Collections.Generic;


namespace Lab5
{
    public class Transport
    {
        public string TransportType { get; set; }
        public string Route { get; set; }
        public string Direction { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, TimeSpan> ScheduleByStation { get; set; } = new Dictionary<string, TimeSpan>();
        public string StartStation { get; set; }
        public string EndStation { get; set; }

        public Transport(string transportType, string route, string direction, DateTime date)
        {
            TransportType = transportType;
            Route = route;
            Direction = direction;
            Date = date;
        }

        public void AddSchedule(string station, TimeSpan departureTime)
        {
            if (ScheduleByStation.Count == 0)
                StartStation = station;
            ScheduleByStation[station] = departureTime;
            EndStation = station;
        }

        public override string ToString()
        {
            return $"{TransportType} {Route} ({StartStation} - {EndStation})";
        }
    }
}