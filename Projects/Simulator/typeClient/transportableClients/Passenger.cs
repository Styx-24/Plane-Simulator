using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client.transportableClients
{
    /// <summary>
    /// Passenger client.
    /// </summary>
    public class Passenger : TransportableClients
    {
        /// <summary>
        /// Initialise a client with a destination.
        /// </summary>
        /// <param name="airportDestination">Destination airport.</param>
        public Passenger(Airport airport) : base(airport) {}
    }
}
