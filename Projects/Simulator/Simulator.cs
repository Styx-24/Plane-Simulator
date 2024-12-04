using Simulator;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simulator
{
    public delegate void TickDelegate();

    /// <summary>
    /// Simulator controler of the projet.
    /// </summary>
    public class Simulator
    {
        /// <summary>
        /// Form of the simulator
        /// </summary>
        MainForm m_mainForm;
        /// <summary>
        /// Scenario of the simulator
        /// </summary>
        Scenario m_scenario;

        /// <summary>
        /// Simulator constructor creating the form and scenario.
        /// </summary>
        public Simulator()
        {
            m_scenario = new Scenario();

            ApplicationConfiguration.Initialize();

            m_mainForm = new MainForm(this);

            Application.Run(m_mainForm);
        }

        /// <summary>
        /// Main of the simulator.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Simulator simulator = new Simulator();
        }

        /// <summary>
        /// Load the simulation.
        /// </summary>
        /// <param name="path"></param>
        public void load(String path)
        {

            XmlSerializer xs = new XmlSerializer(typeof(Scenario)); // Serializator
            using (StreamReader rd = new StreamReader(path))
            {
                m_scenario = xs.Deserialize(rd) as Scenario;
            }

            TickDelegate tickDelegate = new TickDelegate(tick); // Tick delegate

            m_scenario.startSimulator(tickDelegate);
        }

        /// <summary>
        /// Get airports serials.
        /// </summary>
        /// <returns>Airports serials.</returns>
        public List<String> getAirportsSerials()
        {
            return m_scenario.getAirportsSerials();
        }

        /// <summary>
        /// Get aircarfts serials.
        /// </summary>
        /// <returns>Aircarfts serials.</returns>
        public List<List<String>> getAircraftSerials()
        {
            return m_scenario.getAircraftSerials();
        }

        /// <summary>
        /// Increment the timer mulplicator.
        /// </summary>
        public void speedUp()
        {
            m_scenario.speedUp();
        }

        /// <summary>
        /// Decrement the timer mulplicator.
        /// </summary>
        public void slowDown()
        {
            m_scenario.slowDown();
        }

        /// <summary>
        /// Pause/Unpause the timer.
        /// </summary>
        public void pauseUnPause()
        {
            m_scenario.pauseUnPause();
        }

        /// <summary>
        /// Tick loop simulator progression.
        /// </summary>
        public void tick()
        {
            m_scenario.initialiseClientsInAirport();
            m_scenario.generateClientsWithPositions(842, 502);


            m_scenario.tick(m_scenario.getIntervalTime());
            if (m_mainForm.IsHandleCreated)
            {
                m_mainForm.Invoke((MethodInvoker)delegate
                {
                    m_mainForm.setTime(m_scenario.getTime());
                    m_mainForm.updateLists(m_scenario.getAircraftSerials(), m_scenario.getClientSerials());
                });
            }
        }

    }
}