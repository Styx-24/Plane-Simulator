using Simulator.aircraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.states
{
    /// <summary>
    /// the unboarding state
    /// </summary>
    public class UnBoarding : State
    {
        /// <summary>
        /// time left to unboard all clients
        /// </summary>
        private int m_timeRemaining;

        /// <summary>
        /// constructor for the unboarding state
        /// </summary>
        /// <param name="numberClients">number of clients to unboard</param>
        /// <param name="secondPerClient">unboarding speed</param>
        public UnBoarding(int numberClients, int secondPerClient)
        {
            m_timeRemaining = secondPerClient / numberClients;
        }

        /// <summary>
        /// unboards all clients within the interval given then returns the remaining time
        /// </summary>
        /// <param name="interval">the interval to unboard all clients</param>
        /// <returns>the remaining time</returns>
        public override int tick(int interval)
        {
            m_timeRemaining -= interval;

            if (m_timeRemaining > 0)
            {
                return 0;
            }
            else
            {
                if (m_timeRemaining > 0)
                {
                    return m_timeRemaining * -1;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// returns a serialized string of the state
        /// </summary>
        /// <returns>serialized string of the state</returns>
        public override string ToString()
        {
            return "(Unboarding)";
        }
    }
}
