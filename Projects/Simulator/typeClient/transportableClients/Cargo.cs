using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client.transportableClients
{
    /// <summary>
    /// Cargo client.
    /// </summary>
    public class Cargo : TransportableClients
    {
        /// <summary>
        /// Initialise a client with a destination.
        /// </summary>
        /// <param name="airportDestination">Destination airport.</param>
        public Cargo(Airport airport) : base(airport) {}
    }
}
