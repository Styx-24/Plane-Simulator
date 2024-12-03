using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    /// <summary>
    /// base state for the states with positions
    /// </summary>
    public abstract class StatusWithPositions : State
    {
        /// <summary>
        /// speed in kilometers per second
        /// </summary>
        protected int m_kmPerSecond;
        /// <summary>
        /// starting point on the map of the travel
        /// </summary>
        protected Position m_positionStart;
        /// <summary>
        /// current position on the map
        /// </summary>
        protected Position m_positionActuel;
        /// <summary>
        /// destination on the map of the travel
        /// </summary>
        protected Position m_positionEnd;

        /// <summary>
        /// constructor for the base state for the states with positions
        /// </summary>
        /// <param name="positionActual">current position on the map</param>
        public StatusWithPositions(Position positionActual) : base()
        {
            m_positionStart = new Position(positionActual.X, positionActual.Y);
            m_positionEnd = new Position(positionActual.X, positionActual.Y);
            m_positionActuel = new Position(positionActual.X, positionActual.Y);
        }

        /// <summary>
        /// constructor for the base state for the states with positions
        /// </summary>
        /// <param name="positionStart">starting point on the map of the travel</param>
        /// <param name="positionEnd">destination on the map of the travel</param>
        /// <param name="kmPerSecond">speed in kilometers per second</param>
        public StatusWithPositions(Position positionStart, Position positionEnd, int kmPerSecond)
        {
            m_positionStart = new Position(positionStart.X, positionStart.Y);
            m_positionEnd = new Position(positionEnd.X, positionEnd.Y);
            m_positionActuel = new Position(positionStart.X, positionStart.Y);
            m_kmPerSecond = kmPerSecond;
        }

        /// <summary>
        /// returns a serialized string of the state
        /// </summary>
        /// <returns>serialized string of the state</returns>
        public override string ToString()
        {
            return m_positionActuel.getString() + "," + m_positionStart.getString() + "," + m_positionEnd.getString();
        }
    }
}
