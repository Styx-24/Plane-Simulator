using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client.clientWithPositions
{
    /// <summary>
    /// Client to be observed.
    /// </summary>
    public class Observation : ClientsWithPositions
    {
        /// <summary>
        /// True if has been observed, false otherwise.
        /// </summary>
        private bool m_hasBeenObserved;

        /// <summary>
        /// Initialise a client with a position.
        /// </summary>
        /// <param name="x">Position on the x axe</param>
        /// <param name="y">Position on the y axe</param>
        public Observation(int x, int y) : base(x, y)
        {
            HasBeenObserved = false;
        }

        /// <summary>
        /// True if has been observed, false otherwise.
        /// </summary>
        public bool HasBeenObserved
        {
            get { return m_hasBeenObserved; }
            set { m_hasBeenObserved = value; }
        }

        /// <summary>
        /// Observation client information.
        /// </summary>
        /// <returns>Client type and position.</returns>
        public override string ToString()
        {
            return "Observation,CO," + Position.X.ToString() + "," + Position.Y.ToString();
        }

        /// <summary>
        /// Return if the client must be dispose.
        /// </summary>
        /// <returns>True if must be dispose, false otherwise</returns>
        public override bool mustBeDispose()
        {
            return m_hasBeenObserved;
        }
    }
}
