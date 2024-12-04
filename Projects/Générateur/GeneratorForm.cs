using System.Text.RegularExpressions;

namespace TP2
{
    public partial class GeneratorForm : Form
    {
        /// <summary>
        /// List airports.
        /// </summary>
        List<String> m_airports;
        /// <summary>
        /// List aircraft for each airport.
        /// </summary>
        List<List<String>> m_aircrafts;
        /// <summary>
        /// Parent controller.
        /// </summary>
        SenarioGenerator m_parent;

        /// <summary>
        /// Initializer of the form.
        /// </summary>
        /// <param name="parent">Controller parent</param>
        public GeneratorForm(SenarioGenerator parent)
        {
            InitializeComponent();

            m_airports = new List<String>();
            m_aircrafts = new List<List<String>>();
            String[] types = { "Passenger", "Cargo", "Rescue helicopter", "Private jet", "Fire fighting plane" };
            m_parent = parent;

            txtNameAirport.Text = "";
            txtPosition.Text = "";
            txtBoarding.Text = "";
            txtUnBoarding.Text = "";
            txtMinCargo.Text = "";
            txtMaxCargo.Text = "";
            txtMinPassenger.Text = "";
            txtMaxCargo.Text = "";
            txtNameAircraft.Text = "";
            txtSpeed.Text = "";
            txtMaintenance.Text = "";

            cmbType.DataSource = types;
            cmbType.SelectedIndex = 0;
        }

        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void labSpeed_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAirport_Click(object sender, EventArgs e)
        {
            string airportSerial = "";
            // Verify if the number are fine for the position.
            String[] coordinates = txtPosition.Text.Split(",");

            // If there's some textbox empty.
            if (txtNameAirport.Text.Equals("") || txtPosition.Text.Equals("") || txtMinPassenger.Text.Equals("") ||
                txtMaxPassenger.Text.Equals("") || txtMinCargo.Text.Equals("") || txtMaxCargo.Text.Equals(""))
            {
                labAirPortStatus.Text = "There's at least one empty field.";
            }
            // If the fields are numbers.
            else if (!(Regex.IsMatch(txtMaxCargo.Text, @"^\d+$") && Regex.IsMatch(txtMinCargo.Text, @"^\d+$") &&
                Regex.IsMatch(txtMinPassenger.Text, @"^\d+$") && Regex.IsMatch(txtMaxPassenger.Text, @"^\d+$")))
            {
                labAirPortStatus.Text = "There's at least one field with an invalid number.";
            }
            else if (coordinates.Length != 2 && (coordinates == null) && !(Regex.IsMatch(coordinates[0], @"^\d+$") && Regex.IsMatch(coordinates[1], @"^\d+$")))
            {
                labAirPortStatus.Text = "invalid position";
            }
            else
            {
                String answer = m_parent.addAirport(txtNameAirport.Text, txtPosition.Text, Int32.Parse(txtMinPassenger.Text), Int32.Parse(txtMaxPassenger.Text), Int32.Parse(txtMinCargo.Text), Int32.Parse(txtMaxCargo.Text));
                if (answer.Equals(""))
                {
                    airportSerial += txtNameAirport.Text + ":" + txtPosition.Text + ":" + txtMinPassenger.Text + ":" + txtMaxPassenger.Text + ":" + txtMinCargo.Text + ":" + txtMaxCargo.Text;

                    m_airports.Add(airportSerial);
                    m_aircrafts.Add(new List<String>());

                    string[] airports = new string[m_airports.Count];

                    for (int i = 0; i < m_airports.Count; i++)
                    {
                        airports[i] = m_airports[i];
                    }

                    lstAirports.DataSource = airports;

                    labAirPortStatus.Text = "";

                    this.Refresh();

                }
                else
                {
                    labAirPortStatus.Text = answer;
                }
            }
        }

        /// <summary>
        /// Verify the value. If ok, add an aircraft.
        /// Verify if there's a selected airport, if there's some field data empty and if number are real numbers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            string aircraftSerial = ""; // Aircraft data

            if (lstAirports.SelectedIndex == -1)
            {
                labAirCraftStatus.Text = "There's no selected airport.";
            }
            else if ((txtNameAircraft.Text.Equals("") || txtSpeed.Text.Equals("") || txtBoarding.Text.Equals("") || txtUnBoarding.Text.Equals("") || txtMaintenance.Text.Equals("")))
            {
                labAirCraftStatus.Text = "Some of the fields are empty.";
            }
            else if (!Regex.IsMatch(txtSpeed.Text, @"^\d+$") && !Regex.IsMatch(txtBoarding.Text, @"^\d+$") &&
                !Regex.IsMatch(txtUnBoarding.Text, @"^\d+$") && !Regex.IsMatch(txtMaintenance.Text, @"^\d+$"))
            {
                labAirCraftStatus.Text = "Invalid number.";
            }
            else
            {
                String answer = m_parent.addAircraft(txtNameAircraft.Text, lstAirports.SelectedIndex, cmbType.SelectedIndex,
                    Int32.Parse(txtSpeed.Text), Int32.Parse(txtBoarding.Text), Int32.Parse(txtUnBoarding.Text), Int32.Parse(txtMaintenance.Text)); // Answer of the attemp to add the aircraft

                if (!answer.Equals(""))
                {
                    labAirCraftStatus.Text = answer;
                }
                else
                {
                    aircraftSerial += txtNameAircraft.Text + ":" + cmbType.Text + ":" + txtSpeed.Text + ":" + txtBoarding.Text + ":" + txtUnBoarding.Text + ":" + txtMaintenance.Text;
                    m_aircrafts[lstAirports.SelectedIndex].Add(aircraftSerial);

                    string[] aircrafts = new string[m_aircrafts[lstAirports.SelectedIndex].Count]; // Aircraft list in the form

                    for (int i = 0; i < m_aircrafts[lstAirports.SelectedIndex].Count; i++)
                    {
                        aircrafts[i] = m_aircrafts[lstAirports.SelectedIndex][i];
                    }

                    lstAircrafts.DataSource = aircrafts;

                    labAirCraftStatus.Text = "";

                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Load the aircrafts of the selected airport.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void lstAirports_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] aircrafts = new string[m_aircrafts[lstAirports.SelectedIndex].Count]; // Aircrafts of the selected airport.

            for (int i = 0; i < m_aircrafts[lstAirports.SelectedIndex].Count; i++)
            {
                aircrafts[i] = m_aircrafts[lstAirports.SelectedIndex][i];
            }

            lstAircrafts.DataSource = aircrafts;

        }

        /// <summary>
        /// Button to serialized the scenario.
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event</param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            m_parent.generateSenario();
        }

        private void txtSpeed_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void GeneratorForm_Load(object sender, EventArgs e)
        {

        }

        private void labMaintenance_Click(object sender, EventArgs e)
        {

        }
    }
}