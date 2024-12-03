using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client
{
    /// <summary>
    /// Client with a destination.
    /// </summary>
    public abstract class TransportableClients: Clients
    {
        /// <summary>
        /// Destination airports
        /// </summary>
        private Airport m_airportDestination;

        /// <summary>
        /// Initialise a client with a destination.
        /// </summary>
        /// <param name="airportDestination">Destination airport.</param>
        public TransportableClients(Airport airportDestination) 
        { 
            AirportDestination = airportDestination;
        }

        /// <summary>
        /// Airport destination.
        /// </summary>
        public Airport AirportDestination
        {
            get { return m_airportDestination; }
            set { m_airportDestination = value; }
        }
    }
}
