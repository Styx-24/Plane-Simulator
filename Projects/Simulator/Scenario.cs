using Simulator;
using Simulator.Client;
using Simulator.Client.clientWithPositions;
using Simulator.Client.transportableClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Simulator.Simulator;

namespace Simulator
{
    /// <summary>
    /// Scenario with the airports.
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// List of airport
        /// </summary>
        private List<Airport> m_airport;
        /// <summary>
        /// Clock
        /// </summary>
        private Clock m_clock;

        /// <summary>
        /// List of the non Assigned fire
        /// </summary>
        private List<ClientsWithPositions> m_nonAsignedFire;
        /// <summary>
        /// List of the non Assigned rescue clients
        /// </summary>
        private List<ClientsWithPositions> m_nonRescuedClient;
        /// <summary>
        /// List of the non Assigned observe clients
        /// </summary>
        private List<ClientsWithPositions> m_nonObservedClient;

        /// <summary>
        /// Agenda to generate rescue client
        /// </summary>
        private List<int> m_nextRescueTime;
        /// <summary>
        /// Agenda to generate fire client
        /// </summary>
        private List<int> m_nextFireTime;
        /// <summary>
        /// Agenda to generate observation client
        /// </summary>
        private List<int> m_nextObservationTime;
        /// <summary>
        /// Timer before the next next planing
        /// </summary>
        private int m_timeRemainingBeforePlaning;

        /// <summary>
        /// Constructor of the scenario. 
        /// </summary>
        public Scenario()
        {
            Airports = new List<Airport>();
            m_timeRemainingBeforePlaning = 0;
        }

        /// <summary>
        /// Property list airports.
        /// </summary>
        public List<Airport> Airports
        {
            get
            {
                if (m_airport == null)
                {
                    m_airport = new List<Airport>();
                }

                return m_airport;
            }
            set { m_airport = value; }
        }

        /// <summary>
        /// Scenario indexer to access an airport.
        /// </summary>
        /// <param name="index">Index of the airport.</param>
        /// <returns>The indexed airport in the scenario.</returns>
        public Airport this[int index]
        {
            get { return Airports[index]; }
            set { Airports[index] = value; }
        }

        /// <summary>
        /// Property of the non assigned fire.
        /// </summary>
        [XmlIgnore]
        public List<ClientsWithPositions> NonAsignedFire
        {
            get
            {
                if (m_nonAsignedFire == null)
                {
                    m_nonAsignedFire = new List<ClientsWithPositions>();
                }

                return m_nonAsignedFire;
            }

            set { m_nonAsignedFire = value; }
        }

        /// <summary>
        /// Property of the non assigned rescue clients.
        /// </summary>
        [XmlIgnore]
        public List<ClientsWithPositions> NonRescuedClients
        {
            get
            {
                if (m_nonRescuedClient == null)
                {
                    m_nonRescuedClient = new List<ClientsWithPositions>();
                }

                return m_nonRescuedClient;
            }

            set { m_nonRescuedClient = value; }
        }

        /// <summary>
        /// Property of the non assigned observe clients.
        /// </summary>
        [XmlIgnore]
        public List<ClientsWithPositions> NonObservedClients
        {
            get
            {
                if (m_nonObservedClient == null)
                {
                    m_nonObservedClient = new List<ClientsWithPositions>();
                }

                return m_nonObservedClient;
            }

            set { m_nonObservedClient = value; }
        }

        /// <summary>
        /// Start the simulation with the clock.
        /// </summary>
        /// <param name="tickDelegate"></param>
        public void startSimulator(TickDelegate tickDelegate)
        {
            foreach (Airport airport in Airports)
            {
                airport.setTypesCaretakerClientsWithPositions();
            }

            m_clock = new Clock(tickDelegate);
            m_clock.Start();
        }

        /// <summary>
        /// Increment the timer mulplicator.
        /// </summary>
        public void speedUp()
        {
            m_clock.speedUp();
        }

        /// <summary>
        /// Decrement the timer mulplicator.
        /// </summary>
        public void slowDown()
        {
            m_clock.speedDown();
        }

        /// <summary>
        /// Pause/Unpause the timer.
        /// </summary>
        public void pauseUnPause()
        {
            m_clock.PauseUnpause();
        }

        /// <summary>
        /// Get the interval time timer.
        /// </summary>
        /// <returns>Interval.</returns>
        public int getIntervalTime()
        {
            return m_clock.IntervalTime;
        }

        /// <summary>
        /// Get the clock time.
        /// </summary>
        /// <returns>The time in format HH:MM:SS.</returns>
        public string getTime()
        {
            return m_clock.getTime();
        }

        /// <summary>
        /// Tick loop scenario progression.
        /// </summary>
        /// <param name="interval">Interval of the progression in seconds.</param>
        public void tick(int interval)
        {
            foreach (Airport airport in Airports)
            {
                airport.tick(interval);
            }
        }

