using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{

    /// <summary>
    /// the base for all state classes that initialises the total time and base position
    /// </summary>
    public abstract class State
    {

        /// <summary>
        /// total time to complete task
        /// </summary>
        protected int m_totalTime;

        /// <summary>
        /// current position
        /// </summary>
        protected Position m_position;
       
        /// <summary>
        /// base constructor for states
        /// </summary>
        public State() 
        {
            m_totalTime = 0;
        }

        /// <summary>
        /// does the task the state is designed to do during the interval time and then returns the remaining time
        /// </summary>
        /// <param name="interval">interval of time to execute the task in seconds</param>
        /// <returns>the time remaining to complete the task in seconds</returns>
        public abstract int tick(int interval);

        /// <summary>
        /// returns if there is already a task running
        /// </summary>
        /// <returns>if there is already a task running</returns>
        public virtual bool isAvailable()
        {
            return false;
        }

        /// <summary>
        /// changes the airport that the state uses as a destination
        /// </summary>
        /// <param name="aircraft">the parent aircraft</param>
        public virtual void changeAirportDestination(Aircraft aircraft)
        {
        }

        /// <summary>
        /// returns a serialized string of the state
        /// </summary>
        /// <returns>serialized string of the state</returns>
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// property of the current position
        /// </summary>
        public Position? Position
        {
            get
            {
                if (m_position == null)
                {
                    return null;
                }

                return m_position;
            }

            set
            {
                if (value == null)
                {
                    m_position = value;
                }
            }
        }
    }
}
