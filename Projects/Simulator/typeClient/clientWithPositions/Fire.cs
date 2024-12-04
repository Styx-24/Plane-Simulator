using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client.clientWithPositions
{
    /// <summary>
    /// Client fire.
    /// </summary>
    public class Fire: ClientsWithPositions
    {
        /// <summary>
        /// Fire intensity
        /// </summary>
        private int m_intensity;

        /// <summary>
        /// Initialise a fire with a position and intensity.
        /// </summary>
        /// <param name="x">Position on the x axe</param>
        /// <param name="y">Position on the y axe</param>
        /// <param name="intensity">Fire intensity</param>
        public Fire(int x, int y, int intensity = -1): base(x, y)
        {
            Intensity = intensity;
        }

        /// <summary>
        /// Fire intensity
        /// </summary>
        public int Intensity
        {
            get { return m_intensity; }
            set 
            { 
                if (value < 0) 
                {
                    Random rand = new Random();
                    m_intensity = rand.Next(1, 6);
                }
                else
                {
                    m_intensity = value;
                }
            }
        }

        /// <summary>
        /// Rescue client information.
        /// </summary>
        /// <returns>Client type and position.</returns>
        public override string ToString()
        {
            return "Fire " + Intensity.ToString() + ",CF," + Position.X.ToString() + "," + Position.Y.ToString();
        }

        /// <summary>
        /// Return if the client must be dispose.
        /// </summary>
        /// <returns>True if must be dispose, false otherwise</returns>
        public override bool mustBeDispose()
        {
            return m_intensity < 1;
        }
    }
}
