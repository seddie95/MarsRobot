using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobot
{
    public static class RobotCommandsSupplier
    {
        /// <summary>
        /// Reads the direction commands for the robot
        /// Inputs will always be valid, so there is no need to validate them
        /// </summary>
        /// <returns></returns>
        public static string ReadCommands()
        {
            string commands = String.Empty;

            Console.WriteLine("Please enter the command for the robot in the Format F:'Forward', R: 'Right' and L: 'Left'");
            commands = Console.ReadLine();

            return commands;
        }

        /// <summary>
        /// Reads the grid size and creates an appropriate grid
        /// Inputs will always be valid, so there is no need to validate them
        /// </summary>
        /// <returns></returns>
        public static Grid ReadGridInputs()
        {
            long gridX = 0;
            long gridY = 0;
            string? gridSize;
            string[] gridSizeArr;
            bool readingLines = true;

            Console.WriteLine("Please enter the plateau size in the format Lenghth x Height e.g. 5 5:");
            gridSize = Console.ReadLine();
            gridSizeArr = gridSize.Split(' ');
            bool xIsLong = long.TryParse(gridSizeArr[0], out gridX);
            bool yIsLong = long.TryParse(gridSizeArr[1], out gridY);

            return new Grid(gridX, gridY);
        }
    }
}
