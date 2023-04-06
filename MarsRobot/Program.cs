
namespace MarsRobot
{
    public class Program
    {

        static void Main(string[] args)
        {
            MarsMission mission = new MarsMission();
            bool executing = true;

            // Executes mission until user exits
            while (executing)
            {
                mission.Execute();
                Console.WriteLine("To execute an other mission press Y or press any other key to terminate mision");
                string userInput = Console.ReadLine();

                if (userInput != "Y" && userInput != "y")
                {
                    executing = false;
                }
            }
        }

    }
}
