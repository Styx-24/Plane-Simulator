using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator.aircraft.marchandise
{
    /// <summary>
    /// Passenger plane extending the class "Marchandise".
    /// </summary>
    public class PassengerPlane : MarchandisePlane
    {
        /// <summary>
        /// Default empty constructor of a passenger plane.
        /// </summary>
        public PassengerPlane() : base() {}

        /// <summary>
        /// Passenger plane constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        public PassengerPlane(string name, int speed = 804, int maintains = 48420, int boarding = 60, int unboarding = 60) : base(name, speed, maintains, boarding, unboarding)
        {
        }
    }
}
