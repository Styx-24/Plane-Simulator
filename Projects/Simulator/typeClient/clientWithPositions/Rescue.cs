using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Client;

namespace Simulator.Client.clientWithPositions
{
    /// <summary>
    /// Client to be rescued.
    /// </summary>
    public class Rescue : ClientsWithPositions
    {
        /// <summary>
        /// True if has been rescued, false otherwise.
        /// </summary>
        private bool m_isRescued;

        /// <summary>
        /// Initialise a client with a position.
        /// </summary>
        /// <param name="x">Position on the x axe</param>
        /// <param name="y">Position on the y axe</param>
        public Rescue(int x, int y) : base(x, y)
        {
            IsRescued = false;
        }

        /// <summary>
        /// True if has been rescued, false otherwise.
        /// </summary>
        public bool IsRescued
        {
            get { return m_isRescued; }
            set { m_isRescued = value; }
        }

        /// <summary>
        /// Rescue client information.
        /// </summary>
        /// <returns>Client type and position.</returns>
        public override string ToString()
        {
            return "Rescue,CR," + Position.X.ToString() + "," + Position.Y.ToString();
        }

        /// <summary>
        /// Return if the client must be dispose.
        /// </summary>
        /// <returns>True if must be dispose, false otherwise</returns>
        public override bool mustBeDispose()
        {
            return IsRescued;
        }
    }
}
