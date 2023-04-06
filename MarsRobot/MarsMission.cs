using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobot
{
    public class MarsMission
    {
        public void Execute()
        {
            Robot robot = new Robot();
            Grid grid = RobotCommandsSupplier.ReadGridInputs();
            NavigateRobot navigate = new NavigateRobot(robot,grid);

            string commands = RobotCommandsSupplier.ReadCommands();

            foreach (char command in commands)
            {
                navigate.ExecuteCommand(command);
            }

            // Prints out final position and direction of robot
            Console.WriteLine(robot);
        }
    }
}
