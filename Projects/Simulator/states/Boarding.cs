using Simulator.aircraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.states
{
    /// <summary>
    /// the boarding state
    /// </summary>
    public class Boarding : State
    {
        /// <summary>
        /// time left to board all clients
        /// </summary>
        private int m_timeRemaining;

        /// <summary>
        /// constructor for the boarding state
        /// </summary>
        /// <param name="numberClients">number of clients to board</param>
        /// <param name="secondPerClient">boarding speed</param>
        public Boarding(int numberClients, int secondPerClient)
        {
            m_timeRemaining = secondPerClient / numberClients;
        }

        /// <summary>
        /// boards all clients within the interval given then returns the remaining time
        /// </summary>
        /// <param name="interval">the interval to board all clients</param>
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
            return "(Boarding)";
        }
    }
}
