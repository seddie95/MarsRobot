using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobot
{
    public class Robot
    {
        public Robot()
        {
            
        }

        public Robot(long xPosition, long yPosition, string direction)
        {
            XPosition = xPosition; 
            YPosition = yPosition;
            Direction = direction;
        }

        public long XPosition { get; set; } = 1;
        public long YPosition { get; set; } = 1;

        public string Direction { get; set; } = "North";

        /// <summary>
        /// Prints out the position and direction of the robot
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{XPosition},{YPosition},{Direction}"; 
        }
    }
}
