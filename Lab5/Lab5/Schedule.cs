    using System;
    using System.Collections.Generic;
    using System.IO;


    namespace Lab5
    {
        public class Schedule
        {
            public readonly SortedSet<string> Stations = new SortedSet<string>();
            private List<Transport> Transports { get; set; } = new List<Transport>();

            public void LoadSchedule(string filePath)
            {
                var lines = File.ReadAllLines(filePath);
                Transport currentTransport = null;

                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();
                    if (trimmedLine.StartsWith("Тип транспорта"))
                    {
                        var typeRouteDirection = trimmedLine
                            .Replace("Тип транспорта: ", "")
                            .Replace("Маршрут: ", "")
                            .Replace("Направление: ", "")
                            .Split(';');
                        if (typeRouteDirection.Length == 3)
                        {
                            var transportType = typeRouteDirection[0].Trim();
                            var route = typeRouteDirection[1].Trim();
                            var direction = typeRouteDirection[2].Trim();

                            currentTransport = new Transport(transportType, route, direction, DateTime.MinValue);
                            Transports.Add(currentTransport);
                        }
                        else
                        {
                            throw new FileLoadException("Ошибка: Неправильный формат строки маршрута");
                        }
                    }
                    else if (trimmedLine.StartsWith("Дата") && currentTransport != null)
                    {
                        var dateStr = trimmedLine.Replace("Дата: ", "").Trim();
                        if (DateTime.TryParse(dateStr, out DateTime date))
                        {
                            currentTransport.Date = date;
                        }
                        else
                        {
                            throw new FileLoadException("Ошибка: Неправильный формат даты");
                        }
                    }
                    else if (trimmedLine.StartsWith("Станция") && currentTransport != null)
                    {
                        var parts = trimmedLine.Replace("Станция: ", "").Split(';');
                        var station = parts[0].Trim();
                        var timeStr = parts.Length > 1 ? parts[1].Replace("Время: ", "").Trim() : "";

                        if (TimeSpan.TryParse(timeStr, out TimeSpan departureTime))
                        {
                            currentTransport.AddSchedule(station, departureTime);
                            Stations.Add(station);
                        }
                        else
                        {
                            throw new FileLoadException("Ошибка: Неправильный формат времени");
                        }
                    }
                }
            }

            public List<(Transport, TimeSpan)> GetNextDepartures(string station, DateTime currentDateTime, uint max)
            {
                var results = new List<(Transport, TimeSpan)>();

                foreach (var transport in Transports)
                {
                    if (results.Count >= max)
                    {
                        break;
                    }

                    if (transport.Date.Date == currentDateTime.Date &&
                        transport.ScheduleByStation.TryGetValue(station, out var departureTime))
                    {
                        if (departureTime >= currentDateTime.TimeOfDay)
                        {
                            results.Add((transport, departureTime));
                        }
                    }
                }

                results.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                return results;
            }
        }
    }