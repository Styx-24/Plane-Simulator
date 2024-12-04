using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Client.clientWithPositions;
using Simulator.states;

namespace Simulator
{
    /// <summary>
    /// State factory creating aircraft states.
    /// </summary>
    public sealed class StatesFactory
    {
        /// <summary>
        /// Aircraft factory object singleton.
        /// </summary>
        private static readonly StatesFactory m_instance = new StatesFactory();

        /// <summary>
        /// Private constructor.
        /// </summary>
        private StatesFactory() { }

        /// <summary>
        /// Access to aircraft factory.
        /// </summary>
        public static StatesFactory Instance
        {
            get { return m_instance; }
        }

        /// <summary>
        /// Create client state waiting.
        /// </summary>
        /// <returns>Waiting state.</returns>
        public Wait createWait()
        {
            return new Wait();
        }

        /// <summary>
        /// Create client state maintenance.
        /// </summary>
        /// <param name="time">Maintenance time in seconds</param>
        /// <returns>Maintenance state.</returns>
        public Maintenance createMaintenance(int time)
        {
            return new Maintenance(time);
        }

        /// <summary>
        /// Create client state boarding.
        /// </summary>
        /// <param name="numberOfClients">Number of client to board</param>
        /// <param name="clientsPerSecond">Amount of client for each second</param>
        /// <returns>Boarding state.</returns>
        public Boarding createBoarding(int numberOfClients, int clientsPerSecond)
        {
            return new Boarding(numberOfClients, clientsPerSecond);
        }

        /// <summary>
        /// Create client state unboarding.
        /// </summary>
        /// <param name="numberOfClients">Number of client to board</param>
        /// <param name="clientsPerSecond">Amount of client for each second</param>
        /// <returns>Unboarding state.</returns>
        public UnBoarding createUnBoarding(int numberOfClients, int clientsPerSecond)
        {
            return new UnBoarding(numberOfClients, clientsPerSecond);
        }

        /// <summary>
        /// Create client state flight.
        /// </summary>
        /// <param name="positionStart">Starting position</param>
        /// <param name="positionEnd">Ending position</param>
        /// <param name="kmPerSecond">Km per second of the flight.</param>
        /// <returns>Flight state.</returns>
        public Flight createFlight(Position positionStart, Position positionEnd, int kmPerSecond)
        {
            return new Flight(positionStart, positionEnd, kmPerSecond);
        }

        /// <summary>
        /// Create client state flight.
        /// </summary>
        /// <param name="kmPerSecond">Km per second of the flight.</param>
        /// <param name="airportStart">Starting airport</param>
        /// <param name="airportDestination">Destination airport</param>
        /// <returns>Flight state.</returns>
        public Flight createFlight(int kmPerSecond, Airport airportStart, Airport airportDestination)
        {
            return new Flight(kmPerSecond, airportStart, airportDestination);
        }

        /// <summary>
        /// Create client state fire.
        /// </summary>
        /// <param name="fire">Fire to be extinguished</param>
        /// <param name="positionStart">Starting position</param>
        /// <param name="kmPerSecond">Km per second of the flight.</param>
        /// <returns>Fire state.</returns>
        public FireFight createFireFight(Fire fire, Position positionStart, int kmPerSecond)
        {
            return new FireFight(fire, positionStart, kmPerSecond);
        }

        /// <summary>
        /// Create client state rescue client.
        /// </summary>
        /// <param name="rescueClient">Client oto rescue</param>
        /// <returns>Rescue state.</returns>
        public Rescuing createRescuing(Rescue rescueClient)
        {
            return new Rescuing(rescueClient);
        }

        /// <summary>
        /// Create client state hover.
        /// </summary>
        /// <param name="observation">Place to observe.</param>
        /// <param name="positionStart">Starting position</param>
        /// <param name="kmPerSecond">Km per second of the flight.</param>
        /// <returns>Hover states.</returns>
        public Hover createHover(Observation observation, Position positionStart, int kmPerSecond)
        {
            return new Hover(observation, positionStart, kmPerSecond);
        }
    }
}
