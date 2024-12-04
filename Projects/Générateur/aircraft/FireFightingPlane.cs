
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.aircraft
{
    /// <summary>
    /// Fire fighting plane extending the class "Aircraft".
    /// </summary>
    public class FireFightingPlane : Aircraft
    {
        /// <summary>
        /// Default empty constructor of a fire fighting plane.
        /// </summary>
        public FireFightingPlane() : base() { }

        /// <summary>
        /// Fire fighting plane constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        public FireFightingPlane(string name, int speed = 804, int maintains = 48420) : base(name, speed, maintains) {}
    }
}
