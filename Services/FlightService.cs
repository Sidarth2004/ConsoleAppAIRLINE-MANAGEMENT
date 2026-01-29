using AirlineManagement.Model;
using AirlineManagement.Repositories;
using System.Collections.Generic;

namespace AirlineManagement.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService()
        {
            _flightRepository = new FlightRepository();
        }

        public void AddFlight(Flight flight)
        {
            _flightRepository.AddFlight(flight);
        }

        public List<Flight> GetFlights()
        {
            return _flightRepository.GetAllFlights();
        }
    }
}
