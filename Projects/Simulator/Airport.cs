using Simulator;
using Simulator.aircraft;
using Simulator.Client;
using Simulator.Client.clientWithPositions;
using Simulator.Client.transportableClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulator
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
        /// List of cargos
        /// </summary>
        private List<TransportableClients> m_cargoList;
        /// <summary>
        /// List of clients
        /// </summary>
        private List<TransportableClients> m_passengerList;

        /// <summary>
        /// Queue of the fires to assign.
        /// </summary>
        private Queue<ClientsWithPositions> m_fires;
        /// <summary>
        /// Queue of the hurted clients to assign.
        /// </summary>
        private Queue<ClientsWithPositions> m_rescueClients;
        /// <summary>
        /// Queue of the observe clients to assign.
        /// </summary>
        private Queue<ClientsWithPositions> m_observeClients;

        /// <summary>
        /// True if the airport has firefigther aircraft, false otherwise.
        /// </summary>
        private bool m_hasFireFighter;
        /// <summary>x
        /// True if the airport has rescuer aircraft, false otherwise.
        /// </summary>
        private bool m_hasRescuer;
        /// <summary>
        /// True if the airport has observer aircraft, false otherwise.
        /// </summary>
        private bool m_hasObserver;

        /// <summary>
        /// Specials clients with a positions assgined
        /// </summary>
        private List<ClientsWithPositions> m_clientsWithPositionsAssigned;

        /// <summary>
        /// Propriety list of clients to rescue.
        /// </summary>
        [XmlIgnore]
        public List<ClientsWithPositions> ClientsWithPositionsAssigned
        {
            get
            {
                if (m_clientsWithPositionsAssigned == null)
                {
                    m_clientsWithPositionsAssigned = new List<ClientsWithPositions>();
                }

                return m_clientsWithPositionsAssigned;
            }

            set { m_clientsWithPositionsAssigned = value; }
        }

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
        /// Propriety list of cargos.
        /// </summary>
        public List<TransportableClients> Cargos
        {
            get
            {
                if (m_cargoList == null)
                {
                    m_cargoList = new List<TransportableClients>();
                }

                return m_cargoList;
            }

            set { m_cargoList = value; }
        }

        /// <summary>
        /// Propriety list of passengers.
        /// </summary>
        [XmlIgnore]
        public List<TransportableClients> Passengers
        {
            get
            {
                if (m_passengerList == null)
                {
                    m_passengerList = new List<TransportableClients>();
                }

                return m_passengerList;
            }

            set { m_passengerList = value; }
        }

        /// <summary>
        /// Propriety queue of fires.
        /// </summary>
        [XmlIgnore]
        public Queue<ClientsWithPositions> Fires
        {
            get
            {
                if (m_fires == null)
                {
                    m_fires = new Queue<ClientsWithPositions>();
                }

                return m_fires;
            }

            set { m_fires = value; }
        }

        /// <summary>
        /// Propriety queue of clients to rescue.
        /// </summary>
        [XmlIgnore]
        public Queue<ClientsWithPositions> RescueClients
        {
            get
            {
                if (m_rescueClients == null)
                {
                    m_rescueClients = new Queue<ClientsWithPositions>();
                }

                return m_rescueClients;
            }

            set { m_rescueClients = value; }
        }

        /// <summary>
        /// Propriety queue of observable clients.
        /// </summary>
        [XmlIgnore]
        public Queue<ClientsWithPositions> ObserveClients
        {
            get
            {
                if (m_observeClients == null)
                {
                    m_observeClients = new Queue<ClientsWithPositions>();
                }

                return m_observeClients;
            }

            set { m_observeClients = value; }
        }

        /// <summary>
        /// Property true if the airport has firefigther aircraft, false otherwise.
        /// </summary>
        [XmlIgnore]
        public bool HasFireFighter
        {
            get { return m_hasFireFighter; }
            set { m_hasFireFighter = value; }
        }

        /// <summary>
        /// Property true if the airport has rescuer aircraft, false otherwise.
        /// </summary>
        [XmlIgnore]
        public bool HasRescuer
        {
            get { return m_hasRescuer; }
            set { m_hasRescuer = value; }
        }

        /// <summary>
        /// Property true if the airport has observer aircraft, false otherwise.
        /// </summary>
        [XmlIgnore]
        public bool HasObserver
        {
            get { return m_hasObserver; }
            set { m_hasObserver = value; }
        }

        /// <summary>
        /// Get list aircraft serials.
        /// </summary>
        /// <returns>List of aircraft serial.</returns>
        public List<string> getAircraftSerials()
        {
            List<string> serials = new List<string>(); // Aircraft Serial

            foreach (Aircraft aircraft in Aircrafts)
            {
                serials.Add(aircraft.ToString());
            }

            return serials;
        }

        /// <summary>
        /// Tick loop of time progression of the simulation.
        /// </summary>
        /// <param name="interval">Progression in seconds</param>
        public void tick(int interval)
        {
            foreach (Aircraft aircraft in Aircrafts)
            {
                if (aircraft.isFree())
                {
                    assignClientToTask(aircraft);
                }
            }

            foreach(Aircraft aircraft in Aircrafts.ToList())
            {
                int timeLeft = aircraft.tick(interval); // Time left in seconds

                if (aircraft.isFree() && timeLeft > 0)
                {
                    assignClientToTask(aircraft, timeLeft);
                }
            }
        }

        /// <summary>
        /// Set the types of the clients with positiosn that the airport can take care.
        /// </summary>
        public void setTypesCaretakerClientsWithPositions()
        {
            foreach (Aircraft aircraft in Aircrafts)
            {
                if (aircraft.isFirefighter())
                {
                    HasFireFighter = true;
                }
                else if (aircraft.isAnObserver())
                {
                    HasObserver = true;
                }
                else if (aircraft.isARescuer())
                {
                    HasRescuer = true;
                }
            }
        }

        /// <summary>
        /// Get the serials, ToString(), of all the clients for each airports.
        /// </summary>
        /// <returns>List of the serials of all the clients.</returns>
        public List<string> getSerialsClientsWithPositions()
        {
            List<String> clientsInfos = new List<string>(); // List of the clients infos

            foreach (ClientsWithPositions fire in Fires)
            { clientsInfos.Add(fire.ToString());}

            foreach (ClientsWithPositions observation in ObserveClients)
            { clientsInfos.Add(observation.ToString());}

            foreach (ClientsWithPositions rescue in RescueClients)
            { clientsInfos.Add(rescue.ToString());  }

            for (int i = ClientsWithPositionsAssigned.Count() - 1; -1 < i; i--)
            {
                if (ClientsWithPositionsAssigned[i].mustBeDispose())
                {
                    ClientsWithPositionsAssigned.RemoveAt(i);
                }
                else
                {
                    clientsInfos.Add(ClientsWithPositionsAssigned[i].ToString());
                }
            }

            return clientsInfos;
        }

        /// <summary>
        /// Assign the clients to an aircraft if their types is compatible.
        /// </summary>
        /// <param name="aircraft">aircraft to assigns the taks</param>
        /// <param name="interval">Interval of time to progress</param>
        public void assignClientToTask(Aircraft aircraft, int interval = 0)
        {
            if (aircraft.isHumansTransporter())
            {
                List<Airport> airportsDestination = new List<Airport>(); // List of the destination airports
                List<List<int>> clientToAirport = new List<List<int>>(); // List of the clients passengers

                for (int i = 0; i < Passengers.Count(); i++)
                {
                    int index = -1;
                    for (int j = 0; j < airportsDestination.Count; j++)
                    {
                        if (airportsDestination[j] == Passengers[i].AirportDestination)
                        {
                            index = j;
                            break;
                        }
                    }


                    if (index == -1)
                    {
                        airportsDestination.Add(Passengers[i].AirportDestination);
                        clientToAirport.Add(new List<int> { i });
                    }
                    else
                    {
                        clientToAirport[index].Add(i);
                    }
                }

                int indexToProcess = 0; // Index of the first group of client big enough for an aircraft
                while (indexToProcess < clientToAirport.Count() && clientToAirport[indexToProcess].Count() < 20)
                {
                    indexToProcess++;
                }

                if (indexToProcess < clientToAirport.Count())
                {
                    int passengersTaken = 0; // Total of clients to attribute
                    Airport airportDestination = airportsDestination[indexToProcess];

                    for (int i = (clientToAirport[indexToProcess].Count() - 1); i > -1 && passengersTaken < 70; i--)
                    {
                        passengersTaken++;
                        Passengers.RemoveAt(clientToAirport[indexToProcess][i]);
                    }

                    Queue<State> aircraftWork = new Queue<State>(); // Queue states
                    aircraftWork.Enqueue(StatesFactory.Instance.createBoarding(passengersTaken, ((MarchandisePlane)aircraft).Boarding));
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(aircraft.Speed, this, airportDestination));
                    aircraftWork.Enqueue(StatesFactory.Instance.createUnBoarding(passengersTaken, ((MarchandisePlane)aircraft).UnBoarding));
                    aircraftWork.Enqueue(StatesFactory.Instance.createMaintenance(aircraft.Maintains));
                    aircraftWork.Enqueue(StatesFactory.Instance.createWait());

                    aircraft.States = aircraftWork;

                    if (interval > 0)
                    {
                        aircraft.tick(interval);
                    }
                }

            }
            else if (aircraft.isCargoTransporter())
            {
                List<Airport> airportsDestination = new List<Airport>(); // List of the destination airports
                List<List<int>> clientToAirport = new List<List<int>>(); // List of the clients passengers

                for (int i = 0; i < Cargos.Count(); i++)
                {
                    int index = -1; // Index
                    for (int j = 0; j < airportsDestination.Count; j++)
                    {
                        if (airportsDestination[j] == Cargos[i].AirportDestination)
                        {
                            index = j;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        airportsDestination.Add(Cargos[i].AirportDestination);
                        clientToAirport.Add(new List<int> { i });
                    }
                    else
                    {
                        clientToAirport[index].Add(i);
                    }
                }

                int indexToProcess = 0; // Index of the first group of client big enough for an aircraft
                while (indexToProcess < clientToAirport.Count() && clientToAirport[indexToProcess].Count() < 20)
                {
                    indexToProcess++;
                }

                if (indexToProcess < clientToAirport.Count())
                {
                    int cargosTaken = 0; // Total of clients to attribute
                    Airport airportDestination = airportsDestination[indexToProcess];

                    for (int i = (clientToAirport[indexToProcess].Count() - 1); i > -1 && cargosTaken < 70; i--)
                    {
                        cargosTaken++;
                        Cargos.RemoveAt(clientToAirport[indexToProcess][i]);
                    }

                    Queue<State> aircraftWork = new Queue<State>(); // Queue states
                    aircraftWork.Enqueue(StatesFactory.Instance.createBoarding(cargosTaken, ((MarchandisePlane)aircraft).Boarding));
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(aircraft.Speed, this, airportDestination));
                    aircraftWork.Enqueue(StatesFactory.Instance.createUnBoarding(cargosTaken, ((MarchandisePlane)aircraft).UnBoarding));
                    aircraftWork.Enqueue(StatesFactory.Instance.createMaintenance(aircraft.Maintains));
                    aircraftWork.Enqueue(StatesFactory.Instance.createWait());

                    aircraft.States = aircraftWork;

                    if (interval > 0)
                    {
                        aircraft.tick(interval);
                    }
                }
            }
            else if (aircraft.isFirefighter())
            {
                if (Fires.Count > 0)
                {
                    Queue<State> aircraftWork = new Queue<State>(); // Queue states
                    aircraftWork.Enqueue(StatesFactory.Instance.createFireFight((Fire)Fires.Peek(), Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createMaintenance(aircraft.Maintains));
                    aircraftWork.Enqueue(StatesFactory.Instance.createWait());

                    ClientsWithPositionsAssigned.Add(Fires.Dequeue());

                    aircraft.States = aircraftWork;

                    if (interval > 0)
                    {
                        aircraft.tick(interval);
                    }
                }
            }
            else if (aircraft.isAnObserver())
            {
                if (ObserveClients.Count > 0)
                {
                    Queue<State> aircraftWork = new Queue<State>(); // Queue states
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(Position, ObserveClients.Peek().Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createHover((Observation)ObserveClients.Peek(), Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(ObserveClients.Peek().Position, Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createMaintenance(aircraft.Maintains));
                    aircraftWork.Enqueue(StatesFactory.Instance.createWait());

                    ClientsWithPositionsAssigned.Add(ObserveClients.Dequeue());

                    aircraft.States = aircraftWork;

                    if (interval > 0)
                    {
                        aircraft.tick(interval);
                    }
                }
            }
            else if (aircraft.isARescuer())
            {
                if (RescueClients.Count > 0)
                {
                    Queue<State> aircraftWork = new Queue<State>(); // Queue states
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(Position, RescueClients.Peek().Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createRescuing((Rescue)RescueClients.Peek()));
                    aircraftWork.Enqueue(StatesFactory.Instance.createFlight(RescueClients.Peek().Position, Position, aircraft.Speed));
                    aircraftWork.Enqueue(StatesFactory.Instance.createMaintenance(aircraft.Maintains));
                    aircraftWork.Enqueue(StatesFactory.Instance.createWait());

                    ClientsWithPositionsAssigned.Add(RescueClients.Dequeue());

                    aircraft.States = aircraftWork;

                    if (interval > 0)
                    {
                        aircraft.tick(interval);
                    }
                }
            }
        }
    }
}
