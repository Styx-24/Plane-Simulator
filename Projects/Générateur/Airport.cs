using Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generator
{
    /// <summary>
    /// Airplane with the aircrafts.
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// Airport position
        /// </summary>
        private Position m_position;
        /// <summary>
        /// Airport name
        /// </summary>
        private string m_name;
        /// <summary>
        /// Number minimum passenger
        /// </summary>
        private int m_passengerMin;
        /// <summary>
        /// Number maximum passenger
        /// </summary>
        private int m_passengerMax;
        /// <summary>
        /// Number minimum cargo
        /// </summary>
        private int m_cargoMin;
        /// <summary>
        /// Number maximum cargo
        /// </summary>
        private int m_cargoMax;
        /// <summary>
        /// List of aircrafts
        /// </summary>
        private List<Aircraft> m_aircraftList;

        /// <summary>
        /// Empty airport constructor
        /// </summary>
        public Airport()
        {
            Name = "Default";
            setPosition("0,0");
            PassengerMin = 0;
            PassengerMax = 0;
            CargoMin = 0;
            CargoMax = 0;
        }

        /// <summary>
        /// Airport constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="position">Position</param>
        /// <param name="passengerMin">Number minimum passenger</param>
        /// <param name="passengerMax">Number maximum passenger</param>
        /// <param name="cargoMin">Number minimum cargo</param>
        /// <param name="cargoMax">Number maximum cargo</param>
        public Airport(string name, string position, int passengerMin,
            int passengerMax, int cargoMin, int cargoMax) 
        { 
            Name = name;
            setPosition(position);
            PassengerMin = (passengerMin);
            PassengerMax = (passengerMax);
            CargoMin = (cargoMin);
            CargoMax = (cargoMax);
        }

        /// <summary>
        /// Airport name
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
            set 
            { 
                if (value != null)
                {
                    m_name = value;
                }    
            }
        }

        /// <summary>
        /// Airport position
        /// </summary>
        public Position Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        /// <summary>
        /// Set position airport.
        /// </summary>
        /// <param name="position">Position</param>
        public void setPosition(string position)
        {
            if (m_position == null)
            {
                m_position = new Position();
            }

            m_position.setString(position);
        }

        /// <summary>
        /// Get position airport.
        /// </summary>
        /// <returns>Position airport.</returns>
        public string getPosition()
        {
            if (m_position != null)
            {
                m_position = new Position();
            }
            return m_position.getString();
        }

        /// <summary>
        /// Number minimum passenger
        /// </summary>
        public int PassengerMin
        {
            get { return m_passengerMin; }
            set { m_passengerMin = value; }
        }

        /// <summary>
        /// Number maximum passenger
        /// </summary>
        public int PassengerMax
        {
            get { return m_passengerMax; }
            set { m_passengerMax = value; }
        }

        /// <summary>
        /// Number minimum cargo
        /// </summary>
        public int CargoMin
        {
            get { return m_cargoMin; }
            set { m_cargoMin = value; }
        }

        /// <summary>
        /// Number maximum cargo
        /// </summary>
        public int CargoMax
        {
            get { return m_cargoMax; }
            set { m_cargoMax = value; }
        }

        /// <summary>
        /// Aircraft list of the airport.
        /// </summary>
        public List<Aircraft> Aircrafts
        {
            get
            {
                if (m_aircraftList == null)
                {
                    m_aircraftList = new List<Aircraft>();
                }

                return m_aircraftList;
            }

            set { m_aircraftList = value; }
        }

        /// <summary>
        /// Valid if the airplane can be create, if so it is.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="typePlane">Type of plane by index</param>
        /// <param name="speed">Speed of the airplane</param>
        /// <param name="maintains">Time to maintains</param>
        /// <ssparam name="boarding">Time for boarding</param>
        /// <param name="droping">Time for droping</param>
        /// <returns>Error message if there is.</returns>
        public string addAircraft(string name, int typePlane,int speed = 804, int maintains = 48420, int boarding = 60, int unboarding = 60)
        {
            string errorMessage = Airport.areAircraftParametersValid(speed, maintains, boarding, unboarding); // Error message

            if (!errorMessage.Equals(""))
            {
                return errorMessage;
            }

            Aircrafts.Add(AircraftFactory.Instance.CreatePlane(name, typePlane, speed, maintains, boarding, unboarding));

            return "";
        }

        /// <summary>
        /// Valid if the parameters are valid for an airport.
        /// </summary>
        /// <param name="passengerMin">Number minimum passenger</param>
        /// <param name="passengerMax">Number maximum passenger</param>
        /// <param name="cargoMin">Number minimum cargo</param>
        /// <param name="cargoMax">Number maximum cargo</param>
        /// <returns>Error message if there is.</returns>
        public static string areParametersValid(String position, int passengerMin, int passengerMax, int cargoMin, int cargoMax)
        {
            if (passengerMin < 1)
            {
                return "The amount minimum of passenger must be 1.";
            }
            else if(passengerMax < passengerMin)
            {
                return "The amount of minimum passenger must be smaller than the number of" +
                    " maximum passenger.";
            }
            else if (cargoMin < 1)
            {
                return "The amount minimum of cargo must be 1.";
            }
            else if (cargoMax < cargoMin)
            {
                return "The amount of minimum cargo must be smaller than the number of" +
                    " maximum cargo.";
            }
            else if (!Position.isValid(position))
            {
                return "The position isn't a valid format.";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Valid if the parameters are valid for an airrcraft.
        /// </summary>
        /// <param name="speed">Aircraft speed</param>
        /// <param name="maintains">Maintains time</param>
        /// <param name="boarding">Boarding time</param>
        /// <param name="unboarding">Unboarding time</param>
        /// <returns></returns>
        public static string areAircraftParametersValid(int speed, int maintains, int boarding, int unboarding)
        {
            return Aircraft.areParametersValid(speed, maintains, boarding, unboarding);
        }
    }
}
