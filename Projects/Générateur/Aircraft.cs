using Generator.aircraft;
using Generator.aircraft.marchandise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Generator
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
        /// Default empty constructor of an aircraft
        /// </summary>
        public Aircraft() 
        {
            Name = "Default";
            Speed = 804;
            Maintains = 48420;
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
        /// Valid if the parameters are valid for an airport.
        /// </summary>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        /// <returns>Error message if there is.</returns>
        public static string areParametersValid(int speed, int maintains, int boarding, int unboarding)
        {
            if (speed <= 0) 
            {
                return "The speed must be at least 1.";
            }
            else if (maintains <= 0)
            {
                return "The maintains time must be at least 1.";
            }
            else if (boarding <= 0)
            {
                return "The boarding time must be at least 1.";
            }
            else if (unboarding <= 0)
            {
                return "The unboarding time must be at least 1.";
            }
            else
            {
                return "";
            }
        }
    }
}
