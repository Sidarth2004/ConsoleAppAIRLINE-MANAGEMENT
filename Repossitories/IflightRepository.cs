using AirlineManagement.Model;
using System.Collections.Generic;

namespace AirlineManagement.Repositories
{
    public interface IFlightRepository
    {
        void AddFlight(Flight flight);
        List<Flight> GetAllFlights();
    }
}