        /// <summary>
        /// Initialise the clients in airports
        /// </summary>
        public void initialiseClientsInAirport()
        {
            Random random = new Random(); // Random

            foreach (Airport airport in Airports)
            {
                int nbClients = random.Next(airport.PassengerMin, airport.PassengerMax + 1); // Number of clients
                for (int i = airport.Passengers.Count(); i < nbClients; i++)
                {
                    Airport airportDestination = getRandomAirport(airport);

                    airport.Passengers.Add(ClientFactory.Instance.createTransportableClients(airportDestination, 1));
                }

                nbClients = random.Next(airport.CargoMin, airport.CargoMax + 1);
                for (int i = airport.Cargos.Count(); i < nbClients; i++)
                {
                    Airport airportDestination = getRandomAirport(airport);

                    airport.Cargos.Add(ClientFactory.Instance.createTransportableClients(airportDestination, 0));
                }
            }
        }

        /// <summary>
        /// Get a random airport.
        /// </summary>
        /// <param name="excludeAirport">Airport to exclude</param>
        /// <returns>Random airport chose if there's at least two.</returns>
        private Airport getRandomAirport(Airport excludeAirport)
        {
            if (Airports.Count < 2)
            {
                return excludeAirport;
            }

            Random rnd = new Random(); // Random
            Airport randomAirport;
            do
            {
                int index = rnd.Next(Airports.Count); // Random airport index
                randomAirport = Airports[index];
            }
            while (randomAirport == excludeAirport);

            return randomAirport;
        }

        /// <summary>
        /// Generate clients with a position
        /// </summary>
        /// <param name="maxX">Maximum position on axe X</param>
        /// <param name="maxY">Maximum position on axe Y</param>
        public void generateClientsWithPositions(int maxX, int maxY)
        {
            int interval = getIntervalTime(); // Timer interval

            planingSpawnProgression(interval);

            // Fire
            if (m_nextFireTime.Count > 0 && m_nextFireTime[0] <= 0)
            {
                generateClient(0, maxX, maxY);
                m_nextFireTime.RemoveAt(0);
            }
            else if (m_nextFireTime.Count > 0)
            {
                m_nextFireTime[0] -= interval;
            }

            // Observation
            if (m_nextObservationTime.Count > 0 && m_nextObservationTime[0] <= 0)
            {
                generateClient(1, maxX, maxY);
                m_nextObservationTime.RemoveAt(0);
            }
            else if (m_nextObservationTime.Count > 0)
            {
                m_nextObservationTime[0] -= interval;
            }

            // Rescue
            if (m_nextRescueTime.Count > 0 && m_nextRescueTime[0] <= 0)
            {
                generateClient(2, maxX, maxY);
                m_nextRescueTime.RemoveAt(0);
            }
            else if (m_nextRescueTime.Count > 0)
            {
                m_nextRescueTime[0] -= interval;
            }
        }

        /// <summary>
        /// Plan the spawn of the clients with a position for the next hour.
        /// </summary>
        /// <param name="interval">Interval progression</param>
        public void planingSpawnProgression(int interval)
        {
            Random rnd = new Random(); // Random

            m_timeRemainingBeforePlaning -= interval;

            if (m_timeRemainingBeforePlaning <= 0)
            {
                // Reset planing timer
                m_timeRemainingBeforePlaning = 3600;

                // Plan Fire
                int numFires = rnd.Next(1, 3);

                m_nextFireTime = new List<int>();

                for (int i = 0; i < numFires; i++)
                {
                    m_nextFireTime.Add(rnd.Next(1, 3601));
                }
                m_nextFireTime.Sort();

                // Observation
                m_nextObservationTime = new List<int>();
                m_nextObservationTime.Add(rnd.Next(1, 3601));

                // Plan Rescue
                int numRescues = rnd.Next(1, 4);

                m_nextRescueTime = new List<int>();

                for (int i = 0; i < numRescues; i++)
                {
                    m_nextRescueTime.Add(rnd.Next(1, 3601));
                }
                m_nextRescueTime.Sort();
            }
        }

