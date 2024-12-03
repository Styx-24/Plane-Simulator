using Simulator.Client.clientWithPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Rescue Helicopter extending the class "Aircraft".
    /// </summary>
    public class RescueHelicopter : Aircraft
    {
        /// <summary>
        /// Default empty constructor of a rescue helicopter.
        /// </summary>
        public RescueHelicopter() : base() { }

        /// <summary>
        /// Rescue helicopter constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        public RescueHelicopter(string name, int speed = 804, int maintains = 48420) : base(name, speed, maintains) { }

        /// <summary>
        /// Aircraft detail with name and current state.
        /// </summary>
        /// <returns>Aircreaft detail with name and current state.</returns>
        public override string ToString()
        {
            return Name + ",H," + getCurrentState().ToString();
        }

        /// <summary>
        /// True if it's a rescuer aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's a rescuer aircraft, false otherwise.</returns>
        public override bool isARescuer()
        {
            return true;
        }
    }
}
