using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

public delegate void TickDelegate();

namespace Simulator
{
    /// <summary>
    /// Clock controling time relation between real life and the simulation. It also generate a new thread that call tick in 
    /// the controler Simulator. Start() is the method to start the loop.
    /// </summary>
    public class Clock
    {
        /// <summary>
        /// Interval time of the loop. 1000 = 1 second.
        /// </summary>
        private const int m_INTERVAL = 1000;
        /// <summary>
        /// Interval in the simulator in seconds for each interval "m_INTERVAL". 2 minutes by default.
        /// </summary>
        private double m_INTERVALSIMULATION = 2 * 60;
        /// <summary>
        /// Total time in seconds accumulated in the simulator.
        /// </summary>
        private double m_totalTime;
        /// <summary>
        /// Interval time simulator multiplication acceleration. 1 by default.
        /// </summary>
        private int m_intervalSimulationMultiplicator;
        /// <summary>
        /// True if the thread is running. False otherwise. It stops the clock.
        /// </summary>
        private bool m_isRunning;
        /// <summary>
        /// Delegate of the methods to execute in the controller each loop.
        /// </summary>
        private TickDelegate m_tickDelegate;

        /// <summary>
        /// Clock constructor. Assign the delegate in the timer loop.
        /// </summary>
        /// <param name="tickDelegate">Tick delegate</param>
        public Clock(TickDelegate tickDelegate) {
            m_tickDelegate = tickDelegate;
        }

        /// <summary>
        /// Property interval time of the loop.
        /// </summary>
        public int IntervalTime
        {
            get { return (int)m_INTERVALSIMULATION * m_intervalSimulationMultiplicator; }
            set { m_INTERVALSIMULATION = (double)value; }
        }

        /// <summary>
        /// Start the new loop thread.
        /// </summary>
        public void Start()
        {
            m_totalTime = 0;
            m_intervalSimulationMultiplicator = 1;

            homeTimer();
        }

        /// <summary>
        /// Return the time in clock on a 24 base.
        /// </summary>
        /// <returns>Time in HH:MM:SS format.</returns>
        public string getTime()
        {
            int total = (int)m_totalTime; // Total time

            int second = total % 60; // Second of the clock
            total /= 60;
            int minute = total % 60; // Minute of the clock
            total /= 60;
            int hour = total % 24; // Hour of the clock

            return hour.ToString("D2") + ":" + minute.ToString("D2") + ":" + second.ToString("D2");
        }

        /// <summary>
        /// Increment the interval multiplicator by 1.
        /// </summary>
        public void speedUp()
        {
            m_intervalSimulationMultiplicator++;
        }

        /// <summary>
        /// Decrement the interval multiplicator by 1.
        /// </summary>
        public void speedDown()
        {
            if (m_intervalSimulationMultiplicator > 1)
            {
                m_intervalSimulationMultiplicator--;
            }
        }

        /// <summary>
        /// Pause/Unpause the timer.
        /// </summary>
        public void PauseUnpause()
        {
           
            m_isRunning = !m_isRunning;
            
        }

        /// <summary>
        /// Home made timer creating a new thread with a task filled with methods to do.
        /// </summary>
        void homeTimer()
        {
            m_isRunning = true;

            new Thread(() =>
            {
                while (true)
                {
                    Task timer = new Task(() => { Thread.Sleep(m_INTERVAL); });
                    timer.Start();

                    if (m_isRunning)
                    {
                        updateTime();
                        if (m_tickDelegate != null)
                        {
                            m_tickDelegate.Invoke();
                        }
                    }

                    if (!timer.IsCompleted || m_isRunning)
                    {
                        timer.Wait();
                    }
                }
            }).Start();
        }

        /// <summary>
        /// Update the simulator total time timer for the loop.
        /// </summary>
        private void updateTime()
        {
            m_totalTime += (m_INTERVALSIMULATION * m_intervalSimulationMultiplicator);
        }
    }
}
