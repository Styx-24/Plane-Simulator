using Simulator.Client.clientWithPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.states
{
    /// <summary>
    /// the rescuing state
    /// </summary>
    public class Rescuing : StatusWithPositions
    {
        /// <summary>
        /// target to rescue
        /// </summary>
        private Rescue m_rescueClient;

        /// <summary>
        /// constructor of the rescue state
        /// </summary>
        /// <param name="rescueClient">target to rescue</param>
        public Rescuing(Rescue rescueClient) : base(rescueClient.Position) 
        { 
            m_rescueClient = rescueClient;
        }

        /// <summary>
        /// recues the target within the interval given then returns the remaining time
        /// </summary>
        /// <param name="interval"></param>
        /// <returns>remaining time</returns>
        public override int tick(int interval)
        {
            m_totalTime += interval;

            if (m_totalTime > 600)
            {
                hasBeenSaved();

                return m_totalTime - 600;
            }
            else if (m_totalTime == 600)
            {
                hasBeenSaved();

                return -1;
            }

            return 0;
        }

        /// <summary>
        /// sets the target "has been saved" flag to true
        /// </summary>
        private void hasBeenSaved()
        {
            m_rescueClient.IsRescued = true;
        }
    }
}
