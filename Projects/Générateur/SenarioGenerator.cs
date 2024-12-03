using Generator;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP2
{
    /// <summary>
    /// Generator controller
    /// </summary>
    public class SenarioGenerator
    {
        /// <summary>
        /// Generator Form
        /// </summary>
        GeneratorForm m_generatorForm;
        /// <summary>
        /// Scenario
        /// </summary>
        Scenario m_scenario;

        /// <summary>
        /// Constructor generator controller loading the form and an empty scenario.
        /// </summary>
        public SenarioGenerator()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            m_generatorForm = new GeneratorForm(this);
            m_scenario = new Scenario();

            Application.Run(m_generatorForm);
        }

        /// <summary>
        /// Main execution of the generator
        /// </summary>
        [STAThread]
        public static void Main()
        {
            SenarioGenerator senarioGenerator = new SenarioGenerator(); // Generator controller
        }

        /// <summary>
        /// Add a new airport.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="position">Position</param>
        /// <param name="passengerMin">Minimum passenger</param>
        /// <param name="passengerMax">MAximum passenger</param>
        /// <param name="cargoMin">Minimum cargo</param>
        /// <param name="cargoMax">Maximmum cargo</param>
        /// <returns></returns>
        public String addAirport(String name, String position, int passengerMin, int passengerMax, int cargoMin, int cargoMax)
        {
            return m_scenario.addAirport(name,position,passengerMin,passengerMax,cargoMin,cargoMax);
        }

        /// <summary>
        /// Add a new aircraft to an airport.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="indexAirport">Index of the aircraft</param>
        /// <param name="indexType">Index of the aircraft type</param>
        /// <param name="speed">Speed of the aircraft</param>
        /// <param name="boarding">Time to board</param>
        /// <param name="unboarding">Time to unboard</param>
        /// <param name="maintenance">Time for maintanance</param>
        /// <returns></returns>
        public String addAircraft(String name, int indexAirport, int indexType, int speed, int boarding, int unboarding, int maintenance)
        {
            return m_scenario.addAircraft(name,indexAirport, indexType, speed, boarding, unboarding, maintenance);
        }

        /// <summary>
        /// Scenario serialization
        /// </summary>
        public void generateSenario()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Scenario)); // Serializer

            using (StreamWriter wr = new StreamWriter("Senario.xml"))
            {
                xs.Serialize(wr, m_scenario);
            }
        }

    }
}