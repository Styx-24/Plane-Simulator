using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    /// <summary>
    /// main form of the simulator
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// serialised list of the airports in the senario
        /// </summary>
        private List<String> m_airports;
        /// <summary>
        /// serialised list of the aircrafts in the senario per airport
        /// </summary>
        private List<List<String>> m_aircrafts;
        /// <summary>
        /// serialised list of the client in the senario per airport
        /// </summary>
        private List<List<String>> m_clients;
        /// <summary>
        /// parent controller
        /// </summary>
        private Simulator m_parent;
        /// <summary>
        /// icons for ui rendering
        /// </summary>
        private Bitmap[] icons;
        /// <summary>
        /// current time multiplier
        /// </summary>
        private String timeMultiplier;

        /// <summary>
        /// constructor of the main fomr
        /// </summary>
        /// <param name="parent">parent controller</param>
        public MainForm(Simulator parent)
        {
            m_parent = parent;
            m_aircrafts = new List<List<String>>();
            m_airports = new List<String>();
            m_clients = new List<List<String>>();

            icons = new Bitmap[8];

            icons[0] = new Bitmap("airport.png");
            icons[1] = new Bitmap("plane.png");
            icons[2] = new Bitmap("jet.png");
            icons[3] = new Bitmap("helicopter.png");
            icons[4] = new Bitmap("firePlane.png");
            icons[5] = new Bitmap("observation.png");
            icons[6] = new Bitmap("fire.png");
            icons[7] = new Bitmap("rescue.png");




            InitializeComponent();

            btnPause.Enabled = false;
            btnFast.Enabled = false;
            btnSlow.Enabled = false;

            checkShowAll.Checked = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labTimeMultExplain_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// event for checkShowAll
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void checkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void labTime_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// sets the time label
        /// </summary>
        public void setTime(String time)
        {
            labTime.Text = time;
        }

        /// <summary>
        /// updates the internal lists for the aircrafts and clients
        /// </summary>
        /// <param name="aircrafts">list of the serialised aircrafts in the senario per airport</param>
        /// <param name="clients">list of the serialised clients in the senario per airport</param>
        public void updateLists(List<List<String>> aircrafts, List<List<String>> clients)
        {

            bool dataHasChanged = false;

            for (int i = 0; i < m_clients.Count; i++)
            {
                if (m_clients[i].Count == clients[i].Count)
                {
                    for (int j = 0; j < m_clients[i].Count; j++)
                    {
                        dataHasChanged = m_clients[i][j].Equals(clients[i][j]);
                    }
                }
                else
                    dataHasChanged = true;
            }

            m_clients = clients;
            m_aircrafts = aircrafts;

            if (dataHasChanged)
            {

                string[] aircraftNames = new string[m_aircrafts[lstAirports.SelectedIndex].Count]; // Aircrafts of the selected airport.

                if (m_aircrafts[lstAirports.SelectedIndex].Count > 0)
                {
                    for (int i = 0; i < m_aircrafts[lstAirports.SelectedIndex].Count; i++)
                    {
                        aircraftNames[i] = m_aircrafts[lstAirports.SelectedIndex][i].Split(',')[0];
                    }
                }

                string[] clientsNames = new string[m_clients[lstAirports.SelectedIndex].Count]; //Clients of the selected airport.

                for (int i = 0; i < m_clients[lstAirports.SelectedIndex].Count; i++)
                {
                    clientsNames[i] = m_clients[lstAirports.SelectedIndex][i].Split(',')[0];
                }

                lstClients.DataSource = clientsNames;

                this.Refresh();
            }
        }

        /// <summary>
        /// loads the senario and disables the btnLoad
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "xml files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                m_parent.load(openFileDialog.FileName);

                m_airports = m_parent.getAirportsSerials();
                m_aircrafts = m_parent.getAircraftSerials();

                for (int i = 0; i < m_aircrafts.Count; i++)
                {
                    m_clients.Add(new List<String>());
                }

                string[] airportNames = new string[m_airports.Count];
                string[] aircrafts = new string[m_aircrafts[0].Count];

                for (int i = 0; i < m_airports.Count; i++)
                {
                    airportNames[i] = m_airports[i].Split(',')[0];
                }

                for (int i = 0; i < m_aircrafts[0].Count; i++)
                {
                    aircrafts[i] = m_aircrafts[0][i].Split(',')[0];
                }

                lstAirports.DataSource = airportNames;
                lstAircrafts.DataSource = aircrafts;
                lstAirports.SelectedIndex = 0;

                btnPause.Enabled = true;
                btnFast.Enabled = true;
                btnSlow.Enabled = true;

                timeMultiplier = "1";
                labTimeMult.Text = "1";
                btnPause.Text = "Pause";

                btnLoad.Enabled = false;


                this.Refresh();
            }
        }

        /// <summary>
        /// paint method mor the main pannel
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="e">paint arguments</param>
        private void panMap_Paint_1(object sender, PaintEventArgs e)
        {

            String[] aircraftSerial;
            String[] clientSerial;
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Point start;
            Point finish;

            CheckForIllegalCrossThreadCalls = false;

            if (checkShowAll.Checked)
            {

                for (int i = 0; i < m_airports.Count; i++)
                {

                    e.Graphics.DrawImage(icons[0], Int32.Parse(m_airports[i].Split(',')[1]), Int32.Parse(m_airports[i].Split(',')[2]));

                    for (int j = 0; j < m_aircrafts[i].Count; j++)
                    {
                        aircraftSerial = m_aircrafts[i][j].Split(",");

                        if (aircraftSerial.Length > 3)
                        {

                            start = new Point(Int32.Parse(aircraftSerial[4]), Int32.Parse(aircraftSerial[5]));
                            finish = new Point(Int32.Parse(aircraftSerial[6]), Int32.Parse(aircraftSerial[7]));
                            g.DrawLine(p, start, finish);

                            switch (aircraftSerial[1])
                            {
                                case "P":
                                    e.Graphics.DrawImage(icons[1], Int32.Parse(aircraftSerial[2]) - 25, Int32.Parse(aircraftSerial[3]) - 25);
                                    break;

                                case "H":
                                    e.Graphics.DrawImage(icons[3], Int32.Parse(aircraftSerial[2]) - 25, Int32.Parse(aircraftSerial[3]) - 25);
                                    break;

                                case "J":
                                    e.Graphics.DrawImage(icons[2], Int32.Parse(aircraftSerial[2]) - 30, Int32.Parse(aircraftSerial[3]) - 25);
                                    break;

                                case "F":
                                    e.Graphics.DrawImage(icons[4], Int32.Parse(aircraftSerial[2]) - 40, Int32.Parse(aircraftSerial[3]) - 20);
                                    break;
                            }


                        }

                    }

                    for (int j = 0; j < m_clients[i].Count; j++)
                    {

                        clientSerial = m_clients[i][j].Split(",");

                        if (clientSerial.Length > 3)
                        {

                            switch (clientSerial[1])
                            {
                                case "CO":
                                    e.Graphics.DrawImage(icons[5], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                    break;

                                case "CF":
                                    e.Graphics.DrawImage(icons[6], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                    break;

                                case "CR":
                                    e.Graphics.DrawImage(icons[7], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                    break;
                            }

                        }

                    }

                }
            }
            else if (lstAirports.SelectedIndex != -1)
            {
                e.Graphics.DrawImage(icons[0], Int32.Parse(m_airports[lstAirports.SelectedIndex].Split(',')[1]), Int32.Parse(m_airports[lstAirports.SelectedIndex].Split(',')[2]));

                for (int i = 0; i < m_aircrafts[lstAirports.SelectedIndex].Count; i++)
                {
                    aircraftSerial = m_aircrafts[lstAirports.SelectedIndex][i].Split(",");

                    if (aircraftSerial.Length > 3)
                    {

                        start = new Point(Int32.Parse(aircraftSerial[4]), Int32.Parse(aircraftSerial[5]));
                        finish = new Point(Int32.Parse(aircraftSerial[6]), Int32.Parse(aircraftSerial[7]));
                        g.DrawLine(p, start, finish);

                        switch (aircraftSerial[1])
                        {
                            case "P":
                                e.Graphics.DrawImage(icons[1], Int32.Parse(aircraftSerial[2]) - 25, Int32.Parse(aircraftSerial[3]) - 25);
                                break;

                            case "H":
                                e.Graphics.DrawImage(icons[3], Int32.Parse(aircraftSerial[2]) - 25, Int32.Parse(aircraftSerial[3]) - 25);
                                break;

                            case "J":
                                e.Graphics.DrawImage(icons[2], Int32.Parse(aircraftSerial[2]) - 30, Int32.Parse(aircraftSerial[3]) - 25);
                                break;

                            case "F":
                                e.Graphics.DrawImage(icons[4], Int32.Parse(aircraftSerial[2]) - 40, Int32.Parse(aircraftSerial[3]) - 20);
                                break;
                        }


                    }

                }


                for (int i = 0; i < m_clients[lstAirports.SelectedIndex].Count; i++)
                {
                    clientSerial = m_clients[lstAirports.SelectedIndex][i].Split(",");

                    if (clientSerial.Length > 3)
                    {

                        switch (clientSerial[1])
                        {
                            case "CO":
                                e.Graphics.DrawImage(icons[5], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                break;

                            case "CF":
                                e.Graphics.DrawImage(icons[6], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                break;

                            case "CR":
                                e.Graphics.DrawImage(icons[7], Int32.Parse(clientSerial[2]) - 25, Int32.Parse(clientSerial[3]) - 25);
                                break;
                        }

                    }

                }

            }

        }

        /// <summary>
        /// pauses the clock
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void btnPause_Click_1(object sender, EventArgs e)
        {

            if (btnPause.Text.Equals("Play"))
            {
                btnPause.Text = "Pause";
                labTimeMult.Text = timeMultiplier;
            }
            else
            {
                btnPause.Text = "Play";
                timeMultiplier = labTimeMult.Text;
                labTimeMult.Text = "0";
            }


            m_parent.pauseUnPause();

        }

        /// <summary>
        /// reduces the current time multiplier by 1
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void btnSlow_Click_1(object sender, EventArgs e)
        {
            if (!(timeMultiplier.Equals("1") || btnPause.Text.Equals("Play")))
            {
                m_parent.slowDown();
                timeMultiplier = (Int32.Parse(timeMultiplier) - 1).ToString();
                labTimeMult.Text = timeMultiplier;
            }

        }

        /// <summary>
        /// rraises the current time multiplier by 1
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void btnFast_Click_1(object sender, EventArgs e)
        {
            if (!(timeMultiplier.Equals("6") || btnPause.Text.Equals("Play")))
            {
                m_parent.speedUp();
                timeMultiplier = (Int32.Parse(timeMultiplier) + 1).ToString();
                labTimeMult.Text = timeMultiplier;
            }

        }

        /// <summary>
        /// fills the clients and aircraft lists with the aircrafts and clients of the newly selected airport
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event arguments</param>
        private void lstAirports_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string[] aircrafts = new string[m_aircrafts[lstAirports.SelectedIndex].Count]; // Aircrafts of the selected airport.

            if (m_aircrafts[lstAirports.SelectedIndex].Count > 0)
            {
                for (int i = 0; i < m_aircrafts[lstAirports.SelectedIndex].Count; i++)
                {
                    aircrafts[i] = m_aircrafts[lstAirports.SelectedIndex][i].Split(',')[0];
                }
            }

            lstAircrafts.DataSource = aircrafts;

            if (m_clients[lstAirports.SelectedIndex].Count > 0)
            {
                string[] clients = new string[m_clients[lstAirports.SelectedIndex].Count]; //Clients of the selected airport.

                for (int i = 0; i < m_clients[lstAirports.SelectedIndex].Count; i++)
                {
                    clients[i] = m_clients[lstAirports.SelectedIndex][i].Split(',')[0];
                }

                lstClients.DataSource = clients;
            }

            this.Refresh();
        }
    }
}
