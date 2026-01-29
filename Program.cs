using AirlineManagement.Model;
using AirlineManagement.Services;
using System;

namespace AirlineManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            IFlightService service = new FlightService();

            Flight flight = new Flight
            {
                DepAirport = "COK",
                DepDate = DateTime.Today,
                DepTime = new TimeSpan(10, 30, 0),
                ArrAirport = "DEL",
                ArrDate = DateTime.Today,
                ArrTime = new TimeSpan(13, 15, 0)
            };

            service.AddFlight(flight);
            Console.WriteLine("Flight added successfully!");

            var flights = service.GetFlights();
            foreach (var f in flights)
            {
                Console.WriteLine($"{f.FlightId} | {f.DepAirport} → {f.ArrAirport}");
            }

            Console.ReadLine();
        }
    }
}
