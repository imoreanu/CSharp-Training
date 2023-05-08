using System.Linq.Expressions;

namespace Automaton
{
    public class Robot
    {
        public string Name { get; set; }
        public Robot(string robotname) 
        {
            Name = robotname;
        }
        public void DisplayName()
        {
            Console.WriteLine($"Hi, my name is {Name}");
        }
        public void RobotActions()
        {
            var keypress = "";
            Console.WriteLine("Enter any Key: ");
            keypress = Console.ReadLine();
            switch (keypress)
            {
                case "5":
                    HighFiveAction();
                    break;
                default:
                    Console.WriteLine("This is not the way to do it");
                    break;
            }
        }
        public void HighFiveAction()
        {
            Console.WriteLine("Wall-E high 5'ed you!");
        }
    }
}