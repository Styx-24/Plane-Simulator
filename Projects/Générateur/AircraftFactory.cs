using Generator.aircraft;
using Generator.aircraft.marchandise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    /// <summary>
    /// Singleton aircraft factory that create diffrent type of aircraft.
    /// </summary>
    public sealed class AircraftFactory
    {
        /// <summary>
        /// Aircraft factory object singleton.
        /// </summary>
        private static readonly AircraftFactory m_instance = new AircraftFactory();

        /// <summary>
        /// Private constructor.
        /// </summary>
        private AircraftFactory() {}

        /// <summary>
        /// Access to aircraft factory.
        /// </summary>
        public static AircraftFactory Instance 
        { 
            get { return m_instance; } 
        }

        /// <summary>
        /// Create an aircraft.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        /// <returns>The new aircraft.</returns>
        public Aircraft CreatePlane(string name, int typePlane, int speed = 804, int maintains = 48420, int boarding = 60, int unboarding = 60)
        {
            switch (typePlane)
            {
                case 0:
                    return new PassengerPlane(name, speed, maintains, boarding, unboarding);
                    break;
                case 1:
                    return new CargoPlane(name, speed, maintains, boarding, unboarding);
                    break;
                case 2:
                    return new RescueHelicopter(name, speed, maintains);
                    break;
                case 3:
                    return new PrivateJet(name, speed, maintains);
                    break;
                case 4:
                    return new FireFightingPlane(name, speed, maintains);
                    break;
                default:
                    return new PassengerPlane("Unusable", 0, 0, 0, 0);
                    break;
            }
        }
    }
}
