using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobot
{
    public class NavigateRobot
    {
        public NavigateRobot(Robot robot, Grid grid)
        {
            _robot = robot;
            _grid = grid;
        }

        /// <summary>
        /// Executes the command to navigate the robot
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteCommand(char command)
        {
            if (command == 'F')
            {
                MoveRobotForward();
            }

            else if (command == 'R')
            {
                TurnRobotRight();
            }

            else if (command == 'L')
            {
                TurnRobotLeft();
            }
        }

        /// <summary>
        /// Changes the direction of the robot left
        /// </summary>
        private void TurnRobotLeft()
        {
            switch (_robot.Direction)
            {
                case "North":
                    _robot.Direction = "West";
                    break;
                case "South":
                    _robot.Direction = "East";
                    break;
                case "East":
                    _robot.Direction = "North";
                    break;
                case "West":
                    _robot.Direction = "South";
                    break;
            }
        }

        /// <summary>
        /// Changes the direction of the robot right
        /// </summary>
        private void TurnRobotRight()
        {
            switch (_robot.Direction)
            {
                case "North":
                    _robot.Direction = "East";
                    break;
                case "South":
                    _robot.Direction = "West";
                    break;
                case "East":
                    _robot.Direction = "South";
                    break;
                case "West":
                    _robot.Direction = "North";
                    break;
            }
        }

        /// <summary>
        /// Moves the robot forward in the current direction if within grid
        /// </summary>
        private void MoveRobotForward()
        {
            switch (_robot.Direction)
            {
                case "North":
                    if (_robot.YPosition < _grid.Height)
                    {
                        _robot.YPosition++;
                    }
                    break;
                case "South":
                    if (_robot.YPosition > 1)
                    {
                        _robot.YPosition--;
                    }
                    break;
                case "East":
                    if (_robot.XPosition < _grid.Length)
                    {
                        _robot.XPosition++;
                    }
                    break;
                case "West":
                    if (_robot.XPosition > 1)
                    {
                        _robot.XPosition--;
                    }

                    break;
            }
        }

        private Robot _robot;
        private Grid _grid;
    }
}
