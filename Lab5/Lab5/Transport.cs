using System;


namespace Lab5
{ 
    public class Transport
    {
        public string Type { get; set; } // Автобус, Трамвай, Поезд
        public string Route { get; set; } // Маршрут
        public string Station { get; set; } // Станция
        public DateTime DepartureTime { get; set; } // Время отправления

        public Transport(string type, string route, string station, DateTime departureTime)
        {
            Type = type;
            Route = route;
            Station = station;
            DepartureTime = departureTime;
        }

        public override string ToString()
        {
            return $"{Type} {Route} в {DepartureTime:HH:mm}";
        }
    }

}