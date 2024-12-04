using Simulator.Client;
using Simulator.Client.clientWithPositions;
using Simulator.Client.transportableClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    /// <summary>
    /// Create client
    /// </summary>
    public class ClientFactory
    {
        /// <summary>
        /// Client factory object singleton.
        /// </summary>
        private static readonly ClientFactory m_instance = new ClientFactory();

        /// <summary>
        /// Private constructor.
        /// </summary>
        private ClientFactory() { }

        /// <summary>
        /// Access to client factory.
        /// </summary>
        public static ClientFactory Instance
        {
            get { return m_instance; }
        }

        /// <summary>
        /// Create a client to tranport.
        /// </summary>
        /// <param name="airportDestination">Airprot destination</param>
        /// <param name="indexType">0 cargo, 1 passenger</param>
        /// <returns>Created client.</returns>
        public TransportableClients createTransportableClients(Airport airportDestination, int indexType = -1)
        {
            if (indexType < 1 || indexType > 1)
            {
                Random rand = new Random(); // Random
                indexType = rand.Next(1, 13); // client type
            }

            switch (indexType)
            {
                case 0:
                    return new Cargo(airportDestination);
                case 1:
                    return new Passenger(airportDestination);
                default:
                    return new Cargo(airportDestination);
            }
        }

        /// <summary>
        /// Create a client with a position.
        /// </summary>
        /// <param name="airportDestination">Airprot destination</param>
        /// <param name="indexType">0 fire, 1 observation, 2 rescue</param>
        /// <returns>Created client.</returns>
        public ClientsWithPositions createClientsWithPositions(int x, int y, int indexType = -1)
        {
            if (indexType < 1 || indexType > 2)
            {
                Random rand = new Random(); // Random
                indexType = rand.Next(1, 13); // client type
            }

            switch (indexType)
            {
                case 0:
                    return new Fire(x, y);
                case 1:
                    return new Observation(x, y);
                case 2:
                    return new Rescue(x, y);
                default:
                    return new Fire(x, y);
            }
        }

        /// <summary>
        /// Create a fire.
        /// </summary>
        /// <param name="x">Position on axe x</param>
        /// <param name="y">Position on axe y</param>
        /// <returns>Fire</returns>
        public ClientsWithPositions createFireClient(int x, int y)
        {
            return new Fire(x, y);
        }

        /// <summary>
        /// Create an observation client.
        /// </summary>
        /// <param name="x">Position on axe x</param>
        /// <param name="y">Position on axe y</param>
        /// <returns>Observation client</returns>
        public ClientsWithPositions createObservationClient(int x, int y)
        {
            return new Observation(x, y);
        }

        /// <summary>
        /// Create a client to rescue.
        /// </summary>
        /// <param name="x">Position on axe x</param>
        /// <param name="y">Position on axe y</param>
        /// <returns>Rescue client</returns>
        public ClientsWithPositions createRescueClient(int x, int y)
        {
            return new Rescue(x, y);
        }
    }
}