        /// <summary>
        /// Generate the clients with a position and assign them to an airport.
        /// </summary>
        /// <param name="typeClient">Type of the client. Between 1 and 3 include.</param>
        /// <param name="maxX">Maximum X on axe X</param>
        /// <param name="maxY">Maximum Y on axe Y</param>
        private void generateClient(int typeClient, int maxX, int maxY)
        {
            Random rnd = new Random(); // Random

            int x = rnd.Next(0, maxX); // Position X
            int y = rnd.Next(0, maxY); // Position Y

            Position positionClient = new Position(x, y); // Position client

            Airport closestAirport = null; // Closest airport

            foreach (Airport airport in Airports)
            {
                if (closestAirport == null || Position.getDistanceBetween(closestAirport.Position, positionClient) > Position.getDistanceBetween(airport.Position, positionClient))
                {
                    switch (typeClient)
                    {
                        case 0:
                            if (airport.HasFireFighter)
                            {
                                closestAirport = airport;
                            }
                            break;
                        case 1:
                            if (airport.HasObserver)
                            {
                                closestAirport = airport;
                            }
                            break;
                        case 2:
                            if (airport.HasRescuer)
                            {
                                closestAirport = airport;
                            }
                            break;
                    }
                }
            }

            if (closestAirport != null)
            {
                switch (typeClient)
                {
                    case 0:
                        closestAirport.Fires.Enqueue(ClientFactory.Instance.createFireClient(x, y));
                        break;
                    case 1:
                        closestAirport.ObserveClients.Enqueue(ClientFactory.Instance.createObservationClient(x, y));
                        break;
                    case 2:
                        closestAirport.RescueClients.Enqueue(ClientFactory.Instance.createRescueClient(x, y));
                        break;
                }
            }
        }

        /// <summary>
        /// Get clients with a position.
        /// </summary>
        /// <returns>List of the client with a position.</returns>
        public List<List<String>> getClientsWithPositions()
        {
            List<List<String>> airportsClientsWithPositions = new List<List<string>>();

            foreach (Airport airport in Airports)
            {
                airportsClientsWithPositions.Add(airport.getSerialsClientsWithPositions());
            }

            return airportsClientsWithPositions;
        }

        /// <summary>
        /// Get airports names.
        /// </summary>
        /// <returns>List airports names.</returns>
        public List<String> getAirportsSerials()
        {
            List<String> names = new List<String>(); // Airports names

            foreach (Airport airport in Airports)
            {
                names.Add(airport.Name + "," + airport.Position.getString());
            }

            return names;
        }

        /// <summary>
        /// Get aircrafts serials.
        /// </summary>
        /// <returns>List aircrafts serials.</returns>
        public List<List<String>> getAircraftSerials()
        {
            List<List<String>> list = new List<List<String>>(); // Serials aircraft list

            foreach (Airport airport in Airports)
            {
                list.Add(airport.getAircraftSerials());
            }

            return list;
        }
        
        /// <summary>
        /// Get client in serial.
        /// </summary>
        /// <returns>List of the clients serials by airport.</returns>
        public List<List<string>> getClientSerials()
        {
            List<List<string>> clientSerials = new List<List<string>>(); // Clients Serials

            foreach (Airport airport in Airports)
            {
                List<string> airportClientSerials = new List<string>(); // Airport serial

                List<Airport> passengerAirportsDestination = new List<Airport>(); // Airports destination
                List<List<int>> passengerToAirport = new List<List<int>>(); // Clients

                for (int i = 0; i < airport.Passengers.Count(); i++)
                {
                    bool beenHad = false;
                    for (int j = 0; j < passengerAirportsDestination.Count() && !beenHad; j++)
                    {
                        if (airport.Passengers[i].AirportDestination == passengerAirportsDestination[j])
                        {
                            beenHad = true;
                        }
                    }

                    if (!beenHad)
                    {
                        passengerAirportsDestination.Add(airport.Passengers[i].AirportDestination);
                        passengerToAirport.Add(new List<int> { i });
                    }
                    else
                    {
                        passengerToAirport[passengerAirportsDestination.IndexOf(airport.Passengers[i].AirportDestination)].Add(i);
                    }
                }

                for (int i = 0; i < passengerAirportsDestination.Count; i++)
                {
                    airportClientSerials.Add(passengerToAirport[i].Count().ToString() + " cargos to " + passengerAirportsDestination[i].Name);
                }

                List<Airport> cargoAirportsDestination = new List<Airport>(); // Airports destination
                List<List<int>> cargoToAirport = new List<List<int>>(); // Clients

                for (int i = 0; i < airport.Cargos.Count(); i++)
                {
                    bool beenHad = false;
                    for (int j = 0; j < cargoAirportsDestination.Count() && !beenHad; j++)
                    {
                        if (airport.Cargos[i].AirportDestination == cargoAirportsDestination[j])
                        {
                            beenHad = true;
                        }
                    }

                    if (!beenHad)
                    {
                        cargoAirportsDestination.Add(airport.Cargos[i].AirportDestination);
                        cargoToAirport.Add(new List<int> { i });
                    }
                    else
                    {
                        cargoToAirport[cargoAirportsDestination.IndexOf(airport.Cargos[i].AirportDestination)].Add(i);
                    }
                }

                for (int i = 0; i < cargoAirportsDestination.Count; i++)
                {
                    airportClientSerials.Add(cargoToAirport[i].Count().ToString() + " passengers to " + cargoAirportsDestination[i].Name);
                }

                List<string> clientsSpecial = airport.getSerialsClientsWithPositions(); // Clients with positions

                foreach (string client in clientsSpecial)
                {
                    airportClientSerials.Add(client);
                }

                clientSerials.Add(airportClientSerials);
            }

            return clientSerials;
        }
    }
}