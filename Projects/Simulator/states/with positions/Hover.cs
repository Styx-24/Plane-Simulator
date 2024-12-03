using Simulator.Client.clientWithPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// hover state
    /// </summary>
    public class Hover : StatusWithPositions
    {
        /// <summary>
        /// radius of the hover circle
        /// </summary>
        private double m_radius;
        /// <summary>
        /// angle of the hover circle
        /// </summary>
        private double m_angle;
        /// <summary>
        /// total distance travled during the over
        /// </summary>
        private double m_totalDistanceTravelled;
        /// <summary>
        /// target to hover
        /// </summary>
        private Observation m_observation;

        /// <summary>
        /// construction of the hover state
        /// </summary>
        /// <param name="observation">target to hover</param>
        /// <param name="positionStart">starting position of the hover</param>
        /// <param name="kmPerSecond">speed in killometers per seconds</param>
        public Hover(Observation observation, Position positionStart, int kmPerSecond)
            : base(positionStart, observation.Position, kmPerSecond)
        {
            m_observation = observation;
            m_radius = 15;
            m_angle = 0;
            m_totalDistanceTravelled = 0;
        }

        /// <summary>
        /// hovers within the interval given then returns the remaining time
        /// </summary>
        /// <param name="interval">interval of time to complete the task in seconds</param>
        /// <returns>the remaining time</returns>
        public override int tick(int interval)
        {
            double distanceTravelled = interval / 200.0 * m_kmPerSecond;
            m_totalDistanceTravelled += distanceTravelled;

            if (m_totalDistanceTravelled >= 2 * Math.PI * m_radius)
            {
                hasBeenObserved();

                return -1;
            }

            m_angle += distanceTravelled / m_radius;

            m_positionActuel.X = (int)(m_positionEnd.X + m_radius * Math.Cos(m_angle));
            m_positionActuel.Y = (int)(m_positionEnd.Y + m_radius * Math.Sin(m_angle));

            return 0;
        }

        /// <summary>
        /// sets the target's "observed" flag to true
        /// </summary>
        public void hasBeenObserved()
        {
            m_observation.HasBeenObserved = true;
        }
    }
}
