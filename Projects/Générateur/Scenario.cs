using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generator
{
    /// <summary>
    /// Scenario with the airports.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// List of airport
        /// </summary>
        private List<Airport> m_airport;

        /// <summary>
        /// Constructor of the scenario. 
        /// </summary>
        public Scenario() 
        {
            Airports = new List<Airport>();
        }

        /// <summary>
        /// Property list airports.
        /// </summary>
        public List<Airport> Airports
        {
            get 
            { 
                if (m_airport == null)
                {
                    m_airport = new List<Airport>();
                }

                return m_airport;
            }
            set { m_airport = value; }
        }

        /// <summary>
        /// Scenario indexer to access an airport.
        /// </summary>
        /// <param name="index">Index of the airport.</param>
        /// <returns>The indexed airport in the scenario.</returns>
        public Airport this[int index]
        {
            get { return Airports[index]; }
            set { Airports[index] = value; }
        }

        /// <summary>
        /// Valid the parameters of the airports. If valid, create a new one and add it to the list.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="position">Position</param>
        /// <param name="passengerMin">Number minimum passenger</param>
        /// <param name="passengerMax">Number maximum passenger</param>
        /// <param name="cargoMin">Number minimum cargo</param>
        /// <param name="cargoMax">Number maximum cargo</param>
        /// <returns>Error message if there is.</returns>
        public String addAirport(String name, String position, int passengerMin, int passengerMax, int cargoMin, int cargoMax)
        {
            foreach (Airport airport in Airports)
            {
                if (airport.Name.Equals(name))
                {
                    return "This name is already being used by an other airport.";
                }
            }

            string errorMessage = Airport.areParametersValid(position, passengerMin, passengerMax, cargoMin, cargoMax); // Error message

            if (!errorMessage.Equals(""))
            {
                return errorMessage;
            }

            Airports.Add(new Airport(name, position, passengerMin, passengerMax, cargoMin, cargoMax));

            return "";
        }

        /// <summary>
        /// Valid the parameters of the aircraft. If valid, create a new one and add it to the list of the specified airport.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="indexAirport">Airport index</param>
        /// <param name="indexType">Index of the aircraft type</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        /// <returns></returns>
        public String addAircraft(String name, int indexAirport, int indexType, int speed, int maintains, int boarding, int unboarding)
        {
            foreach (Airport airport in Airports)
            {
                foreach (Aircraft aircraft in airport.Aircrafts)
                {
                    if (aircraft.Name.Equals(name))
                    {
                        return "This name is already being used by an other aircraft.";
                    }
                }
            }

            return Airports[indexAirport].addAircraft(name, indexType, speed, boarding, unboarding, maintains);
        }

    }
}
