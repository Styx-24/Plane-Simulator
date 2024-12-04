using Simulator.Client.clientWithPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// the fire fighting state
    /// </summary>
    public class FireFight : StatusWithPositions
    {
        /// <summary>
        /// targted fire to fire fight
        /// </summary>
        private Fire? m_fire;
        /// <summary>
        /// is traveling to the fire or not
        /// </summary>
        private bool m_goingTofire;

        /// <summary>
        /// constructor for the fire fighting state
        /// </summary>
        /// <param name="fire">targted fire to fire fight</param>
        /// <param name="positionStart">starting position of the travel to the fire</param>
        /// <param name="kmPerSecond">speed in killometers per seconds</param>
        public FireFight(Fire fire, Position positionStart, int kmPerSecond) : base(positionStart, fire.Position, kmPerSecond)
        {
            m_fire = fire;
            m_goingTofire = true;
        }

        /// <summary>
        /// fire fights within the interval given then returns the remaining time
        /// </summary>
        /// <param name="interval">interval of time to complete the task in seconds</param>
        /// <returns>remaining time</returns>
        public override int tick(int interval)
        {
            m_totalTime += interval;

            double xTotalFinished = m_positionEnd.X - m_positionStart.X;
            double yTotalFinished = m_positionEnd.Y - m_positionStart.Y;

            double totalDistance = Math.Sqrt(Math.Pow(xTotalFinished, 2) + Math.Pow(yTotalFinished, 2));

            // Divide by 200 to slow down things
            double totalTraveled = m_totalTime * m_kmPerSecond / 200;

            double xTotalTraveled = totalTraveled * (xTotalFinished / totalDistance);
            double yTotalTraveled = totalTraveled * (yTotalFinished / totalDistance);

            m_positionActuel.X = (int)(xTotalTraveled + m_positionStart.X);
            m_positionActuel.Y = (int)(yTotalTraveled + m_positionStart.Y);

            // Arrived
            if (totalTraveled >= totalDistance)
            {
                if (m_fire == null && !m_goingTofire)
                {
                    return -1;
                }

                if (m_goingTofire)
                {

                    Position invertPosition;

                    invertPosition = m_positionStart;
                    m_positionStart = m_positionEnd;
                    m_positionEnd = invertPosition;

                    m_totalTime = 0;

                    splashFire();

                    m_goingTofire = false;
                }
                else
                {
                    Position invertPosition;

                    invertPosition = m_positionStart;
                    m_positionStart = m_positionEnd;
                    m_positionEnd = invertPosition;

                    m_totalTime = 0;

                    m_goingTofire = true;
                }
            }

            return 0;
        }

        /// <summary>
        /// reduces the target fire's intesity by 2
        /// </summary>
        public void splashFire()
        {
            if (m_fire != null)
            {
                m_fire.Intensity -= 2;

                if (m_fire.mustBeDispose())
                {
                    m_fire = null;
                }
            }
        }
    }

}
