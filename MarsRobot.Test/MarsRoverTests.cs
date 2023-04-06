namespace MarsRobot.Test
{
    public class MarsRoverTests
    {
        /// <summary>
        /// Robot should not be able to go beyond the length of the grid
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <param name="commands"></param>
        [Theory]
        [InlineData(3, 3, "RFFFF")]
        [InlineData(1, 10, "RFFFFFFFFFFFFF")]
        public void MoveRobotForward_ShouldNotGotBeyondGridLength(long gridX, long gridY, string commands)
        {
            Robot robot = new();

            Grid grid = new(gridX, gridY);
            NavigateRobot navigateRobot = new(robot, grid);

            long expected = gridX;

            // lop through the commands
            foreach (char command in commands)
            {
                navigateRobot.ExecuteCommand(command);
            }

            long actual = grid.Length;
            Assert.Equal(expected, actual);

        }

        // <summary>
        /// Robot should not be able to go beyond the height of the grid
        /// </summary>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        /// <param name="commands"></param>
        [Theory]
        [InlineData(3, 3, "FFFF")]
        [InlineData(6, 10, "FFFFFFFFFFFFF")]
        public void MoveRobotForward_ShouldNotGotBeyondGridHeight(long gridX, long gridY, string commands)
        {
            Robot robot = new();

            Grid grid = new(gridX, gridY);
            NavigateRobot navigateRobot = new(robot, grid);

            long expected = gridY;

            // lop through the commands
            foreach (char command in commands)
            {
                navigateRobot.ExecuteCommand(command);
            }

            long actual = grid.Height;
            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// The Robot should not be able to move forward if their position is equal to Max Value
        /// </summary>
        [Fact]
        public void MoveRobotForward_ShouldNotGotBeyondMaxValue()
        {
            // Create a grid of Max Value and set the robots position to Masx Value
            long expected = long.MaxValue;
            Robot robot = new(expected, expected, "North");
            Grid grid = new(expected, expected);
            NavigateRobot navigateRobot = new(robot, grid);

            // Pass a forward command
            navigateRobot.ExecuteCommand('F');

            long actual = robot.XPosition;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// The robot should maintain the same direction if they turn right or left 4 times
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="command"></param>
        [Theory]
        [InlineData("North", 'R')]
        [InlineData("East", 'R')]
        [InlineData("South", 'R')]
        [InlineData("West", 'R')]
        [InlineData("North", 'L')]
        [InlineData("East", 'L')]
        [InlineData("South", 'L')]
        [InlineData("West", 'L')]
        public void TurnRobotRight_TurningDirectionFourTimesShouldMaintainOriginalDirection(string expected, char command)
        {
            Robot robot = new();
            robot.Direction = expected;

            Grid grid = new(5, 5);
            NavigateRobot navigateRobot = new(robot, grid);

            // Pass a right command four times
            for (int i = 0; i < 4; i++)
            {
                navigateRobot.ExecuteCommand(command);
            }

            string actual = robot.Direction;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Robot should navigate to the expected position
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="expected"></param>
        /// <param name="gridX"></param>
        /// <param name="gridY"></param>
        [Theory]
        [InlineData("FFRFLFLF", "1,4,West", 5, 5)]
        [InlineData("FFFFRFFFLFFRFFLRF", "7,7,East", 20, 20)]
        [InlineData("FRFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFLFFFFFFFFFFFFFFRFFFFFFFFFFFFLFFFFFFFFFFFF", "56,28,North", 100, 46)]
        public void ExecuteCommand_ShouldNavigateRobotToCorrectLocation(string commands, string expected, long gridX, long gridY)
        {

            Robot robot = new();
            Grid grid = new(gridX, gridY);
            NavigateRobot navigateRobot = new(robot, grid);

            foreach (char command in commands)
            {
                navigateRobot.ExecuteCommand(command);
            }

            string actual = robot.ToString();
            Assert.Equal(expected, actual);

        }

    }
}