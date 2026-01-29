using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using AirlineManagement.Model;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace AirlineManagement.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly string _connectionString;

        public FlightRepository()
        {
            var conn = ConfigurationManager.ConnectionStrings["DbConnection"];
            if (conn == null)
                throw new Exception("Connection string 'DbConnection' not found.");

            _connectionString = conn.ConnectionString;
        }

        public void AddFlight(Flight flight)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query =
                    "INSERT INTO Flight (DepAirport, DepDate, DepTime, ArrAirport, ArrDate, ArrTime) " +
                    "VALUES (@DepAirport, @DepDate, @DepTime, @ArrAirport, @ArrDate, @ArrTime)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@DepAirport", SqlDbType.VarChar, 50).Value = flight.DepAirport;
                    cmd.Parameters.Add("@DepDate", SqlDbType.Date).Value = flight.DepDate.Date;
                    cmd.Parameters.Add("@DepTime", SqlDbType.Time).Value = flight.DepTime;
                    cmd.Parameters.Add("@ArrAirport", SqlDbType.VarChar, 50).Value = flight.ArrAirport;
                    cmd.Parameters.Add("@ArrDate", SqlDbType.Date).Value = flight.ArrDate.Date;
                    cmd.Parameters.Add("@ArrTime", SqlDbType.Time).Value = flight.ArrTime;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Flight> GetAllFlights()
        {
            List<Flight> flights = new List<Flight>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string query =
                    "SELECT FlightId, DepAirport, DepDate, DepTime, ArrAirport, ArrDate, ArrTime FROM Flight";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            flights.Add(new Flight
                            {
                                FlightId = Convert.ToInt32(dr["FlightId"]),
                                DepAirport = dr["DepAirport"].ToString(),
                                DepDate = Convert.ToDateTime(dr["DepDate"]),
                                DepTime = (TimeSpan)dr["DepTime"],
                                ArrAirport = dr["ArrAirport"].ToString(),
                                ArrDate = Convert.ToDateTime(dr["ArrDate"]),
                                ArrTime = (TimeSpan)dr["ArrTime"]
                            });
                        }
                    }
                }
            }
            return flights;
        }
    }
}
