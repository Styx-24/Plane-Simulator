using Simulator.aircraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulator
{
    [XmlInclude(typeof(FireFightingPlane))]
    [XmlInclude(typeof(MarchandisePlane))]
    [XmlInclude(typeof(PrivateJet))]
    [XmlInclude(typeof(RescueHelicopter))]

    /// <summary>
    /// Aircraft class
    /// </summary>
    public abstract class Aircraft
    {
        /// <summary>
        /// Name of the aircraft
        /// </summary>
        private string m_name;
        /// <summary>
        /// Speed of the aircraft
        /// </summary>
        private int m_speed;
        /// <summary>
        /// Time of maintains
        /// </summary>
        private int m_maintains;

        /// <summary>
        /// List of state
        /// </summary>
        protected Queue<State> m_listState;

        /// <summary>
        /// Default empty constructor of an aircraft
        /// </summary>
        public Aircraft()
        {
            Name = "Default";
            Speed = 804;
            Maintains = 48420;
            m_listState = new Queue<State>();
            m_listState.Enqueue(new Wait());
        }

        /// <summary>
        /// Aircraft constructor.
        /// </summary>
        /// <param name="name">Aircraft name</param>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        public Aircraft(string name, int speed = 804, int maintains = 48420)
        {
            Name = name;
            Speed = speed;
            Maintains = maintains;
            m_listState = new Queue<State>();
            m_listState.Enqueue(new Wait());
        }

        /// <summary>
        /// Property aircraft name.
        /// </summary>
        public string Name
        {
            get
            {
                if (m_name == null)
                {
                    return "";
                }

                return m_name;
            }
            set { m_name = value; }
        }

        /// <summary>
        /// Property aircraft speed.
        /// </summary>
        public int Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        /// <summary>
        /// Property maintains time.
        /// </summary>
        public int Maintains
        {
            get { return m_maintains; }
            set { m_maintains = value; }
        }

        /// <summary>
        /// Property list of state
        /// </summary>
        [XmlIgnore]
        public Queue<State> States
        {
            get { return m_listState; }
            set { m_listState = value; }
        }

        /// <summary>
        /// Tick states progression.
        /// </summary>
        /// <param name="interval">Second of progression.</param>
        /// <returns>Remaining seconds</returns>
        public int tick(int interval)
        {
            int timeLeft = interval; // Time left

            do
            {
                timeLeft = getCurrentState().tick(timeLeft);

                if (timeLeft > 0 && !getCurrentState().isAvailable() || timeLeft == -1)
                {
                    getCurrentState().changeAirportDestination(this);
                    m_listState.Dequeue();
                }

            } while (timeLeft > 0 && !getCurrentState().isAvailable());

            return timeLeft;
        }

        /// <summary>
        /// Get current state.
        /// </summary>
        /// <returns>Current state.</returns>
        public State getCurrentState()
        {
            return m_listState.First();
        }

        /// <summary>
        /// True if the aircraft is available, false otherwise.
        /// </summary>
        /// <returns>True if the aircraft is available, false otherwise</returns>
        public bool isFree()
        {
            return getCurrentState().isAvailable();
        }

        /// <summary>
        /// True if it's a firefigther aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's a firefigther aircraft, false otherwise.</returns>
        public virtual bool isFirefighter()
        {
            return false;
        }

        /// <summary>
        /// True if it's an observer aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's an observer aircraft, false otherwise.</returns>
        public virtual bool isAnObserver()
        {
            return false;
        }

        /// <summary>
        /// True if it's a rescuer aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's a rescuer aircraft, false otherwise.</returns>
        public virtual bool isARescuer()
        {
            return false;
        }

        /// <summary>
        /// True if it's a cargo transporter aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's a cargo transporter aircraft, false otherwise.</returns>
        public virtual bool isCargoTransporter()
        {
            return false;
        }

        /// <summary>
        /// True if it's a humans transporter aircraft, false otherwise.
        /// </summary>
        /// <returns>True if it's a humans transporter aircraft, false otherwise.</returns>
        public virtual bool isHumansTransporter()
        {
            return false;
        }

        /// <summary>
        /// Compare to an object to see if it's the same by looking at the unique name.
        /// </summary>
        /// <param name="obj">Objet to compare.</param>
        /// <returns>True if it's the same, false otherwise.</returns>
        public override bool Equals(Object obj)
        {
            return obj is Aircraft aircraft && Name.Equals(aircraft.Name);
        }

        /// <summary>
        /// Aircraft detail with name and current state.
        /// </summary>
        /// <returns>Aircreaft detail with name and current state.</returns>
        public override string ToString()
        {
            return Name + " " + getCurrentState().ToString();
        }
    }
}
