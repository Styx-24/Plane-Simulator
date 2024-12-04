using Simulator.aircraft.marchandise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulator.aircraft
{
    [XmlInclude(typeof(CargoPlane))]
    [XmlInclude(typeof(PassengerPlane))]

    /// <summary>
    /// Marchandise plane extending the class "Aircraft".
    /// </summary>
    public abstract class MarchandisePlane : Aircraft
    {
        /// <summary>
        /// Time for boarding
        /// </summary>
        private int m_boarding;
        /// <summary>
        /// Time for unboarding
        /// </summary>
        private int m_unboarding;

        protected int m_nbOfClients;

        /// <summary>
        /// Default empty constructor of a marchandise plane
        /// </summary>
        public MarchandisePlane() : base() 
        {
            Boarding = 60;
            UnBoarding = 60;
        }

        /// <summary>
        /// Marchandise plane constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        public MarchandisePlane(string name, int speed = 804, int maintains = 48420, int boarding = 60, int unboarding = 60) : base(name, speed, maintains) 
        { 
            Boarding = boarding;
            UnBoarding = unboarding;
        }

        /// <summary>
        /// Property boarding time.
        /// </summary>
        public int Boarding 
        { 
            get { return m_boarding; } 
            set { m_boarding = value; } 
        }

        /// <summary>
        /// Property unboarding time.
        /// </summary>
        public int UnBoarding
        {
            get { return m_unboarding; }
            set { m_unboarding = value; }
        }

        /// <summary>
        /// Aircraft detail with name and current state.
        /// </summary>
        /// <returns>Aircreaft detail with name and current state.</returns>
        public override string ToString()
        {
            return Name + ",P," + getCurrentState().ToString();
        }
    }
}
