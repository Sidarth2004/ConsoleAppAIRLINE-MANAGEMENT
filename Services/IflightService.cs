using AirlineManagement.Model;
using System.Collections.Generic;

namespace AirlineManagement.Services
{
    public interface IFlightService
    {
        void AddFlight(Flight flight);
        List<Flight> GetFlights();
    }
}
