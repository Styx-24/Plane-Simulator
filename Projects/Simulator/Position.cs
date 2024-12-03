using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// Position class.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Position axe X.
        /// </summary>
        private int m_x;
        /// <summary>
        /// Position axe Y.
        /// </summary>
        private int m_y;

        /// <summary>
        /// Default empty constructor.
        /// </summary>
        public Position()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Position constructor with axes x and y.
        /// </summary>
        /// <param name="x">Position axe x</param>
        /// <param name="y">Position axe y</param>
        public Position(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Property position axe x.
        /// </summary>
        public int X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        /// <summary>
        /// Property position axe y.
        /// </summary>
        public int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        /// <summary>
        /// Assign position from a string.
        /// </summary>
        /// <param name="position">Position</param>
        public void setString(string position)
        {
            string[] parts = position.Split(',');
            X = Int32.Parse(parts[0]);
            Y = Int32.Parse(parts[1]);
        }

        /// <summary>
        /// Get position.
        /// </summary>
        /// <returns>Position</returns>
        public string getString()
        {
            return X.ToString() + ',' + Y.ToString();
        }

        /// <summary>
        /// Valid the position entry.
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>True if valide, otherwise false.</returns>
        public static bool isValid(string position)
        {
            // TODO
            return true;
        }

        public static double getDistanceBetween(Position position1, Position position2)
        {
            int x = position2.X - position1.X;
            int y = position2.Y - position1.Y;

            return Math.Sqrt(x * x + y * y);
        }

    }
}
