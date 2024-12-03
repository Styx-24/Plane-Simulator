using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.aircraft
{
    /// <summary>
    /// Private jet extending the class "Aircraft".
    /// </summary>
    public class PrivateJet : Aircraft
    {
        /// <summary>
        /// Default empty constructor of a private jet.
        /// </summary>
        public PrivateJet() : base() {}

        /// <summary>
        /// Private jet constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        public PrivateJet(string name, int speed = 804, int maintains = 48420) : base(name, speed, maintains) 
        {
        }

        /// <summary>
        /// Aircraft detail with name and current state.
        /// </summary>
        /// <returns>Aircreaft detail with name and current state.</returns>
        public override string ToString()
        {
            return Name + ",J," + getCurrentState().ToString();
        }

        /// <summary>
        /// True if it's an observer aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's an observer aircraft, false otherwise.</returns>
        public override bool isAnObserver()
        {
            return true;
        }
    }
}
