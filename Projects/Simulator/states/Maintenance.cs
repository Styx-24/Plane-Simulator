using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// the maintenance state
    /// </summary>
    public class Maintenance : State
    {
        /// <summary>
        /// time to complete the maintenance in seconds
        /// </summary>
        private int m_maintanceTime;

        /// <summary>
        /// constructor for the maintenance
        /// </summary>
        /// <param name="maintanceTime">time to complete the maintenance in seconds</param>
        public Maintenance(int maintanceTime) : base() 
        {
            m_maintanceTime = maintanceTime;
        }

        /// <summary>
        /// completes the maintenance during the alotted inteval and returns the remaining time to complete the task
        /// </summary>
        /// <param name="interval">interval of time to complete the task in seconds</param>
        /// <returns>the remaining time</returns>
        public override int tick(int interval)
        {
            m_totalTime += interval;

            if (m_totalTime < m_maintanceTime)
            {
                return 0;
            }
            else if (m_totalTime == m_maintanceTime)
            {
                return -1;
            }
            else
            {
                return m_totalTime - m_maintanceTime;
            }
        }

        /// <summary>
        /// returns a serialized string of the state
        /// </summary>
        /// <returns>serialized string of the state</returns>
        public override string ToString()
        {
            return "(Maintenance)";
        }
    }
}
