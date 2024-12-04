using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Client
{
    /// <summary>
    /// Client with a position.
    /// </summary>
    public abstract class ClientsWithPositions: Clients
    {
        /// <summary>
        /// Client position
        /// </summary>
        private Position m_position;

        /// <summary>
        /// Initialise a client with a position.
        /// </summary>
        /// <param name="x">Position on the x axe</param>
        /// <param name="y">Position on the y axe</param>
        public ClientsWithPositions(int x, int y) 
        { 
            Position = new Position(x, y);
        }

        /// <summary>
        /// Client position
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
        /// Return if the client must be dispose.
        /// </summary>
        /// <returns>True if must be dispose, false otherwise</returns>
        public virtual bool mustBeDispose()
        {
            return false;
        }
    }
}
