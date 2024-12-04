using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// the flight state
    /// </summary>
    public class Flight : StatusWithPositions
    {
        /// <summary>
        /// the starting airport of the flight
        /// </summary>
        private Airport m_airportStart;
        /// <summary>
        /// the destination airport of the flight
        /// </summary>
        private Airport m_airportDestination;

        /// <summary>
        /// constructor of the flight state
        /// </summary>
        /// <param name="positionStart">starting point on the map of the travel</param>
        /// <param name="positionEnd">destination on the map of the travel</param>
        /// <param name="kmPerSecond">speed in kilometers per second</param>
        public Flight(Position positionStart, Position positionEnd, int kmPerSecond) : base(positionStart, positionEnd, kmPerSecond)
        {
            m_totalTime = 0;
        }

        /// <summary>
        /// constructor of the flight state
        /// </summary>
        /// <param name="kmPerSecond">speed in kilometers per second</param>
        /// <param name="airportStart">the starting airport of the flight</param>
        /// <param name="airportDestination">the destination airport of the flight</param>
        public Flight(int kmPerSecond, Airport airportStart, Airport airportDestination) : base(airportStart.Position, airportDestination.Position, kmPerSecond) 
        {
            m_airportStart = airportStart;
            m_airportDestination = airportDestination;
        }

        /// <summary>
        /// flies during the alotted inteval and returns the remaining time to complete the task
        /// </summary>
        /// <param name="interval">interval of time to complete the task in seconds</param>
        /// <returns>the remaining time</returns>
        public override int tick(int interval)
        {
            m_totalTime += interval;

            double xTotalFinished = m_positionEnd.X - m_positionStart.X;
            double yTotalFinished = m_positionEnd.Y - m_positionStart.Y;

            double totalDistance = Math.Sqrt(Math.Pow(xTotalFinished, 2) + Math.Pow(yTotalFinished, 2));

            // Divide by 200
            double totalTraveled = m_totalTime * m_kmPerSecond / 200;

            double xTotalTraveled = totalTraveled * (xTotalFinished / totalDistance);
            double yTotalTraveled = totalTraveled * (yTotalFinished / totalDistance);

            m_positionActuel.X = (int)(xTotalTraveled + m_positionStart.X);
            m_positionActuel.Y = (int)(yTotalTraveled + m_positionStart.Y);

            if (totalTraveled >= totalDistance)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// changes the airport that the state uses as a destination
        /// </summary>
        /// <param name="aircraft">the parent aircraft</param>
        public override void changeAirportDestination(Aircraft aircraft)
        {
            if (m_airportDestination != null)
            {
                m_airportDestination.Aircrafts.Add(aircraft);

                m_airportStart.Aircrafts.Remove(aircraft);
            }
        }
    }
}
