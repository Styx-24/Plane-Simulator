using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// the wait state that the aircrafts use when they are not yet assigned
    /// </summary>
    public class Wait : State
    {

        /// <summary>
        /// constructor of the wait status
        /// </summary>
        public Wait():base() { }

        /// <summary>
        /// does nothing because it has not been assigned yet
        /// </summary>
        /// <param name="interval">interval of time to execute the task in seconds</param>
        /// <returns>the remaing time</returns>
        public override int tick(int interval)
        {
            return interval;
        }

        /// <summary>
        /// returns if there is already a task running
        /// </summary>
        /// <returns>if there is already a task running</returns>
        public override bool isAvailable()
        {
            return true;
        }

        /// <summary>
        /// returns a serialized string of the state
        /// </summary>
        /// <returns>serialized string of the state</returns>
        public override string ToString()
        {
            return "(Waiting)";
        }
    }
}
